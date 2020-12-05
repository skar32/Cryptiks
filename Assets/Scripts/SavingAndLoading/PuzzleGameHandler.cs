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
    public TextAsset originalJSONFile;
    public TextAsset recentSaveJSON;
    private static bool initialSetup = false;

    private void Awake() 
    {
        if (!initialSetup) {
            SavingSystem.Init();
            Load();
            stages = JsonUtility.FromJson<Stages>(originalJSONFile.text); // use when saving mechanic is NOT needed to test
            // stages = JsonUtility.FromJson<Stages>(recentSaveJSON.text); // use when saving mechanic is needed to test
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

        SaveObject saveObject = new SaveObject { 
            currElementSelected = currElementSelected,
            currArcanaSelected = currArcanaSelected,
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
        public int currElementSelected, currArcanaSelected;
        public StageInfo[] stages;
    }
}