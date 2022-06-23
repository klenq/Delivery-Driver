using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool picked = false;
    [SerializeField] float delayDestory;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Print Something");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package")
        {
            if (picked)
            {
                Debug.Log("already got the package");
            }
            else
            {
                Debug.Log("package picked up");
                picked = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(collision.gameObject, delayDestory);
                
            }
            
        }
        if(collision.tag == "Customer")
        {
            if (picked)
            {
                Debug.Log("package delivered.");
                picked = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("package not picked up.");
            }
            
        }

       
    }
}
