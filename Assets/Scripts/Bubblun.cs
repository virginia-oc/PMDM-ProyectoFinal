using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubblun : MonoBehaviour
{
    [SerializeField] float velocidad = 3.0f;
    [SerializeField] float velocidadSalto = 2.0f;
    private float xInicial, yInicial;
    private float alturaPlayer;
    [SerializeField] Transform prefabBubbleShot;
    private Animator anim;
    public bool mirandoHaciaDerecha = true;

    // Start is called before the first frame update
    void Start()
    {
        xInicial = transform.position.x;
        yInicial = transform.position.y;
        alturaPlayer = GetComponent<Collider2D>().bounds.size.y;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float direccion = Input.GetAxis("Horizontal");
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1));
        float distanciaSuelo = hit.distance;
        bool tocandoElSuelo = distanciaSuelo < alturaPlayer *3/4;

        if (tocandoElSuelo && (direccion > 0.1f))
        {
            anim.Play("BubblunCorriendoDerecha");
            mirandoHaciaDerecha = true;
        }         
        else if (tocandoElSuelo && (direccion < -0.1f))
        {
            anim.Play("BubblunCorriendoIzquierda");
            mirandoHaciaDerecha = false;
        }
            

        transform.Translate(direccion * velocidad * Time.deltaTime, 0, 0);

        float salto = Input.GetAxisRaw("Jump");
        if (salto > 0)
        {
            if (tocandoElSuelo)
            {
                Vector3 fuerzaSalto = new Vector3(0, velocidadSalto, 0);
                GetComponent<Rigidbody2D>().AddForce(fuerzaSalto);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (mirandoHaciaDerecha)
                anim.Play("BubblunShootingRight");
            else
                anim.Play("BubblunShootingLeft");
            Transform bubbleShot = Instantiate(prefabBubbleShot, transform.position,
                Quaternion.identity);
            Physics2D.IgnoreCollision(bubbleShot.GetComponent<Collider2D>(),
                GetComponent<Collider2D>());
        }
    }

    private void ResetPosition()
    {
        transform.position = new Vector3(xInicial, yInicial, 0);
    }

    private void playDeathAnimation()
    {
        
        anim.Play("BubblunDeath");
    }
}
