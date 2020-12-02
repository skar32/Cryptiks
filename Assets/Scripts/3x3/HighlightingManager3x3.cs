using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HighlightingManager3x3 : MonoBehaviour
{
    public GameObject Tile11, Tile12, Tile13, Tile21, Tile22, Tile23, Tile31, Tile32, Tile33;
    public string[] correctLetters;
    public GameObject[] letterTexts;
    public GraphicRaycaster tileGrid;
    public Image unsolvedScreen, solvedScreen, blackOut, unsolvedArcana, solvedArcana;
    public CanvasGroup columnsGroup, rowsGroup, puzzleCompletePopUp;
    public GameObject backMenu, puzzleCompleteMenu;
    public Button backButton;
    private bool letter1, letter2, letter3, letter4, letter5, letter6, letter7, letter8, letter9;
    private bool[] allLetters;

    void Start()
    {
        StartCoroutine(CheckForWords());
        allLetters = new bool[] {letter1, letter2, letter3, letter4, letter5, letter6, letter7, letter8, letter9};
    }

    public IEnumerator CheckForWords()
    {  
        yield return new WaitForSeconds(0.5f);

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

        results = Physics2D.OverlapCircleAll(new Vector2(Tile11.transform.position.x, Tile11.transform.position.y), 0.3f); // Tile11
        FindTiles(results, out rowTile1Text, out colTile1Text, out rowTile1, out colTile1);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile12.transform.position.x, Tile12.transform.position.y), 0.3f); // Tile12
        FindTiles(results, out rowTile2Text, out colTile2Text, out rowTile2, out colTile2);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile13.transform.position.x, Tile13.transform.position.y), 0.3f); // Tile13
        FindTiles(results, out rowTile3Text, out colTile3Text, out rowTile3, out colTile3);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile21.transform.position.x, Tile21.transform.position.y), 0.3f); // Tile21
        FindTiles(results, out rowTile4Text, out colTile4Text, out rowTile4, out colTile4);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile22.transform.position.x, Tile22.transform.position.y), 0.3f); // Tile22
        FindTiles(results, out rowTile5Text, out colTile5Text, out rowTile5, out colTile5);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile23.transform.position.x, Tile23.transform.position.y), 0.3f); // lile23
        FindTiles(results, out rowTile6Text, out colTile6Text, out rowTile6, out colTile6);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile31.transform.position.x, Tile31.transform.position.y), 0.3f); // Tile31
        FindTiles(results, out rowTile7Text, out colTile7Text, out rowTile7, out colTile7);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile32.transform.position.x, Tile32.transform.position.y), 0.3f); // Tile32
        FindTiles(results, out rowTile8Text, out colTile8Text, out rowTile8, out colTile8);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile33.transform.position.x, Tile33.transform.position.y), 0.3f); // Tile33
        FindTiles(results, out rowTile9Text, out colTile9Text, out rowTile9, out colTile9);

        Debug.Log(rowTile1Text.text + rowTile2Text.text + rowTile3Text.text + rowTile4Text.text + rowTile5Text.text + rowTile6Text.text + rowTile7Text.text + rowTile8Text.text + rowTile9Text.text);

        // check for correct letter placements
        if (rowTile1Text.text == correctLetters[0] && colTile1Text.text == correctLetters[0] && (!rowTile1.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile1.GetComponent<PuzzleTileScript>().GetBorderHighlight()))         
        {
            rowTile1.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile1.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile1.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile1.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter1) {
                letter1 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[0].GetComponent<TMP_Text>()));
            }
        } 

        if (rowTile2Text.text == correctLetters[1] && colTile2Text.text == correctLetters[1] && (!rowTile2.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile2.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile2.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile2.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile2.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile2.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile2.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile2.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter2) {
                letter2 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[1].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile3Text.text == correctLetters[2] && colTile3Text.text == correctLetters[2] && (!rowTile3.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile3.GetComponent<PuzzleTileScript>().GetBorderHighlight()))         
        {
            rowTile3.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile3.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile3.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile3.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter3) {
                letter3 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[2].GetComponent<TMP_Text>()));
            }
        } 

        if (rowTile4Text.text == correctLetters[3] && colTile4Text.text == correctLetters[3] && (!rowTile4.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile4.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile4.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile4.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile4.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile4.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile4.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile4.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter4) {
                letter4 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[3].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile5Text.text == correctLetters[4] && colTile5Text.text == correctLetters[4] && (!rowTile5.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile5.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile5.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile5.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile5.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile5.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile5.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile5.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter5) {
                letter5 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[4].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile6Text.text == correctLetters[5] && colTile6Text.text == correctLetters[5] && (!rowTile6.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile6.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile6.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile6.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile6.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile6.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile6.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile6.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter6) {
                letter6 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[5].GetComponent<TMP_Text>()));
            }
        } 

        if (rowTile7Text.text == correctLetters[6] && colTile7Text.text == correctLetters[6] && (!rowTile7.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile7.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile7.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile7.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile7.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile7.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile7.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile7.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter7) {
                letter7 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[6].GetComponent<TMP_Text>()));
            }
        } 

        if (rowTile8Text.text == correctLetters[7] && colTile8Text.text == correctLetters[7] && (!rowTile8.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile8.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile8.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile8.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile8.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile8.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile8.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile8.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter8) {
                letter8 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[7].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile9Text.text == correctLetters[8] && colTile9Text.text == correctLetters[8] && (!rowTile9.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile9.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile9.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile9.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile9.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile9.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile9.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile9.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter9) {
                letter9 = true;
                StartCoroutine(FadeTextToFullAlpha(0.4f, letterTexts[8].GetComponent<TMP_Text>()));
            }
        } 

        bool[] allTiles = new bool[] {colTile1.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile2.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile3.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile4.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile5.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile6.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile7.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile8.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile9.GetComponent<PuzzleTileScript>().GetBorderHighlight()};

        // check if all letters are in the right position
        if (CheckAllLetters(allTiles)) 
        {
            tileGrid.enabled = true;
            backButton.interactable = false;
            puzzleCompleteMenu.SetActive(true);
            backMenu.SetActive(false);
            yield return new WaitForSeconds(1.0f);
            StartCoroutine(FadeInAndFadeOut(1.0f, solvedScreen, unsolvedScreen));
            StartCoroutine(FadeInAndFadeOut(1.0f, solvedArcana, unsolvedArcana));
            yield return new WaitForSeconds(2.5f);
            StartCoroutine(FadeIn(1.0f, blackOut, 0.7f));
            yield return new WaitForSeconds(0.2f);
            while (puzzleCompletePopUp.alpha < 1.0f)
            {
                puzzleCompletePopUp.alpha = puzzleCompletePopUp.alpha + (Time.deltaTime / 1.0f);
                yield return null;
            }
            puzzleCompletePopUp.interactable = true;
            puzzleCompletePopUp.blocksRaycasts = true;
        }
    }

     private bool CheckAllLetters(bool[] letterList)
    {
        foreach (bool letter in letterList) {
            if (!letter) {
                return false;
            }
        }
        return true;
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

    public IEnumerator FadeInAndFadeOut(float t, Image FadeIn, Image FadeOut)
    {
        FadeIn.color = new Color(FadeIn.color.r, FadeIn.color.g, FadeIn.color.b, 0);
        FadeOut.color = new Color(FadeOut.color.r, FadeOut.color.g, FadeOut.color.b, 1);
        while (FadeIn.color.a < 1.0f && FadeOut.color.a > 0.0f)
        {
            FadeIn.color = new Color(FadeIn.color.r, FadeIn.color.g, FadeIn.color.b, FadeIn.color.a + (Time.deltaTime / t));
            FadeOut.color = new Color(FadeOut.color.r, FadeOut.color.g, FadeOut.color.b, FadeOut.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

     public IEnumerator FadeIn(float t, Image fadeIn, float alphaAmount)
    {
        fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, 0);
        while (fadeIn.color.a < alphaAmount)
        {
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, fadeIn.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
