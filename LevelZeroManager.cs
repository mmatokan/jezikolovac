using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VRTK.Controllables.ArtificialBased;

public class LevelZeroManager : MonoBehaviour
{
    public GameObject teleporter;
    public GameObject globe;
    public GameObject puzzleStation;
    public GameObject gunStation;
    public GameObject buttons;
    public GameObject puzzleScriptContainer;
    public TextMeshProUGUI instructionText;
    public GameObject leverControl;
    public AudioScript[] audioObjects;

    public static string controller;

    private void Start()
    {
        LoadMyText.getMyLanguage();

        if(MyGameManager.Level == 1)
        {
            
            LevelOne();
            leverControl.GetComponent<VRTK_ArtificialRotator>().SetValue(90);
        }
        else
        {
            LevelZero();
        }
    }

    public void LevelOne()
    {
        Debug.Log("Level one");
        SwitchActiveOne();
        ApplyText();
        ApplyLanguageSound();
    }

    public void LevelZero()
    {
        Debug.Log("Level zero");
        SwitchActiveZero();
    }

    public void ApplyText()
    {
        LoadMyText.getWords(MyGameManager.Language);
        foreach (string key in MyGameManager.Keys)
        {
            GameObject[] textObjects = GameObject.FindGameObjectsWithTag(key);
            foreach (GameObject cube in textObjects)
            {
                TextMeshPro[] names = cube.GetComponentsInChildren<TextMeshPro>();
                foreach (TextMeshPro name in names)
                {
                    name.text = MyGameManager.LearningLanguage[key];
                }
            }
        }
    }

    public void SwitchActiveOne()
    {
        instructionText.text = "Ubaci kockice odgovarajućim redoslijedom!\nAko ne znaš uzmi oružje i stani na teleportacijsku platformu. Riječ možeš naučiti tako da pogodiš odgovarajući objekt.";
        globe.SetActive(false);
        buttons.SetActive(false);
        teleporter.SetActive(true);
        puzzleStation.SetActive(true);
        gunStation.SetActive(true);

        puzzleScriptContainer.GetComponent<PuzzleOne>().enabled = true;
    }

    public void SwitchActiveZero()
    {
        Debug.Log("Setting active...");
        instructionText.text = "Pritiskom odgovarajuceg gumba odaberite jezik, a za pocetak igre povucite polugu.";
        globe.SetActive(true);
        buttons.SetActive(true);
        teleporter.SetActive(false);
        puzzleStation.SetActive(false);
        gunStation.SetActive(false);

        puzzleScriptContainer.GetComponent<PuzzleOne>().enabled = false;
    }

    public void ApplyLanguageSound()
    {
        audioObjects = FindObjectsOfType(typeof(AudioScript)) as AudioScript[];
        foreach (AudioScript audio in audioObjects)
        {
            audio.ChangeLanguageAudio();
        }
    }

    public void SetHand(GameObject gun)
    {
        Debug.Log("Setting hand");
        if (controller == "Left")
        {
            MyGameManager.Hand = "Left";
            Debug.Log(MyGameManager.Hand);
        }
        else
        {
            MyGameManager.Hand = "Right";
            Debug.Log(MyGameManager.Hand);
        }
    }

    public void SetController(string c)
    {
        controller = c;
    }
}
