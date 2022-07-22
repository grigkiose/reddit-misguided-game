using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public GameObject fpsCamera;
    public LayerMask layerMaskToTarget;

    void Update()
    {
        RaycastHit hit;
        var ray = new Ray(fpsCamera.transform.position, fpsCamera.transform.forward*3);
        Debug.DrawRay(fpsCamera.transform.position,fpsCamera.transform.forward*3, Color.green);

        if (Physics.Raycast(ray, out hit, 50, layerMaskToTarget)) {
            GameObject objectHit = hit.transform.gameObject;
            if( objectHit.tag =="Ghost"){
                objectHit.SetActive(false);
            }
        }
    }
}
