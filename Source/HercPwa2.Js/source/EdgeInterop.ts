import { makeEdgeUiContext } from 'edge-login-ui-web';
import { BlazorState } from './BlazorState';
import { BlazorStateName } from './Constants';


export const EdgeInteropName: string = 'EdgeInterop';

export class EdgeInterop {
  private EdgeUiContext: any;

  constructor() {
    console.log('Constructing EdgeInterop');
  }

  InitializeEdge = async () => {
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
    console.log('OpenLoginWindow js');
    this.EdgeUiContext.openLoginWindow({
      onLogin: this.OnLogin,
      onClose: this.OnClose
    })
    console.log('OpenLoginWindow 2 js');
    return true;
  }

  // Not a fat arrow function 
  OnLogin(edgeUiAccount: EdgeUiAccount) {
    console.log(edgeUiAccount);
    console.log(edgeUiAccount.username);

    const blazorState: BlazorState = window[BlazorStateName] as BlazorState;
    const assemblyQualifiedName = "BlazorHerc.Client.Features.Edge.OpenLoginWindow.OnLogin.OnLoginRequest, BlazorHerc.Client";
    blazorState.DispatchRequest({
      RequestType: assemblyQualifiedName,
      Payload: {} // TODO: actually send something in the Payload.
    });
    console.log('The user logged in, so save the account somewhere');

    //const blazorMethod = Blazor.platform.findMethod(
    //  "BlazorHerc.Client",
    //  "BlazorHerc.Client.Features.Edge",
    //  "EdgeModel",
    //  "OnLogin");


    //const username = Blazor.platform.toDotNetString(edgeUiAccount.username);

    //const assemblyName = 'HercPwa2.Client';
    //const methodName = 'Handle';
    //DotNet.invokeMethod(assemblyName, methodName, requestAsJson)
    //Blazor.platform.callMethod(blazorMethod, null,
    //  [
    //    username
    //  ]);




    //const blazorState = new BlazorState();
    //// Call back into C# 
    //console.log("Pre DispatchRequest");
    ////const assemblyQualifiedName = "BlazorHerc.Client.Features.Edge.OpenLoginWindow.OnLogin.OnLoginRequest, BlazorHerc.Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
    //const assemblyQualifiedName = "BlazorHerc.Client.Features.Edge.OpenLoginWindow.OnLogin.OnLoginRequest, BlazorHerc.Client";
    //const fullname = "BlazorHerc.Client.Features.Edge.OpenLoginWindow.OnLogin.OnLoginRequest";
    //blazorState.DispatchRequest({
    //  RequestType: assemblyQualifiedName,
    //  Payload: {}
    //})

  }

  OnClose() {
    console.log('The user has dismissed the login window');
  }
}