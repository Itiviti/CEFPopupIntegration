// Copyright © 2010-2016 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CefSharp;

namespace CEFPanel.api
{
    public class JsOrdersDataService : IObservable<Order>, IDisposable
    {
        private IWebBrowser webBrowser;
        private IDictionary<int, Order> caches = new Dictionary<int, Order>();
        private IObserver<Order> observer;

        public JsOrdersDataService(IWebBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
            webBrowser.RegisterAsyncJsObject("jsOrdersDataService", this);
        }

        #region CallFromJS

        public void PublishUpdate(IDictionary<string, object> rawOrder)
        {
            var order = DictionaryToObject<Order>(rawOrder);

            if (!caches.ContainsKey(order.Id))
            {
                caches.Add(order.Id, order);
            }
            else
            {
                caches[order.Id] = order;
            }
            observer.OnNext(caches[order.Id]);
        }

        #endregion


        #region CallFromC#

        //TODO : Observable
        public Task<IObservable<Order>> SubscribeAsync()
        {
            // Call to Javasript API : How is this handle behind ?
            var task = webBrowser.GetMainFrame().EvaluateScriptAsync("(function() { " +
                                                    "setInterval(function() {" +
                                                        "var order = {type:'Order', id:1, broker:'Broker' + new Date().getTime()};" +
                                                        "jsOrdersDataService.publishUpdate(order);" +
                                                                     "}, 2000);})();", null);
            return task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    throw new Exception(String.Format("Unable to scubscribe to orders"));
                }

                // TODO
                //var responseString = response.Success ? (response.Result ?? "null") : response.Message;
                return (IObservable<Order>)this;


            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion

        /// <summary>
        /// O My ! we will never get ride of performance cost of de/serialization....
        /// </summary>
        private static T DictionaryToObject<T>(IDictionary<string, object> dict) where T : new()
        {
            T t = new T();
            PropertyInfo[] properties = t.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (!dict.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;
                KeyValuePair<string, object> item = dict.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));
                Type tPropertyType = t.GetType().GetProperty(property.Name).PropertyType;
                Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;
                object newA = Convert.ChangeType(item.Value, newT);
                t.GetType().GetProperty(property.Name).SetValue(t, newA, null);
            }
            return t;
        }


        public IDisposable Subscribe(IObserver<Order> observer)
        {
            this.observer = observer;
            foreach (var order in caches.Values)
            {
                observer.OnNext(order);
            }
            return this;
        }

        public void Dispose()
        {
            observer = null;
        }
    }
}
