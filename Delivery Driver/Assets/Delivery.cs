using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(0, 0, 0, 0);
    
    private bool hasPackage;
    [SerializeField] private float destroyDelay = 0.5f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        } 
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered to Customer!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        
    }
}
