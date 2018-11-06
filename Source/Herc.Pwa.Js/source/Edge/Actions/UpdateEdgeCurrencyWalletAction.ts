import { EdgeBalances } from "../TypeDefinitions/EdgeBalances";


export interface UpdateEdgeCurrencyWalletAction {
  fiatCurrencyCode: string;
  id: string;
  keys: any;
  balances: EdgeBalances;
  enabledTokens: Array<string>;
}