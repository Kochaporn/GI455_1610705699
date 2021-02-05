using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

namespace ProgramChat
{
    public class WebsocketConnection : MonoBehaviour
    {
        public WebSocket websocket;

        public GameObject connectingScene;
        public GameObject chatScene;
        public GameObject chatMessage;

        public Transform chatPanel;

        public InputField ip_Input;
        public InputField port_Input;
        public InputField username_Input;
        public InputField chat_Input;


        void Start()
        {
            
        }
        /*{
            websocket = new WebSocket("ws://127.0.0.1:25500/");

            websocket.OnMessage += OnMessage;

            websocket.Connect();

            websocket.Send("I'm coming here.");
        }*/

       
        void Update()
        {

        }

        public void FirstScene()
        {
            websocket = new WebSocket("ws://" + ip_Input.text + ":" + port_Input.text + "/");
            
            websocket.OnMessage += OnMessage;

            websocket.Connect();

            if (websocket.ReadyState == WebSocketState.Open)
            {
                connectingScene.SetActive(false);
                chatScene.SetActive(true);
            }
        }
        
        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            //Text serverMessage += messageEventArgs.Data;
            var chatWindow = Instantiate(chatMessage, chatPanel);
            chatWindow.GetComponent<Text>().text = messageEventArgs.Data + "\n";
            string[] messages = messageEventArgs.Data.Split('/');
            
            chatWindow.transform.SetSiblingIndex(0);

            if (username_Input.text + " " == messages[0])
            {
                chatWindow.GetComponent<Text>().alignment = TextAnchor.LowerRight;
            }
        }

        public void ChatData()
        {
            if (websocket.ReadyState == WebSocketState.Open)
            {
                websocket.Send(username_Input.text + " / " + chat_Input.text);
            }
        }
        
        private void OnDestroy()
        {
            if(websocket != null)
            {
                websocket.Close();
            }
        }
    }
}