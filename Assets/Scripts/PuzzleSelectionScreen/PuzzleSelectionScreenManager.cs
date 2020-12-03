using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DanielLochner.Assets.SimpleScrollSnap;

public class PuzzleSelectionScreenManager : MonoBehaviour
{
    public TMP_Text elementText, arcanaText;
    public GameObject elementsList, airArcanaList, fireArcanaList, waterArcanaList, earthArcanaList, readingsArcanaList;
    public GameObject stageLocations;
    public GameObject stagePrefab;
    public SimpleScrollSnap elementScroller, arcanaScroller;
    public SimpleScrollSnap[] arcanaScrollers;
    public static int currElementNumber = 0, currArcanaNumber = 0;
    private GameObject currArcanaList;
    private GameObject currElement;
    private GameObject currArcana;
    private string currElementSelected, currArcanaSelected;
    private string lastElementSelected, lastArcanaSelected;

    private string[][] airStageList =
    {
        new string[] { "Justice1", "Justice2", "Justice3", "Justice4", "" },
        new string[] { "Wheel1", "Wheel2", "Wheel3", "Wheel4", "Wheel5" }
    };

    private string[][] fireStageList = 
    {
        new string[] { "Hanged1", "Hanged2", "Hanged3", "Hanged4", "" },
        new string[] { "Devil1", "Devil2", "Devil3", "Devil4", "Devil5" }
    };

    private string[][] waterStageList =
    {
        new string[] { "Star1", "Star2", "Star3", "Star4", "" },
        new string[] { "World1", "World2", "World3", "World4", "World5" }
    };

    private string[][] earthStageList =
    {
        new string[] { "Moon1", "Moon2", "Moon3", "Moon4", "" },
        new string[] { "Sun1", "Sun2", "Sun3", "Sun4", "Sun5" }
    };

    private string[][] readingsStageList =
    {
        new string[] { "Lorem1", "Lorem2", "Lorem3", "Lorem4", "" },
        new string[] { "Ipsum1", "Ipsum2", "Ipsum3", "Ipsum4", "Ipsum5" }
    };

    void Start()
    {
        lastElementSelected = "Air";
        lastArcanaSelected = "Justice";
        currArcanaList = airArcanaList;
        elementScroller.GoToPanel(currElementNumber);
        arcanaScroller.GoToPanel(currArcanaNumber);
        removeStages();
        generateStages(0, 0);
    }

    void Update()
    {
        Debug.Log(currArcanaNumber);
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
                currElementNumber = 0;
                arcanaScroller = arcanaScrollers[0];
                // Switch the Arcana lists to Air
                currArcanaList = airArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(true);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(false);
                readingsArcanaList.transform.parent.parent.gameObject.SetActive(false);
                break;
            case "Fire":
                Debug.Log("Fire is selected!");
                currElementNumber = 1;
                arcanaScroller = arcanaScrollers[1];
                // Switch the Arcana lists to Fire
                currArcanaList = fireArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(true);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(false);
                readingsArcanaList.transform.parent.parent.gameObject.SetActive(false);
                break;
            case "Water":
                Debug.Log("Water is selected!");
                currElementNumber = 2;
                arcanaScroller = arcanaScrollers[2];
                // Switch the Arcana lists to Water
                currArcanaList = waterArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(true);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(false);
                readingsArcanaList.transform.parent.parent.gameObject.SetActive(false);
                break;
            case "Earth":
                Debug.Log("Earth is selected!");
                currElementNumber = 3;
                arcanaScroller = arcanaScrollers[3];
                // Switch the Arcana lists to Earth
                currArcanaList = earthArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(true);
                readingsArcanaList.transform.parent.parent.gameObject.SetActive(false);
                break;
            case "Readings":
                Debug.Log("Readings is selected!");
                currElementNumber = 4;
                arcanaScroller = arcanaScrollers[4];
                // Switch the Arcana lists to Readings
                currArcanaList = readingsArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(false);
                readingsArcanaList.transform.parent.parent.gameObject.SetActive(true);
                break;
            default:
                Debug.Log("Bro what");
                break;
        }
    }

    void changeArcana(string newArcana, string currElementText) {
        lastArcanaSelected = newArcana;
        removeStages();

        switch (currElementText) {
            case "Air":
                switch (newArcana) {
                    case "Justice":
                        Debug.Log("Justice is selected!");
                        currArcanaNumber = 0;
                        generateStages(0, currArcanaNumber);
                        break;
                    case "Wheel of Fortune":
                        currArcanaNumber = 1;
                        Debug.Log("Wheel of Fortune is selected!");
                        generateStages(0, currArcanaNumber);
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
                        currArcanaNumber = 0;
                        generateStages(1, currArcanaNumber);
                        break;
                    case "Devil":
                        Debug.Log("Devil is selected!");
                        currArcanaNumber = 1;
                        generateStages(1, currArcanaNumber);
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
                        currArcanaNumber = 0;
                        generateStages(2, currArcanaNumber);
                        break;
                    case "World":
                        Debug.Log("World is selected!");
                        currArcanaNumber = 1;
                        generateStages(2, currArcanaNumber);
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
                        currArcanaNumber = 0;
                        generateStages(3, currArcanaNumber);
                        break;
                    case "Sun":
                        Debug.Log("Sun is selected!");
                        currArcanaNumber = 1;
                        generateStages(3, currArcanaNumber);
                        break;
                    default:
                        Debug.Log("You got " + newArcana + " in " + currElementText);
                        break;
                }
                break;
            case "Readings":
                // do stuff if Readings element is selected
                break;
            default:
                Debug.Log("bruh what");
                break;
        }    
    }

    void removeStages() {
        foreach (Transform child in stageLocations.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    void generateStages(int elementNo, int arcanaNo) {
        string[] stageList;
        switch (elementNo) {
            case 0:
                stageList = airStageList[arcanaNo];
                break;
            case 1:
                stageList = fireStageList[arcanaNo];
                break;
            case 2:
                stageList = waterStageList[arcanaNo];
                break;
            case 3:
                stageList = earthStageList[arcanaNo];
                break;
            default:
                Debug.Log("Probably in Readings");
                stageList = new string[] {""};
                break;
        }
        int numStages = 0;
        foreach (string stage in stageList) {
            if (stage.Length == 0) {
                break;
            }
            numStages++;

            GameObject newStage = Instantiate(stagePrefab, stageLocations.transform);

            TMP_Text stageTextComponent = getTextComponent(newStage);

            if (stageTextComponent) {
                stageTextComponent.text = stage;
            } else {
                Debug.Log("Yo prefabs are broken");
            }
        }
        int bottomHeight = 728 - numStages * 240;
        RectTransform rt = stageLocations.GetComponent<RectTransform>();

        if (bottomHeight < 0) {
            rt.offsetMin = new Vector2(rt.offsetMin.x, bottomHeight);
        } else {
            rt.offsetMin = new Vector2(rt.offsetMin.x, 0);
        }
    }

    TMP_Text getTextComponent(GameObject stage) {
        foreach (Transform t in stage.transform) {
            if (t.tag == "Title") {
                return t.GetComponent<TMP_Text>();
            }
        }

        return null;
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
