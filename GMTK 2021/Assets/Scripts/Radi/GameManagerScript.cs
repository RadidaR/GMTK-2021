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
    public InputData inputData;

    public GameObject tutorialScreen;
    public Image tutorialPanel;
    public TextMeshProUGUI tutorialText;

    public GameObject taskScreen;
    public TextMeshProUGUI taskText;

    public GameEvent eTask1;
    public GameEvent eTask1Completed;
    public GameEvent eTask2;
    public GameEvent eTask2Completed;

    public GameObject target;
    public GameObject key;
    public List<Transform> taskPositions;

    public CinemachineVirtualCamera task1Cam;
    public CinemachineVirtualCamera keyCam;
    public CinemachineVirtualCamera fireCam;
    public CinemachineVirtualCamera gateCam;

    void Start()
    {
        StartCoroutine(Tutorial());
    }

    void ShowTutorialScreen()
    {
        if (!tutorialScreen.activeInHierarchy)
        {
            tutorialScreen.SetActive(true);
        }

        if (tutorialPanel.color.a < 1)
        {
            Color visible = tutorialPanel.color;
            visible.a += Time.deltaTime;
            tutorialPanel.color = visible;

            ShowTutorialScreen();
            return;
        }
    }

    void HideTutorialScreen()
    {

        if (tutorialPanel.color.a > 0)
        {
            Color visible = tutorialPanel.color;
            visible.a -= Time.deltaTime;
            tutorialPanel.color = visible;
            HideTutorialScreen();
            return;
        }
        else
        {
            tutorialScreen.SetActive(false);
        }

    }
    IEnumerator Tutorial()
    {
        //////////////////////////////////////////////                  We are the tribe’s only hope of victory!
        //tutorialScreen.SetActive(true);

        ShowTutorialScreen();
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

            ///////////////////////////////////////////////                 Use arrow keys or WASD to move. Try not to bump into anything!

            tutorialText.text = tutorial.text2;

            gameData.frozen = false;
            gameData.invincible = false;

            timer = tutorial.mediumTime;

            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                timer -= Time.deltaTime;
                if (inputData.horizontalInput != 0 || inputData.verticalInput != 0)
                {
                    HideTutorialScreen();
                }
            }
            //tutorialScreen.SetActive(false);

            /////////////////////////////////////////////                   Press G to switch to the other goblin for a better view.
            tutorialText.text = tutorial.text3;
            yield return new WaitForSecondsRealtime(tutorial.shortTime);

            ShowTutorialScreen();

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

            //////////////////////////////////////////                      Complete the sequence to switch. Quick, you don’t have all day!
            tutorialText.text = tutorial.text4;

            timer = tutorial.mediumTime;

            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                timer -= Time.deltaTime;

                if (!gameData.quickTimeEvent)
                {
                    HideTutorialScreen();
                    break;
                }
                else if (timer < 0)
                {
                    ////////////////////////////////////////////            You can cancel the switch by pressing ENTER.
                    tutorialText.text = tutorial.text5;
                    break;
                }
            }

            bool backOut = false;
            if (tutorialText.text == tutorial.text5)
            {
                timer = tutorial.mediumTime;

                while (timer > 0)
                {
                    yield return new WaitForSecondsRealtime(Time.deltaTime);
                    timer -= Time.deltaTime;

                    if (inputData.enterInput != 0)
                    {
                        backOut = true;
                        HideTutorialScreen();
                        break;
                    }
                    else if (!gameData.quickTimeEvent)
                    {
                        HideTutorialScreen();
                        break;
                    }
                }
            }

            yield return new WaitForSecondsRealtime(tutorial.shortTime);
            
            if (backOut)
            {
                //////////////////////////////////////                             Press G and complete the sequence to switch goblins.
                tutorialText.text = tutorial.text6;
            }

            ShowTutorialScreen();
            
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

            ////////////////////////////////////////                     You can see much better from here!
            tutorialText.text = tutorial.text7;
            ShowTutorialScreen();

            yield return new WaitForSecondsRealtime(tutorial.shortTime);

            //////////////////////////////////////////                      You can also click on things you want to avoid to mark them!
            tutorialText.text = tutorial.text8;


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
            ////////////////////////////////////                        Marks remain visible for a while, even if you switch to the other goblin.
            tutorialText.text = tutorial.text9;

            yield return new WaitForSecondsRealtime(tutorial.mediumTime);
            
        }

        gameData.frozen = false;
        HideTutorialScreen();

        eTask1.Raise();

        

    }

    public void StartTask1()
    {
        StartCoroutine(Task1());
    }

    IEnumerator Task1()
    {
        target.transform.position = taskPositions[0].position;

        gameData.frozen = true;
        gameData.invincible = true;

        taskText.text = tutorial.task1Text1;
        taskScreen.SetActive(true);

        task1Cam.Priority = 100;

        yield return new WaitForSecondsRealtime(tutorial.shortTime);
        taskText.text = tutorial.task1Text2;
        yield return new WaitForSecondsRealtime(tutorial.shortTime);

        task1Cam.Priority = -100;

        yield return new WaitForSecondsRealtime(tutorial.shortTime);

        taskScreen.SetActive(false);
        gameData.frozen = false;

        yield return new WaitForSecondsRealtime(1);
        gameData.invincible = false;

        float timer = 60;
        while (timer > 0)
        {
            //Debug.Log(timer.ToString());
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

        key.SetActive(true);
        gameData.frozen = true;
        gameData.invincible = true;
        taskText.text = tutorial.task1Text3;
        taskScreen.SetActive(true);

        keyCam.Priority = 100;

        yield return new WaitForSecondsRealtime(tutorial.mediumTime);


        //gameData.frozen = false;
        //gameData.invincible = false;
        //taskScreen.SetActive(false);

        eTask2.Raise();
    }

    public void StartTask2()
    {
        StartCoroutine(Task2());
    }

    IEnumerator Task2()
    {
        taskText.text = tutorial.task2Text1;
        taskScreen.SetActive(true);

        yield return new WaitForSecondsRealtime(tutorial.shortTime);
        keyCam.Priority = -100;

        fireCam.Priority = 100;
        taskText.text = tutorial.task2Text2;
        target.transform.position = taskPositions[1].position;

        yield return new WaitForSecondsRealtime(tutorial.mediumTime);
        fireCam.Priority = -100;
        yield return new WaitForSecondsRealtime(tutorial.shortTime);
        gameData.frozen = false;
        taskScreen.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        gameData.invincible = false;




    }

        public void GameOver()
    {
        gameData.frozen = true;
    }
}
