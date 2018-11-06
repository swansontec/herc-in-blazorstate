import { BlazorState } from '../../BlazorState';
import { BlazorStateName } from '../../Constants';
import { EdgeUiContext } from '../TypeDefinitions/EdgeUiContext';
import { EdgeAccount } from '../TypeDefinitions/EdgeAccount';
import { EdgeAccountInterop } from './EdgeAccountInterop';
import { OnLoginAction } from '../Actions/OnLoginAction';

export const EdgeInteropName: string = 'EdgeInterop';

export class EdgeUiContextInterop {
  public EdgeAccountInterop?: EdgeAccountInterop;
  private EdgeUiContext: EdgeUiContext;

  constructor(edgeUiContext: EdgeUiContext) {
    this.EdgeUiContext = edgeUiContext;
    this.EdgeUiContext.on('login', this.OnLogin);
  }

  ShowLoginWindow = () => {
    this.EdgeUiContext.showLoginWindow();
    return true;
  }

  OnLogin = (edgeAccount: EdgeAccount) => {
    this.EdgeAccountInterop = new EdgeAccountInterop(edgeAccount);
    this.EdgeAccountInterop.Initialize();
    console.log('OnLogin');

    //const blazorState: BlazorState = window[BlazorStateName] as BlazorState;
    //const assemblyQualifiedName = "Herc.Pwa.Client.Features.Edge.OnLoginAction, Herc.Pwa.Client, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null"
    //const onLoginAction: OnLoginAction = {
    //  userName: edgeAccount.username,
    //}
    //blazorState.DispatchRequest(assemblyQualifiedName, onLoginAction);
  }

  OnClose = () => {
    console.log('The user has dismissed the login window');
  }
}