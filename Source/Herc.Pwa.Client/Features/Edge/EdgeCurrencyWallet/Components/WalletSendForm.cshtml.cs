﻿namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet.Components
{
  using System;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using BlazorState.Features.Routing;
  using FluentValidation;
  using FluentValidation.Results;
  using Herc.Pwa.Client.Components;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Pages;
  using Herc.Pwa.Client.Services;
  using Herc.Pwa.Shared;
  using Herc.Pwa.Shared.Enumerations.FeeOption;
  using Microsoft.AspNetCore.Components;

  public class WalletSendFormModel : BaseComponent
  {
    private readonly Lazy<FormDataClass> LazyFormData;

    public WalletSendFormModel()
    {
      LazyFormData = new Lazy<FormDataClass>(() => new FormDataClass(AmountConverter));
    }

    [Inject] private AmountConverter AmountConverter { get; set; }
    private string EdgeCurrencyWalletId => WebUtility.UrlDecode(EdgeCurrencyWalletEncodedId);
    [Inject] private IValidator<SendAction> SendValidator { get; set; }
    [Parameter] protected string EdgeCurrencyWalletEncodedId { get; set; }
    protected FormDataClass FormData => LazyFormData.Value;
    protected FormValidatorClass FormValidator => new FormValidatorClass(SendValidator);
    protected string Balance => string.IsNullOrEmpty(FormData.SendAction.CurrencyCode) ? "" : EdgeCurrencyWallet.Balances[FormData.SendAction.CurrencyCode];
    protected EdgeCurrencyWallet EdgeCurrencyWallet => EdgeCurrencyWalletsState.EdgeCurrencyWallets[EdgeCurrencyWalletId];
    protected string MaxAmount => AmountConverter.GetFormatedAmount(new FormatAmountRequest { Amount = Balance, DecimalPlacesToDisplay = 18, DecimalSeperator = '.', Granularity = 18 });
    protected string Pattern => RegularExpressions.FloatingPointNumberNoSign('.');
    protected ValidationResult ValidationResult { get; set; }
    protected string WalletName => EdgeCurrencyWallet.Name;

    protected override void OnInit()
    {
      if (EdgeCurrencyWallet.Balances.Keys.Any())
      {
        FormData.SendAction.CurrencyCode = EdgeCurrencyWallet.Balances.Keys.First();
      }
      FormData.SendAction.Fee = FeeOption.Standard;
      FormData.SendAction.EdgeCurrencyWalletId = EdgeCurrencyWalletId;
    }

    protected async Task Send()
    {
      ValidationResult = FormValidator.Validate(FormData);

      if (ValidationResult.IsValid)
      {
        await Mediator.Send(FormData.SendAction);

        await Mediator.Send(new ChangeRouteRequest { NewRoute = WalletPageModel.Route });
      }
    }

    protected class FormDataClass
    {
      private string _Amount;

      public FormDataClass(AmountConverter aAmountConverter)
      {
        _Amount = "";
        SendAction = new SendAction();
        AmountConverter = aAmountConverter;
      }

      private AmountConverter AmountConverter { get; }
      public string Amount { get => _Amount; set { _Amount = value; OnAmountChange(); } }

      public SendAction SendAction { get; set; }

      protected void OnAmountChange()
      {
        var getNativeAmountRequest = new GetNativeAmountRequest
        {
          Amount = Amount,
          DecimalSeperator = '.',
          Granularity = 18
        };
        SendAction.NativeAmount = AmountConverter.GetNativeAmount(getNativeAmountRequest);
      }
    }

    protected class FormValidatorClass : AbstractValidator<FormDataClass>
    {
      public FormValidatorClass(IValidator<SendAction> aSendActionValidator)
      {
        RuleFor(aForm => aForm.Amount)
          .NotEmpty();
        RuleFor(aForm => aForm.SendAction.DestinationAddress)
          .NotEmpty()
          .WithName("Destination Address");
        RuleFor(aForm => aForm.SendAction)
          .SetValidator(aSendActionValidator)
          .When(aForm => !string.IsNullOrEmpty(aForm.Amount))
          .When(aForm => !string.IsNullOrEmpty(aForm.SendAction.DestinationAddress));
      }
    }
  }
}