using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using VRTK.Examples;
public class Portal : MonoBehaviour
{
    public string newScene;
    public static bool onTeleporter;
    public GameObject teleportEffect;
    public GameObject info;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "[VRSimulator_CameraRig]")
        {
            Debug.Log("Standing on telepotrtation pad!");
            onTeleporter = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "[VRSimulator_CameraRig]")
        {
            Debug.Log("Not on telepotrtationa pad anymore!");
            onTeleporter = false;
        }
    }

    public void Teleport()
    {
        if(onTeleporter)
        {
            teleportEffect.SetActive(true);
            SceneManager.LoadScene(newScene);
        }
    }

    IEnumerator ShowInfo()
    {
        info.SetActive(true);
        yield return new WaitForSeconds(10);
        info.SetActive(false);
    }
}
