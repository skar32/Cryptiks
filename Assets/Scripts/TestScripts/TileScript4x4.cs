using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using TMPro;

public class TileScript4x4 : MonoBehaviour
{
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

        if (borderHighlighted && tileCounterpart.GetComponent<TileScript4x4>().GetBorderHighlight()) 
        {
            StartCoroutine(RemoveBorderHighlight());
            StartCoroutine(tileCounterpart.GetComponent<TileScript4x4>().RemoveBorderHighlight());
            tileCounterpart.GetComponent<TileScript4x4>().SetBorderHighlight(false);
            borderHighlighted = false;
        }
    }

    IEnumerator RemoveBorderHighlight()
    {
        StartCoroutine(FadeInAndFadeOut(0.4f, this.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>(), this.gameObject.transform.GetChild(0).GetChild(2).GetComponent<Image>()));
        yield return null;
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
}
