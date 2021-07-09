using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI qteText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI victoryText;

    public GameObject endGameScreen;
    public GameObject buttons;

    public Image endGameBackground;

    public GameData gameData;

    ActionMap inputAction;
    public bool paused = false;
    public GameObject pauseMenu;

    public GameObject[] lives;

    private void Awake()
    {
        inputAction = new ActionMap();

        inputAction.Gameplay.Escape.performed += ctx => PauseUnpause();
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    public void UpdateLives()
    {
        for (int i = 0; i < gameData.currentLife; i++)
        {
            lives[i].SetActive(true);
        }

        for (int i = gameData.startingLife; i > gameData.currentLife - 1; i--)
        {
            lives[i - 1].SetActive(false);
        }
    }

    public void PauseUnpause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            paused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }

    public void LoadScene(int scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }

    void Update()
    {
        if (gameData.quickTimeEvent)
        {
            qteText.gameObject.SetActive(true);
            ControlScript control = FindObjectOfType<ControlScript>();
            if (control.qteButtons.Count >= 3)
            {
                qteText.text = control.qteButtons[0] + "     " + control.qteButtons[1] + "     " + control.qteButtons[2];
            }
            else if (control.qteButtons.Count == 2)
            {
                qteText.text = control.qteButtons[0] + "     " + control.qteButtons[1];
            }
            if (control.qteButtons.Count == 1)
            {
                qteText.text = control.qteButtons[0];
            }
        }
        else
        {
            qteText.gameObject.SetActive(false);

        }
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCo());
    }

    IEnumerator GameOverCo()
    {
        yield return new WaitForSecondsRealtime(1);

        endGameScreen.SetActive(true);

        float count = 0;

        while (count <= 1)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime / 2);
            count += Time.deltaTime / 2;

            Color increaseBackgroundAlpha = endGameBackground.color;
            increaseBackgroundAlpha.a += Time.deltaTime / 2;
            endGameBackground.color = increaseBackgroundAlpha;

            Color increaseTextAlpha = gameOverText.color;
            increaseTextAlpha.a += Time.deltaTime / 2;
            gameOverText.color = increaseTextAlpha;


            if (count > 1)
            {
                Time.timeScale = 0;
                break;
            }
        }

        buttons.SetActive(true);
    }

    public void Victory()
    {
        StartCoroutine(VictoryCo());
    }

    IEnumerator VictoryCo()
    {
        yield return new WaitForSecondsRealtime(1);

        endGameScreen.SetActive(true);

        float count = 0;

        while (count <= 1)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime / 2);
            count += Time.deltaTime / 2;

            Color increaseBackgroundAlpha = endGameBackground.color;
            increaseBackgroundAlpha.a += Time.deltaTime / 2;
            endGameBackground.color = increaseBackgroundAlpha;

            Color increaseTextAlpha = victoryText.color;
            increaseTextAlpha.a += Time.deltaTime / 2;
            victoryText.color = increaseTextAlpha;


            if (count > 1)
            {
                Time.timeScale = 0;
                break;
            }
        }

        buttons.SetActive(true);
    }


}
