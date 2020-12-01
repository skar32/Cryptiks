using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelReturnToMenu : MonoBehaviour
{
    private Slider cancelSlider;
    public CanvasGroup confirmationPopUp, columnsGroup, rowsGroup;
    public GraphicRaycaster tileGrid;
    public Image blackout;
    public Button backButton;
    private bool changing = false;

    void Awake()
    {
        cancelSlider = GetComponent<Slider>();
    }

    void Update()
    {
        if (cancelSlider.value == 1.0f && !changing) {
            changing = true;
            confirmationPopUp.interactable = false;
            confirmationPopUp.blocksRaycasts = false;
            StartCoroutine(FadeOut(1f, blackout));
        }
    }

    public IEnumerator FadeOut(float t, Image fadeOut)
    {
        fadeOut.color = new Color(fadeOut.color.r, fadeOut.color.g, fadeOut.color.b, fadeOut.color.a);
        while (fadeOut.color.a > 0.0f || confirmationPopUp.alpha > 0.0f)
        {
            fadeOut.color = new Color(fadeOut.color.r, fadeOut.color.g, fadeOut.color.b, fadeOut.color.a - (Time.deltaTime / t));
            confirmationPopUp.alpha = confirmationPopUp.alpha - (Time.deltaTime / t);
            yield return null;
        }
        cancelSlider.value = 0.0f;
        changing = false;
        backButton.interactable = true;
        tileGrid.enabled = false;
    }
}
