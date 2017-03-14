// Copyright © 2010-2016 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Windows.Forms;
using CefSharp.WinForms.Internals;
using CEFPanel.api;

namespace CefSharp.WinForms.Example.Minimal
{
    public partial class IFForm : Form
    {
        private ChromiumWebBrowser browser;

        public IFForm()
        {
            InitializeComponent();

            var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}, Environment: {3}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, bitness);
            
            //Only perform layout when control has completly finished resizing
            ResizeBegin += (s, e) => SuspendLayout();
            ResizeEnd += (s, e) => ResumeLayout(true);

            Load += OnLoad;
        }

        public ChromiumWebBrowser Browser
        {
            get { return browser; }
            set { browser = value; }
        }

        public ChartsService Handler
        {
            set { browser.LifeSpanHandler = value; }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            CreateBrowser();
        }

        private void CreateBrowser()
        {
            browser = new ChromiumWebBrowser("localhost:8080")
            {
                Dock = DockStyle.Fill,
            };
            pnlWebBrowser.Controls.Add(browser);  
        }
    }
}
