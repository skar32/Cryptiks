using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using TMPro;

public class TileScript4x4 : MonoBehaviour
{
    public Color baseBorderColor;
    public Color correctBorderColor;
    public GameObject border;
    private GameObject tileCounterpart;
    private bool borderHighlighted;

    public void SetBorderHighlight(bool value)
    {
        borderHighlighted = value;
    }

    public bool GetBorderHighlight()
    {
        return borderHighlighted;
    }

    public void DetectHighlight()
    {
        Collider2D[] results = Physics2D.OverlapCircleAll(new Vector2(this.transform.position.x, this.transform.position.y), 0.05f);
        foreach (Collider2D col in results) {
            GameObject curr = col.gameObject;
            if (this.tag == "Row" && curr.tag == "Col") {
                tileCounterpart = curr;
            } else if (this.tag == "Col" && curr.tag == "Row") {
                tileCounterpart = curr;
            }
        }

        if (borderHighlighted || tileCounterpart.GetComponent<TileScript4x4>().GetBorderHighlight()) 
        {
            StartCoroutine(RemoveBorderHighlight());
            StartCoroutine(tileCounterpart.GetComponent<TileScript4x4>().RemoveBorderHighlight());
            tileCounterpart.GetComponent<TileScript4x4>().SetBorderHighlight(false);
            borderHighlighted = false;
        }
    }

    IEnumerator RemoveBorderHighlight()
    {
        float t = 0f;
        while (t <= 1f)
        {
            border.GetComponent<Image>().color = Color.Lerp(correctBorderColor, baseBorderColor, t);
            t += Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
