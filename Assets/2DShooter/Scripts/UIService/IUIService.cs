using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiplayerSystem;
using System;

namespace UISystem
{
    public interface IUIService
    {
        event Action joinRoom;
        event Action<string> logIn; 

        void LogInEvent(string playerName);
        void JoinRoomEvent();

        void SetMultiplayerService(IMultiplayer multiplayer);
    }
}