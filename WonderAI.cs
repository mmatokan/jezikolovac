using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderAI : MonoBehaviour
{
    public float moveSpeed = 1F;
    public float rotSpeed = 100F;
    public bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    Animator anim;
    GameObject sheep;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sheep = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(isWandering == false)
        {
            StartCoroutine(Wander());
        }
        
        if(isRotatingRight)
        {
            sheep.transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft)
        {
            sheep.transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }

        
        if(isWalking)
        {
            sheep.transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        
    }

    IEnumerator Wander()
    {
        int rotateTime = Random.Range(1, 3);
        int rotateWait = Random.Range(15, 30);
        int rotateLR = Random.Range(1, 2);
        int walkTime = Random.Range(1, 5);
        int idleTime = Random.Range(15, 30);

        isWandering = true;

        anim.SetBool("isIdle", true);
        yield return new WaitForSeconds(idleTime);
        anim.SetBool("isIdle", false);
        
        isWalking = true;
        anim.SetBool("isWalking", true);
        yield return new WaitForSeconds(walkTime);
        anim.SetBool("isWalking", false);
        isWalking = false;

        
        //yield return new WaitForSeconds(rotateWait);
        if(rotateLR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotateTime);
            isRotatingRight = false;
        }
        if (rotateLR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotateTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
}
