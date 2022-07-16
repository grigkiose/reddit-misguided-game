using UnityEngine;
using System.Collections;


public class Collectible : MonoBehaviour{
    public ItemObject item;

    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag=="Player"){
            PlayerInventory playerInventory = col.gameObject.GetComponent<PlayerInventory>();
            playerInventory.intentory.AddItem(item,1);

            if(gameObject.GetComponent<ShowUI>()!=null){
                StartCoroutine("WaitBeforeHiding");
            }else{
                Destroy(gameObject);
            }
        }
    }

    IEnumerator WaitBeforeHiding(){
        gameObject.GetComponent<Renderer>().enabled=false;
        yield return new WaitForSeconds(6);
        gameObject.SetActive(false);
    }
}
