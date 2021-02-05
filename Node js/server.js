var websocket = require('ws');

var callbackInitServer = ()=>{
    console.log("hanzserver is running.");
}

var wss = new websocket.Server({port:5500}, callbackInitServer);

var wslist = [];

wss.on("connection", (ws)=>{

    console.log("client connected.");
    wslist.push(ws);

    ws.on("message", (data)=>
    {
        console.log("send from client :" + data);
        Broadcast(data);
    });

    ws.on("close", ()=>{
        console.log("client disconnected.");
        wslist = ArrayRemove(wslist, ws);
    });

});

function ArrayRemove(arr, value)
{
    return arr.filter((element)=>{
        return element != value;
    })
}

function Broadcast(data)
{
    for(var i = 0; i < wslist.length; i++)
    {
        wslist[i].send(data);
    }
}