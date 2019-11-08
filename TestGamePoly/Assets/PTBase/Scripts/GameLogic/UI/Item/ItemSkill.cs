using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePloy.UI
{
    public class ItemSkill : UIItem
    {
        public ItemTechnology firstItem;
        public ItemTechnology secondItem00;
        public ItemTechnology secondItem01;
        public ItemTechnology thirdItem00;
        public ItemTechnology thirdItem01;

        private List<ItemTechnology> itemList;

        protected override void OnCreate(object arg = null)
        {
            itemList = new List<ItemTechnology>();
            itemList.Add(firstItem);
            itemList.Add(secondItem00);
            itemList.Add(secondItem01);
            itemList.Add(thirdItem00);
            itemList.Add(thirdItem01);
        }

        public void Hide()
        {

        }

        protected override void OnRelease()
        {
            
        }
    }
}

