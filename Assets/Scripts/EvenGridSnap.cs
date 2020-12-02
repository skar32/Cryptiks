using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvenGridSnap : MonoBehaviour
{
    public float panelLength;
    public void SnapAfterScrollY(bool scrollUp)
    {
        //Debug.Log(scrollUp);
        Vector2 targetPos = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
        float yPos = GetComponent<RectTransform>().anchoredPosition.y;
        float newYPos = GetComponent<RectTransform>().anchoredPosition.y;
        if (scrollUp) {
            newYPos = Mathf.RoundToInt((GetComponent<RectTransform>().anchoredPosition.y / panelLength)) * panelLength;
        } else {
            newYPos = Mathf.RoundToInt((GetComponent<RectTransform>().anchoredPosition.y / panelLength)) * panelLength;
        }
        //Debug.Log(newYPos);
        targetPos = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, newYPos);
        StartCoroutine(Snap(targetPos));
    }

    public void SnapAfterScrollX(bool scrollRight)
    {
        Vector2 targetPos = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, GetComponent<RectTransform>().anchoredPosition.y);
        float xPos = GetComponent<RectTransform>().anchoredPosition.x;
        float newXPos = GetComponent<RectTransform>().anchoredPosition.x;
        if (scrollRight) {
            newXPos = Mathf.RoundToInt((GetComponent<RectTransform>().anchoredPosition.x / panelLength)) * panelLength;
        } else {
            newXPos = Mathf.RoundToInt((GetComponent<RectTransform>().anchoredPosition.x / panelLength)) * panelLength;
        }
        //Debug.Log(newXPos);
        targetPos = new Vector2(newXPos, GetComponent<RectTransform>().anchoredPosition.y);
        StartCoroutine(Snap(targetPos));
    }

    IEnumerator Snap(Vector2 targetPos)
    {
        float step = 0;
        while (step < 1) {
            GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(GetComponent<RectTransform>().anchoredPosition, targetPos, step += Time.deltaTime);
            yield return null;
        }
    }
}
