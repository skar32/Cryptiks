using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{
    public string[] letters;
    public GameObject[] columnTiles;
    public GameObject[] rowTiles;
    public GameObject rows, columns;
    private bool mouseClicked = false; // checks if the left mouse button is down
    private bool dragging = false; // checks if the mouse is being dragged

    void Awake() // initialize both the column and row grids with the array of letters inputted in the inspector
    {
        int count = 0;
        foreach (GameObject tile in columnTiles) {
            GameObject tileCanvas = tile.transform.GetChild(0).gameObject;
            GameObject tileTextObject = tileCanvas.transform.GetChild(0).gameObject;
            TMP_Text tileText = tileTextObject.GetComponent<TMP_Text>();
            tileText.text = letters[count];
            count++;
        }

        count = 0;
        foreach (GameObject tile in rowTiles) {
            GameObject tileCanvas = tile.transform.GetChild(0).gameObject;
            GameObject tileTextObject = tileCanvas.transform.GetChild(0).gameObject;
            TMP_Text tileText = tileTextObject.GetComponent<TMP_Text>();
            tileText.text = letters[count];
            count++;
        }
    }

    void Update() 
    {

        if (Input.GetMouseButtonDown(0)) {
            mouseClicked = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            mouseClicked = false;
        }
        
        // if the left mouse button is down, is being dragged to the right/left, and is not shifting a column/row already, change the grid to the row grid
        if (mouseClicked && !dragging && (Input.GetAxis("Mouse X") > 0.2 || Input.GetAxis("Mouse X") < -0.2)) {
            rows.GetComponent<CanvasGroup>().alpha = 1f;
            rows.GetComponent<CanvasGroup>().blocksRaycasts = true;
            columns.GetComponent<CanvasGroup>().alpha = 0f;
            columns.GetComponent<CanvasGroup>().blocksRaycasts = false;
            dragging = true;
        // if the left mouse button is down, is being dragged upward/downward, and is not shifting a column/row already, change the grid to the column grid
        } else if (mouseClicked && !dragging && (Input.GetAxis("Mouse Y") > 0.2 || Input.GetAxis("Mouse Y") < -0.2)) {
            rows.GetComponent<CanvasGroup>().alpha = 0f;
            rows.GetComponent<CanvasGroup>().blocksRaycasts = false;
            columns.GetComponent<CanvasGroup>().alpha = 1f;
            columns.GetComponent<CanvasGroup>().blocksRaycasts = true;
            dragging = true;
        }
    }

    public void updateRowTiles() // once a mouse drag ends and a shift is made in the column grid, update the positions of the letters in the row grid underneath
    {
        dragging = false; 

        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 585), 50); // upper left tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 585), 50); // upper middle tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 585), 50); // upper right tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 420), 50); // middle left tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 420), 50); // middle middle tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 420), 50); // middle right tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 250), 50); // lower left tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 250), 50); // lower middle tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 250), 50); // lower right tiles
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;
    }

    public void updateColumnTiles() // once a mouse drag ends and a shift is made in the row grid, update the positions of the letters in the column grid underneath
    {
        dragging = false;
        
        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 585), 50); // upper left tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 585), 50); // upper middle tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 585), 50); // upper right tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 420), 50); // middle left tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 420), 50); // middle middle tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 420), 50); // middle right tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 250), 50); // lower left tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 250), 50); // lower middle tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 250), 50); // lower right tiles
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;
    }

    private void findText(Collider2D[] results, out TMP_Text rowText, out TMP_Text colText) // helper method for updating tile text after mouse drag ends and a shift occurs
    { 
        rowText = null;
        colText = null;
        foreach (Collider2D collider in results) {
            GameObject curr = collider.gameObject;
            if (curr.tag == "Row") {
                GameObject rowTileCanvas = curr.transform.GetChild(0).gameObject;
                GameObject rowTileTextObject = rowTileCanvas.transform.GetChild(0).gameObject;
                rowText = rowTileTextObject.GetComponent<TMP_Text>(); 
            } else if (curr.tag == "Col") {
                GameObject colTileCanvas = curr.transform.GetChild(0).gameObject;
                GameObject colTileTextObject = colTileCanvas.transform.GetChild(0).gameObject;
                colText = colTileTextObject.GetComponent<TMP_Text>(); 
            }
        }
    }

}
