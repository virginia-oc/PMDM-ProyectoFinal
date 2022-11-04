using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] float velocidad;
    private Animator anim;
    [SerializeField] Transform prefabRay;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(WaitForShot());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime, 0 , 0);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Walls")
        {
            velocidad *= -1;
        }
    }

    private IEnumerator WaitForShot()
    {
        yield return new WaitForSeconds(3.0f);
        Transform rayShot = Instantiate(prefabRay, transform.position,
                Quaternion.identity);
        Physics2D.IgnoreCollision(rayShot.GetComponent<Collider2D>(),
                GetComponent<Collider2D>());
        StartCoroutine(WaitForShot());
    }
}
