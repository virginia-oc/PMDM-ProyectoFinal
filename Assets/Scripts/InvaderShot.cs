using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderShot : MonoBehaviour
{
    private float velocidad = -1.0f;
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
        if (collision.tag == "Bubblun")
        {
            FindObjectOfType<GameController>().SendMessage("PerderVida");
            Destroy(gameObject);
        }
        else if (collision.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
