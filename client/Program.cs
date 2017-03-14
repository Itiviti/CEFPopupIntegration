// Copyright © 2010-2016 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms.Example.Minimal;
using CEFPanel.utils;
using CEFPanel.utils.handlers;

namespace CefSharp.WinForms.Example
{
    public class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            const bool simpleSubProcess = false;

            Cef.EnableHighDPISupport();

            //NOTE: Using a simple sub processes uses your existing application executable to spawn instances of the sub process.
            //Features like JSB, EvaluateScriptAsync, custom schemes require the CefSharp.BrowserSubprocess to function
            if (simpleSubProcess)
            {
                var exitCode = Cef.ExecuteProcess();

                if(exitCode >= 0)
                {
                    return exitCode;
                }

#if DEBUG
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show("When running this Example outside of Visual Studio" +
                                    "please make sure you compile in `Release` mode.", "Warning");
                }
#endif

                var settings = new CefSettings();
                settings.BrowserSubprocessPath = "CefSharp.WinForms.Example.exe";

                Cef.Initialize(settings);

                var browser = new XForm();
                Application.Run(browser);
            }
            else
            {
#if DEBUG
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    MessageBox.Show("When running this Example outside of Visual Studio" +
                                    "please make sure you compile in `Release` mode.", "Warning");
                }
#endif

                const bool multiThreadedMessageLoop = true;
                var browser = new XForm();
                
                IBrowserProcessHandler browserProcessHandler;
                browserProcessHandler = new BrowserProcessHandler();
                CefInitialization.Init(osr: false, multiThreadedMessageLoop: multiThreadedMessageLoop, browserProcessHandler: browserProcessHandler);

                Application.Run(browser);
            }

            return 0;
        }
    }
}
