using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiplayerSystem;
using UISystem;

namespace MultiplayerSystem
{
    public interface IMultiplayer
    {
        #region events
        event Action connectedToMaster;
        event Action<string> joinedToLobby;
        event Action joinedLobbyFailed;
        event Action disconnectedFromServer;
        event Action joinedRoom;
        #endregion

        #region Methods
        void ConnectToServer();
        void SetUIService(IUIService uiService);
        #endregion

        #region event methods
        void ConnectedToMasterEvent();
        void JoinedLobbyFailedEvent();
        void JoinedToLobbyEvent(string playerName);
        void DisconnectedFromServerEvent();
        void JoinedRoomEvent();
        #endregion
    }
}