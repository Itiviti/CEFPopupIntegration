# Web Worker Multi Window Example
This example sets up a dedicated worker in each window that is opened and 
sets up communication directly between the web worker in the primary window
and each web worker in the secondary window.

This allows for high data throughput between the workers without putting any
load on the main window js that relies on the UI.

There is also logic in there to close all windows when the primary window is 
closed.

## Quick Start
To run this demo you will need to host the files in your own web server
as the example will not work by just opening the html file in the browser.

Once the webserver is running just navigate to the index.html

## Expected Results
To know that it is working you should see messages 'fromChild' in the
primary window and 'fromParent' in the secondary windows.

There is quite a bit of extra logging in there to illustrate the flow of
the messages and also to show messages directly between the workers without
communicating with the UI thread of each window.