using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class StageInfo 
{
    /*
    // state 0 : LOCKED
    // state 1 : NO PROGRESS
    // state 2 : PROGRESS
    // state 3 : COMPLETE
    */

    public int stageNumber, numTiles;
    public int state = 0; // default to locked state
    public string[] originalPuzzleArrangement; // starting arrangement of letters
    public string[] currentPuzzleArrangement; // current arrangement of letters
    public string[] savedPuzzleArrangement; // saved arrangement of letters
    public float[] originalHangmanLetterVisibilities; // starting visibility of hangman-style letters
    public float[] savedHangmanLetterVisibilities; // saved visibility of hangman-style letters
}
