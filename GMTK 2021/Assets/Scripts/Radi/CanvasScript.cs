using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    public TextMeshProUGUI qteText;

    public GameData gameData;
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
}
