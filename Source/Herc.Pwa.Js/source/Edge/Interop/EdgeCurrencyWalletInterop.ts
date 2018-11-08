import { BlazorState } from '../../BlazorState';
import { BlazorStateName, DotNetActionQualifiedNames } from '../../Constants';
import { EdgeCurrencyWallet } from "../TypeDefinitions/EdgeCurrencyWallet";
import { EdgeTokenInfo } from "../TypeDefinitions/EdgeTokenInfo";
import { EdgeCurrencyInfo } from "../TypeDefinitions/EdgeCurrencyInfo";
import { UpdateEdgeCurrencyWalletAction } from '../Actions/UpdateEdgeCurrencyWalletAction';

export class EdgeCurrencyWalletInterop {
  private EdgeCurrencyWallet: EdgeCurrencyWallet;
  private HercTokenInfo: EdgeTokenInfo = {
    currencyName: 'Hercules',
    contractAddress: '0x6251583e7D997DF3604bc73B9779196e94A090Ce',
    currencyCode: 'HERC',
    multiplier: '1000000000000000000'
  };

  constructor(edgeCurrencyWallet: EdgeCurrencyWallet) {
    this.EdgeCurrencyWallet = edgeCurrencyWallet;
    console.log(`EdgeCurrencyWalletInterop constructor ${edgeCurrencyWallet.id}`);
  }

  public async Initialize(): Promise<void> {
    const enabledTokens: Array<string> = await this.EdgeCurrencyWallet.getEnabledTokens();
    if (!enabledTokens.includes(this.HercTokenInfo.currencyCode)) {
      await this.EdgeCurrencyWallet.addCustomToken(this.HercTokenInfo);
      await this.EdgeCurrencyWallet.enableTokens([this.HercTokenInfo.currencyCode]);
    }
    this.ConfigureSubscriptions();
    this.DispatchUpdateEdgeCurrencyWallet();
  }

  private ConfigureSubscriptions() {
    this.EdgeCurrencyWallet.watch('balances', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('currencyInfo', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('fiatCurrencyCode', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('id', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('keys', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('name', () => this.DispatchUpdateEdgeCurrencyWallet());
    this.EdgeCurrencyWallet.watch('type', () => this.DispatchUpdateEdgeCurrencyWallet());
  }

  getEnabledTokens = (): Promise<string[]> => {
    return this.EdgeCurrencyWallet.getEnabledTokens();
  }

  private GetEdgeCurrencyWalletAction = async (): Promise<UpdateEdgeCurrencyWalletAction> => {
    const currencyInfo: EdgeCurrencyInfo = this.EdgeCurrencyWallet.currencyInfo;
    const enabledTokens: string[] = await this.EdgeCurrencyWallet.getEnabledTokens();
    return {
      id: this.EdgeCurrencyWallet.id,
      keys: this.EdgeCurrencyWallet.keys,
      balances: this.EdgeCurrencyWallet.balances,
      fiatCurrencyCode: this.EdgeCurrencyWallet.fiatCurrencyCode,
      name: this.EdgeCurrencyWallet.name,
      enabledTokens
    };
  }

  private DispatchUpdateEdgeCurrencyWallet = async (): Promise<void> => {
    const updateEdgeCurrencyWalletAction: UpdateEdgeCurrencyWalletAction = await this.GetEdgeCurrencyWalletAction();
    const blazorState: BlazorState = window[BlazorStateName] as BlazorState;

    blazorState.DispatchRequest(
      DotNetActionQualifiedNames.UpdateEdgeCurrencyWalletAction,
      updateEdgeCurrencyWalletAction);
  }
}
