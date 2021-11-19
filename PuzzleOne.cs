using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;

public class PuzzleOne : MonoBehaviour
{
    public TextMeshPro currentWord;
    public static string currentKey;
    int index = 0;
    List<string> listOfKeys;
    public List<GameObject> cubes;

    public Dictionary<string, Vector3> positions = new Dictionary<string, Vector3>();

    public AudioClip success;
    public AudioClip fail;
    public AudioClip win;
    public AudioSource audioEffect;

    private void OnEnable()
    {
        audioEffect = GetComponent<AudioSource>();
        listOfKeys = new List<string>(MyGameManager.Keys);
        Shuffle();
        currentWord.text = MyGameManager.MyLanguage[listOfKeys[index]];
        currentKey = listOfKeys[index];
        foreach (string key in listOfKeys)
        {
            GameObject cube = GameObject.FindWithTag(key);
            positions[key] = cube.transform.position;
            cubes.Add(cube);

        }
    }

    private void OnDisable()
    {
        foreach (GameObject cube in cubes)
        {
            if (!cube.activeSelf)
            {
                cube.SetActive(true);
            }

            cube.transform.position = positions[cube.tag];
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == currentKey)
        {
            audioEffect.PlayOneShot(success);
            index++;
            if (index == listOfKeys.Count)
            {
                audioEffect.PlayOneShot(win);
                currentWord.text = "USPJEH!";
            }
            currentWord.text = MyGameManager.MyLanguage[listOfKeys[index]];
            currentKey = listOfKeys[index];
            collision.gameObject.SetActive(false);

        }
        else
        {
            collision.gameObject.SetActive(false);
            audioEffect.PlayOneShot(fail);
            foreach (GameObject cube in cubes)
            {
                if (!cube.activeSelf)
                {
                    cube.SetActive(true);
                    cube.transform.position = positions[cube.tag];
                }

            }
            Shuffle();
            index = 0;
            currentWord.text = MyGameManager.MyLanguage[listOfKeys[index]];
            currentKey = listOfKeys[index];
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < listOfKeys.Count; i++)
        {
            string temp = listOfKeys[i];
            int randomIndex = Random.Range(i, listOfKeys.Count);
            listOfKeys[i] = listOfKeys[randomIndex];
            listOfKeys[randomIndex] = temp;
        }
    }

}
