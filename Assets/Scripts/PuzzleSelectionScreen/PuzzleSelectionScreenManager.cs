using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DanielLochner.Assets.SimpleScrollSnap;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class PuzzleSelectionScreenManager : MonoBehaviour
{
    public TMP_Text elementText, arcanaText;
    public GameObject elementsList, airArcanaList, fireArcanaList, waterArcanaList, earthArcanaList, readingsArcanaList;
    public GameObject stageLocations;
    public GameObject stagePrefab;
    public SimpleScrollSnap elementScroller, arcanaScroller;
    public SimpleScrollSnap[] arcanaScrollers;
    public static int currElementNumber = 0, currArcanaNumber = 0, currArcanaScroller = 4;
    private GameObject currArcanaList;
    private GameObject currElement;
    private GameObject currArcana;
    private string currElementSelected, currArcanaSelected;
    private string lastElementSelected, lastArcanaSelected;
    private PuzzleGameHandler gameHandler;

    private string[] airArcana =
    {
        "Justice", "Star"
    };

    private string[] waterArcana =
    {
        "Chariot", "Hanged_Man"
    };

    private string[] earthArcana =
    {
        "Devil", "World"
    };

    private string[] fireArcana =
    {
        "Sun", "Fortune"
    };

    private string[] readingsArcana =
    {
        "Readings"
    };

    // Keep in mind that the length of the each list needs to be the same (fill in empty ones with "")
    private string[][] airStageList =
    {
        new string[] { "The Search", "The Weapon", "The Task", "The Cause", "The Guide" },
        new string[] { "Oppose Doubt", "Light", "Endure", "Revival", "Celestial Connection" }
    };

    private string[][] waterStageList =
    {
        new string[] { "Ever Forward", "In Balance", "Step Up", "Blinders On", "Dual Sides" },
        new string[] { "Patience", "Martyr", "Old Habits Die Hard", "A Different View", "Counterintuitive" }
    };

    private string[][] earthStageList =
    {
        new string[] { "Lost", "Controlled", "Succumb", "Hollow", "You Hold the Key" },
        new string[] { "Wrapping Up", "Ouroboros", "Appreciation", "Whole", "Nirvana" }
    };

    private string[][] fireStageList = 
    {
        new string[] { "Perpetual Light", "Positive", "Moment in the Sun", "Shine", "Comfortable Temperature" },
        new string[] { "Harbinger", "Gamble", "Seeming Contradiction", "Karma", "(Mis)Fortune" }
    };

    private string[][] readingsStageList =
    {
        new string[] { "Columns", "Rows", "Read", "Begin"},
    };

    void Awake()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").gameObject.GetComponent<PuzzleGameHandler>();
        gameHandler.Save();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameHandler.Load();
        arcanaScroller = arcanaScrollers[currArcanaScroller];
        InitializeScreen(currElementNumber, currArcanaNumber);

        switch (currElementNumber) {
        case 0:
            currElementSelected = "Readings";
            break;
        case 1:
            currElementSelected = "Air";
            break;
        case 2:
            currElementSelected = "Water";
            break;
        case 3:
            currElementSelected = "Earth";
            break;
        case 4:
            currElementSelected = "Fire";
            break;
        default:
            break;
        }
        changeElement(currElementSelected);

        elementScroller.GoToPanel(currElementNumber);
        arcanaScrollers[currArcanaScroller].GoToPanel(currArcanaNumber);
        removeStages();
        generateStages(currElementNumber, currArcanaNumber);
        checkIcons();
    }

    void Start()
    {
        Debug.Log("currElementNumber: " + currElementNumber);
        Debug.Log("currArcanaNumber: " + currArcanaNumber);
        Debug.Log("currArcanaScrollerNumber: " + currArcanaScroller);

        arcanaScroller = arcanaScrollers[currArcanaScroller];
        InitializeScreen(currElementNumber, currArcanaNumber);

        switch (currElementNumber) {
            case 0:
                currElementSelected = "Readings";
                break;
            case 1:
                currElementSelected = "Air";
                break;
            case 2:
                currElementSelected = "Water";
                break;
            case 3:
                currElementSelected = "Earth";
                break;
            case 4:
                currElementSelected = "Fire";
                break;
            default:
                break;
        }
        changeElement(currElementSelected);

        Debug.Log("currArcanaScrollerSelected: " + arcanaScroller.name);

        elementScroller.GoToPanel(currElementNumber);
        arcanaScrollers[currArcanaScroller].GoToPanel(currArcanaNumber);
        removeStages();
        generateStages(currElementNumber, currArcanaNumber);
        checkIcons();
        // generateStages(0, 0);
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void InitializeScreen(int elementNo, int arcanaNo)
    {
        switch (elementNo) {
            case 0:
                lastElementSelected = "Readings";
                lastArcanaSelected = "Readings";
                currArcanaList = readingsArcanaList;
                break;
            case 1:
                lastElementSelected = "Air";
                currArcanaList = airArcanaList;
                lastArcanaSelected = airArcana[arcanaNo];
                break;
            case 2:
                lastElementSelected = "Water";
                currArcanaList = waterArcanaList;
                lastArcanaSelected = waterArcana[arcanaNo];
                break;
            case 3:
                lastElementSelected = "Earth";
                currArcanaList = earthArcanaList;
                lastArcanaSelected = earthArcana[arcanaNo];
                break;
            case 4:
                lastElementSelected = "Fire";
                currArcanaList = fireArcanaList;
                lastArcanaSelected = fireArcana[arcanaNo];
                break;
            default:
                Debug.Log("bruh what");
                lastElementSelected = "Readings";
                currArcanaList = readingsArcanaList;
                lastArcanaSelected = "Readings";
                break;
        }
    }

    void checkIcons()
    {
        int numStages = gameHandler.stages.stages.Length;

        string imagePath = "Art/Element_Icons/";
        string arcanaPath = "Art/Arcana_Icons/";
        string[] elements = new string[] { "Air", "Water", "Earth", "Fire" };
        GameObject thisArcanaList = readingsArcanaList;
        GameObject[] theseArcanaLists = new GameObject[] { airArcanaList, waterArcanaList, earthArcanaList, fireArcanaList };
        string[][] thisArcanaNames = new string[][] { airArcana, waterArcana, earthArcana, fireArcana };

        bool isComplete = true;
        for (var i = 0; i < 4; i++)
        {
            if (gameHandler.stages.stages[i].state != 3) {
                isComplete = false;
                break;
            }
        }

        string currPath = imagePath;
        string currArcanaPath = arcanaPath;

        if (isComplete) {
            currPath += "ElementsOn/Reading_On_Circle";
            currArcanaPath += "Readings/Card_ReadingComplete";
        } else {
            currPath += "ElementsOff/Reading_Off_Circle";
            currArcanaPath += "Readings/Card_ReadingIncomplete";
        }

        elementsList.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(currPath);
        thisArcanaList.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(currArcanaPath);

        bool isComplete2 = true;
        for (var j = 0; j < (long)Mathf.Floor(numStages/10); j++)
        {
            string[] currList = thisArcanaNames[j];
            isComplete = true;
            isComplete2 = true;
            for (var i = 4; i < 9; i++)
            {
                if (gameHandler.stages.stages[i + j*10].state != 3) {
                    isComplete = false;
                    break;
                }
            }

            currArcanaPath = arcanaPath;

            if (isComplete) {
                currArcanaPath += currList[0] + "/Card_" + currList[0] + "Complete";
            } else {
                currArcanaPath += currList[0] + "/Card_" + currList[0] + "Incomplete";
            }

            theseArcanaLists[j].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(currArcanaPath);

            for (var i = 9; i < 14; i++)
            {
                if (gameHandler.stages.stages[i + j*10].state != 3) {
                    isComplete2 = false;
                    break;
                }
            }

            currArcanaPath = arcanaPath;

            if (isComplete2) {
                currArcanaPath += currList[1] + "/Card_" + currList[1] + "Complete";
            } else {
                currArcanaPath += currList[1] + "/Card_" + currList[1] + "Incomplete";
            }

            theseArcanaLists[j].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(currArcanaPath);

            currPath = imagePath;

            if (isComplete && isComplete2) {
                currPath += "ElementsOn/" + elements[j] + "_On_Circle";
            } else {
                currPath += "ElementsOff/" + elements[j] + "_Off_Circle";
            }
            elementsList.transform.GetChild(j+1).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(currPath);
        }
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
            case "Readings":
                Debug.Log("Readings is selected!");
                currElementNumber = 0;
                arcanaScroller = arcanaScrollers[4];
                currArcanaScroller = 4;
                // Switch the Arcana lists to Readings
                currArcanaList = readingsArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(false);
                readingsArcanaList.transform.parent.parent.gameObject.SetActive(true);
                break;
            case "Air":
                Debug.Log("Air is selected!");
                currElementNumber = 1;
                arcanaScroller = arcanaScrollers[0];
                currArcanaScroller = 0;
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
                currElementNumber = 4;
                arcanaScroller = arcanaScrollers[1];
                currArcanaScroller = 1;
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
                currArcanaScroller = 2;
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
                currArcanaScroller = 3;
                // Switch the Arcana lists to Earth
                currArcanaList = earthArcanaList;
                airArcanaList.transform.parent.parent.gameObject.SetActive(false);
                fireArcanaList.transform.parent.parent.gameObject.SetActive(false);
                waterArcanaList.transform.parent.parent.gameObject.SetActive(false);
                earthArcanaList.transform.parent.parent.gameObject.SetActive(true);
                readingsArcanaList.transform.parent.parent.gameObject.SetActive(false);
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
            case "Readings":
                // do stuff if Readings element is selected
                Debug.Log("Readings is selected!");
                currArcanaNumber = 0;
                generateStages(0, currArcanaNumber);
                break;
            case "Air":
                switch (newArcana) {
                    case "Justice":
                        Debug.Log("Justice is selected!");
                        currArcanaNumber = 0;
                        generateStages(1, currArcanaNumber);
                        break;
                    case "The Star":
                        currArcanaNumber = 1;
                        Debug.Log("Star is selected!");
                        generateStages(1, currArcanaNumber);
                        break;
                    default:
                        Debug.Log("You got " + newArcana + " in " + currElementText);
                        break;
                }
                break;
            case "Water":
                 switch (newArcana) {
                    case "The Chariot":
                        Debug.Log("Chariot is selected!");
                        currArcanaNumber = 0;
                        generateStages(2, currArcanaNumber);
                        break;
                    case "The Hanged Man":
                        Debug.Log("Hanged Man is selected!");
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
                    case "The Devil":
                        Debug.Log("Devil is selected!");
                        currArcanaNumber = 0;
                        generateStages(3, currArcanaNumber);
                        break;
                    case "The World":
                        Debug.Log("World is selected!");
                        currArcanaNumber = 1;
                        generateStages(3, currArcanaNumber);
                        break;
                    default:
                        Debug.Log("You got " + newArcana + " in " + currElementText);
                        break;
                }
                break;
            case "Fire":
                 switch (newArcana) {
                    case "The Sun":
                        Debug.Log("Sun is selected!");
                        currArcanaNumber = 0;
                        generateStages(4, currArcanaNumber);
                        break;
                    case "Wheel of Fortune":
                        Debug.Log("Wheel of Fortune is selected!");
                        currArcanaNumber = 1;
                        generateStages(4, currArcanaNumber);
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

    void removeStages() {
        foreach (Transform child in stageLocations.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    void generateStages(int elementNo, int arcanaNo) {
        string[] stageList;
        string currentCard;
        int currentStageNumber;
        switch (elementNo) {
            case 0:
                stageList = readingsStageList[arcanaNo];
                currentCard = readingsArcana[arcanaNo];
                currentStageNumber = 0;
                break;
            case 1:
                stageList = airStageList[arcanaNo];
                currentCard = airArcana[arcanaNo];
                currentStageNumber = 4 + 5*arcanaNo;
                break;
            case 2:
                stageList = waterStageList[arcanaNo];
                currentCard = waterArcana[arcanaNo];
                currentStageNumber = 14 + 5*arcanaNo;
                break;
            case 3:
                stageList = earthStageList[arcanaNo];
                currentCard = earthArcana[arcanaNo];
                currentStageNumber = 24 + 5*arcanaNo;
                break;
            case 4:
                stageList = fireStageList[arcanaNo];
                currentCard = fireArcana[arcanaNo];
                currentStageNumber = 34 + 5*arcanaNo;
                break;
            default:
                Debug.Log("da huh");
                stageList = new string[] {""};
                currentCard = "";
                currentStageNumber = 0;
                break;
        }
        int numStages = 0;
        foreach (string stage in stageList) {
            if (stage.Length == 0) {
                break;
            }
            int thisStageNumber = currentStageNumber + numStages;

            numStages++;

            GameObject newStage = Instantiate(stagePrefab, stageLocations.transform);

            newStage.GetComponent<StageNumber>().SetStageNumber(thisStageNumber);
            newStage.transform.GetChild(1).GetChild(0).GetComponent<SliderHandler>().SetStageNum(thisStageNumber);

            // Debug.Log("Stage number: " + newStage.GetComponent<StageNumber>().GetStageNumber());

            TMP_Text stageTextComponent = getTextComponent(newStage);

            Image stageImage = getImageComponent(newStage);

            int currIntState = gameHandler.stages.stages[thisStageNumber].state;
            string imagePath = "Art/Arcana_Icons/" + currentCard + "/" + currentCard + "_";

            switch (currIntState) {
                case 0:
                    imagePath += "Locked";
                    break;
                case 1:
                    imagePath += "NoProgress";
                    break;
                case 2:
                    imagePath += "Progress";
                    break;
                case 3:
                    imagePath += "Complete";
                    break;
                default:
                    Debug.Log("Where you state at");
                    break;
            }

            stageImage.sprite = Resources.Load<Sprite>(imagePath);

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

    Image getImageComponent(GameObject stage) {
        Transform sliderTransform = null;
        foreach (Transform t in stage.transform) {
            if (t.tag == "Slider") {
                sliderTransform = t;
            }
        }

        return sliderTransform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
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
