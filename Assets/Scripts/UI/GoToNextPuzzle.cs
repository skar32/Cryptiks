using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GoToNextPuzzle : MonoBehaviour
{
    public Slider menuSlider, nextPuzzleSlider;
    public string nextLevel;
    public Animator transition;
    public float transitionTime;
    private bool pointerDown;

    void Update()
    {
        if (nextPuzzleSlider.value == 1.0f) {
            menuSlider.interactable = false;
            nextPuzzleSlider.interactable = false;
            StartCoroutine(LoadLevel(nextLevel));
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
}
