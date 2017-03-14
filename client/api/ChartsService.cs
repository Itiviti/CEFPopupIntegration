// Copyright © 2010-2016 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace CEFPanel.api
{
    public class ChartsService : ILifeSpanHandler
    {
        private readonly IFrame _frame;
        private readonly Dictionary<string, Control> containers = new Dictionary<string, Control>();

        public ChartsService(IFrame frame)
        {
            _frame = frame;
        }

        public void RegisterContainer(string name, Control container)
        {
            containers.Add(name, container);
        }

        public void ShowChart(string containerName, params KeyValuePair<string, string>[] properties)
        {
            //TODO JS API to close & Open
            _frame.ExecuteJavaScriptAsync("var windowId = windowManager.openWindow('" + containerName +  "'); $('#open-window-list').append('<li class=\"window-item\" data-window=\"' + windowId + '\">Close Window ' + windowId + '</li>');");
        }

        # region ILifeSpanHandler
        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            var first = containers.Keys.FirstOrDefault(_ => targetFrameName.Contains(_));
            if (first == null)
            {
                newBrowser = null;
                return true;
            }
            
            //EXPERIMENTAL OPTION #1: Demonstrates using a new instance of ChromiumWebBrowser to host the popup.
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

            ChromiumWebBrowser chromiumBrowser = null;

            //var windowX = windowInfo.X;
            //var windowY = windowInfo.Y;
            //var windowWidth = (windowInfo.Width == int.MinValue) ? 600 : windowInfo.Width;
            //var windowHeight = (windowInfo.Height == int.MinValue) ? 800 : windowInfo.Height;

            chromiumWebBrowser.Invoke(new Action(() =>
            {
                chromiumBrowser = new ChromiumWebBrowser(targetUrl)
                {
                    LifeSpanHandler = this
                };

                //NOTE: This is important and must be called before the handle is created
                chromiumBrowser.SetAsPopup();

                //Ask nicely for the control to create it's underlying handle as we'll need to
                //pass it to IWindowInfo.SetAsChild
                chromiumBrowser.CreateControl();

                var lbl = new Label
                {
                    Text = targetFrameName
                };

                var container = containers[first];
                container.Controls.Clear();
                container.Controls.Add(chromiumBrowser);
                chromiumBrowser.Dock = DockStyle.Fill;

                var rect = chromiumBrowser.ClientRectangle;

                //This is key, need to tell the IronFly which handle will it's parent
                //You maybe able to pass in 0 values for left, top, right and bottom though it's safest to provide them
                windowInfo.SetAsChild(chromiumBrowser.Handle, rect.Left, rect.Top, rect.Right, rect.Bottom);
            }));

            newBrowser = chromiumBrowser;

            return false;
        }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            //We need to allow popups to close
            //If the browser has been disposed then we'll just let the default behaviour take place
            if(browser.IsDisposed || browser.IsPopup)
            {
                return false;
            }

            //The default CEF behaviour (return false) will send a OS close notification (e.g. WM_CLOSE).
            //See the doc for this method for full details.
            //return true here to handle closing yourself (no WM_CLOSE will be sent).
            return true;
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }
#endregion
    }
}
