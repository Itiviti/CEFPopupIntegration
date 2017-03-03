// Copyright © 2010-2016 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Windows.Forms;
using CefSharp.Example;
using CefSharp.WinForms.Example.Handlers;
using CefSharp.WinForms.Internals;

namespace CefSharp.WinForms.Example.Minimal
{
    public partial class XForm : Form
    {
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
            var handler = new LifeSpanHandler(splitContainer.Panel1, splitContainer.Panel2);
            _ifForm = new IFForm(handler);
            _ifForm.Show();
        }

        private void btnChart1_Click(object sender, EventArgs e)
        {
            _ifForm.Browser.GetMainFrame().ExecuteJavaScriptAsync(txtChart1.Text);
        }

        private void btnChart2_Click(object sender, EventArgs e)
        {
            _ifForm.Browser.GetMainFrame().ExecuteJavaScriptAsync(txtChart2.Text);
        }
    }
}
