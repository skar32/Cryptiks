using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleSelectionScreenManager : MonoBehaviour
{
    public TMP_Text elementText, arcanaText;
    public GameObject elementsList, arcanaList;
    private GameObject currElement;
    private GameObject currArcana;

    void Update()
    {
        // check what element is currently selected
        foreach (Transform child in elementsList.transform) 
        {
            if (child.transform.localPosition.z < 30) {
                currElement = child.gameObject;
                elementText.text = currElement.tag.ToUpper();
            }
        }
        // check what arcana is currently selected
        foreach (Transform child in arcanaList.transform) 
        {
            if (child.transform.localPosition.z < 30) {
                currArcana = child.gameObject;
               arcanaText.text = "THE " + currArcana.tag.ToUpper();
            }
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeInAndOutAlpha(float t, TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
