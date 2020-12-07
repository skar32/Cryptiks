/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class PuzzleGameHandler : MonoBehaviour 
{
    public Stages stages;
    public static int currStageSelected = 0;
    private static bool initialSetup = false;

    private void Awake() 
    {
        if (!initialSetup) {
            StreamReader saveReader = new StreamReader(Application.streamingAssetsPath + "/Saves/recentSave.json");
            string saveData = saveReader.ReadToEnd(); 
            saveReader.Close();
            StreamReader originalReader = new StreamReader(Application.streamingAssetsPath + "/Saves/Stages.json");
            string originalData = originalReader.ReadToEnd(); 
            originalReader.Close();

            SavingSystem.Init();
            Load();
            // stages = JsonUtility.FromJson<Stages>(originalData); // use when saving mechanic is NOT needed to test
            stages = JsonUtility.FromJson<Stages>(saveData); // use when saving mechanic is needed to test
            initialSetup = true;
        }
    }

    // private void Update() { // for dev testing
    //     if (Input.GetKeyDown(KeyCode.S)) {
    //         Save();
    //     }

    //     if (Input.GetKeyDown(KeyCode.L)) {
    //         Load();
    //     }
    // }

    public void Save() {
        // Save
        int currElementSelected = PuzzleSelectionScreenManager.currElementNumber;
        int currArcanaSelected = PuzzleSelectionScreenManager.currArcanaNumber;
        int currArcanaScrollerSelected = PuzzleSelectionScreenManager.currArcanaScroller;

        SaveObject saveObject = new SaveObject { 
            currElementSelected = currElementSelected,
            currArcanaSelected = currArcanaSelected,
            currStage = currStageSelected,
            currArcanaScroller = currArcanaScrollerSelected,
            stages = stages.stages
        };
        string json = JsonUtility.ToJson(saveObject);
        SavingSystem.Save(json);

        Debug.Log("Saved!");
    }

    public void Load() {
        // Load
        string saveString = SavingSystem.Load();
        if (saveString != null) {
            Debug.Log("Loaded: " + saveString);

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            PuzzleSelectionScreenManager.currElementNumber = saveObject.currElementSelected;
            PuzzleSelectionScreenManager.currArcanaNumber = saveObject.currArcanaSelected;
            PuzzleSelectionScreenManager.currArcanaScroller = saveObject.currArcanaScroller;
            currStageSelected = saveObject.currStage;
            stages.stages = saveObject.stages;

        } else {
            Debug.Log("No save :(");
        }
    }

    void OnApplicationQuit()
    {
        Save();
    }


    private class SaveObject {
        public int currElementSelected, currArcanaSelected, currStage, currArcanaScroller;
        public StageInfo[] stages;
    }
}