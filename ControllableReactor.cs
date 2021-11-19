namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;

    using System.Collections.Generic;
    using TMPro;

    public class ControllableReactor : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";

        //moje varijable
        public bool levelStart = false;
        public LevelZeroManager levelManager;
        public GameObject[] btns;

        public AudioSource buttonSound;
        public AudioSource leverMax;

        //Metode za upravljanje controllable objektima
        protected virtual void OnEnable()
        {
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
                     
            btns = GameObject.FindGameObjectsWithTag("button");
           
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            if (displayText != null)
            {
                //displayText.text = e.value.ToString("F1");
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMax != "")
            {
                Debug.Log(outputOnMax);
                if(outputOnMax.Equals("GameOn"))
                {
                    
                    levelStart = true;
                    MyGameManager.Level = 1;
                    levelManager.LevelOne();
                    leverMax.Play();
                    if (displayText != null)
                    {
                        displayText.text = "ON";
                    }                
                }
                //ako igra nije pocela mozes mijenjati jezik
                if(levelStart == false)
                {
                    buttonSound.Play();
                    Debug.Log("Current language: " + MyGameManager.Language);
                    MyGameManager.Language = outputOnMax;
                    foreach (GameObject btn in btns)
                    {
                        btn.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                        Debug.Log("Turning off lights");
                    }
                    this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                }
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
                if (outputOnMin.Equals("GameOff"))
                {
                    levelStart = false;
                    MyGameManager.Level = 0;
                    levelManager.LevelZero();
                    if (displayText != null)
                    {
                        displayText.text = "OFF";
                    }
                  
                }
            }
        }

    }
}