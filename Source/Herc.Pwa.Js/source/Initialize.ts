import { EdgeInterop, EdgeInteropName } from './Edge/Interop/EdgeInterop';

function initialize() {
  console.log('Initialize Blazor-Herc');
  window[EdgeInteropName] = new EdgeInterop();
}

initialize();