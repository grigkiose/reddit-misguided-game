using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory System/Inventory")]
public class InventoryObject : ScriptableObject{

    public Inventory container;
    
    public void AddItem( ItemObject _item, int _amount){
        bool hasItem = false;
        int i=0;
        while(i< container.items.Count && !hasItem){
            if(container.items[i].item == _item){
                hasItem = true;
                container.items[i].AddAmount(_amount);
            }
            i++;
        }
        if(!hasItem){
            container.items.Add(new InventorySlot(_item,_amount));
        }
    }

}

[System.Serializable]
public class InventorySlot{

    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount){
        item = _item;
        amount=_amount;
    }

    public void AddAmount( int val){
        amount += val;
    }
}

[System.Serializable] public class Inventory{
    public List<InventorySlot> items = new  List<InventorySlot>();
}