import { EdgeInterop, EdgeInteropName } from './EdgeInterop';

function initialize() {
  console.log('Initialize Blazor-Herc');
  window[EdgeInteropName] = new EdgeInterop();
}

initialize();