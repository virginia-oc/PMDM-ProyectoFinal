using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaItem : MonoBehaviour
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
        FindObjectOfType<GameController>().SendMessage("AnotarItemRecogido");
        Destroy(gameObject);
    }
}
