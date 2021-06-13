using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class GameManagerScript : MonoBehaviour
{
    public GameData gameData;
    public TutorialData tutorial;

    public GameObject tutorialScreen;
    public TextMeshProUGUI tutorialText;

    public GameEvent eTask1;
    public GameEvent eTask1Completed;
    public GameEvent eTask2;
    public GameEvent eTask2Completed;

    public GameObject target;
    public List<Transform> taskPositions;

    void Start()
    {
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        
        //////////////////////////////////////////////                  1
        tutorialScreen.SetActive(true);
        gameData.frozen = true;
        tutorialText.text = tutorial.text1;
        if (!tutorial.tutorialCompleted)
        {
            gameData.invincible = true;

            float timer = tutorial.shortTime;
            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                timer -= Time.deltaTime;

                Color transparency = tutorialText.color;
                transparency.a -= 0.005f;
                tutorialText.color = transparency;
                if (timer < 0)
                {
                    break;
                }

            }
            Color reset = tutorialText.color;
            reset.a = 1;
            tutorialText.color = reset;

            ///////////////////////////////////////////////                 2
            tutorialText.text = tutorial.text2;

            yield return new WaitForSecondsRealtime(tutorial.shortTime);
            gameData.frozen = false;

            yield return new WaitForSecondsRealtime(tutorial.mediumTime);
            //tutorialScreen.SetActive(false);

            /////////////////////////////////////////////                   3
            tutorialText.text = tutorial.text3;
            yield return new WaitForSecondsRealtime(tutorial.shortTime);

            timer = tutorial.longTime;

            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                timer -= Time.deltaTime;
                if (gameData.quickTimeEvent)
                {
                    break;
                }
                else if (timer < 0)
                {
                    timer = tutorial.longTime;
                }
            }

            //////////////////////////////////////////                      4
            tutorialText.text = tutorial.text4;

            yield return new WaitForSecondsRealtime(tutorial.shortTime);

            /////////////////////////////////////////                       5
            tutorialText.text = tutorial.text5;

            timer = tutorial.longTime;
            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                timer -= Time.deltaTime;

                if (!gameData.botControl)
                {
                    break;
                }
                else if (timer < 0)
                {
                    timer = tutorial.longTime;
                }
            }

            ////////////////////////////////////////                     6
            tutorialText.text = tutorial.text6;

            timer = tutorial.longTime;
            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                timer -= Time.deltaTime;

                if (FindObjectOfType<ControlScript>().markers.Count >= 2)
                {
                    break;
                }
                else if (timer < 0)
                {
                    timer = tutorial.longTime;
                }
            }

            ////////////////////////////////////                        7
            tutorialText.text = tutorial.text7;

            yield return new WaitForSecondsRealtime(tutorial.shortTime);
            tutorialScreen.SetActive(false);
        }
        eTask1.Raise();

        

    }

    public void StartTask1()
    {
        StartCoroutine(Task1());
    }

    IEnumerator Task1()
    {
        //TURN ON CAMERA
        //WAIT FOR CAMERA
        //CHANGE UI ELEMENTS
        target.transform.position = taskPositions[0].position;

        float timer = 60;

        while (timer > 0)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            timer -= Time.deltaTime;

            if (FindObjectOfType<ControlScript>().gameObject.transform.position.x >= taskPositions[0].position.x)
            {

                eTask1Completed.Raise();
                break;
            }
            else if (timer < 0)
            {
                timer += 60;
            }
        }
        gameData.frozen = true;
        gameData.invincible = true;
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("task 2");
        eTask2.Raise();
    }

    public void GameOver()
    {
        gameData.frozen = true;
    }
}
