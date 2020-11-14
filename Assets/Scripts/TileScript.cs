using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using TMPro;

public class TileScript : MonoBehaviour
{
    public Color baseTileColor;
    public Color correctWordColor;
    public Color baseBorderColor;
    public Color correctBorderColor;
    public GameObject border;
    private GameObject tileCounterpart;
    private GameObject otherTile1, otherTile2;
    private bool borderHighlighted;
    private bool partOfWord;

    public void SetBorderHighlight(bool value)
    {
        borderHighlighted = value;
    }

    public void SetTileHighlight(bool value)
    {
        partOfWord = value;
    }

    public void SetOtherTile1(GameObject tile1) {
        otherTile1 = tile1;
    }

    public void SetOtherTile2(GameObject tile2) {
        otherTile2 = tile2;
    }

    public bool GetBorderHighlight()
    {
        return borderHighlighted;
    }

    public bool GetTileHighlight()
    {
        return partOfWord;
    }

    void Update()
    {
        
    }

    public void DetectHighlight()
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(new Vector2(this.transform.position.x, this.transform.position.y), 50);
        foreach (Collider2D col in results) {
            GameObject curr = col.gameObject;
            if (this.tag == "Row" && curr.tag == "Col") {
                tileCounterpart = curr;
            } else if (this.tag == "Col" && curr.tag == "Row") {
                tileCounterpart = curr;
            }
        }

        if (borderHighlighted && tileCounterpart.GetComponent<TileScript>().GetBorderHighlight()) 
        {
            StartCoroutine(RemoveBorderHighlight());
            StartCoroutine(tileCounterpart.GetComponent<TileScript>().RemoveBorderHighlight());
            tileCounterpart.GetComponent<TileScript>().SetBorderHighlight(false);
            borderHighlighted = false;
        }

         if (partOfWord && tileCounterpart.GetComponent<TileScript>().GetTileHighlight()) 
         {
            StartCoroutine(RemoveTileHighlight());
            StartCoroutine(tileCounterpart.GetComponent<TileScript>().RemoveTileHighlight());
            tileCounterpart.GetComponent<TileScript>().SetTileHighlight(false);
            partOfWord = false;

            otherTile1.GetComponent<TileScript>().RemoveOtherTileHighlight();
            otherTile2.GetComponent<TileScript>().RemoveOtherTileHighlight();
        }
    }

    public void RemoveOtherTileHighlight()
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(new Vector2(this.transform.position.x, this.transform.position.y), 50);
        foreach (Collider2D col in results) {
            GameObject curr = col.gameObject;
            if (this.tag == "Row" && curr.tag == "Col") {
                tileCounterpart = curr;
            } else if (this.tag == "Col" && curr.tag == "Row") {
                tileCounterpart = curr;
            }
        }

        StartCoroutine(RemoveTileHighlight());
        StartCoroutine(tileCounterpart.GetComponent<TileScript>().RemoveTileHighlight());
        tileCounterpart.GetComponent<TileScript>().SetTileHighlight(false);
        partOfWord = false;
    }

    IEnumerator RemoveBorderHighlight()
    {
        float t = 0f;
        while (t <= 1f)
        {
            GetComponent<Image>().color = Color.Lerp(correctWordColor, baseTileColor, t);
            // border.GetComponent<Image>().color = Color.Lerp(correctBorderColor, baseBorderColor, t);
            t += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator RemoveTileHighlight()
    {
        float t = 0f;
        while (t <= 1f)
        {
            border.GetComponent<Image>().color = Color.Lerp(correctBorderColor, baseBorderColor, t);
            //GetComponent<Image>().color = Color.Lerp(correctWordColor, baseTileColor, t);
            t += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
