using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAlone : MonoBehaviour
{
    [SerializeField] float velocidad = 1f;
    private Animator anim;
    bool bubbleDeath = false;

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
            bubbleDeath = true;
            anim.Play("BubbleDeathAnimation");
            StartCoroutine(WaitForDeathAnimation(1.20f));
            FindObjectOfType<GameController>().SendMessage("AnotarBubbleAlone");
        }
        else if (collision.tag == "Ceiling" && bubbleDeath == false)
        {
            velocidad = 0;
            anim.Play("BubbleAloneAutodestruction");
            StartCoroutine(WaitForAutodestruction(10.0f));
        }
    }

    private IEnumerator WaitForDeathAnimation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    private IEnumerator WaitForAutodestruction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.Play("BubbleDeathAnimation");
        StartCoroutine(WaitForDeathAnimation(1.20f));
    }
}
