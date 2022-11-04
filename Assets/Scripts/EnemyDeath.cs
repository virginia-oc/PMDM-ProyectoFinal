using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    float fuerzaX = -20;
    float fuerzaY = 50;
    [SerializeField] Transform prefabItem;
    private bool isMightaDeath = false;
    private bool isInvaderDeath = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x <= 0)
            fuerzaX *= -1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaX, fuerzaY));
        anim = gameObject.GetComponent<Animator>();
        if (isMightaDeath)
            anim.Play("MightaDeath");
        else if (isInvaderDeath)
            anim.Play("InvaderDeath");

        StartCoroutine(WaitForItem());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().GetPointVelocity(new Vector2(0,0)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ceiling")
        {
            if (fuerzaX < 0)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, -20));
            else
                GetComponent<Rigidbody2D>().AddForce(new Vector2(20, -20));
        }
        else if (collision.tag == "Walls")
        {
            if (transform.position.x < 0)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(60, -10));
            else
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-80, -10));
        }
        
    }

    private IEnumerator WaitForItem()
    {
        yield return new WaitForSeconds(2.0f);
        ConvertirEnItem();
    }

    public void ConvertirEnItem()
    {
        Transform item = Instantiate(prefabItem, transform.position,
                Quaternion.identity);
        Physics2D.IgnoreCollision(item.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());
        Destroy(gameObject);
    }

    private void IsMightaDeath()
    {
        isMightaDeath = true;
    }

    private void IsInvaderDeath()
    {
        isInvaderDeath = true;
    }
}
