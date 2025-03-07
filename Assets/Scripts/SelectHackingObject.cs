using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHackingObject : MonoBehaviour
{   
    public Camera playerCamera;
    RaycastHit[] hits;
    public GameObject hackedObject;
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if(hit.transform.gameObject.CompareTag("Hack"))
            {
                hackedObject = hit.transform.gameObject;
                hackedObject.GetComponent<Outline>().enabled = true;
            }
            else
            {
                if(hackedObject != null)
                {
                    hackedObject.GetComponent<Outline>().enabled = false;
                    hackedObject = null;
                }
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 0.1f);

    }
}

