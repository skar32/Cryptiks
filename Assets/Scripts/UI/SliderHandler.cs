using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class SliderHandler : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public GameObject currLevel;
    private Slider sliderComponent;
    private bool pointerDown;
    private Animator transition;
    private int stageNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        pointerDown = false;
        sliderComponent = GetComponent<Slider>();
        transition = GameObject.FindWithTag("LevelLoader").transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        if (!pointerDown) {
            if (sliderComponent.value > 0) sliderComponent.value -= 1 * Time.deltaTime;
        }
    }

    public void SetStageNum(int newStageNum)
    {
        stageNumber = newStageNum + 2;
    }

    public void OnPointerDown(PointerEventData ev) {
        pointerDown = true;

        Debug.Log("Dragging");
    }

    public void OnPointerUp(PointerEventData ev) {
        float currValue = sliderComponent.value;
        if (currValue > .9) {
            string selectedStage = currLevel.GetComponent<TMP_Text>().text;

            Debug.Log("Going to " + selectedStage);
            StartCoroutine(LoadLevel(stageNumber));
        } else {
            pointerDown = false;

            Debug.Log("Pointer Up!");
        }
    }

    IEnumerator LoadLevel(int stage)
    {
        yield return new WaitForSeconds(0.3f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(stage);
    }
}
