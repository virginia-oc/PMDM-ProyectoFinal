using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mighta : MonoBehaviour
{
    [SerializeField] float velocidad = 0.5f;
    [SerializeField] List<Transform> wayPoints;
    private Vector3 siguientePosicion;
    private byte indiceSiguientePosicion = 0;
    private float distanciaCambio = 0.1f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        siguientePosicion = wayPoints[0].position;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            siguientePosicion,
            velocidad * Time.deltaTime);
        

        if (Vector3.Distance(transform.position, siguientePosicion) < distanciaCambio)
        {
            indiceSiguientePosicion++;

            if (indiceSiguientePosicion == 1 || indiceSiguientePosicion == 2)
                anim.Play("MightaWalkingLeft");
            else
                anim.Play("MightaWalkingRight");
            if (indiceSiguientePosicion >= wayPoints.Count)
                indiceSiguientePosicion = 0;
            siguientePosicion = wayPoints[indiceSiguientePosicion].position;
        }
        
        //Mighta se mueve siempre en sentido antihorario
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bubblun")
        {
            FindObjectOfType<GameController>().SendMessage("PerderVida");
        }
    }

    
}
