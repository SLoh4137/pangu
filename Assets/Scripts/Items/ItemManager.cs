using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pangu
{
    public enum ItemName
    {
        ExampleItem,
        SliverOfDivineSense,
    }
    public class ItemManager : Singleton<ItemManager>
    {
        protected IDictionary<ItemName, ItemBase> allItems;

        void Awake()
        {
            allItems = new Dictionary<ItemName, ItemBase>();
        }

        /**
        * Extend this to add more items
        */
        protected virtual ItemBase GetItemClass(ItemName itemName)
        {
            switch (itemName)
            {
                case ItemName.ExampleItem:
                    return new ExampleItem();
                default:
                    return new ExampleItem();
            }
        }

        public ItemBase GetItem(ItemName itemName)
        {
            ItemBase item;
            if (!allItems.TryGetValue(itemName, out item))
            {
                item = GetItemClass(itemName);
                allItems[itemName] = item;
            }

            return item;
        }
    }
}

