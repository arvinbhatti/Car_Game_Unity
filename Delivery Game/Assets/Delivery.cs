using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);

    [SerializeField] float destoryDelay = 0.5f; 
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("boop");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage)
        {
            spriteRenderer.color = hasPackageColor;
            Debug.Log("picked up");
            hasPackage = true;
            Destroy(other.gameObject, destoryDelay);
        }
        else if(other.tag == "Package" && hasPackage)
        {
            Debug.Log("Already has package");
        }
        else if(other.tag == "Customer" && hasPackage)
        {
            spriteRenderer.color = noPackageColor;
            Debug.Log("delivered");
            hasPackage = false;
        }
        else if(other.tag == "Customer" && !hasPackage){
            Debug.Log("No package");
        }
    }
}
