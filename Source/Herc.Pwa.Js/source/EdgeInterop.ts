import { makeEdgeUiContext } from 'edge-login-ui-web';
import { BlazorState } from './BlazorState';
import { BlazorStateName } from './Constants';

export const EdgeInteropName: string = 'EdgeInterop';

export class EdgeInterop {
  private EdgeUiContext?: EdgeUiContext;
  private EdgeUiAccount?: EdgeUiAccount;
  private EdgeWalletInfo?: EdgeWalletInfo;
  private EdgeCurrencyWallet?: EdgeCurrencyWallet;

  constructor() {
    console.log('EdgeInterop constructor');
  }

  InitializeEdge = async (): Promise<boolean> => {
    if (!this.EdgeUiContext) {
      console.log('initializeEdge js');
      const edgeUiContextOptions = {
        apiKey: 'a9ef0e4134410268a37d833e49990a1b90ec79dc',
        appId: 'com.mydomain.myapp',
        assetsPath: './edge/index.html',
        vendorName: 'Herc.One',
        vendorImageUrl: 'https://airbitz.co/go/wp-content/uploads/2016/10/GenericEdgeLoginIcon.png'
      };
      console.log(`EdgeInterop.edgeUiContextOptions: ${edgeUiContextOptions}`);
      console.log(`EdgeInterop.makeEdgeUiContext: ${makeEdgeUiContext}`);
      this.EdgeUiContext = await makeEdgeUiContext(edgeUiContextOptions);
      if (!this.EdgeUiContext) throw "Failed to create EdgeUiContext!";
      console.log(`EdgeInterop.EdgeUiContext: ${this.EdgeUiContext}`);
      this.EdgeUiContext.on('login', this.OnLogin);
    }
    return true;
  }

  ShowLoginWindow = () => {
    if (!this.EdgeUiContext) throw "EdgeUiContext is unassigned";
    this.EdgeUiContext.showLoginWindow();
    return true;
  }

  OnLogin = (edgeUiAccount: EdgeUiAccount) => {
    this.EdgeUiAccount = edgeUiAccount;
    const blazorState: BlazorState = window[BlazorStateName] as BlazorState;
    const assemblyQualifiedName = "Herc.Pwa.Client.Features.Edge.OnLoginAction, Herc.Pwa.Client, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null"
    blazorState.DispatchRequest(assemblyQualifiedName, { userName: edgeUiAccount.username });
  }

  OnClose = () => {
    console.log('The user has dismissed the login window');
  }

  GetFirstWalletInfo = (aType: string): string => {
    if (!this.EdgeUiAccount) throw "EdgeUiAccount required ensure logged in before calling.";
    this.EdgeWalletInfo = this.EdgeUiAccount.getFirstWalletInfo(aType);
    return JSON.stringify(this.EdgeWalletInfo);
  }

  CreateCurrencyWallet = async (aType: string, edgeCreateCurrencyWalletOptions?: EdgeCreateCurrencyWalletOptions): Promise<string> => {
    console.log(`CreateCurrencyWallet with aType:${aType}`);
    if (!this.EdgeUiAccount) throw "EdgeUiAccount required ensure logged in before calling.";
    this.EdgeCurrencyWallet = await this.EdgeUiAccount.createCurrencyWallet(aType, edgeCreateCurrencyWalletOptions);
    console.log(this.EdgeCurrencyWallet);
    this.EdgeCurrencyWallet.balances;
    const json = JSON.stringify(this.EdgeCurrencyWallet.balances);
    console.log(json);
    return json;
  };

  WaitForCurrencyWallet = async (walletId: string): Promise<string> => {
    console.log(`WaitForCurrencyWallet with walletId:${walletId}`);
    if (!this.EdgeUiAccount) throw "EdgeUiAccount required ensure logged in before calling.";
    this.EdgeCurrencyWallet = await this.EdgeUiAccount.waitForCurrencyWallet(walletId);
    console.log({ EdgeCurrencyWallet: this.EdgeCurrencyWallet });
    const wallet: EdgeCurrencyWallet = {
      id: this.EdgeCurrencyWallet.id,
      keys: this.EdgeCurrencyWallet.keys,
      balances: this.EdgeCurrencyWallet.balances,
      fiatCurrencyCode: this.EdgeCurrencyWallet.fiatCurrencyCode
    };
    const json = JSON.stringify(wallet);
    console.log({json});

    return json;
  };
}