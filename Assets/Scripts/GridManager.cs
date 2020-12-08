using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GridManager : MonoBehaviour
{
    public GameObject[] columnTiles;
    public GameObject[] rowTiles;
    public int stageNumber;
    private PuzzleGameHandler gameHandler;

    void Awake()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").gameObject.GetComponent<PuzzleGameHandler>();
        PuzzleGameHandler.currStageSelected = stageNumber + 2;
    }

    public void Init() // initialize both the column and row grids with the array of letters inputted in the inspector
    {
        Debug.Log("initializing grid");
        int count = 0;
        foreach (GameObject tile in columnTiles) {
            GameObject tileCanvas = tile.transform.GetChild(0).gameObject;
            GameObject tileTextObject = tileCanvas.transform.GetChild(0).gameObject;
            TMP_Text tileText = tileTextObject.GetComponent<TMP_Text>();
            tileText.text = gameHandler.stages.stages[stageNumber].savedPuzzleArrangement[count];
            count++;
        }

        count = 0;
        foreach (GameObject tile in rowTiles) {
            GameObject tileCanvas = tile.transform.GetChild(0).gameObject;
            GameObject tileTextObject = tileCanvas.transform.GetChild(0).gameObject;
            TMP_Text tileText = tileTextObject.GetComponent<TMP_Text>();
            tileText.text = gameHandler.stages.stages[stageNumber].savedPuzzleArrangement[count];
            count++;
        }
    }
}
