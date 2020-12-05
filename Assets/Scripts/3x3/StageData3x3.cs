using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageData3x3 : MonoBehaviour
{
    public int stageNumber;
    private PuzzleGameHandler gameHandler;
    public GameObject Tile11, Tile12, Tile13, Tile21, Tile22, Tile23, Tile31, Tile32, Tile33;
    public GameObject[] hangmanLetters;
    private GridManager gridManagerScript;

    void Awake()
    {
        gridManagerScript = GetComponent<GridManager>();
        gameHandler = GameObject.FindWithTag("GameHandler").gameObject.GetComponent<PuzzleGameHandler>();
        if (gameHandler.stages.stages[stageNumber].state == 1) // if first time opening stage 
        { 
            gameHandler.stages.stages[stageNumber].state = 2;
            gameHandler.stages.stages[stageNumber].currentPuzzleArrangement = new string[gameHandler.stages.stages[stageNumber].numTiles];
            UpdateTiles(gameHandler.stages.stages[stageNumber].currentPuzzleArrangement, gameHandler.stages.stages[stageNumber].originalPuzzleArrangement);
            UpdateHangmanLetters(hangmanLetters, gameHandler.stages.stages[stageNumber].originalHangmanLetterVisibilities);
        } else if (gameHandler.stages.stages[stageNumber].state == 2) // if stage is in progress
        { 
            UpdateTiles(gameHandler.stages.stages[stageNumber].currentPuzzleArrangement, gameHandler.stages.stages[stageNumber].savedPuzzleArrangement);
            UpdateHangmanLetters(hangmanLetters, gameHandler.stages.stages[stageNumber].savedHangmanLetterVisibilities);
            gridManagerScript.Start();
        } else if (gameHandler.stages.stages[stageNumber].state == 3) // if stage is being opened after being completed before
        { 
            gameHandler.stages.stages[stageNumber].state = 1;
            Awake();
        }
    }

    public void SaveData()
    {
        Debug.Log("Saving stage " + stageNumber + " data!");

        Collider2D[] results;

        GameObject colTile1 = null;
        GameObject colTile2 = null;
        GameObject colTile3 = null;
        GameObject colTile4 = null;
        GameObject colTile5 = null;
        GameObject colTile6 = null;
        GameObject colTile7 = null;
        GameObject colTile8 = null;
        GameObject colTile9 = null;

        GameObject rowTile1 = null;
        GameObject rowTile2 = null;
        GameObject rowTile3 = null;
        GameObject rowTile4 = null;
        GameObject rowTile5 = null;
        GameObject rowTile6 = null;
        GameObject rowTile7 = null;
        GameObject rowTile8 = null;
        GameObject rowTile9 = null;

        TMP_Text colTile1Text = null;
        TMP_Text colTile2Text = null;
        TMP_Text colTile3Text = null;
        TMP_Text colTile4Text = null;
        TMP_Text colTile5Text = null;
        TMP_Text colTile6Text = null;
        TMP_Text colTile7Text = null;
        TMP_Text colTile8Text = null;
        TMP_Text colTile9Text = null;

        TMP_Text rowTile1Text = null;
        TMP_Text rowTile2Text = null;
        TMP_Text rowTile3Text = null;
        TMP_Text rowTile4Text = null;
        TMP_Text rowTile5Text = null;
        TMP_Text rowTile6Text = null;
        TMP_Text rowTile7Text = null;
        TMP_Text rowTile8Text = null;
        TMP_Text rowTile9Text = null;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile11.transform.position.x, Tile11.transform.position.y), 0.05f); // Tile11
        FindTiles(results, out rowTile1Text, out colTile1Text, out rowTile1, out colTile1);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile12.transform.position.x, Tile12.transform.position.y), 0.05f); // Tile12
        FindTiles(results, out rowTile2Text, out colTile2Text, out rowTile2, out colTile2);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile13.transform.position.x, Tile13.transform.position.y), 0.05f); // Tile13
        FindTiles(results, out rowTile3Text, out colTile3Text, out rowTile3, out colTile3);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile21.transform.position.x, Tile21.transform.position.y), 0.05f); // Tile21
        FindTiles(results, out rowTile4Text, out colTile4Text, out rowTile4, out colTile4);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile22.transform.position.x, Tile22.transform.position.y), 0.05f); // Tile22
        FindTiles(results, out rowTile5Text, out colTile5Text, out rowTile5, out colTile5);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile23.transform.position.x, Tile23.transform.position.y), 0.05f); // lile23
        FindTiles(results, out rowTile6Text, out colTile6Text, out rowTile6, out colTile6);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile31.transform.position.x, Tile31.transform.position.y), 0.05f); // Tile31
        FindTiles(results, out rowTile7Text, out colTile7Text, out rowTile7, out colTile7);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile32.transform.position.x, Tile32.transform.position.y), 0.05f); // Tile32
        FindTiles(results, out rowTile8Text, out colTile8Text, out rowTile8, out colTile8);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile33.transform.position.x, Tile33.transform.position.y), 0.05f); // Tile33
        FindTiles(results, out rowTile9Text, out colTile9Text, out rowTile9, out colTile9);

        TMP_Text[] tileTexts = new TMP_Text[] {colTile1Text, colTile2Text, colTile3Text, colTile4Text, colTile5Text, colTile6Text, colTile7Text, colTile8Text, colTile9Text};

        int count = 0;

        foreach (TMP_Text tileText in tileTexts) { // save tile configuration
            gameHandler.stages.stages[stageNumber].savedPuzzleArrangement[count] = tileText.text;
            count++;
        }

        count = 0;

        foreach (GameObject letter in hangmanLetters) { // save hangman letter visibilities 
            gameHandler.stages.stages[stageNumber].savedHangmanLetterVisibilities[count] = letter.GetComponent<TMP_Text>().color.a;
            count++;
        }
    }

    private void FindTiles(Collider2D[] results, out TMP_Text rowText, out TMP_Text colText, out GameObject rowTile, out GameObject colTile) // helper method for updating tile text after mouse drag ends and a shift occurs
    { 
        rowText = null;
        colText = null;
        rowTile = null;
        colTile = null;

        foreach (Collider2D collider in results) {
            GameObject curr = collider.gameObject;
            if (curr.tag == "Row") {
                rowTile = curr;
                GameObject rowTileCanvas = curr.transform.GetChild(0).gameObject;
                GameObject rowTileTextObject = rowTileCanvas.transform.GetChild(0).gameObject;
                rowText = rowTileTextObject.GetComponent<TMP_Text>(); 
            } else if (curr.tag == "Col") {
                colTile = curr;
                GameObject colTileCanvas = curr.transform.GetChild(0).gameObject;
                GameObject colTileTextObject = colTileCanvas.transform.GetChild(0).gameObject;
                colText = colTileTextObject.GetComponent<TMP_Text>(); 
            }
        }
    }

    private void UpdateTiles(string[] originalList, string[] newList) {
        for (int i = 0; i < gameHandler.stages.stages[stageNumber].numTiles; i++) {
            originalList[i] = newList[i];
        }
    }

    private void UpdateHangmanLetters(GameObject[] letters, float[] savedVisibilities) {
        int count = 0;
        foreach (GameObject letter in letters) {
            letter.GetComponent<TMP_Text>().color = new Color(letter.GetComponent<TMP_Text>().color.r, letter.GetComponent<TMP_Text>().color.g, letter.GetComponent<TMP_Text>().color.b, savedVisibilities[count]); 
            count++;
        }
    }
}
