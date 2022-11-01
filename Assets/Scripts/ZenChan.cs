using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZenChan : MonoBehaviour
{
    private float alturaPersonaje;
    private float anchoPersonaje;
    private float velocidadX = -0.5f;
    private float constante;   
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
        anchoPersonaje = GetComponent<Collider2D>().bounds.size.x;
        constante = anchoPersonaje / 2 + anchoPersonaje / 8;
        localScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, 0, 0);       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>().tag == "Walls")
        {
            velocidadX *= -1;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        if (collision.gameObject.GetComponent<Collider2D>().tag == "Bubblun")
        {
            FindObjectOfType<GameController>().SendMessage("PerderVida");
            FindObjectOfType<Bubblun>().SendMessage("ResetPosition");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "JumpPoint")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150f);
        }
    }

}
