using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDiscovered : MonoBehaviour
{
    public AudioSource spokenWord;
    public ParticleSystem foundEffect;
    public AudioScript audioScript;

    private void Start()
    {
        spokenWord = GetComponent<AudioSource>();
        foundEffect = GetComponentInChildren<ParticleSystem>();
        audioScript = GetComponent<AudioScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            Debug.Log("Collision detected");
            StartCoroutine(StartFoundEffect());
            spokenWord.Play();
            Destroy(collision.gameObject);
        }
    }

    IEnumerator StartFoundEffect()
    {
        foundEffect.Play();
        yield return new WaitForSeconds(3);
        foundEffect.Stop();
    }
}
