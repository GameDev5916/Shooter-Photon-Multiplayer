using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiplayerSystem;
using System;

namespace UISystem
{
    public class UIService : IUIService
    {
        private UIController uiController;
        private IMultiplayer multiplayer;

        public event Action joinRoom;
        public event Action<string> logIn;

        public UIService(UIView uiView)
        {
            uiController = new UIController(uiView, this);
        }

        public void JoinRoomEvent()
        {
            joinRoom?.Invoke();
            Debug.Log("[UIService] JoinRoom Event");
        }

        public void LogInEvent(string playerName)
        {
            logIn?.Invoke(playerName);
            Debug.Log("[UIService] LogIn Event");
        }

        public void SetMultiplayerService(IMultiplayer multiplayer)
        {
            this.multiplayer = multiplayer;
            uiController.SetMultiplayerService(multiplayer);
        }
    }
}