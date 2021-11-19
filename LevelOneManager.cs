using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LevelOneManager : MonoBehaviour
{
    AudioScript[] audioObjects;
    GameObject gun;

    void Awake()
    {
        SnapToHand(gun);
        audioObjects = FindObjectsOfType(typeof(AudioScript)) as AudioScript[];
        foreach (AudioScript audio in audioObjects)
        {
            audio.ChangeLanguageAudio();
        }
    }

    public void SnapToHand(GameObject gun)
    {
        Debug.Log("Setting hand");
        if (MyGameManager.Hand == "Left")
        {
            GameObject.Find("LeftControllerScriptAlias").GetComponent<VRTK_ObjectAutoGrab>().enabled = true;
        }
        else if(MyGameManager.Hand == "Right")
        {
            GameObject.Find("RightControllerScriptAlias").GetComponent<VRTK_ObjectAutoGrab>().enabled = true;
        }
    }

}
