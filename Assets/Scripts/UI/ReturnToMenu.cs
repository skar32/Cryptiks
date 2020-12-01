using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public Slider menuSlider, nextPuzzleSlider;
    public string nextLevel;
    public Animator transition;
    public float transitionTime;

    void Update()
    {
        if (menuSlider.value == 1.0f) {
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
}
