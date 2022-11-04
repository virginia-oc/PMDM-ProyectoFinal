using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinemachineFollowingObject : MonoBehaviour
{
    [SerializeField] float velocidad = - 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCredits());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, velocidad * Time.deltaTime, 0);

        if (Input.anyKey)
            SceneManager.LoadScene("WelcomeScene");
    }

    private IEnumerator WaitForCredits()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("WelcomeScene");
    }
}
