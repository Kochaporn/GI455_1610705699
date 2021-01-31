using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

namespace ProgramChat
{
    public class WebsocketConnection : MonoBehaviour
    {
        private WebSocket websocket;
      
        void Start()
        {
            websocket = new WebSocket("ws://127.0.0.1:25500/");

            websocket.OnMessage += OnMessage;

            websocket.Connect();

            //websocket.Send("I'm coming here.");
        }

       
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                if(websocket.ReadyState == WebSocketState.Open)
                {
                    websocket.Send("Random number : "+ Random.Range(0, 999999));
                }
            }
        }

        private void OnDestroy()
        {
            if(websocket != null)
            {
                websocket.Close();
            }
        }

        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Debug.Log("Recieved msg : " + messageEventArgs.Data);
        }
    }
}


