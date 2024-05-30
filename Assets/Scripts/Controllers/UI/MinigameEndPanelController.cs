using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameEndPanelController : MonoBehaviour
{
    public TextMeshProUGUI resultText, titleText;

    public void Initialize(int score, float timeRemaining, bool victory)

    {

        resultText.text =
           string.Format("You obtained {0} points, and had {1} seconds left", score, timeRemaining);
        titleText.text = victory ? "You won!<3" : "You lost!:(";

    }

    private void OnDisable()
    {
        if (MinigameUIController.instance != null && MinigameUIController.instance.minigamePetController != null)
        {
            MinigameUIController.instance.minigamePetController.enabled = false;
        }
        gameObject.SetActive(false);
    }

}
