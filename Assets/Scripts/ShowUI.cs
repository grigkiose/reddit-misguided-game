using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowUI : MonoBehaviour
{
    [SerializeField] private TMP_Text uiObject;

    [SerializeField] private string textToShow;

    void Start(){
        uiObject.gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider collider){
        if(collider.gameObject.tag == "Player"){
            uiObject.SetText(textToShow);
            uiObject.gameObject.SetActive(true);
            StartCoroutine("WaitBeforeHiding");
        }
    }

    IEnumerator WaitBeforeHiding(){
        yield return new WaitForSeconds(5);
        uiObject.gameObject.SetActive(false);
    }
}
