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

public static class SavingSystem {

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private const string SAVE_EXTENSION = "json";

    public static void Init() {
        // Test if Save Folder exists
        if (!Directory.Exists(SAVE_FOLDER)) {
            // Create Save Folder
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString) 
    {
        File.WriteAllText(SAVE_FOLDER + "recentSave" + "." + SAVE_EXTENSION, saveString);
    }

    public static string Load() 
    {
        // find the save file called "recentSave.json"
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
        FileInfo saveFile = null;
        foreach (FileInfo fileInfo in saveFiles) {
            if (fileInfo.Name == "recentSave.json") {
                saveFile = fileInfo;
                Debug.Log("found save file!");
            }
        }

        // If theres a save file, load it, if not return null
        if (saveFile != null) {
            string saveString = File.ReadAllText(saveFile.FullName);
            return saveString;
        } else {
            return null;
        }
    }

}
