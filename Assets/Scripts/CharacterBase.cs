using UnityEngine;

namespace pangu
{
    public abstract class CharacterBase : MonoBehaviour
    {
        #region publicvars
        public int MaxHealth;

        public int Defense;
        public int Speed;
        public int JumpForce;

        public float AttackRate;
        public float AttackRange;

        [Range(0, 100)]
        public float CritChance;
        public int CritDamageMult;
        #endregion publicvars

        private int currentHealth;

        void Awake()
        {
            currentHealth = MaxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
        }

    }
}

