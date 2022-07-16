using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ItemTipManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject descriptionPanel;

    public ItemObject item;

    public void Start(){
        descriptionPanel = GameObject.Find("DescriptionPanel");
    }

     public void OnPointerEnter(PointerEventData eventData){
        descriptionPanel.GetComponentInChildren<TextMeshProUGUI>().text = item.text;
     }
 
     public void OnPointerExit(PointerEventData eventData){
        descriptionPanel.GetComponentInChildren<TextMeshProUGUI>().text = "";
     }
}
