using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SliderHandler : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public GameObject currLevel;
    private Slider sliderComponent;
    private bool pointerDown;
    // Start is called before the first frame update
    void Start()
    {
        pointerDown = false;
        sliderComponent = GetComponent<Slider>();
    }

    void Update()
    {
        if (!pointerDown) {
            if (sliderComponent.value > 0) sliderComponent.value -= 1 * Time.deltaTime;
        }
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
            // @Soham: Switch to the selected stage
        } else {
            pointerDown = false;

            Debug.Log("Pointer Up!");
        }
    }
}
