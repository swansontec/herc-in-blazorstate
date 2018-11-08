import { EdgeAccount } from "../TypeDefinitions/EdgeAccount";
import { EdgeCurrencyWalletInterop } from "./EdgeCurrencyWalletInterop";
import { BlazorState } from "../../BlazorState";
import { BlazorStateName, DotNetActionQualifiedNames } from "../../Constants";
import { UpdateEdgeAccountAction } from "../Actions/UpdateEdgeAccount";
import { EdgeCurrencyWallet } from "../TypeDefinitions/EdgeCurrencyWallet";

const EtheriumWalletType: string = "wallet:ethereum";

export class EdgeAccountInterop {

  private EdgeAccount: EdgeAccount;
  private EdgeWalletInfo?: EdgeWalletInfo;
  private EdgeCurrencyWalletInterops: { [key: string]: EdgeCurrencyWalletInterop } = {};

  constructor(edgeAccount: EdgeAccount) {
    this.EdgeAccount = edgeAccount;
  }

  public async Initialize(): Promise<void> {
    this.ConfigureSubscriptions();
    this.DispatchUpdateEdgeAccount();
    this.EdgeWalletInfo = this.EdgeAccount.getFirstWalletInfo(EtheriumWalletType);

    const currencyWallets = this.EdgeAccount.currencyWallets;

    console.log({ currencyWallets });

    Object.keys(currencyWallets).forEach((key) =>
      this.ConfigureCurrencyWalletInterop(currencyWallets[key]));
  }

  private ConfigureSubscriptions() {

    this.EdgeAccount.watch('username', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('loggedIn', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('id', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('currencyWallets', async (newValue) => console.log({ newCurrencyWallets: newValue }));
  }

  ConfigureCurrencyWalletInterop(edgeCurrencyWallet: EdgeCurrencyWallet): void {
    if (this.EdgeCurrencyWalletInterops[edgeCurrencyWallet.id] === undefined) {
      const edgeCurrencyWalletInterop = new EdgeCurrencyWalletInterop(edgeCurrencyWallet);
      this.EdgeCurrencyWalletInterops[edgeCurrencyWallet.id] = edgeCurrencyWalletInterop;
      edgeCurrencyWalletInterop.Initialize();
    }
  }

  CreateUpdateEdgeAccountAction(): UpdateEdgeAccountAction {
    return {
      username: this.EdgeAccount.username,
      id: this.EdgeAccount.id,
      loggedIn: this.EdgeAccount.loggedIn
    };
  }

  private DispatchUpdateEdgeAccount = async (): Promise<void> => {
    console.log('DispatchUpdateEdgeAccount');
    const updateEdgeCurrencyWalletAction: UpdateEdgeAccountAction = this.CreateUpdateEdgeAccountAction();
    const blazorState: BlazorState = window[BlazorStateName] as BlazorState;

    blazorState.DispatchRequest(DotNetActionQualifiedNames.UpdateEdgeAccountAction, updateEdgeCurrencyWalletAction);
  }


  GetFirstWalletInfo = (aType: string): string => {

    this.EdgeWalletInfo = this.EdgeAccount.getFirstWalletInfo(aType);
    return JSON.stringify(this.EdgeWalletInfo);
  }

  CreateCurrencyWallet = async (aType: string, edgeCreateCurrencyWalletOptions?: EdgeCreateCurrencyWalletOptions): Promise<string> => {
    console.log(`CreateCurrencyWallet with aType:${aType}`);
    const edgeCurrencyWallet = await this.EdgeAccount.createCurrencyWallet(aType, edgeCreateCurrencyWalletOptions);
    //this.EdgeCurrencyWalletInterop = new EdgeCurrencyWalletInterop(edgeCurrencyWallet);
    //this.EdgeCurrencyWalletInterop.Initialize();
    //const json = JSON.stringify(edgeCurrencyWallet.balances);
    return "";
  };

  WaitForCurrencyWallet = async (walletId: string): Promise<string> => {
    console.log(`WaitForCurrencyWallet with walletId:${walletId}`);
    //if (!this.EdgeAccount) throw "EdgeAccount required ensure logged in before calling.";
    //const edgeCurrencyWallet = await this.EdgeAccount.waitForCurrencyWallet(walletId);
    //console.log({ EdgeCurrencyWallet: edgeCurrencyWallet });
    //this.EdgeCurrencyWalletInterop = new EdgeCurrencyWalletInterop(edgeCurrencyWallet);
    //this.EdgeCurrencyWalletInterop.Initialize();
    //return JSON.stringify(edgeCurrencyWallet.balances);
    return "";
  };
}