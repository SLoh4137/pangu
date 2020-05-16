using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class GameAssets : Singleton<GameAssets>
    {
        public Transform pfDamagePopup;
        public GameObject pfDestroyedAgentParticles;
        public Flock UnclaimedFlock;
    }
}

