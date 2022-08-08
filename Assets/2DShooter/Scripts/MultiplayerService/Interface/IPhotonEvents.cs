using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MultiplayerSystem
{
    public interface IPhotonEvents
    {
        event Action connectedToMaster;
        event Action joinedToLobby;
        event Action joinedLobbyFailed;
        event Action disconnectedFromServer;
        event Action joinedRoom;
    }
}