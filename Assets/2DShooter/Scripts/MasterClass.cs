using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiplayerSystem;
using UISystem;
using Commons;
using PlayerSystem;

namespace MasterSystem
{
    public class MasterClass : Singleton<MasterClass>
    {
        [SerializeField]
        private UIView uIView;
        [SerializeField]
        private PlayerView playerView;

        public GameObject GetPlayerPrefab { get { return playerView.gameObject; } }


        IMultiplayer multiplayer;
        IUIService uiService;

        private void Start()
        {
            multiplayer = new MultiplayerService();
            uiService = new UIService(uIView);
            uiService.SetMultiplayerService(multiplayer);
            multiplayer.SetUIService(uiService);

            multiplayer.ConnectToServer();
        }
    }
}