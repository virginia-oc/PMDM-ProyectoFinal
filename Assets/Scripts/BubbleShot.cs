using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShot : MonoBehaviour
{
    private float velocidad = 2f;
    private bool direccionDerecha;
    [SerializeField] Transform prefabBubbleWithEnemy;
    [SerializeField] Transform prefabBubbleAlone;

    // Start is called before the first frame update
    void Start()
    {
        direccionDerecha = FindObjectOfType<Bubblun>().mirandoHaciaDerecha;
    }

    // Update is called once per frame
    void Update()
    {      
        if (direccionDerecha)
            transform.Translate(velocidad * Time.deltaTime, 0, 0);
        else
            transform.Translate(-velocidad * Time.deltaTime, 0, 0);      

        StartCoroutine(WaitForBubbleUp(0.5f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ZenChan")
        {
            Vector3 lugarMuerteZenChan = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            //Instantiate<BubbleWithEnemy>

        }
        if (collision.tag == "Walls")
        {
            CambiarDireccion();
        }     
    }

    private IEnumerator WaitForBubbleUp(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CambiarDireccion();
    }

    private void CambiarDireccion()
    {
        Transform bubbleAlone = Instantiate(prefabBubbleAlone, transform.position,
                Quaternion.identity);
        Physics2D.IgnoreCollision(bubbleAlone.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());
        Destroy(gameObject);
    }
}
