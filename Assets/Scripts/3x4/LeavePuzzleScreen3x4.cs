using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LeavePuzzleScreen3x4 : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public Slider targetSlider, otherSlider;
    public string nextLevel;
    public Animator transition;
    public float transitionTime;
    public StageData3x4 stageData3x4;
    private bool pointerDown;

    void Awake()
    {
        pointerDown = false;
    }

    void Update()
    {
        if (!pointerDown) {
            if (targetSlider.value > 0) targetSlider.value -= 1 * Time.deltaTime;
        }
    }

    IEnumerator LoadLevel(string nextLevel)
    {
        yield return new WaitForSeconds(0.3f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextLevel);
    }

    public void OnPointerDown(PointerEventData ev) {
        pointerDown = true;
        Debug.Log("Dragging");
    }

    public void OnPointerUp(PointerEventData ev) {
        float currValue = targetSlider.value;
        if (currValue > .9) {
            targetSlider.interactable = false;
            otherSlider.interactable = false;
            stageData3x4.SaveData();
            StartCoroutine(LoadLevel(nextLevel));
        } else {
            pointerDown = false;
            Debug.Log("Pointer Up!");
        }
    }
}
