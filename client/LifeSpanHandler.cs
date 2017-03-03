// Copyright © 2010-2016 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Windows.Forms;

namespace CefSharp.WinForms.Example.Handlers
{
    public class LifeSpanHandler : ILifeSpanHandler
    {
        private readonly Control container1;
        private readonly Control container2;

        public LifeSpanHandler(Control container1, Control container2 )
        {
            this.container1 = container1;
            this.container2 = container2;
        }

        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
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

                if (targetFrameName.Contains("container2"))
                {
                    container2.Controls.Clear();
                    container2.Controls.Add(lbl);
                    lbl.Dock = DockStyle.Bottom;
                    container2.Controls.Add(chromiumBrowser);
                    chromiumBrowser.Dock = DockStyle.Fill;
                }
                else
                {
                    container1.Controls.Clear();
                    container1.Controls.Add(lbl);
                    lbl.Dock = DockStyle.Bottom;
                    container1.Controls.Add(chromiumBrowser);
                    chromiumBrowser.Dock = DockStyle.Fill;
                }

                var rect = chromiumBrowser.ClientRectangle;

                //This is key, need to tell the IronFly which handle will it's parent
                //You maybe able to pass in 0 values for left, top, right and bottom though it's safest to provide them
                windowInfo.SetAsChild(chromiumBrowser.Handle, rect.Left, rect.Top, rect.Right, rect.Bottom);
            }));

            newBrowser = chromiumBrowser;

            return false;

            //EXPERIMENTAL OPTION #2: Use IWindowInfo.SetAsChild to specify the parent handle
            //NOTE: Window resize not yet handled - it should be possible to get the
            // IBrowserHost from the newly created IBrowser instance that represents the popup
            // Then subscribe to window resize notifications and call NotifyMoveOrResizeStarted
            //var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

            //var windowX = windowInfo.X;
            //var windowY = windowInfo.Y;
            //var windowWidth = (windowInfo.Width == int.MinValue) ? 600 : windowInfo.Width;
            //var windowHeight = (windowInfo.Height == int.MinValue) ? 800 : windowInfo.Height;

            //chromiumWebBrowser.Invoke(new Action(() =>
            //{
            //    var owner = chromiumWebBrowser.FindForm();

            //    var popup = new Form
            //    {
            //        Left = windowX,
            //        Top = windowY,
            //        Width = windowWidth,
            //        Height = windowHeight,
            //        Text = targetFrameName
            //    };

            //    popup.CreateControl();

            //    owner.AddOwnedForm(popup);

            //    var control = new Control();
            //    control.Dock = DockStyle.Fill;
            //    control.CreateControl();

            //    popup.Controls.Add(control);

            //    popup.Show();

            //    var rect = control.ClientRectangle;

            //    windowInfo.SetAsChild(control.Handle, rect.Left, rect.Top, rect.Right, rect.Bottom);
            //}));
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
    }
}
