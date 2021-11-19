using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

public class AudioScript : MonoBehaviour
{
    public AudioSource myAudio;

    public void ChangeLanguageAudio()
    {
        string name = gameObject.tag;
        string language = MyGameManager.Language;
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = Resources.Load<AudioClip>(language + "/" + name);
    }

}
