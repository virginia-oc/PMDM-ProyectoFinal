using System.Collections;
using UnityEngine;

public class ZenChanDeath : MonoBehaviour
{
    float fuerzaX = -20;
    float fuerzaY = 50;
    [SerializeField] Transform prefabItem;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x <= 0)
            fuerzaX *= -1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaX, fuerzaY));

        StartCoroutine(WaitForItem());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().GetPointVelocity(new Vector2(0,0)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            ConvertirEnItem();
        }
        else if (collision.tag == "Ceiling")
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
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-60, -10));
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
}
