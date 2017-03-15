// Created on 27/02/2017.
// (C) Ironfly Technologies 2016

/**
 * windowManager
 * @module
 */
function createWindowManager () {
    var _worker                = null;
    var _nextId                = 0;
    var _counter               = 0;
    var _childWindows          = {};
    var _isPrimary             = !window.opener;
    var _workerListeners       = {};
    var _parentWindowListeners = {};
    var _onWindowClosed        = null;
    var _windowId              = _isPrimary ? 'parent' : null;
    var _origin                = window.location.origin;

    init();
    
    function openWindow (name) {
        if (!_isPrimary) { return null; }
        var windowId            = 'child_' + name + '_' + (++_nextId);
        var newWindow           = window.open('.', windowId, 'width=600,height=400');
        var messageChannel      = new MessageChannel();
        _childWindows[windowId] = { window: newWindow, channel: messageChannel, listeners: {} };
        sendToWorker('addWindow', { window: windowId }, [messageChannel.port1]);
        onChildWindowMessage(windowId, 'ready', function () {
            sendToChildWindow(windowId, 'messagePort', { window: windowId }, [messageChannel.port2]);
        });
        newWindow.addEventListener('unload', function () {
            delete _childWindows[windowId];
            if (_onWindowClosed) { _onWindowClosed(windowId);}
        });
//        setupChildWindowListener(windowId);
        var interval = setInterval(function () {
            if (_childWindows[windowId]) {
                sendToWorker('toChild', { window: windowId, message: _windowId + ' | my counter is ' + ++_counter });
            }
            else {
                clearInterval(interval);
            }
        }, 5000);

        return windowId;
    }

    function onWindowClosed (callback) {
        _onWindowClosed = callback;
    }

    function closeWindow (windowId) {
        if (_childWindows[windowId]) {
            _childWindows[windowId].window.close();
            delete _childWindows[windowId];
            sendToWorker('removeWindow', { window: windowId });
        }
    }

    function closeAllWindows () {
        var keys = Object.keys(_childWindows);
        for (var i = 0; i < keys.length; i++) {
            var windowId = keys[i];
            closeWindow(windowId);
        }
    }

    function init () {
        if (startsWith(window.name, 'child_')) {
            _windowId = window.name;
        }
        _worker = new Worker('worker.js');
        sendToWorker('init', { primary: _isPrimary });
        setupWorkerListener();
        setupWindowListener();
        onParentWindowMessage('messagePort', function (data, ports) {
            // pass the port on to the worker. Theoretically, the child window worker can now talk to the parent window worker directly.
            sendToWorker('parentPort', {}, ports);
        });
        onWorkerMessage('fromChild', function (data) {
            console.log('WINDOW | fromChild | ' + data.window + ' | ' + data.message);
        });
        onWorkerMessage('fromParent', function (data) {
            console.log('WINDOW | fromParent | ' + data.message);
        });
        if (window.opener) { sendToParentWindow('ready'); }
        if (!_isPrimary) {
            setInterval(function () {
                if (_windowId) {
                    sendToWorker('toParent', { window: _windowId, message: _windowId + ' | my counter is ' + (++_counter) });
                }
            }, 5000);
        }
    }

    function sendToWorker (type, data, transfer) {
        console.log('WINDOW | sendToWorker | exists: ' + !!_worker + ' | ' + type);
        if (_worker) {
            _worker.postMessage({ type: type, data: data }, transfer);
        }
    }

    function sendToChildWindow (windowId, type, data, transfer) {
        console.log('WINDOW | sendToChildWindow | ' + windowId + ' | exists: ' + !!_childWindows[windowId] + ' | ' + type);
        if (_childWindows[windowId]) {
            _childWindows[windowId].window.postMessage({ type: type, source: _windowId, data: data }, window.location.origin, transfer);
        }
    }

    function sendToParentWindow (type, data, transfer) {
        console.log('WINDOW | sendToParentWindow | exists: ' + !!window.opener + ' | ' + type);
        if (window.opener) {
            window.opener.postMessage({ type: type, source: _windowId, data: data }, window.location.origin, transfer);
        }
    }

    function onWorkerMessage (type, callback) {
        _workerListeners[type] = callback;
    }

    function onChildWindowMessage (windowId, type, callback) {
        if (_childWindows[windowId]) {
            _childWindows[windowId].listeners[type] = callback;
        }
    }

    function onParentWindowMessage (type, callback) {
        if (window.opener) {
            _parentWindowListeners[type] = callback;
        }
    }

    function setupWorkerListener () {
        if (_worker) {
            _worker.addEventListener('message', function (e) {
                if (_workerListeners[e.data.type]) {
                    _workerListeners[e.data.type](e.data.data, e.ports);
                }
            });
        }
    }

    function setupWindowListener () {
        window.addEventListener('message', function (e) {
            if (!_isPrimary && e.data.source === 'parent') {
                if (_parentWindowListeners[e.data.type]) {
                    _parentWindowListeners[e.data.type](e.data.data, e.ports);
                }
            }
            else if (_isPrimary && _childWindows[e.data.source]) {
                if (_childWindows[e.data.source].listeners[e.data.type]) {
                    _childWindows[e.data.source].listeners[e.data.type](e.data.data, e.ports);
                }
            }
        });

        if (_isPrimary) {
            window.addEventListener('unload', closeAllWindows);
        }
    }

    function startsWith (str, checkStr) {
        if (!str || !checkStr) { return false; }
        return str.slice(0, checkStr.length) === checkStr;
    }

    return {
        openWindow:      openWindow,
        onWindowClosed:  onWindowClosed,
        closeWindow:     closeWindow,
        closeAllWindows: closeAllWindows
    };
}