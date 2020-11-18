using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HighlightingManager4x4 : MonoBehaviour
{
    public GameObject Tile11, Tile12, Tile13, Tile14, Tile21, Tile22, Tile23, Tile24, Tile31, Tile32, Tile33, Tile34, Tile41, Tile42, Tile43, Tile44;
    public string[] correctLetters;
    public Color baseBorderColor;
    public Color correctBorderColor;
    public GameObject[] letterTexts;
    private bool letter1, letter2, letter3, letter4, letter5, letter6, letter7, letter8, letter9, letter10, letter11, letter12, letter13, letter14, letter15, letter16;

    void Start()
    {
        //StartCoroutine(CheckForWords());
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
        GameObject colTile10 = null;
        GameObject colTile11 = null;
        GameObject colTile12 = null;
        GameObject colTile13 = null;
        GameObject colTile14 = null;
        GameObject colTile15 = null;
        GameObject colTile16 = null;

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

        results = Physics2D.OverlapCircleAll(new Vector2(Tile11.transform.position.x, Tile11.transform.position.y), 0.05f); // Tile11
        FindTiles(results, out rowTile1Text, out colTile1Text, out rowTile1, out colTile1);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile12.transform.position.x, Tile12.transform.position.y), 0.05f); // Tile12
        FindTiles(results, out rowTile2Text, out colTile2Text, out rowTile2, out colTile2);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile13.transform.position.x, Tile13.transform.position.y), 0.05f); // Tile13
        FindTiles(results, out rowTile3Text, out colTile3Text, out rowTile3, out colTile3);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile14.transform.position.x, Tile14.transform.position.y), 0.05f); // Tile14
        FindTiles(results, out rowTile4Text, out colTile4Text, out rowTile4, out colTile4);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile21.transform.position.x, Tile21.transform.position.y), 0.05f); // Tile21
        FindTiles(results, out rowTile5Text, out colTile5Text, out rowTile5, out colTile5);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile22.transform.position.x, Tile22.transform.position.y), 0.05f); // Tile22
        FindTiles(results, out rowTile6Text, out colTile6Text, out rowTile6, out colTile6);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile23.transform.position.x, Tile23.transform.position.y), 0.05f); // lile23
        FindTiles(results, out rowTile7Text, out colTile7Text, out rowTile7, out colTile7);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile24.transform.position.x, Tile24.transform.position.y), 0.05f); // Tile24
        FindTiles(results, out rowTile8Text, out colTile8Text, out rowTile8, out colTile8);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile31.transform.position.x, Tile31.transform.position.y), 0.05f); // Tile31
        FindTiles(results, out rowTile9Text, out colTile9Text, out rowTile9, out colTile9);
        
        results = Physics2D.OverlapCircleAll(new Vector2(Tile32.transform.position.x, Tile32.transform.position.y), 0.05f); // Tile32
        FindTiles(results, out rowTile10Text, out colTile10Text, out rowTile10, out colTile10);
        
        results = Physics2D.OverlapCircleAll(new Vector2(Tile33.transform.position.x, Tile33.transform.position.y), 0.05f); // Tile33
        FindTiles(results, out rowTile11Text, out colTile11Text, out rowTile11, out colTile11);
        
        results = Physics2D.OverlapCircleAll(new Vector2(Tile34.transform.position.x, Tile34.transform.position.y), 0.05f); // Tile34
        FindTiles(results, out rowTile12Text, out colTile12Text, out rowTile12, out colTile12);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile41.transform.position.x, Tile41.transform.position.y), 0.05f); // Tile41
        FindTiles(results, out rowTile13Text, out colTile13Text, out rowTile13, out colTile13);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile42.transform.position.x, Tile42.transform.position.y), 0.05f); // Tile42
        FindTiles(results, out rowTile14Text, out colTile14Text, out rowTile14, out colTile14);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile43.transform.position.x, Tile43.transform.position.y), 0.05f); // Tile43
        FindTiles(results, out rowTile15Text, out colTile15Text, out rowTile15, out colTile15);

        results = Physics2D.OverlapCircleAll(new Vector2(Tile44.transform.position.x, Tile44.transform.position.y), 0.05f); // Tile44
        FindTiles(results, out rowTile16Text, out colTile16Text, out rowTile16, out colTile16);

        Debug.Log(rowTile1Text.text + rowTile2Text.text + rowTile3Text.text + rowTile4Text.text + rowTile5Text.text + rowTile6Text.text + rowTile7Text.text + rowTile8Text.text + rowTile9Text.text + rowTile10Text.text + rowTile11Text.text + rowTile12Text.text + rowTile13Text.text + rowTile14Text.text + rowTile15Text.text + rowTile16Text.text);

        // check for correct letter placements
        if (rowTile1Text.text == correctLetters[0] && colTile1Text.text == correctLetters[0] && (!rowTile1.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile1.GetComponent<TileScript4x4>().GetBorderHighlight()))         
        {
            rowTile1.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile1.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile1.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile1.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile1.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter1) {
                letter1 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[0].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile2Text.text == correctLetters[1] && colTile2Text.text == correctLetters[1] && (!rowTile2.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile2.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile2.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile2.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile2.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile2.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile2.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile2.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter2) {
                letter2 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[1].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile3Text.text == correctLetters[2] && colTile3Text.text == correctLetters[2] && (!rowTile3.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile3.GetComponent<TileScript4x4>().GetBorderHighlight()))         {
            rowTile3.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile3.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile3.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile3.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile3.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter3) {
                letter3 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[2].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile4Text.text == correctLetters[3] && colTile4Text.text == correctLetters[3] && (!rowTile4.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile4.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile4.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile4.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile4.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile4.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile4.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile4.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter4) {
                letter4 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[3].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile5Text.text == correctLetters[4] && colTile5Text.text == correctLetters[4] && (!rowTile5.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile5.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile5.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile5.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile5.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile5.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile5.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile5.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter5) {
                letter5 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[4].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile6Text.text == correctLetters[5] && colTile6Text.text == correctLetters[5] && (!rowTile6.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile6.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile6.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile6.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile6.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile6.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile6.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile6.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter6) {
                letter6 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[5].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile7Text.text == correctLetters[6] && colTile7Text.text == correctLetters[6] && (!rowTile7.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile7.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile7.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile7.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile7.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile7.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile7.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile7.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter7) {
                letter7 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[6].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile8Text.text == correctLetters[7] && colTile8Text.text == correctLetters[7] && (!rowTile8.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile8.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile8.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile8.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile8.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile8.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile8.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile8.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);

                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter8) {
                letter8 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[7].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile9Text.text == correctLetters[8] && colTile9Text.text == correctLetters[8] && (!rowTile9.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile9.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile9.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile9.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile9.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile9.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile9.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile9.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter9) {
                letter9 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[8].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile10Text.text == correctLetters[9] && colTile10Text.text == correctLetters[9] && (!rowTile10.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile10.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {     
            rowTile10.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile10.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile10.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile10.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile10.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile10.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter10) {
                letter10 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[9].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile11Text.text == correctLetters[10] && colTile11Text.text == correctLetters[10] && (!rowTile11.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile11.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile11.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile11.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile11.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile11.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile11.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile11.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter11) {
                letter11 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[10].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile12Text.text == correctLetters[11] && colTile12Text.text == correctLetters[11] && (!rowTile12.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile12.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile12.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile12.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile12.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile12.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile12.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile12.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter12) {
                letter12 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[11].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile13Text.text == correctLetters[12] && colTile13Text.text == correctLetters[12] && (!rowTile13.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile13.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile13.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile13.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile13.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile13.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile13.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile13.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter13) {
                letter13 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[12].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile14Text.text == correctLetters[13] && colTile14Text.text == correctLetters[13] && (!rowTile14.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile14.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile14.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile14.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile14.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile14.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile14.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile14.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter14) {
                letter14 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[13].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile15Text.text == correctLetters[14] && colTile15Text.text == correctLetters[14] && (!rowTile15.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile15.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile15.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile15.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile15.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile15.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile15.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile15.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter15) {
                letter15 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[14].GetComponent<TMP_Text>()));
            }
        }

        if (rowTile16Text.text == correctLetters[15] && colTile16Text.text == correctLetters[15] && (!rowTile16.GetComponent<TileScript4x4>().GetBorderHighlight() && !colTile16.GetComponent<TileScript4x4>().GetBorderHighlight())) 
        {
            rowTile16.GetComponent<TileScript4x4>().SetBorderHighlight(true);
            colTile16.GetComponent<TileScript4x4>().SetBorderHighlight(true);

            float t = 0f;
            while (t <= 1f)
            {
                rowTile16.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);
                colTile16.transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.Lerp(baseBorderColor, correctBorderColor, t);

                // rowTile16.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);
                // colTile16.GetComponent<Image>().color = Color.Lerp(baseTileColor, correctWordColor, t);


                t += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
            }

            if (!letter16) {
                letter16 = true;
                StartCoroutine(FadeTextToFullAlpha(1f, letterTexts[15].GetComponent<TMP_Text>()));
            }
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

    public IEnumerator FadeTextToFullAlpha(float t, TMP_Text text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}
