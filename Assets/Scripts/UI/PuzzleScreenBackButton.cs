using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleScreenBackButton : MonoBehaviour
{
    private Button backButton;
    public Animator transition;
    public GraphicRaycaster tileGrid;
    public float transitionTime;
    public Image blackout;
    public CanvasGroup confirmationPopUp, columnsGroup, rowsGroup;

    void Awake()
    {
        backButton = GetComponent<Button>();
    }

    public void OpenMenu()
    {
        tileGrid.enabled = true;
        backButton.interactable = false;
        StartCoroutine(OpenPopUpMenu());
    }

    IEnumerator OpenPopUpMenu()
    {
        StartCoroutine(FadeIn(1.0f, blackout, 0.7f));
        while (confirmationPopUp.alpha < 1.0f)
        {
            confirmationPopUp.alpha = confirmationPopUp.alpha + (Time.deltaTime / 1.0f);
            yield return null;
        }
        confirmationPopUp.interactable = true;
        confirmationPopUp.blocksRaycasts = true;
    }

    public IEnumerator FadeIn(float t, Image fadeIn, float alphaAmount)
    {
        fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, 0);
        while (fadeIn.color.a < alphaAmount)
        {
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, fadeIn.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
