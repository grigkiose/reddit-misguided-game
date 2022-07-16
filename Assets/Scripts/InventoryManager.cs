using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public int X_START;
    public int Y_START;
    public InventoryObject inventory;
    public int X_SPACE_BETWEEN_ITEMS;
    public int NUMBER_OF_COLUMNS;
    public int Y_SPACE_BETWEEN_ITEMS;
    Dictionary<InventorySlot,GameObject> itemsDisplayed = new Dictionary<InventorySlot,GameObject>();
    // Start is called before the first frame update
    void Start(){
        CreateDisplay();
    }

    // Update is called once per frame
    void Update(){
        UpdateDisplay();   
    }

    public void UpdateDisplay(){
        for (int i = 0; i < inventory.container.items.Count; i++){
           InventorySlot slot = inventory.container.items[i];
           if(itemsDisplayed.ContainsKey(slot)){
                itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text= slot.amount.ToString("n0");
           }else{
                addToInvetory(i,slot);
           }
        }
    }
    public void CreateDisplay(){
        for (int i = 0; i < inventory.container.items.Count; i++){
            InventorySlot slot = inventory.container.items[i];
            addToInvetory(i,slot);        
        }
    }

    public Vector3 GetPosition(int index){
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * (index % NUMBER_OF_COLUMNS)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (index/NUMBER_OF_COLUMNS)),0f);
    }

    public void addToInvetory(int index, InventorySlot slot){
            var obj = Instantiate(itemPrefab,Vector3.zero, Quaternion.identity,transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = slot.item.uiSprite;
            obj.GetComponentInChildren<ItemTipManager>().item = slot.item;obj.GetComponent<RectTransform>().localPosition = GetPosition(index);
            obj.GetComponentInChildren<TextMeshProUGUI>().text= slot.amount.ToString("n0");
            itemsDisplayed.Add(slot,obj);
    }
}
