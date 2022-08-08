using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiplayerSystem;

namespace UISystem
{
    public class UIController
    {
        private UIView uiView;
        private IMultiplayer multiplayer;
        private UIService uiService;

        public UIController(UIView uiView, UIService uiService)
        {
            this.uiService = uiService;
            this.uiView = uiView;
            this.uiView.SetUIService(this.uiService);
        }

        public void SetMultiplayerService(IMultiplayer multiplayer)
        {
            this.multiplayer = multiplayer;
            multiplayer.connectedToMaster += OnConnected;
            multiplayer.disconnectedFromServer += OnDisconnected;
            multiplayer.joinedToLobby += OnJoinLobby;
            multiplayer.joinedRoom += OnJoinRoom;
        }

        ~UIController()
        {
            multiplayer.connectedToMaster -= OnConnected;
            multiplayer.disconnectedFromServer -= OnDisconnected;
            multiplayer.joinedToLobby -= OnJoinLobby;
            multiplayer.joinedRoom -= OnJoinRoom;
        }

        void OnConnected()
        {
            uiView.connectionStatus.text = "Connected";
            uiView.ConnectedToMaster();
            Debug.Log("[UIController] OnConnected");
        }

        void OnDisconnected()
        {
            uiView.Disconnected();
            Debug.Log("[UIController] OnDisconnected");
        }

        void OnJoinLobby(string playerName)
        {
            Debug.Log("[UIController] OnJoinLobby");
            uiView.JoinedLobby(playerName);
        }

        void OnJoinRoom()
        {
            Debug.Log("[UIController] OnJoinRoom");
            uiView.JoinedRoom();
        }

    }
}