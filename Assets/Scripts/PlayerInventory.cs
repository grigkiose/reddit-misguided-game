using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventoryObject intentory;

    private void OnApplicationQuit(){
      intentory.container.items.Clear();
    }
}
