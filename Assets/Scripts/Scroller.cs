 using UnityEngine;
 using System.Collections;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using TMPro;

public class Scroller : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject rows, columns;
    public ScrollRect OtherScrollRect1, OtherScrollRect2, OtherScrollRect3;
    public GameObject upperLeft, middleLeft, lowerLeft, upperMiddle, middleMiddle, lowerMiddle, upperRight, middleRight, lowerRight;
    private ScrollRect _myScrollRect;
    public static bool scrollOther; //This tracks if the other one should be scrolling instead of the current one.
    private bool scrollOtherHorizontally; //This tracks whether the other one should scroll horizontally or vertically.
    private bool scroll1, scroll2, scroll3;
    private bool word1;
    public HighlightingManager highlightingScript;

    void Awake()
    {
        _myScrollRect = this.GetComponent<ScrollRect>(); //Get the current scroll rect so we can disable it if the other one is scrolling
        scrollOtherHorizontally = _myScrollRect.vertical; //If the current scroll Rect has the vertical checked then the other one will be scrolling horizontally.
        
        //Check some attributes to let the user know if this wont work as expected
        if (scrollOtherHorizontally)
        {
            if(_myScrollRect.horizontal)
                Debug.Log("You have added the SecondScrollRect to a scroll view that already has both directions selected");
            if (!OtherScrollRect1.horizontal)
                Debug.Log("The other scroll rect doesnt support scrolling horizontally");
        }
        else if (!OtherScrollRect1.vertical)
        {
            Debug.Log("The other scroll rect doesnt support scrolling vertically");
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Get the absolute values of the x and y differences so we can see which one is bigger and scroll the other scroll rect accordingly
        float horizontal = Mathf.Abs(eventData.position.x - eventData.pressPosition.x);
        float vertical = Mathf.Abs(eventData.position.y - eventData.pressPosition.y);

        float xPos = eventData.pressPosition.x / Screen.width;
        float yPos = eventData.pressPosition.y / Screen.height;

        Debug.Log("X: " + xPos);
        Debug.Log("Y: " + yPos);

        if (scrollOtherHorizontally) // if the other scroll rect should be scrolled horizontally
        {
            if (horizontal > vertical)
            {
                scrollOther = true;
                Debug.Log("Switching to horizontal");
                _myScrollRect.enabled = false; //disable the current scroll rect so it doesnt move.

                updateRowTiles(); // update the row tiles with the right letters before switching to it

                rows.GetComponent<CanvasGroup>().alpha = 1f;
                rows.GetComponent<CanvasGroup>().blocksRaycasts = true;
                columns.GetComponent<CanvasGroup>().alpha = 0f;
                columns.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (0.6 < yPos && yPos < 1) { // if row 1 should be scrolled
                    ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect1.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row1");
                    scroll1 = true;
                } else if (0.4 < yPos && yPos < 0.6) { // if row 2 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect2.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row2");
                    scroll2 = true;
                } else if (0 < yPos && yPos < 0.4) { // if row 3 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect3.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row3");
                    scroll3 = true;
                }
            }
        }
        else if (vertical > horizontal) // if the other scroll rect should be scrolled vertically
        {
            scrollOther = true;
            Debug.Log("Switching to vertical");
            _myScrollRect.enabled = false; //disable the current scroll rect so it doesnt move.

            updateColumnTiles(); // update the column tiles with the right letters before switching to it

            rows.GetComponent<CanvasGroup>().alpha = 0f;
            rows.GetComponent<CanvasGroup>().blocksRaycasts = false;
            columns.GetComponent<CanvasGroup>().alpha = 1f;
            columns.GetComponent<CanvasGroup>().blocksRaycasts = true;

            if (0.2 < xPos && xPos < 0.4) { // if col 1 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect1.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col1");
                scroll1 = true;
            } else if (0.4 < xPos && xPos < 0.6) { // if col 2 should be scrolled 
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect2.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col2");
                scroll2 = true;
            } else if (0.6 < xPos && xPos < 0.8) { // if col 3 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect3.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col3");
                scroll3 = true;
            }
        }
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (scrollOther)
        {
            scrollOther = false;
            _myScrollRect.enabled = true;

            if (scroll1) {
                ExecuteEvents.Execute<IEndDragHandler> (OtherScrollRect1.gameObject, eventData, ExecuteEvents.endDragHandler);
                scroll1 = false;
            } else if (scroll2) {
                ExecuteEvents.Execute<IEndDragHandler> (OtherScrollRect2.gameObject, eventData, ExecuteEvents.endDragHandler);
                scroll2 = false;
            } else if (scroll3) {
                ExecuteEvents.Execute<IEndDragHandler> (OtherScrollRect3.gameObject, eventData, ExecuteEvents.endDragHandler);
                scroll3 = false;
            }
        }

        if (rows.GetComponent<CanvasGroup>().alpha == 0f) {
            updateRowTiles();
        } else if (columns.GetComponent<CanvasGroup>().alpha == 0f) {
            updateColumnTiles();
        }

        StartCoroutine(highlightingScript.CheckForWords());
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (scrollOther)
        {
            if (scroll1) {
            	//Debug.Log("scrolling");
                OtherScrollRect1.OnDrag(eventData);
            } else if (scroll2) {
            	//Debug.Log("scrolling");
                OtherScrollRect2.OnDrag(eventData);
            } else if (scroll3) {
            	//Debug.Log("scrolling");
                OtherScrollRect3.OnDrag(eventData);
            }
            
        }
    }

    public void updateRowTiles() // once a mouse drag ends and a shift is made in the column grid, update the positions of the letters in the row grid underneath
    {
        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(upperLeft.transform.position.x, upperLeft.transform.position.y), 50); // upper left tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(upperMiddle.transform.position.x, upperMiddle.transform.position.y), 50); // upper middle tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(upperRight.transform.position.x, upperRight.transform.position.y), 50); // upper right tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(middleLeft.transform.position.x, middleLeft.transform.position.y), 50); // middle left tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(middleMiddle.transform.position.x, middleMiddle.transform.position.y), 50); // middle middle tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(middleRight.transform.position.x, middleRight.transform.position.y), 50); // middle right tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(lowerLeft.transform.position.x, lowerLeft.transform.position.y), 50); // lower left tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(lowerMiddle.transform.position.x, lowerMiddle.transform.position.y), 50); // lower middle tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(lowerRight.transform.position.x, lowerRight.transform.position.y), 50); // lower right tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;
    }

    public void updateColumnTiles() // once a mouse drag ends and a shift is made in the row grid, update the positions of the letters in the column grid underneath
    {
        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(upperLeft.transform.position.x, upperLeft.transform.position.y), 50); // upper left tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(upperMiddle.transform.position.x, upperMiddle.transform.position.y), 50); // upper middle tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(upperRight.transform.position.x, upperRight.transform.position.y), 50); // upper right tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(middleLeft.transform.position.x, middleLeft.transform.position.y), 50); // middle left tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(middleMiddle.transform.position.x, middleMiddle.transform.position.y), 50); // middle middle tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(middleRight.transform.position.x, middleRight.transform.position.y), 50); // middle right tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(lowerLeft.transform.position.x, lowerLeft.transform.position.y), 50); // lower left tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(lowerMiddle.transform.position.x, lowerMiddle.transform.position.y), 50); // lower middle tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(lowerRight.transform.position.x, lowerRight.transform.position.y), 50); // lower right tile
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

    // IEnumerator CheckForWords() 
    // {
    //     Collider2D[] results;
    //     GameObject rowTile1, rowTile2, rowTile3, colTile1, colTile2, colTile3;
    //     TMP_Text rowTile1Text, rowTile2Text, rowTile3Text, colTile1Text, colTile2Text, colTile3Text;

    //     results = Physics2D.OverlapCircleAll(new Vector2(265, 585), 50); // upper left tiles
    //     CheckForWordsHelper(results, out rowTile1, out colTile1, out rowTile1Text, out colTile1Text);

    //     results = Physics2D.OverlapCircleAll(new Vector2(435, 585), 50); // upper middle tiles
    //     CheckForWordsHelper(results, out rowTile2, out colTile2, out rowTile2Text, out colTile2Text);

    //     results = Physics2D.OverlapCircleAll(new Vector2(610, 585), 50); // upper right tiles
    //     CheckForWordsHelper(results, out rowTile3, out colTile3, out rowTile3Text, out colTile3Text);

    //     if (rowTile1Text.text == "H" && rowTile2Text.text == "A" && rowTile3Text.text == "Y" || colTile1Text.text == "H" && colTile2Text.text == "A" && colTile3Text.text == "Y") {
    //         float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
    //         float increment = 0.2f/5; //The amount of change to apply.
    //         while (progress < 1)
    //         {
    //             rowTile1.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
    //             rowTile2.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
    //             rowTile3.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
    //             colTile1.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
    //             colTile2.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
    //             colTile3.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
    //             progress += increment;
    //             yield return new WaitForSeconds(0.02f);
    //         }
    //         word1 = true;
    //     } else {
    //         if (word1) {
    //             float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
    //             float increment = 0.2f/5; //The amount of change to apply.
    //             while (progress < 1)
    //             {
    //                 rowTile1.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
    //                 rowTile2.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
    //                 rowTile3.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
    //                 colTile1.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
    //                 colTile2.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
    //                 colTile3.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
    //                 currDraggedTile.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
    //                 progress += increment;
    //                 yield return new WaitForSeconds(0.02f);
    //             }
    //             word1 = false;
    //         }
    //     }
    // }

    // private void CheckForWordsHelper(Collider2D[] results, out GameObject rowTile, out GameObject colTile, out TMP_Text rowTileText, out TMP_Text colTileText) 
    // {
    //     rowTile = null;
    //     colTile = null;
    //     rowTileText = null;
    //     colTileText = null;

    //     foreach (Collider2D collider in results) {
    //         GameObject curr = collider.gameObject;
    //         if (curr.tag == "Row") {
    //             rowTile = curr.gameObject;
    //             GameObject rowTileCanvas = curr.transform.GetChild(0).gameObject;
    //             GameObject rowTileTextObject = rowTileCanvas.transform.GetChild(0).gameObject;
    //             rowTileText = rowTileTextObject.GetComponent<TMP_Text>(); 
    //         } else if (curr.tag == "Col") {
    //             colTile = curr.gameObject;
    //             GameObject colTileCanvas = curr.transform.GetChild(0).gameObject;
    //             GameObject colTileTextObject = colTileCanvas.transform.GetChild(0).gameObject;
    //             colTileText = colTileTextObject.GetComponent<TMP_Text>(); 
    //         }
    //     }
    // }
}
