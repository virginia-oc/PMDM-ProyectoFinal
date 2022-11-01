using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAlone : MonoBehaviour
{
    [SerializeField] float velocidad = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, velocidad * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ceiling")
        {
            velocidad = 0;
        }
    }

    
}
