using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XrayScanner : MonoBehaviour
{
    public Player player;
    public PlayerStateMachine playerState;
    public MeshRenderer meshRenderer;
    public Material baseMaterial;
    public int baseLayer;
    public Material XrayMaterial;
    public UnityEvent onXray;
    public UnityEvent offXray;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        baseMaterial = meshRenderer.material;
        baseLayer = gameObject.layer;
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, player.transform.position - transform.position, out hit))
        {
            if(hit.collider.CompareTag("Player") == false )
            {
                gameObject.layer = 6;
                meshRenderer.material = XrayMaterial;
                onXray.Invoke();
            }
            else
            {
                gameObject.layer = baseLayer;
                meshRenderer.material = baseMaterial;
                offXray.Invoke();
            }
        }
    }
}
