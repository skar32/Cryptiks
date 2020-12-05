using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToPuzzle : MonoBehaviour
{
    public Slider targetSlider;
    public Slider[] otherSliders;
    public string nextLevel;
    public Animator transition;
    public float transitionTime;

    void Update()
    {
        if (targetSlider.value == 1.0f) {
            targetSlider.interactable = false;
            foreach (Slider otherSlider in otherSliders) {
                otherSlider.interactable = false;
            }
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
