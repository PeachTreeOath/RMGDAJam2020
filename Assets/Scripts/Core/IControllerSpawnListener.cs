using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.Core
{
    public interface IControllerSpawnListener
    {
        void OnPlayerSpawned(int playerNum);
    }
}