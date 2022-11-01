using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZenChan : MonoBehaviour
{
    private float alturaPersonaje;
    private float anchoPersonaje;
    private float velocidadX = -0.5f;
    private float velocidadSalto = 8f;
    private float constante;

    // Start is called before the first frame update
    void Start()
    {
        alturaPersonaje = GetComponent<Collider2D>().bounds.size.y;
        anchoPersonaje = GetComponent<Collider2D>().bounds.size.x;
        constante = anchoPersonaje / 2 + anchoPersonaje / 8;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorDere = new Vector2(
            transform.position.x + constante, transform.position.y);
        Vector2 vectorIzq = new Vector2(
            transform.position.x - constante, transform.position.y);
        RaycastHit2D hitIzq = Physics2D.Raycast(vectorDere, new Vector2(0, -1));
        RaycastHit2D hitDer = Physics2D.Raycast(vectorIzq, new Vector2(0, -1));
        
        float distanciaAlSueloIzq = hitIzq.distance;
        float distanciaAlSueloDer = hitDer.distance;
        bool tocandoElSueloIzq = distanciaAlSueloIzq < alturaPersonaje;
        bool tocandoElSueloDer = distanciaAlSueloDer < alturaPersonaje;

        if (tocandoElSueloDer || tocandoElSueloIzq)
        {
            transform.Translate(velocidadX * Time.deltaTime, 0, 0);
            //System.Random r = new System.Random();
            //int aleatorio = r.Next(1, 11);
            //Debug.Log(aleatorio);                             
        }           
        else
            transform.Translate(0, velocidadX * Time.deltaTime, 0);
       
    }

    private void CambiarDireccion()
    {
        velocidadX *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>().tag == "Walls")
        {
            CambiarDireccion();
        }
        else if (collision.gameObject.GetComponent<Collider2D>().tag == "Bubblun")
        {
            FindObjectOfType<GameController>().SendMessage("PerderVida");
            FindObjectOfType<Bubblun>().SendMessage("ResetPosition");
        }
        //else if (collision.gameObject.GetComponent<Collider2D>().tag == "Respawn")
        //{
        //    Saltar();
        //}
    }

    private void Saltar()
    {
        Vector3 fuerzaSalto = new Vector3(0, velocidadSalto, 0);
        GetComponent<Rigidbody2D>().AddForce(fuerzaSalto);
    }
}
