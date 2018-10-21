declare module 'edge-login-ui-web';
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

interface EdgeCurrencyWallet
{
  readonly id: string,
  readonly keys: any,
}

interface EdgeCreateCurrencyWalletOptions
{
  name?: string;
  fiatCurrencyCode?: string;
  // Used to tell the currency plugin what keys to create:
  //keyOptions?: EdgeCreatePrivateKeyOptions,

  // Used to copy wallet keys between accounts:
  //keys?: {}
}