using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager4x4 : MonoBehaviour
{
    public string[] letters;
    public GameObject[] columnTiles;
    public GameObject[] rowTiles;

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
}
