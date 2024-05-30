using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Sprite[] backs, middles, middlebacks, fronts;
    public SpriteRenderer[] backsRenderers, middlesRenderers, middleBacksRenderers, frontsRenderers;

    public GameObject mainBackground;
    public GameObject minigameBackground;
    public GameObject minigame2Background;
    public static BackgroundController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one BackgroundController instance in the scene.");
    }
            private void Start()
    {
        RandomizeBackground();
    }

    public void RandomizeBackground()
    {
        ChooseGraphicForRenderers(backsRenderers, backs);
        ChooseGraphicForRenderers(middlesRenderers, middles);
        ChooseGraphicForRenderers(middleBacksRenderers, middlebacks);
        ChooseGraphicForRenderers(frontsRenderers, fronts);
    }

    private void ChooseGraphicForRenderers(SpriteRenderer[] spriteRenderers, Sprite[] sprites)
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }

    public void SetMainBackgroundActive(bool active)
    {
        if (mainBackground != null)
        {
            mainBackground.SetActive(active);
        }
    }


    public void SetMinigameBackgroundActive(bool active)
    {
        if (minigameBackground != null)
        {
            minigameBackground.SetActive(active);
        }
    }

    public void SetMinigame2BackgroundActive(bool active)
    {
        if (minigame2Background != null)
        {
            minigame2Background.SetActive(active);
        }
    }

}
