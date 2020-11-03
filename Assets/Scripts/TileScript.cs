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
    public GameObject tileCounterpart;
    private GameObject otherTile1, otherTile2;
    private bool borderHighlighted;
    private bool partOfWord;

    public void setBorderHighlight(bool value)
    {
        borderHighlighted = value;
    }

    public void setTileHighlight(bool value)
    {
        partOfWord = value;
    }

    public void setOtherTile1(GameObject tile1) {
        otherTile1 = tile1;
    }

    public void setOtherTile2(GameObject tile2) {
        otherTile2 = tile2;
    }

    public bool getBorderHighlight()
    {
        return borderHighlighted;
    }

    public bool getTileHighlight()
    {
        return partOfWord;
    }

    void Update()
    {
        
    }

    public void detectHighlight()
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

        if (borderHighlighted && tileCounterpart.GetComponent<TileScript>().getBorderHighlight()) 
        {
            StartCoroutine(removeBorderHighlight());
            StartCoroutine(tileCounterpart.GetComponent<TileScript>().removeBorderHighlight());
            tileCounterpart.GetComponent<TileScript>().setBorderHighlight(false);
            borderHighlighted = false;
        }

         if (partOfWord && tileCounterpart.GetComponent<TileScript>().getTileHighlight()) 
         {
            StartCoroutine(removeTileHighlight());
            StartCoroutine(tileCounterpart.GetComponent<TileScript>().removeTileHighlight());
            tileCounterpart.GetComponent<TileScript>().setTileHighlight(false);
            partOfWord = false;

            otherTile1.GetComponent<TileScript>().removeOtherTileHighlight();
            otherTile2.GetComponent<TileScript>().removeOtherTileHighlight();
        }
    }

    public void removeOtherTileHighlight()
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

        StartCoroutine(removeTileHighlight());
        StartCoroutine(tileCounterpart.GetComponent<TileScript>().removeTileHighlight());
        tileCounterpart.GetComponent<TileScript>().setTileHighlight(false);
        partOfWord = false;
    }

    IEnumerator removeBorderHighlight()
    {
        float t = 0f;
        while (t <= 1f)
        {
            border.GetComponent<Image>().color = Color.Lerp(correctBorderColor, baseBorderColor, t);
            t += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }
    }

    IEnumerator removeTileHighlight()
    {
        float t = 0f;
        while (t <= 1f)
        {
            GetComponent<Image>().color = Color.Lerp(correctWordColor, baseTileColor, t);
            t += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
