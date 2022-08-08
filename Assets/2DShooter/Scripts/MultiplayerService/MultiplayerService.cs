using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UISystem;

namespace MultiplayerSystem
{
    public class MultiplayerService : IMultiplayer
    {
        public event Action connectedToMaster;
        public event Action<string> joinedToLobby;
        public event Action joinedLobbyFailed;
        public event Action disconnectedFromServer;
        public event Action joinedRoom;

        private MultiplayerController multiplayerController;
        private IUIService uiService;

        public MultiplayerService()
        {
            multiplayerController = new MultiplayerController(this);
        }

        public void SetUIService(IUIService uiService)
        {
            this.uiService = uiService;
            uiService.joinRoom += JoinRoom;
            uiService.logIn += LogIn;
        }

        ~MultiplayerService()
        {
            uiService.joinRoom -= JoinRoom; 
        }

        public void ConnectToServer()
        {
            multiplayerController.ConnectToServer();
        }

        void LogIn(string playerName)
        {
            multiplayerController.LogIn(playerName);
            Debug.Log("[MultiplayerService] LogIn");
        }

        void JoinRoom()
        {
            multiplayerController.JoinRoom();
            Debug.Log("[MultiplayerService] JoinRoom");
        }

        public void ConnectedToMasterEvent()
        {
            connectedToMaster?.Invoke();
            Debug.Log("[MultiplayerService]Connected to the Master Event");
        }

        public void DisconnectedFromServerEvent()
        {
            disconnectedFromServer?.Invoke();
            Debug.Log("[MultiplayerService]Disconnected Event");
        }

        public void JoinedLobbyFailedEvent()
        {
            joinedLobbyFailed?.Invoke();
            Debug.Log("[MultiplayerService]JoinedLobbyFailed Event");
        }

        public void JoinedRoomEvent()
        {
            joinedRoom?.Invoke();
            Debug.Log("[MultiplayerService]JoinedRoom Event");
        }

        public void JoinedToLobbyEvent(string playerName)
        {
            joinedToLobby?.Invoke(playerName);
            Debug.Log("[MultiplayerService]JoinedToLobby Event");
        }
    }
}