using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZenChan : MonoBehaviour
{
    private float alturaPersonaje;
    private float anchoPersonaje;
    private float velocidadX = -0.5f;
    private float velocidadY = 0.5f;
    private bool vertical = false;
    bool corrutinaTerminada = false;
    bool tocandoElSuelo = true;
    bool playingAnimAscenso = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
        anchoPersonaje = GetComponent<Collider2D>().bounds.size.x;             
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playingAnimAscenso)
        {
            if (vertical && corrutinaTerminada)
            {
                Vector3 rayOrigin = new Vector3(
                    transform.position.x, transform.position.y - alturaPersonaje, transform.position.z);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, new Vector2(0, -1));
                float distanciaSuelo = hit.distance;
                tocandoElSuelo = distanciaSuelo < alturaPersonaje / 2;
                if (tocandoElSuelo == true)
                {
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                    vertical = false;
                    corrutinaTerminada = false;
                }
            }

            if (vertical == false)
            {
                if (velocidadX < 0)                                
                    anim.Play("ZenChanWalkingLeft");                                  
                else             
                    anim.Play("ZenChanWalkingRight");               
                   
                transform.Translate(velocidadX * Time.deltaTime, 0, 0);
            }             
            else
            {
                tocandoElSuelo = false;
                transform.Translate(0, velocidadY * Time.deltaTime, 0);
            }
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>().tag == "Walls")
        {
            velocidadX *= -1;           
        }
        if (collision.gameObject.GetComponent<Collider2D>().tag == "Bubblun")
        {
            velocidadX *= -1;
            FindObjectOfType<GameController>().SendMessage("PerderVida");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "JumpPoint")
        {
            playingAnimAscenso = true;
            vertical = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            anim.Play("ZenChanAscenso");
            StartCoroutine(WaitForAnimacionAscenso());           
        }
    }

    private IEnumerator WaitForAnimacionAscenso()
    {
        yield return new WaitForSeconds(1.0f);
        playingAnimAscenso = false;
        StartCoroutine(Ascenso());
    }

    private IEnumerator Ascenso()
    {
        yield return new WaitForSeconds(0.5f);
        corrutinaTerminada = true;
    }
}
