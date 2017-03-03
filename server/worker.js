var _listeners       = {};
var _windowPorts     = {};
var _parentPort      = null;
var _isPrimary       = null;
var _internalCounter = 0;

function handleMessage (e) {
    if (e.data) {
        if (_listeners[e.data.type]) {
            _listeners[e.data.type](e.data.data, e.ports);
        }
    }
}

self.addEventListener('message', handleMessage);

_listeners.init         = function (data) {
    console.log('WORKER | init | ' + JSON.stringify(data));
    _isPrimary = data.primary;
};
_listeners.parentPort   = function (data, ports) {
    console.log('WORKER | parentPort |' + JSON.stringify(data));
    _parentPort           = ports[0];
    _parentPort.onmessage = function (e) {handleMessage(e); };
};
_listeners.addWindow    = function (data, ports) {
    console.log('WORKER | addWindow |' + JSON.stringify(data));
    _windowPorts[data.window]           = ports[0];
    _windowPorts[data.window].onmessage = function (e) {handleMessage(e); };
    var interval                        = setInterval(function () {
        if (_windowPorts[data.window]) {
            _windowPorts[data.window].postMessage({ type: 'workerInternal', data: 'internal counter: ' + (++_internalCounter) });
        }
        else {
            clearInterval(interval);
        }
    }, 1000);
};
_listeners.removeWindow = function (data) {
    console.log('WORKER | removeWindow |' + JSON.stringify(data));
    delete _windowPorts[data.window];
};
_listeners.toParent     = function (data) {
    console.log('WORKER | toParent | hasParent: ' + !!_parentPort, '|' + JSON.stringify(data));
    if (_parentPort) {
        // sends the message to the worker for the parent window.
        _parentPort.postMessage({ type: 'toParentWorker', data: data });
    }
};
_listeners.toChild      = function (data) {
    console.log('WORKER | toChild | hasChild: ' + !!_windowPorts[data.window], '|' + JSON.stringify(data));
    if (_windowPorts[data.window]) {
        // sends the message to the worker for that window.
        _windowPorts[data.window].postMessage({ type: 'toChildWorker', data: data });
    }
};

_listeners.toParentWorker = function (data) {
    // message from the worker of the child window.
    console.log('WORKER | toParentWorker | ' + JSON.stringify(data));
    // send the message back to the window of this worker.
    self.postMessage({ type: 'fromChild', data: data });
};

_listeners.toChildWorker = function (data) {
    // message from the worker of the parent window.
    console.log('WORKER | toChildWorker | ' + JSON.stringify(data));
    // send the message back to the window of this worker.
    self.postMessage({ type: 'fromParent', data: data });

};

_listeners.workerInternal = function (data) {
    console.log('WORKER | workerInternal | ' + JSON.stringify(data));
};
