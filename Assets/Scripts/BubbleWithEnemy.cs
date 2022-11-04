using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWithEnemy : MonoBehaviour
{
    [SerializeField] float velocidad = 1f;
    private Animator anim;
    [SerializeField] Transform prefabEnemyDeath;
    [SerializeField] Transform prefabItem;
    bool isBubbleWithMighta = false;
    bool isBubbleWithInvader = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (isBubbleWithMighta)
            anim.Play("BubbleWithMighta");
        else if (isBubbleWithInvader)
            anim.Play("BubbleWithInvader");
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
            FindObjectOfType<GameController>().SendMessage("AnotarBubbleWithEnemy");

            Transform enemyDeath = Instantiate(prefabEnemyDeath, transform.position,
                Quaternion.identity);
            Physics2D.IgnoreCollision(enemyDeath.GetComponent<Collider2D>(),
                GetComponent<Collider2D>());

            if (isBubbleWithMighta)
            {
                enemyDeath.gameObject.SendMessage("IsMightaDeath");
            }
            else if (isBubbleWithInvader)
                enemyDeath.gameObject.SendMessage("IsInvaderDeath");
                
            StartCoroutine(WaitForDeathAnimation(1.20f));
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

    private void BubbleWithMighta()
    {
        isBubbleWithMighta = true;
    }

    private void BubbleWithInvader()
    {
        isBubbleWithInvader = true;
    }
}
