using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHackingObject : MonoBehaviour
{   
    public Camera playerCamera;
    RaycastHit hit;
    GameObject hackedObject;
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.CompareTag("Hack"))
            {
                hackedObject = hit.transform.gameObject;
                hackedObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                hackedObject.GetComponent<Outline>().enabled = false;
                hackedObject = null;
            }
        }
    }
}

