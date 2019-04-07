
namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System;
  using System.Linq;
  using System.Numerics;
  using BlazorState;
  using FluentValidation;

  public class SendValidator : AbstractValidator<SendAction>
  {
    private IStore Store { get; set; }

    private EdgeCurrencyWalletsState EdgeCurrencyWalletsState => Store.GetState<EdgeCurrencyWalletsState>();

    public const string InvalidEthereumAddressMessage = "Not a valid Ethereum address";
    public const string NoWalletForIdMessage = "No wallet found with Id {PropertyValue}";
    public const string MustBeGreaterThanZeroMessage = "{PropertyName} must be greater than zero";
    public const string NoCurrencyCodeMessage = "The currency code does not exist in this wallet";
    public const string InsufficentFundsMessage = "You can not send more than your balance";

    public SendValidator(IStore aStore)
    {
      Store = aStore;
      RuleFor(aSendAction => aSendAction.CurrencyCode)
        .NotEmpty();
      RuleFor(aSendAction => aSendAction.DestinationAddress)
        .NotEmpty()
        .Must(BeValidEthereumAddress)
        .WithMessage(InvalidEthereumAddressMessage);
      RuleFor(aSendAction => aSendAction.EdgeCurrencyWalletId)
        .NotEmpty()
        .Must(WalletMustExist)
        .WithMessage(aSendAction => NoWalletForIdMessage);
      RuleFor(aSendAction => aSendAction.Fee).NotEmpty();
      RuleFor(aSendAction => aSendAction.NativeAmount)
        .NotEmpty()
        .Must(BeGreaterThanZero)
        .WithMessage(MustBeGreaterThanZeroMessage);
      RuleFor(aSendAction => aSendAction)
        .Must(CurrencyMustExistInWallet)
        .WithMessage(NoCurrencyCodeMessage)
        .When(aSendAction => WalletMustExist(aSendAction.EdgeCurrencyWalletId))
        .When(aSendAction => !string.IsNullOrWhiteSpace(aSendAction.CurrencyCode));
      RuleFor(aSendAction => aSendAction)
        .Must(aSendAction => BalanceGreaterThanSendAmount(aSendAction))
        .WithMessage(InsufficentFundsMessage)
        .When(aSendAction => CurrencyMustExistInWallet(aSendAction))
        .When(aSendAction => WalletMustExist(aSendAction.EdgeCurrencyWalletId));
    }

    private bool CurrencyMustExistInWallet(SendAction aSendAction)
    {
      return EdgeCurrencyWalletsState
        .EdgeCurrencyWallets[aSendAction.EdgeCurrencyWalletId]
        .Balances
        .ContainsKey(aSendAction.CurrencyCode);
    }

    private bool BeValidEthereumAddress(string aDestinationAddress)
    {
      // add Nethereum use its validation address function
      return true;
    }

    private bool WalletMustExist(string aEdgeCurrencyWalletId) =>
      EdgeCurrencyWalletsState.EdgeCurrencyWallets.ContainsKey(aEdgeCurrencyWalletId);

    private bool BeGreaterThanZero(string aNativeAmount) =>
      BigInteger.Parse(aNativeAmount).CompareTo(0) > 0;

    private bool BalanceGreaterThanSendAmount(SendAction aSendAction)
    {
      var balance = BigInteger.Parse(EdgeCurrencyWalletsState.EdgeCurrencyWallets[aSendAction.EdgeCurrencyWalletId].Balances[aSendAction.CurrencyCode]);
      return balance.CompareTo(BigInteger.Parse(aSendAction.NativeAmount)) > 0;
    }

  }
}
