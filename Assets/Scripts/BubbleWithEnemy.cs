using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWithEnemy : MonoBehaviour
{
    [SerializeField] float velocidad = 1f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
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
            velocidad = 0;
            anim.Play("BubbleDeathAnimation");
            StartCoroutine(WaitForDeathAnimation(1.20f));
            FindObjectOfType<GameController>().SendMessage("AnotarBubbleWithEnemy");
        }
        else if (collision.tag == "Ceiling")
        {
            velocidad = 0;
        }
    }

    private IEnumerator WaitForDeathAnimation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
