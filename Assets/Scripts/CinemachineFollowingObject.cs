using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinemachineFollowingObject : MonoBehaviour
{
    [SerializeField] float velocidad = - 0.5f;
    private AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCredits());
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, velocidad * Time.deltaTime, 0);
    }

    private IEnumerator WaitForCredits()
    {
        yield return new WaitForSeconds(8.0f);
        SceneManager.LoadScene("WelcomeScene");
    }
}
