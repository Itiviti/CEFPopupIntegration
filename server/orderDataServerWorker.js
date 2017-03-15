self.onmessage = function(objEvent)
{
    var jsOrder = objEvent.orderDataService;
    var order = {type:'Order', id:1, broker:'Broker' + new Date().getTime()};
    jsOrder.publishUpdate(order);
}