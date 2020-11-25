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
    private string currElementSelected, currArcanaSelected;

    void Update()
    {
        // check what element is currently selected
        foreach (Transform child in elementsList.transform) 
        {
            if (child.transform.localPosition.z < 30) {
                currElement = child.gameObject;
                currElementSelected = currElement.gameObject.tag;
                elementText.text = currElement.tag.ToUpper();
            }
        }
        // check what arcana is currently selected
        foreach (Transform child in arcanaList.transform) 
        {
            if (child.transform.localPosition.z < 30) {
                currArcana = child.gameObject;
                currArcanaSelected = currArcana.gameObject.tag;
               arcanaText.text = "THE " + currArcana.tag.ToUpper();
            }
        }

        // do stuff depending on current element and current arcana selected
        switch (currElementSelected) {
            case "Air":
                Debug.Log("Air is selected!");
                // do stuff if Air element is selected
                break;
            case "Fire":
                Debug.Log("Fire is selected!");
                // do stuff if Fire element is selected
                break;
            case "Water":
                Debug.Log("Water is selected!");
                // do stuff if Water element is selected
                break;
            case "Earth":
                Debug.Log("Earth is selected!");
                // do stuff if Earth element is selected
                break;
            case "Readings":
                Debug.Log("Readings is selected!");
                // do stuff if Readings is selected
                break;
        }
        switch (currArcanaSelected) {
            case "Justice":
                Debug.Log("Justice is selected!");
                // do stuff if Justice arcana is selected
                break;
            case "Wheel of Fortune":
                Debug.Log("Wheel of Fortune is selected!");
                // do stuff if Wheel of Fortune arcana is selected
                break;
            case "Hanged Man":
                Debug.Log("Hanged Man is selected!");
                // do stuff if Hanged Man arcana is selected
                break;
            case "Devil":
                Debug.Log("Devil is selected!");
                // do stuff if Devil arcana is selected
                break;
            case "Moon":
                Debug.Log("Moon is selected!");
                // do stuff if Moon arcana is selected
                break;
            case "Sun":
                Debug.Log("Sun is selected!");
                // do stuff if Sun arcana is selected
                break;
            case "Star":
                Debug.Log("Star is selected!");
                // do stuff if Star arcana is selected
                break;
            case "World":
                Debug.Log("World is selected!");
                // do stuff if World arcana is selected
                break;
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
