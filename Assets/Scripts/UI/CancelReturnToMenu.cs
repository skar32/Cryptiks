using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CancelReturnToMenu : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    private Slider cancelSlider;
    public CanvasGroup confirmationPopUp;
    public GraphicRaycaster tileGrid;
    public Image blackout;
    public Button backButton;
    private bool pointerDown;

    void Awake()
    {
        cancelSlider = GetComponent<Slider>();
        pointerDown = false;
    }

    void Update()
    {
        if (!pointerDown) {
            if (cancelSlider.value > 0) cancelSlider.value -= 1 * Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData ev) {
        pointerDown = true;
        Debug.Log("Dragging");
    }

    public void OnPointerUp(PointerEventData ev) {
        float currValue = cancelSlider.value;
        if (currValue > .9) {
            confirmationPopUp.interactable = false;
            confirmationPopUp.blocksRaycasts = false;
            StartCoroutine(FadeOut(1f, blackout));
        } else {
            pointerDown = false;
            Debug.Log("Pointer Up!");
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
        backButton.interactable = true;
        tileGrid.enabled = false;
    }
}
