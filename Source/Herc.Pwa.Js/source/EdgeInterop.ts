import { makeEdgeUiContext } from 'edge-login-ui-web';
import { BlazorState } from './BlazorState';
import { BlazorStateName } from './Constants';

export const EdgeInteropName: string = 'EdgeInterop';

export class EdgeInterop {
  private EdgeUiContext: any;
  private EdgeUiAccount?: EdgeUiAccount;
  private EdgeWalletInfo?: EdgeWalletInfo;
  private EdgeCurrencyWallet?: EdgeCurrencyWallet;

  constructor() {
    console.log('Constructing EdgeInterop');
  }

  InitializeEdge = async (): Promise<boolean> => {
    console.log('initializeEdge js');
    const edgeUiContextOptions = {
      apiKey: 'a9ef0e4134410268a37d833e49990a1b90ec79dc',
      appId: 'com.mydomain.myapp',
      assetsPath: './edge/index.html',
      frameTimeout: 30000, // Give the asset bundler more time
      vendorName: 'My Awesome Project',
      vendorImageUrl: 'https://airbitz.co/go/wp-content/uploads/2016/10/GenericEdgeLoginIcon.png'
    };
    console.log('initializeEdge 2 js');
    this.EdgeUiContext = await makeEdgeUiContext(edgeUiContextOptions);
    console.log('initializeEdge 3 js');
    return true;
  }

  OpenLoginWindow = () => {
    this.EdgeUiContext.openLoginWindow({
      onLogin: this.OnLogin,
      onClose: this.OnClose
    })
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
    if (!this.EdgeUiAccount) throw "EdgeUiAccount required ensure logged in before calling.";
    this.EdgeCurrencyWallet = await this.EdgeUiAccount.createCurrencyWallet(aType, edgeCreateCurrencyWalletOptions);
    return JSON.stringify(this.EdgeCurrencyWallet);
  };

  WaitForCurrencyWallet = async (walletId: string): Promise<string> => {
    if (!this.EdgeUiAccount) throw "EdgeUiAccount required ensure logged in before calling.";
    this.EdgeCurrencyWallet = await this.EdgeUiAccount.waitForCurrencyWallet(walletId);
    return JSON.stringify(this.EdgeCurrencyWallet);
  };
}