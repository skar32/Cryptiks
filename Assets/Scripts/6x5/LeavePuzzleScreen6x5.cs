using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LeavePuzzleScreen6x5 : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public Slider targetSlider, otherSlider;
    public string nextLevel;
    public Animator transition;
    public float transitionTime;
    public StageData6x5 stageData6x5;
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
            stageData6x5.SaveData();
            StartCoroutine(LoadLevel(nextLevel));
        } else {
            pointerDown = false;
            Debug.Log("Pointer Up!");
        }
    }
}
