using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAlone : MonoBehaviour
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
        if (collision.tag == "Ceiling")
        {
            velocidad = 0;
        }
        if (collision.tag == "Bubblun")
        {
            anim.Play("BubbleDeathAnimation");
            StartCoroutine(WaitForBubbleAnimation(1.20f));
        }

    }

    private IEnumerator WaitForBubbleAnimation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        FindObjectOfType<GameController>().SendMessage("AnotarBubbleAlone");
        Destroy(gameObject);
    }
}
