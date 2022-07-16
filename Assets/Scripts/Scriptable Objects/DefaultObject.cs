using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Default Object", menuName = "Inventory/Items/Default")]
public class DefaultObject : ItemObject{
    public void Awake(){
        if(text.Length==0 || text== null){
            text= "This is a default Object";
        }
    }
}
