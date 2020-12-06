using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HighlightingManager6x5 : MonoBehaviour
{
    public int stageNumber;
    public GameObject Tile11, Tile12, Tile13, Tile14, Tile15, Tile21, Tile22, Tile23, Tile24, Tile25, Tile31, Tile32, Tile33, Tile34, Tile35, Tile41, Tile42, Tile43, Tile44, Tile45, Tile51, Tile52, Tile53, Tile54, Tile55, Tile61, Tile62, Tile63, Tile64, Tile65;
    public string[] correctLetters;
    public GameObject[] letterTexts;
    public GraphicRaycaster tileGrid;
    public Image unsolvedScreen, solvedScreen, blackOut, unsolvedArcana, solvedArcana;
    public CanvasGroup columnsGroup, rowsGroup, puzzleCompletePopUp;
    public GameObject backMenu, puzzleCompleteMenu;
    public Button backButton;
    private bool letter1, letter2, letter3, letter4, letter5, letter6, letter7, letter8, letter9, letter10, letter11, letter12, letter13, letter14, letter15, letter16, letter17, letter18, letter19, letter20, letter21, letter22, letter23, letter24, letter25, letter26, letter27, letter28, letter29, letter30;
    private bool[] allLetters;
    private PuzzleGameHandler gameHandler;

    void Awake()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").gameObject.GetComponent<PuzzleGameHandler>();
    }

    void Start()
    {
        StartCoroutine(CheckForWords());
        allLetters = new bool[] {letter1, letter2, letter3, letter4, letter5, letter6, letter7, letter8, letter9, letter10, letter11, letter12, letter13, letter14, letter15, letter16, letter17, letter18, letter19, letter20, letter21, letter22, letter23, letter24, letter25, letter26, letter27, letter28, letter29, letter30};
    }

    public IEnumerator CheckForWords()
    {        
        yield return new WaitForSeconds(0.6f);

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
        GameObject colTile10 = null;
        GameObject colTile11 = null;
        GameObject colTile12 = null;
        GameObject colTile13 = null;
        GameObject colTile14 = null;
        GameObject colTile15 = null;
        GameObject colTile16 = null;
        GameObject colTile17 = null;
        GameObject colTile18 = null;
        GameObject colTile19 = null;
        GameObject colTile20 = null;
        GameObject colTile21 = null;
        GameObject colTile22 = null;
        GameObject colTile23 = null;
        GameObject colTile24 = null;
        GameObject colTile25 = null;
        GameObject colTile26 = null;
        GameObject colTile27 = null;
        GameObject colTile28 = null;
        GameObject colTile29 = null;
        GameObject colTile30 = null;

        GameObject rowTile1 = null;
        GameObject rowTile2 = null;
        GameObject rowTile3 = null;
        GameObject rowTile4 = null;
        GameObject rowTile5 = null;
        GameObject rowTile6 = null;
        GameObject rowTile7 = null;
        GameObject rowTile8 = null;
        GameObject rowTile9 = null;
        GameObject rowTile10 = null;
        GameObject rowTile11 = null;
        GameObject rowTile12 = null;
        GameObject rowTile13 = null;
        GameObject rowTile14 = null;
        GameObject rowTile15 = null;
        GameObject rowTile16 = null;
        GameObject rowTile17 = null;
        GameObject rowTile18 = null;
        GameObject rowTile19 = null;
        GameObject rowTile20 = null;
        GameObject rowTile21 = null;
        GameObject rowTile22 = null;
        GameObject rowTile23 = null;
        GameObject rowTile24 = null;
        GameObject rowTile25 = null;
        GameObject rowTile26 = null;
        GameObject rowTile27 = null;
        GameObject rowTile28 = null;
        GameObject rowTile29 = null;
        GameObject rowTile30 = null;

        TMP_Text colTile1Text = null;
        TMP_Text colTile2Text = null;
        TMP_Text colTile3Text = null;
        TMP_Text colTile4Text = null;
        TMP_Text colTile5Text = null;
        TMP_Text colTile6Text = null;
        TMP_Text colTile7Text = null;
        TMP_Text colTile8Text = null;
        TMP_Text colTile9Text = null;
        TMP_Text colTile10Text = null;
        TMP_Text colTile11Text = null;
        TMP_Text colTile12Text = null;
        TMP_Text colTile13Text = null;
        TMP_Text colTile14Text = null;
        TMP_Text colTile15Text = null;
        TMP_Text colTile16Text = null;
        TMP_Text colTile17Text = null;
        TMP_Text colTile18Text = null;
        TMP_Text colTile19Text = null;
        TMP_Text colTile20Text = null;
        TMP_Text colTile21Text = null;
        TMP_Text colTile22Text = null;
        TMP_Text colTile23Text = null;
        TMP_Text colTile24Text = null;
        TMP_Text colTile25Text = null;
        TMP_Text colTile26Text = null;
        TMP_Text colTile27Text = null;
        TMP_Text colTile28Text = null;
        TMP_Text colTile29Text = null;
        TMP_Text colTile30Text = null;

        TMP_Text rowTile1Text = null;
        TMP_Text rowTile2Text = null;
        TMP_Text rowTile3Text = null;
        TMP_Text rowTile4Text = null;
        TMP_Text rowTile5Text = null;
        TMP_Text rowTile6Text = null;
        TMP_Text rowTile7Text = null;
        TMP_Text rowTile8Text = null;
        TMP_Text rowTile9Text = null;
        TMP_Text rowTile10Text = null;
        TMP_Text rowTile11Text = null;
        TMP_Text rowTile12Text = null;
        TMP_Text rowTile13Text = null;
        TMP_Text rowTile14Text = null;
        TMP_Text rowTile15Text = null;
        TMP_Text rowTile16Text = null;
        TMP_Text rowTile17Text = null;
        TMP_Text rowTile18Text = null;
        TMP_Text rowTile19Text = null;
        TMP_Text rowTile20Text = null;
        TMP_Text rowTile21Text = null;
        TMP_Text rowTile22Text = null;
        TMP_Text rowTile23Text = null;
        TMP_Text rowTile24Text = null;
        TMP_Text rowTile25Text = null;
        TMP_Text rowTile26Text = null;
        TMP_Text rowTile27Text = null;
        TMP_Text rowTile28Text = null;
        TMP_Text rowTile29Text = null;
        TMP_Text rowTile30Text = null;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile11.transform.position.x, Tile11.transform.position.y), 0.05f); // Tile11
        FindTiles(results, out rowTile1Text, out colTile1Text, out rowTile1, out colTile1);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile12.transform.position.x, Tile12.transform.position.y), 0.05f); // Tile12
        FindTiles(results, out rowTile2Text, out colTile2Text, out rowTile2, out colTile2);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile13.transform.position.x, Tile13.transform.position.y), 0.05f); // Tile13
        FindTiles(results, out rowTile3Text, out colTile3Text, out rowTile3, out colTile3);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile14.transform.position.x, Tile14.transform.position.y), 0.05f); // Tile14
        FindTiles(results, out rowTile4Text, out colTile4Text, out rowTile4, out colTile4);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile15.transform.position.x, Tile15.transform.position.y), 0.05f); // Tile15
        FindTiles(results, out rowTile5Text, out colTile5Text, out rowTile5, out colTile5);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile21.transform.position.x, Tile21.transform.position.y), 0.05f); // Tile21
        FindTiles(results, out rowTile6Text, out colTile6Text, out rowTile6, out colTile6);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile22.transform.position.x, Tile22.transform.position.y), 0.05f); // Tile22
        FindTiles(results, out rowTile7Text, out colTile7Text, out rowTile7, out colTile7);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile23.transform.position.x, Tile23.transform.position.y), 0.05f); // Tile23
        FindTiles(results, out rowTile8Text, out colTile8Text, out rowTile8, out colTile8);
        
        results = Physics2D.OverlapCircleAll(new Vector2(Tile24.transform.position.x, Tile24.transform.position.y), 0.05f); // Tile24
        FindTiles(results, out rowTile9Text, out colTile9Text, out rowTile9, out colTile9);
        
        results = Physics2D.OverlapCircleAll(new Vector2(Tile25.transform.position.x, Tile25.transform.position.y), 0.05f); // Tile25
        FindTiles(results, out rowTile10Text, out colTile10Text, out rowTile10, out colTile10);
    
        results = Physics2D.OverlapCircleAll(new Vector2(Tile31.transform.position.x, Tile31.transform.position.y), 0.05f); // Tile31
        FindTiles(results, out rowTile11Text, out colTile11Text, out rowTile11, out colTile11);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile32.transform.position.x, Tile32.transform.position.y), 0.05f); // Tile32
        FindTiles(results, out rowTile12Text, out colTile12Text, out rowTile12, out colTile12);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile33.transform.position.x, Tile33.transform.position.y), 0.05f); // Tile33
        FindTiles(results, out rowTile13Text, out colTile13Text, out rowTile13, out colTile13);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile34.transform.position.x, Tile34.transform.position.y), 0.05f); // Tile34
        FindTiles(results, out rowTile14Text, out colTile14Text, out rowTile14, out colTile14);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile35.transform.position.x, Tile35.transform.position.y), 0.05f); // Tile35
        FindTiles(results, out rowTile15Text, out colTile15Text, out rowTile15, out colTile15);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile41.transform.position.x, Tile41.transform.position.y), 0.05f); // Tile41
        FindTiles(results, out rowTile16Text, out colTile16Text, out rowTile16, out colTile16);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile42.transform.position.x, Tile42.transform.position.y), 0.05f); // Tile42
        FindTiles(results, out rowTile17Text, out colTile17Text, out rowTile17, out colTile17);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile43.transform.position.x, Tile43.transform.position.y), 0.05f); // Tile43
        FindTiles(results, out rowTile18Text, out colTile18Text, out rowTile18, out colTile18);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile44.transform.position.x, Tile44.transform.position.y), 0.05f); // Tile44
        FindTiles(results, out rowTile19Text, out colTile19Text, out rowTile19, out colTile19);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile45.transform.position.x, Tile45.transform.position.y), 0.05f); // Tile45
        FindTiles(results, out rowTile20Text, out colTile20Text, out rowTile20, out colTile20);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile51.transform.position.x, Tile51.transform.position.y), 0.05f); // Tile51
        FindTiles(results, out rowTile21Text, out colTile21Text, out rowTile21, out colTile21);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile52.transform.position.x, Tile52.transform.position.y), 0.05f); // Tile52
        FindTiles(results, out rowTile22Text, out colTile22Text, out rowTile22, out colTile22);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile53.transform.position.x, Tile53.transform.position.y), 0.05f); // Tile53
        FindTiles(results, out rowTile23Text, out colTile23Text, out rowTile23, out colTile23);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile54.transform.position.x, Tile54.transform.position.y), 0.05f); // Tile54
        FindTiles(results, out rowTile24Text, out colTile24Text, out rowTile24, out colTile24);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile55.transform.position.x, Tile55.transform.position.y), 0.05f); // Tile55
        FindTiles(results, out rowTile25Text, out colTile25Text, out rowTile25, out colTile25);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile61.transform.position.x, Tile61.transform.position.y), 0.05f); // Tile61
        FindTiles(results, out rowTile26Text, out colTile26Text, out rowTile26, out colTile26);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile62.transform.position.x, Tile62.transform.position.y), 0.05f); // Tile62
        FindTiles(results, out rowTile27Text, out colTile27Text, out rowTile27, out colTile27);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile63.transform.position.x, Tile63.transform.position.y), 0.05f); // Tile63
        FindTiles(results, out rowTile28Text, out colTile28Text, out rowTile28, out colTile28);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile64.transform.position.x, Tile64.transform.position.y), 0.05f); // Tile64
        FindTiles(results, out rowTile29Text, out colTile29Text, out rowTile29, out colTile29);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile65.transform.position.x, Tile65.transform.position.y), 0.05f); // Tile65
        FindTiles(results, out rowTile30Text, out colTile30Text, out rowTile30, out colTile30);

        Debug.Log(rowTile1Text.text + rowTile2Text.text + rowTile3Text.text + rowTile4Text.text + rowTile5Text.text + rowTile6Text.text + rowTile7Text.text + rowTile8Text.text + rowTile9Text.text + rowTile10Text.text + rowTile11Text.text + rowTile12Text.text + rowTile13Text.text + rowTile14Text.text + rowTile15Text.text + rowTile16Text.text + rowTile17Text.text + rowTile18Text.text + rowTile19Text.text + rowTile20Text.text + rowTile21Text.text + rowTile22Text.text + rowTile23Text.text + rowTile24Text.text + rowTile25Text.text + rowTile26Text.text + rowTile27Text.text + rowTile28Text.text + rowTile29Text.text + rowTile30Text.text);

        // check for correct letter placements
        if (rowTile1Text.text == correctLetters[0] && colTile1Text.text == correctLetters[0] && (!rowTile1.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile1.GetComponent<PuzzleTileScript>().GetBorderHighlight()))         
        {
            rowTile1.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile1.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile1.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile1.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter1) {
                letter1 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[0].GetComponent<TMP_Text>()));
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
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[1].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile3Text.text == correctLetters[2] && colTile3Text.text == correctLetters[2] && (!rowTile3.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile3.GetComponent<PuzzleTileScript>().GetBorderHighlight()))         {
            
            rowTile3.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile3.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile3.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile3.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter3) {
                letter3 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[2].GetComponent<TMP_Text>()));
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
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[3].GetComponent<TMP_Text>()));
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
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[4].GetComponent<TMP_Text>()));
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
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[5].GetComponent<TMP_Text>()));
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
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[6].GetComponent<TMP_Text>()));
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
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[7].GetComponent<TMP_Text>()));
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
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[8].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile10Text.text == correctLetters[9] && colTile10Text.text == correctLetters[9] && (!rowTile10.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile10.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {     
            rowTile10.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile10.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile10.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile10.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile10.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile10.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter10) {
                letter10 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[9].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile11Text.text == correctLetters[10] && colTile11Text.text == correctLetters[10] && (!rowTile11.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile11.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile11.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile11.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile11.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile11.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile11.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile11.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter11) {
                letter11 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[10].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile12Text.text == correctLetters[11] && colTile12Text.text == correctLetters[11] && (!rowTile12.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile12.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile12.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile12.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile12.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile12.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile12.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile12.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter12) {
                letter12 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[11].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile13Text.text == correctLetters[12] && colTile13Text.text == correctLetters[12] && (!rowTile13.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile13.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile13.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile13.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile13.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile13.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile13.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile13.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter13) {
                letter13 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[12].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile14Text.text == correctLetters[13] && colTile14Text.text == correctLetters[13] && (!rowTile14.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile14.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile14.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile14.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile14.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile14.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile14.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile14.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter14) {
                letter14 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[13].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile15Text.text == correctLetters[14] && colTile15Text.text == correctLetters[14] && (!rowTile15.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile15.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile15.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile15.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile15.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile15.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile15.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile15.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter15) {
                letter15 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[14].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile16Text.text == correctLetters[15] && colTile16Text.text == correctLetters[15] && (!rowTile16.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile16.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile16.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile16.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile16.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile16.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile16.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile16.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter16) {
                letter16 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[15].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile17Text.text == correctLetters[16] && colTile17Text.text == correctLetters[16] && (!rowTile17.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile17.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile17.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile17.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile17.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile17.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile17.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile17.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter17) {
                letter17 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[16].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile18Text.text == correctLetters[17] && colTile18Text.text == correctLetters[17] && (!rowTile18.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile18.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile18.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile18.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile18.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile18.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile18.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile18.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter18) {
                letter18 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[17].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile19Text.text == correctLetters[18] && colTile19Text.text == correctLetters[18] && (!rowTile19.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile19.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile19.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile19.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile19.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile19.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile19.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile19.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter19) {
                letter19 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[18].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile20Text.text == correctLetters[19] && colTile20Text.text == correctLetters[19] && (!rowTile20.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile20.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile20.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile20.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile20.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile20.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile20.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile20.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter20) {
                letter20 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[19].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile21Text.text == correctLetters[20] && colTile21Text.text == correctLetters[20] && (!rowTile21.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile21.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile21.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile21.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile21.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile21.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile21.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile21.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter21) {
                letter21 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[20].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile22Text.text == correctLetters[21] && colTile22Text.text == correctLetters[21] && (!rowTile22.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile22.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile22.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile22.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile22.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile22.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile22.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile22.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter22) {
                letter22 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[21].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile23Text.text == correctLetters[22] && colTile23Text.text == correctLetters[22] && (!rowTile23.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile23.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile23.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile23.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile23.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile23.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile23.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile23.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter23) {
                letter23 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[22].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile24Text.text == correctLetters[23] && colTile24Text.text == correctLetters[23] && (!rowTile24.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile24.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile24.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile24.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile24.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile24.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile24.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile24.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter24) {
                letter24 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[23].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile25Text.text == correctLetters[24] && colTile25Text.text == correctLetters[24] && (!rowTile25.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile25.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile25.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile25.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile25.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile25.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile25.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile25.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter25) {
                letter25 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[24].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile26Text.text == correctLetters[25] && colTile26Text.text == correctLetters[25] && (!rowTile26.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile26.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile26.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile26.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile26.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile26.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile26.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile26.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter26) {
                letter26 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[25].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile27Text.text == correctLetters[26] && colTile27Text.text == correctLetters[26] && (!rowTile27.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile27.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile27.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile27.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile27.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile27.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile27.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile27.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter27) {
                letter27 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[26].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile28Text.text == correctLetters[27] && colTile28Text.text == correctLetters[27] && (!rowTile28.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile28.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile28.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile28.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile28.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile28.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile28.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile28.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter28) {
                letter28 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[27].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile29Text.text == correctLetters[28] && colTile29Text.text == correctLetters[28] && (!rowTile29.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile29.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile29.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile29.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile29.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile29.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile29.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile29.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter29) {
                letter29 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[28].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile30Text.text == correctLetters[29] && colTile30Text.text == correctLetters[29] && (!rowTile30.GetComponent<PuzzleTileScript>().GetBorderHighlight() && !colTile30.GetComponent<PuzzleTileScript>().GetBorderHighlight())) 
        {
            rowTile30.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);
            colTile30.GetComponent<PuzzleTileScript>().SetBorderHighlight(true);

            StartCoroutine(FadeInAndFadeOut(0.4f, rowTile30.transform.GetChild(0).GetChild(2).GetComponent<Image>(), rowTile30.transform.GetChild(0).GetChild(1).GetComponent<Image>()));
            StartCoroutine(FadeInAndFadeOut(0.4f, colTile30.transform.GetChild(0).GetChild(2).GetComponent<Image>(), colTile30.transform.GetChild(0).GetChild(1).GetComponent<Image>()));

            if (!letter30) {
                letter30 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[29].GetComponent<TMP_Text>()));
            }
        }

        bool[] allTiles = new bool[] {colTile1.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile2.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile3.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile4.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile5.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile6.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile7.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile8.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile9.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile10.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile11.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile12.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile13.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile14.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile15.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile16.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile17.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile18.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile19.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile20.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile21.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile22.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile23.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile24.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile25.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile26.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile27.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile28.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile29.GetComponent<PuzzleTileScript>().GetBorderHighlight(), colTile30.GetComponent<PuzzleTileScript>().GetBorderHighlight()};

        // check if all letters are in the right position
        if (CheckAllLetters(allTiles)) 
        {
            gameHandler.stages.stages[stageNumber].state = 3;
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

    public IEnumerator FadeInAndFadeOut(float t, Image fadeIn, Image fadeOut)
    {
        fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, 0);
        fadeOut.color = new Color(fadeOut.color.r, fadeOut.color.g, fadeOut.color.b, 1);
        while (fadeIn.color.a < 1.0f && fadeOut.color.a > 0.0f)
        {
            fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, fadeIn.color.a + (Time.deltaTime / t));
            fadeOut.color = new Color(fadeOut.color.r, fadeOut.color.g, fadeOut.color.b, fadeOut.color.a - (Time.deltaTime / t));
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
