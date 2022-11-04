using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bubblun")
        {
            sonido.Play();
            FindObjectOfType<GameController>().SendMessage("AnotarItemRecogido");
            Destroy(gameObject);
        }
    }
}
