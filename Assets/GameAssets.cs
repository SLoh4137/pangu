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
        public GameObject pfSwordAttack;
        public GameObject pfDefend;
        public GameObject Panel;

        public GameObject Create(GameObject prefab, Vector2 position, Quaternion rotation, Transform parent)
        {
            return Instantiate(prefab, position, rotation, parent);
        }
    }
}

