﻿import { EdgeAccount } from "../TypeDefinitions/EdgeAccount";
import { EdgeCurrencyWalletInterop } from "./EdgeCurrencyWalletInterop";
import { BlazorState } from "../../BlazorState";
import { BlazorStateName, DotNetActionQualifiedNames } from "../../Constants";
import { UpdateEdgeAccountAction } from "../Actions/UpdateEdgeAccount";
import { EdgeCurrencyWallet } from "../TypeDefinitions/EdgeCurrencyWallet";
import { EdgeTransaction } from "../TypeDefinitions/EdgeTransaction";
import { SendDto} from "../Dtos/SendDto";
import { EdgeSpendInfo } from "../TypeDefinitions/EdgeSpendInfo";

const EtheriumWalletType: string = "wallet:ethereum";

export class EdgeAccountInterop {

  private EdgeAccount: EdgeAccount;
  private EdgeWalletInfo?: EdgeWalletInfo;
  private EdgeCurrencyWalletInterops: { [key: string]: EdgeCurrencyWalletInterop } = {};

  constructor(edgeAccount: EdgeAccount) {
    this.EdgeAccount = edgeAccount;
  }

  public Initialize = async (): Promise<void> => {
    this.ConfigureSubscriptions();
    this.DispatchUpdateEdgeAccount();
    this.EdgeWalletInfo = this.EdgeAccount.getFirstWalletInfo(EtheriumWalletType);
    if (this.EdgeWalletInfo === undefined) {
      const edgeCreateCurrencyWalletOptions: EdgeCreateCurrencyWalletOptions = {
        name: "HERC Wallet",
        fiatCurrencyCode: "iso:USD"
      }
      this.CreateCurrencyWallet(EtheriumWalletType, edgeCreateCurrencyWalletOptions);
    }
    this.ConfigureCurrencyWallets();
  }

  private ConfigureSubscriptions = () => {

    this.EdgeAccount.watch('username', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('loggedIn', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('id', () => this.DispatchUpdateEdgeAccount());
    this.EdgeAccount.watch('currencyWallets', () => this.ConfigureCurrencyWallets());
    this.EdgeAccount.watch('activeWalletIds', () => this.ConfigureCurrencyWallets());
  }

  private ConfigureCurrencyWallets = async (): Promise<void> => {

    const currencyWallets = this.EdgeAccount.currencyWallets;
    console.log({ currencyWallets });
    if (Object.keys(currencyWallets).length === 0)
      console.log('%cNo CurrencyWallets on EdgeAccount', 'color: purple');
    console.log('%cConfigureCurrencyWallets', 'color: purple');
    
    Object.keys(currencyWallets).forEach((key) =>
      this.ConfigureCurrencyWalletInterop(currencyWallets[key]));
  }

  private ConfigureCurrencyWalletInterop = (edgeCurrencyWallet: EdgeCurrencyWallet): void => {
    if (this.EdgeCurrencyWalletInterops[edgeCurrencyWallet.id] === undefined) {
      const edgeCurrencyWalletInterop = new EdgeCurrencyWalletInterop(edgeCurrencyWallet);
      this.EdgeCurrencyWalletInterops[edgeCurrencyWallet.id] = edgeCurrencyWalletInterop;
      edgeCurrencyWalletInterop.Initialize();
    }
  }

  private CreateUpdateEdgeAccountAction = (): UpdateEdgeAccountAction => {
    return {
      username: this.EdgeAccount.loggedIn ? this.EdgeAccount.username : undefined,
      id: this.EdgeAccount.id,
      loggedIn: this.EdgeAccount.loggedIn
    };
  }

  private DispatchUpdateEdgeAccount = async (): Promise<void> => {
    console.log('%cDispatchUpdateEdgeAccount', 'color: green');
    const updateEdgeCurrencyWalletAction: UpdateEdgeAccountAction = this.CreateUpdateEdgeAccountAction();
    const blazorState: BlazorState = window[BlazorStateName] as BlazorState;

    blazorState.DispatchRequest(DotNetActionQualifiedNames.UpdateEdgeAccountAction, updateEdgeCurrencyWalletAction);
  }


  //GetFirstWalletInfo = (aType: string): string => {

  //  this.EdgeWalletInfo = this.EdgeAccount.getFirstWalletInfo(aType);
  //  return JSON.stringify(this.EdgeWalletInfo);
  //}

  private CreateCurrencyWallet = async (aType: string, edgeCreateCurrencyWalletOptions?: EdgeCreateCurrencyWalletOptions): Promise<string> => {
    console.log(`CreateCurrencyWallet with aType:${aType}`);
    const edgeCurrencyWallet = await this.EdgeAccount.createCurrencyWallet(aType, edgeCreateCurrencyWalletOptions);
    this.ConfigureCurrencyWalletInterop(edgeCurrencyWallet);
    return "";
  };

  public Logout = async (): Promise<boolean> => {
    await this.EdgeAccount.logout();
    return true; // TODO blazor doesn't support return of void yet. that I know of
  }

  public Send = async (aSendAction: SendDto): Promise<string> => {
    const edgeCurrencyWalletInterop = this.EdgeCurrencyWalletInterops[aSendAction.edgeCurrencyWalletId];
    return edgeCurrencyWalletInterop.Send(aSendAction);
  }
  //WaitForCurrencyWallet = async (walletId: string): Promise<string> => {
  //  console.log(`WaitForCurrencyWallet with walletId:${walletId}`);
  //  //if (!this.EdgeAccount) throw "EdgeAccount required ensure logged in before calling.";
  //  //const edgeCurrencyWallet = await this.EdgeAccount.waitForCurrencyWallet(walletId);
  //  //console.log({ EdgeCurrencyWallet: edgeCurrencyWallet });
  //  //this.EdgeCurrencyWalletInterop = new EdgeCurrencyWalletInterop(edgeCurrencyWallet);
  //  //this.EdgeCurrencyWalletInterop.Initialize();
  //  //return JSON.stringify(edgeCurrencyWallet.balances);
  //  return "";
  //};
}