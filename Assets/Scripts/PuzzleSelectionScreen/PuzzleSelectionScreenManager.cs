using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleSelectionScreenManager : MonoBehaviour
{
    public TMP_Text elementText, arcanaText;
    public GameObject elementsList, airArcanaList, fireArcanaList, waterArcanaList, earthArcanaList;
    private GameObject currArcanaList;
    private GameObject currElement;
    private GameObject currArcana;
    private string currElementSelected, currArcanaSelected;
    private string lastElementSelected, lastArcanaSelected;

    void Awake()
    {
        lastElementSelected = "Air";
        lastArcanaSelected = "Justice";
        currArcanaList = airArcanaList;
    }

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

        // If the element isn't the same, do some updates
        if (lastElementSelected != currElementSelected) {
            changeElement(currElementSelected);
        }

        // check what arcana is currently selected
        foreach (Transform child in currArcanaList.transform) 
        {
            if (child.transform.localPosition.z < 30) {
                currArcana = child.gameObject;
                currArcanaSelected = currArcana.gameObject.tag;
               arcanaText.text = currArcana.tag.ToUpper();
            }
        }

        // If the arcana isn't the same, do some updates
        if (lastArcanaSelected != currArcanaSelected) {
            changeArcana(currArcanaSelected, currElementSelected);
        }
        
    }

    void changeElement(string newElement) {
        lastElementSelected = newElement;
        switch (newElement) {
            case "Air":
                Debug.Log("Air is selected!");
                // Switch the Arcana lists to Air
                currArcanaList = airArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(true);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(false);
                break;
            case "Fire":
                Debug.Log("Fire is selected!");
                // Switch the Arcana lists to Fire
                currArcanaList = fireArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(true);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(false);
                break;
            case "Water":
                Debug.Log("Water is selected!");
                // Switch the Arcana lists to Water
                currArcanaList = waterArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(true);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(false);
                break;
            case "Earth":
                Debug.Log("Earth is selected!");
                // Switch the Arcana lists to Earth
                currArcanaList = earthArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Bro what");
                break;
        }
    }

    void changeArcana(string newArcana, string currElementText) {
        lastArcanaSelected = newArcana;

        switch (currElementText) {
            case "Air":
                switch (newArcana) {
                    case "Justice":
                        Debug.Log("Justice is selected!");
                        // do stuff if Justice arcana is selected
                        break;
                    case "Wheel of Fortune":
                        Debug.Log("Wheel of Fortune is selected!");
                        // do stuff if Wheel of Fortune arcana is selected
                        break;
                    default:
                        Debug.Log("You got " + newArcana + " in " + currElementText);
                        break;
                }
                break;
            case "Fire":
                 switch (newArcana) {
                    case "Hanged Man":
                        Debug.Log("Hanged Man is selected!");
                        // do stuff if Justice arcana is selected
                        break;
                    case "Devil":
                        Debug.Log("Devil is selected!");
                        // do stuff if Wheel of Fortune arcana is selected
                        break;
                    default:
                        Debug.Log("You got " + newArcana + " in " + currElementText);
                        break;
                }
                break;
            case "Water":
                 switch (newArcana) {
                    case "Star":
                        Debug.Log("Star is selected!");
                        // do stuff if Justice arcana is selected
                        break;
                    case "World":
                        Debug.Log("World is selected!");
                        // do stuff if Wheel of Fortune arcana is selected
                        break;
                    default:
                        Debug.Log("You got " + newArcana + " in " + currElementText);
                        break;
                }
                break;
            case "Earth":
                switch (newArcana) {
                    case "Moon":
                        Debug.Log("Moon is selected!");
                        // do stuff if Justice arcana is selected
                        break;
                    case "Sun":
                        Debug.Log("Sun is selected!");
                        // do stuff if Wheel of Fortune arcana is selected
                        break;
                    default:
                        Debug.Log("You got " + newArcana + " in " + currElementText);
                        break;
                }
                break;
            default:
                Debug.Log("bruh what");
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
