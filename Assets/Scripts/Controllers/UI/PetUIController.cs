using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImage, happinessImage, energyImage;
    public GameObject minigamePrefab, minigame;
    public GameObject[] minigamePrefabs;
    public static PetUIController instance;
    public SettingsUIManager settingsUI; // Ссылка на SettingsUI
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in the Scene");
    }

    public void SelectMinigame(int index)
    {
        if (index >= 0 && index < minigamePrefabs.Length)
        {
            minigamePrefab = minigamePrefabs[index];
            GameData.SelectedMinigamePrefab = minigamePrefab; // Сохранение выбранного префаба
        }
        else
        {
            Debug.LogWarning("Invalid minigame index");
        }
    }

    public void OpenSettings()
    {
        settingsUI.OpenSettings();
    }
    public void UpdateImages(int food, int happiness, int energy)
    {
        foodImage.fillAmount = (float)food / 100;
        happinessImage.fillAmount = (float)happiness / 100;
        energyImage.fillAmount = (float)energy / 100;
    }
}
