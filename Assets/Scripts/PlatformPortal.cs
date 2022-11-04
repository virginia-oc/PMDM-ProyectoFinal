using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float xInicial = collision.gameObject.GetComponent<Transform>().position.x;
        float zInicial = collision.gameObject.GetComponent<Transform>().position.z;
        collision.gameObject.GetComponent<Transform>().position = 
            new Vector3(xInicial, 1.20f, zInicial);
    }
}
