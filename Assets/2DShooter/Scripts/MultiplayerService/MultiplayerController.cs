using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiplayerSystem
{
    public class MultiplayerController
    {
        private MultiplayerService multiplayerService;
        private Launcher launcher;//photon launcher

        public MultiplayerService MultiplayerService { get { return multiplayerService; } }

        public MultiplayerController(MultiplayerService multiplayerService)
        {
            this.multiplayerService = multiplayerService;

            launcher = GameObject.FindObjectOfType<Launcher>();
        }

        public void ConnectToServer()
        {
            launcher.ConnectPhoton(MultiplayerService);
        }

        public void LogIn(string playerName)
        {
            launcher.LogIn(playerName);
            Debug.Log("[MultiplayerController] LogIn");
        }

        public void JoinRoom()
        {
            launcher.JoinRoom();
            Debug.Log("[MultiplayerController] JoinRoom");
        }


    }
}