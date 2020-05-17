using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public class CharacterStats : MonoBehaviour
    {
        public StartingStats startingStats;
        public ICanConsume character;

        [HideInInspector]
        public int Health;

        [HideInInspector]
        public int MaxHealth;

        [HideInInspector]
        public Stat Defense;

        [HideInInspector]
        public Stat Speed;

        [HideInInspector]
        public Stat AirSpeed;

        [HideInInspector]
        public Stat JumpForce;

        [HideInInspector]
        public Stat AttackRate;

        [HideInInspector]
        public Stat AttackRange;

        [HideInInspector]
        public Stat AttackDamage;

        [HideInInspector]
        public Stat CritChance;

        [HideInInspector]
        public Stat CritDamageMultiplier;

        [HideInInspector]
        public Stat SensingRadius;

        [HideInInspector]
        public IDictionary<ItemName, int> Items;

        void Awake()
        {
            character = GetComponent<ICanConsume>();
            Items = new Dictionary<ItemName, int>();

            Health = startingStats.StartingHealth;
            MaxHealth = startingStats.StartingHealth;
            Defense = new Stat(startingStats.Defense);
            Speed = new Stat(startingStats.Speed);
            AirSpeed = new Stat(startingStats.AirSpeed);
            JumpForce = new Stat(startingStats.JumpForce);
            AttackRate = new Stat(startingStats.AttackRate);
            AttackRange = new Stat(startingStats.AttackRange);
            AttackDamage = new Stat(startingStats.AttackDamage);
            CritChance = new Stat(startingStats.CritChance);
            CritDamageMultiplier = new Stat(startingStats.CritDamageMultiplier);
            SensingRadius = new Stat(startingStats.SensingRadius);
        }


        public void AddItem(ItemName itemName)
        {
            int currentStack;
            Items.TryGetValue(itemName, out currentStack); // currentStack either gets the value or initialized to 0
            currentStack += 1;
            Items[itemName] = currentStack;

            ItemBase item = ItemManager.Instance.GetItem(itemName);
            item.AddEffect(character, currentStack);
            Debug.Log("Added: " + item.itemName.ToString());
        }

        public bool RemoveItem(ItemName itemName)
        {
            int currentStack;
            Items.TryGetValue(itemName, out currentStack);
            if (currentStack == 0)
            {
                return false;
            }

            currentStack -= 1;
            if (currentStack <= 0)
            {
                Items.Remove(itemName);
            }
            else
            {
                Items[itemName] = currentStack;
            }

            ItemBase item = ItemManager.Instance.GetItem(itemName);
            item.RemoveEffect(character, currentStack);
            Debug.Log("Removed: " + item.itemName.ToString());
            return true;
        }

        void OnDestroy() {
            if(character == null) return;

            ItemManager itemManager = ItemManager.Instance;
            foreach(KeyValuePair<ItemName, int> item in Items)
            {
                ItemBase itemClass = itemManager.GetItem(item.Key);
                for(int i = item.Value; i >= 1; i--)
                {
                    itemClass.RemoveEffect(character, i - 1);
                }
            }
        }
    }
}

