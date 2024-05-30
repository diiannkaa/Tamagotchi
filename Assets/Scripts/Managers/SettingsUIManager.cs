using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUIManager : MonoBehaviour
{
    public GameObject settingsPanel; 

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SelectMinigame1()
    {
        PetUIController.instance.SelectMinigame(0);
        CloseSettings(); 
    }

    public void SelectMinigame2()
    {
        PetUIController.instance.SelectMinigame(1);
        CloseSettings(); 
    }
}
