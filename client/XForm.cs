// Copyright © 2010-2016 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CefSharp.WinForms.Internals;
using CEFPanel.api;

namespace CefSharp.WinForms.Example.Minimal
{
    public partial class XForm : Form, IObserver<Order>
    {
        private ChartsService service;
        private JsOrdersDataService ordersDataService;
        private IFForm _ifForm;

        public XForm()
        {
            InitializeComponent();
            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}, Environment: {3}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, bitness);
            //Only perform layout when control has completly finished resizing
            ResizeBegin += (s, e) => SuspendLayout();
            ResizeEnd += (s, e) => ResumeLayout(true);
            Load += XilixForm_Load;
        }

        private void XilixForm_Load(object sender, EventArgs e)
        {
            _ifForm = new IFForm();
            _ifForm.Show();

            ordersDataService = new JsOrdersDataService(_ifForm.Browser);

            _ifForm.Browser.IsBrowserInitializedChanged += Browser_IsBrowserInitializedChanged;
        }

        private void Browser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {
            service = new ChartsService(this._ifForm.Browser.GetMainFrame());
            _ifForm.Handler = service;
            service.RegisterContainer("container1", splitContainer.Panel1);
            service.RegisterContainer("container2", splitContainer.Panel2);
        }

        private void btnChart1_Click(object sender, EventArgs e)
        {
            service.ShowChart("container1", null);
        }

        private void btnChart2_Click(object sender, EventArgs e)
        {
            service.ShowChart("container2", null);
        }

        private async void btnSubscribeOrder_Click(object sender, EventArgs e)
        {
            await ordersDataService.SubscribeAsync().ContinueWith(t =>
                {
                    t.Result.Subscribe(this);
                }
                ).ConfigureAwait(false);
           
        }

        public void OnNext(Order value)
        {
            lblBroker.Invoke(new MethodInvoker(() =>
            {
                lblOrder.Text = value.Id.ToString();
                lblBroker.Text = value.Broker;
                lblBroker.BackColor = Color.Green;
            }));
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblBroker.BackColor = Color.Transparent;
        }
    }
}
