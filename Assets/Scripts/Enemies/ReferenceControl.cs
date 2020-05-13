using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class ReferenceControl : MonoBehaviour
    {
        private EnemyBase enemyBase;
        public EnemyBase Control
        {
            get
            {
                if(enemyBase == null)
                {
                    enemyBase = GetComponentInParent<EnemyBase>();
                }
                return enemyBase;
            }
        }
    }
}

