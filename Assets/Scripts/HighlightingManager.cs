using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HighlightingManager : MonoBehaviour
{
    public GameObject upperLeft, middleLeft, lowerLeft, upperMiddle, middleMiddle, lowerMiddle, upperRight, middleRight, lowerRight;
    public string[] correctWords;
    public GameObject[] columnTiles;
    public GameObject[] rowTiles;
    public Color baseTileColor;
    public Color baseBorderColor;
    public Color correctWordColor;
    public Color correctBorderColor;

    void Start()
    {
        //StartCoroutine(CheckForWords());
    }

    public IEnumerator CheckForWords()
    {
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

        results = Physics2D.OverlapCircleAll(new Vector2(upperLeft.transform.position.x, upperLeft.transform.position.y), 50); // upper left tile
        findTiles(results, out rowTile1Text, out colTile1Text, out rowTile1, out colTile1);

        results = Physics2D.OverlapCircleAll(new Vector2(upperMiddle.transform.position.x, upperMiddle.transform.position.y), 50); // upper middle tile
        findTiles(results, out rowTile2Text, out colTile2Text, out rowTile2, out colTile2);

        results = Physics2D.OverlapCircleAll(new Vector2(upperRight.transform.position.x, upperRight.transform.position.y), 50); // upper right tile
        findTiles(results, out rowTile3Text, out colTile3Text, out rowTile3, out colTile3);

        results = Physics2D.OverlapCircleAll(new Vector2(middleLeft.transform.position.x, middleLeft.transform.position.y), 50); // middle left tile
        findTiles(results, out rowTile4Text, out colTile4Text, out rowTile4, out colTile4);

        results = Physics2D.OverlapCircleAll(new Vector2(middleMiddle.transform.position.x, middleMiddle.transform.position.y), 50); // middle middle tile
        findTiles(results, out rowTile5Text, out colTile5Text, out rowTile5, out colTile5);

        results = Physics2D.OverlapCircleAll(new Vector2(middleRight.transform.position.x, middleRight.transform.position.y), 50); // middle right tile
        findTiles(results, out rowTile6Text, out colTile6Text, out rowTile6, out colTile6);

        results = Physics2D.OverlapCircleAll(new Vector2(lowerLeft.transform.position.x, lowerLeft.transform.position.y), 50); // lower left tile
        findTiles(results, out rowTile7Text, out colTile7Text, out rowTile7, out colTile7);

        results = Physics2D.OverlapCircleAll(new Vector2(lowerMiddle.transform.position.x, lowerMiddle.transform.position.y), 50); // lower middle tile
        findTiles(results, out rowTile8Text, out colTile8Text, out rowTile8, out colTile8);

        results = Physics2D.OverlapCircleAll(new Vector2(lowerRight.transform.position.x, lowerRight.transform.position.y), 50); // lower right tile
        findTiles(results, out rowTile9Text, out colTile9Text, out rowTile9, out colTile9);

        string rowGridWord1 = rowTile1Text.text + rowTile2Text.text + rowTile3Text.text;
        string colGridWord1 = colTile1Text.text + colTile2Text.text + colTile3Text.text;
        
        string rowGridWord2 = rowTile4Text.text + rowTile5Text.text + rowTile6Text.text;
        string colGridWord2 = colTile4Text.text + colTile5Text.text + colTile6Text.text;

        string rowGridWord3 = rowTile7Text.text + rowTile8Text.text + rowTile9Text.text;
        string colGridWord3 = colTile7Text.text + colTile8Text.text + colTile9Text.text;

        // check for correct letter placements
        if (rowTile1Text.text == "H" && colTile1Text.text == "H" && (!rowTile1.GetComponent<TileScript>().GetBorderHighlight() && !colTile1.GetComponent<TileScript>().GetBorderHighlight()))         {
            rowTile1.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile1.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile1.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile1.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }

        if (rowTile2Text.text == "I" && colTile2Text.text == "I" && (!rowTile2.GetComponent<TileScript>().GetBorderHighlight() && !colTile2.GetComponent<TileScript>().GetBorderHighlight())) 
        {
            rowTile2.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile2.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile2.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile2.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile2.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile2.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }

        if (rowTile3Text.text == "T" && colTile3Text.text == "T" && (!rowTile3.GetComponent<TileScript>().GetBorderHighlight() && !colTile3.GetComponent<TileScript>().GetBorderHighlight()))         {
            rowTile3.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile3.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile3.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile3.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }

        if (rowTile4Text.text == "T" && colTile4Text.text == "T" && (!rowTile4.GetComponent<TileScript>().GetBorderHighlight() && !colTile4.GetComponent<TileScript>().GetBorderHighlight())) 
        {
            rowTile4.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile4.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile4.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile4.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile4.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile4.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }

        if (rowTile5Text.text == "H" && colTile5Text.text == "H" && (!rowTile5.GetComponent<TileScript>().GetBorderHighlight() && !colTile5.GetComponent<TileScript>().GetBorderHighlight())) 
        {
            rowTile5.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile5.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile5.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile5.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile5.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile5.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }

        if (rowTile6Text.text == "E" && colTile6Text.text == "E" && (!rowTile6.GetComponent<TileScript>().GetBorderHighlight() && !colTile6.GetComponent<TileScript>().GetBorderHighlight())) 
        {
            rowTile6.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile6.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile6.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile6.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile6.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile6.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }

        if (rowTile7Text.text == "H" && colTile7Text.text == "H" && (!rowTile7.GetComponent<TileScript>().GetBorderHighlight() && !colTile7.GetComponent<TileScript>().GetBorderHighlight())) 
        {
            rowTile7.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile7.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile7.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile7.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile7.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile7.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }

        if (rowTile8Text.text == "A" && colTile8Text.text == "A" && (!rowTile8.GetComponent<TileScript>().GetBorderHighlight() && !colTile8.GetComponent<TileScript>().GetBorderHighlight())) 
        {
            rowTile8.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile8.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile8.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile8.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile8.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile8.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }

        if (rowTile9Text.text == "Y" && colTile9Text.text == "Y" && (!rowTile9.GetComponent<TileScript>().GetBorderHighlight() && !colTile9.GetComponent<TileScript>().GetBorderHighlight())) 
        {
            rowTile9.GetComponent<TileScript>().SetBorderHighlight(true);
            colTile9.GetComponent<TileScript>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                // rowTile9.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                // colTile9.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                rowTile9.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                colTile9.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }
        }
        
        // check for correct words in the wrong spots
        foreach (string word in correctWords) 
        {
            if ((!rowTile1.GetComponent<TileScript>().GetTileHighlight() || !colTile1.GetComponent<TileScript>().GetTileHighlight()) && (string.Equals(word, rowGridWord1) || string.Equals(word, colGridWord1))) 
            {
                rowTile1.GetComponent<TileScript>().SetTileHighlight(true);
                rowTile2.GetComponent<TileScript>().SetTileHighlight(true);
                rowTile3.GetComponent<TileScript>().SetTileHighlight(true);

                colTile1.GetComponent<TileScript>().SetTileHighlight(true);
                colTile2.GetComponent<TileScript>().SetTileHighlight(true);
                colTile3.GetComponent<TileScript>().SetTileHighlight(true);

                rowTile1.GetComponent<TileScript>().SetOtherTile1(rowTile2);
                rowTile1.GetComponent<TileScript>().SetOtherTile2(rowTile3);

                rowTile2.GetComponent<TileScript>().SetOtherTile1(rowTile1);
                rowTile2.GetComponent<TileScript>().SetOtherTile2(rowTile3);

                rowTile3.GetComponent<TileScript>().SetOtherTile1(rowTile1);
                rowTile3.GetComponent<TileScript>().SetOtherTile2(rowTile2);

                colTile1.GetComponent<TileScript>().SetOtherTile1(colTile2);
                colTile1.GetComponent<TileScript>().SetOtherTile2(colTile3);

                colTile2.GetComponent<TileScript>().SetOtherTile1(colTile1);
                colTile2.GetComponent<TileScript>().SetOtherTile2(colTile3);

                colTile3.GetComponent<TileScript>().SetOtherTile1(colTile1);
                colTile3.GetComponent<TileScript>().SetOtherTile2(colTile2);

                float t = 0f;
                while (t <= 1f)
                {
                    // rowTile1.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile1.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    // rowTile2.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile2.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    // rowTile3.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile3.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    rowTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                    rowTile2.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile2.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                    rowTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    
                    t += Time.deltaTime;
                    yield return new WaitForSeconds(0.001f);
                }
            }
            if ((!rowTile4.GetComponent<TileScript>().GetTileHighlight() || !colTile4.GetComponent<TileScript>().GetTileHighlight()) && (string.Equals(word, rowGridWord2) || string.Equals(word, colGridWord2))) 
            {
                rowTile4.GetComponent<TileScript>().SetTileHighlight(true);
                rowTile5.GetComponent<TileScript>().SetTileHighlight(true);
                rowTile6.GetComponent<TileScript>().SetTileHighlight(true);

                colTile4.GetComponent<TileScript>().SetTileHighlight(true);
                colTile5.GetComponent<TileScript>().SetTileHighlight(true);
                colTile6.GetComponent<TileScript>().SetTileHighlight(true);

                rowTile4.GetComponent<TileScript>().SetOtherTile1(rowTile5);
                rowTile4.GetComponent<TileScript>().SetOtherTile2(rowTile6);

                rowTile5.GetComponent<TileScript>().SetOtherTile1(rowTile4);
                rowTile5.GetComponent<TileScript>().SetOtherTile2(rowTile6);

                rowTile6.GetComponent<TileScript>().SetOtherTile1(rowTile4);
                rowTile6.GetComponent<TileScript>().SetOtherTile2(rowTile5);

                colTile4.GetComponent<TileScript>().SetOtherTile1(colTile5);
                colTile4.GetComponent<TileScript>().SetOtherTile2(colTile6);

                colTile5.GetComponent<TileScript>().SetOtherTile1(colTile4);
                colTile5.GetComponent<TileScript>().SetOtherTile2(colTile6);

                colTile6.GetComponent<TileScript>().SetOtherTile1(colTile4);
                colTile6.GetComponent<TileScript>().SetOtherTile2(colTile5);

                float t = 0f;
                while (t <= 1f)
                {
                    // rowTile4.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile4.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    // rowTile5.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile5.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    // rowTile6.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile6.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    rowTile4.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile4.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                    rowTile5.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile5.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                    rowTile6.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile6.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    
                    t += Time.deltaTime;
                    yield return new WaitForSeconds(0.001f);
                }
            }
            if ((!rowTile7.GetComponent<TileScript>().GetTileHighlight() || !colTile7.GetComponent<TileScript>().GetTileHighlight()) && (string.Equals(word, rowGridWord3) || string.Equals(word, colGridWord3))) 
            {
                rowTile7.GetComponent<TileScript>().SetTileHighlight(true);
                rowTile8.GetComponent<TileScript>().SetTileHighlight(true);
                rowTile9.GetComponent<TileScript>().SetTileHighlight(true);

                colTile7.GetComponent<TileScript>().SetTileHighlight(true);
                colTile8.GetComponent<TileScript>().SetTileHighlight(true);
                colTile9.GetComponent<TileScript>().SetTileHighlight(true);

                rowTile7.GetComponent<TileScript>().SetOtherTile1(rowTile8);
                rowTile7.GetComponent<TileScript>().SetOtherTile2(rowTile9);

                rowTile8.GetComponent<TileScript>().SetOtherTile1(rowTile7);
                rowTile8.GetComponent<TileScript>().SetOtherTile2(rowTile9);

                rowTile9.GetComponent<TileScript>().SetOtherTile1(rowTile7);
                rowTile9.GetComponent<TileScript>().SetOtherTile2(rowTile8);

                colTile7.GetComponent<TileScript>().SetOtherTile1(colTile8);
                colTile7.GetComponent<TileScript>().SetOtherTile2(colTile9);

                colTile8.GetComponent<TileScript>().SetOtherTile1(colTile7);
                colTile8.GetComponent<TileScript>().SetOtherTile2(colTile9);

                colTile9.GetComponent<TileScript>().SetOtherTile1(colTile7);
                colTile9.GetComponent<TileScript>().SetOtherTile2(colTile8);

                float t = 0f;
                while (t <= 1f)
                {
                    // rowTile7.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile7.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    // rowTile8.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile8.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    // rowTile9.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                    // colTile9.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                    rowTile7.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile7.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                    rowTile8.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile8.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                    rowTile9.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    colTile9.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                    
                    t += Time.deltaTime;
                    yield return new WaitForSeconds(0.001f);
                }
            }
        }
    }

    private void findTiles(Collider2D[] results, out TMP_Text rowText, out TMP_Text colText, out GameObject rowTile, out GameObject colTile) // helper method for updating tile text after mouse drag ends and a shift occurs
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
}
