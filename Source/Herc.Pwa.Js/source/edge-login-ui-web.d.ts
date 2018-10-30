declare module 'edge-login-ui-web';

declare function makeEdgeUiContext(opts: EdgeUiContextOptions): Promise<EdgeUiContext>;

interface EdgeUiContext {
  readonly on: any; // Subscriber<mixed>
  readonly watch: any; // Subscriber<mixed>
  readonly localUsers: EdgeUserInfo[];
  readonly windowVisible: boolean;
  hideWindow(): Promise<any>; // Promise<mixed>
  showLoginWindow(): Promise<any>, // Promise<mixed>
  showAccountSettingsWindow(account: EdgeAccount): Promise<any>, // Promise<mixed>
  close(): any; // mixed
}

interface EdgeAccount { }

interface EdgeUserInfo { }

interface EdgeUiContextOptions {
  apiKey: string;
  appId: string;
  assetsPath?: string;
  hideKeys?: boolean;
  vendorImageUrl?: string;
  vendorName?: string;
}

interface EdgeUiAccount {
  readonly username: string;
  getFirstWalletInfo(type: string): EdgeWalletInfo | undefined;
  waitForCurrencyWallet(walletId: string): Promise<EdgeCurrencyWallet>;
  createCurrencyWallet(type: string, opts?: EdgeCreateCurrencyWalletOptions): Promise<EdgeCurrencyWallet>;
}

interface EdgeWalletInfo {
  id: string;
  type: string;
  keys: any;
}

interface EdgeCurrencyWallet {
  readonly id: string;
  readonly keys: any;
  readonly fiatCurrencyCode: string;
  readonly balances: EdgeBalances;
  //readonly currencyInfo: EdgeCurrencyInfo;
}

interface EdgeBalances {
  [currencyCode: string]: string
}

interface EdgeCreateCurrencyWalletOptions {
  name?: string;
  fiatCurrencyCode?: string;
  // Used to tell the currency plugin what keys to create:
  //keyOptions?: EdgeCreatePrivateKeyOptions,

  // Used to copy wallet keys between accounts:
  //keys?: {}
}