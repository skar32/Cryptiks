 using UnityEngine;
 using System.Collections;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using TMPro;

public class Scroller : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject rows, columns;
    public ScrollRect OtherScrollRect1, OtherScrollRect2, OtherScrollRect3;
    public static GameObject currDraggedTile;
    private ScrollRect _myScrollRect;
    private bool scrollOther; //This tracks if the other one should be scrolling instead of the current one.
    private bool scrollOtherHorizontally; //This tracks whether the other one should scroll horizontally or vertically.
    private bool scroll1, scroll2, scroll3;
    private bool word1;

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

        float xPos = eventData.pressPosition.x;
        float yPos = eventData.pressPosition.y;

        // Debug.Log("X: " + xPos);
        // Debug.Log("Y: " + yPos);

        if (scrollOtherHorizontally) // if the other scroll rect should be scrolled horizontally
        {
            if (horizontal > vertical)
            {
                scrollOther = true;
                _myScrollRect.enabled = false; //disable the current scroll rect so it doesnt move.

                updateRowTiles(); // update the row tiles with the right letters before switching to it

                rows.GetComponent<CanvasGroup>().alpha = 1f;
                rows.GetComponent<CanvasGroup>().blocksRaycasts = true;
                columns.GetComponent<CanvasGroup>().alpha = 0f;
                columns.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (500 < yPos && yPos < 675) { // if row 1 should be scrolled
                    OtherScrollRect1.OnBeginDrag(eventData);
                    //Debug.Log("row1");
                    scroll1 = true;
                } else if (325 < yPos && yPos < 500) { // if row 2 should be scrolled
                    OtherScrollRect2.OnBeginDrag(eventData);
                    //Debug.Log("row2");
                    scroll2 = true;
                } else if (165 < yPos && yPos < 325) { // if row 3 should be scrolled
                    OtherScrollRect3.OnBeginDrag(eventData);
                    //Debug.Log("row3");
                    scroll3 = true;
                }
            }
        }
        else if (vertical > horizontal) // if the other scroll rect should be scrolled vertically
        {
            scrollOther = true;
            _myScrollRect.enabled = false; //disable the current scroll rect so it doesnt move.

            updateColumnTiles(); // update the column tiles with the right letters before switching to it

            rows.GetComponent<CanvasGroup>().alpha = 0f;
            rows.GetComponent<CanvasGroup>().blocksRaycasts = false;
            columns.GetComponent<CanvasGroup>().alpha = 1f;
            columns.GetComponent<CanvasGroup>().blocksRaycasts = true;

            if (180 < xPos && xPos < 360) { // if col 1 should be scrolled
                OtherScrollRect1.OnBeginDrag(eventData);
                //Debug.Log("col1");
                scroll1 = true;
            } else if (360 < xPos && xPos < 540) { // if col 2 should be scrolled 
                OtherScrollRect2.OnBeginDrag(eventData);
                //Debug.Log("col2");
                scroll2 = true;
            } else if (540 < xPos && xPos < 690) { // if col 3 should be scrolled
                OtherScrollRect3.OnBeginDrag(eventData);
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
                OtherScrollRect1.OnEndDrag(eventData);
                scroll1 = false;
            } else if (scroll2) {
                OtherScrollRect2.OnEndDrag(eventData);
                scroll2 = false;
            } else if (scroll3) {
                OtherScrollRect3.OnEndDrag(eventData);
                scroll3 = false;
            }
        }

        StartCoroutine(CheckForWords());
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (scrollOther)
        {
            if (scroll1) {
                OtherScrollRect1.OnDrag(eventData);
            } else if (scroll2) {
                OtherScrollRect2.OnDrag(eventData);
            } else if (scroll3) {
                OtherScrollRect3.OnDrag(eventData);
            }
            
        }
    }

    public void updateRowTiles() // once a mouse drag ends and a shift is made in the column grid, update the positions of the letters in the row grid underneath
    {
        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 585), 50); // upper left tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 585), 50); // upper middle tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 585), 50); // upper right tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 420), 50); // middle left tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 420), 50); // middle middle tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 420), 50); // middle right tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 250), 50); // lower left tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 250), 50); // lower middle tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 250), 50); // lower right tile
        findText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;
    }

    public void updateColumnTiles() // once a mouse drag ends and a shift is made in the row grid, update the positions of the letters in the column grid underneath
    {
        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 585), 50); // upper left tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 585), 50); // upper middle tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 585), 50); // upper right tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 420), 50); // middle left tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 420), 50); // middle middle tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 420), 50); // middle right tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 250), 50); // lower left tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(435, 250), 50); // lower middle tile
        findText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(610, 250), 50); // lower right tile
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

    IEnumerator CheckForWords() 
    {
        Collider2D[] results;
        GameObject rowTile1, rowTile2, rowTile3, colTile1, colTile2, colTile3;
        TMP_Text rowTile1Text, rowTile2Text, rowTile3Text, colTile1Text, colTile2Text, colTile3Text;

        results = Physics2D.OverlapCircleAll(new Vector2(265, 585), 50); // upper left tiles
        CheckForWordsHelper(results, out rowTile1, out colTile1, out rowTile1Text, out colTile1Text);

        results = Physics2D.OverlapCircleAll(new Vector2(435, 585), 50); // upper middle tiles
        CheckForWordsHelper(results, out rowTile2, out colTile2, out rowTile2Text, out colTile2Text);

        results = Physics2D.OverlapCircleAll(new Vector2(610, 585), 50); // upper right tiles
        CheckForWordsHelper(results, out rowTile3, out colTile3, out rowTile3Text, out colTile3Text);

        if (rowTile1Text.text == "H" && rowTile2Text.text == "A" && rowTile3Text.text == "Y" || colTile1Text.text == "H" && colTile2Text.text == "A" && colTile3Text.text == "Y") {
            float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
            float increment = 0.2f/5; //The amount of change to apply.
            while (progress < 1)
            {
                rowTile1.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
                rowTile2.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
                rowTile3.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
                colTile1.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
                colTile2.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
                colTile3.GetComponent<Image>().color = Color.Lerp(Color.white, Color.red, progress);
                progress += increment;
                yield return new WaitForSeconds(0.02f);
            }
            word1 = true;
        } else {
            if (word1) {
                float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
                float increment = 0.2f/5; //The amount of change to apply.
                while (progress < 1)
                {
                    rowTile1.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
                    rowTile2.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
                    rowTile3.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
                    colTile1.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
                    colTile2.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
                    colTile3.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
                    currDraggedTile.GetComponent<Image>().color = Color.Lerp(Color.red, Color.white, progress);
                    progress += increment;
                    yield return new WaitForSeconds(0.02f);
                }
                word1 = false;
            }
        }
    }

    private void CheckForWordsHelper(Collider2D[] results, out GameObject rowTile, out GameObject colTile, out TMP_Text rowTileText, out TMP_Text colTileText) 
    {
        rowTile = null;
        colTile = null;
        rowTileText = null;
        colTileText = null;

        foreach (Collider2D collider in results) {
            GameObject curr = collider.gameObject;
            if (curr.tag == "Row") {
                rowTile = curr.gameObject;
                GameObject rowTileCanvas = curr.transform.GetChild(0).gameObject;
                GameObject rowTileTextObject = rowTileCanvas.transform.GetChild(0).gameObject;
                rowTileText = rowTileTextObject.GetComponent<TMP_Text>(); 
            } else if (curr.tag == "Col") {
                colTile = curr.gameObject;
                GameObject colTileCanvas = curr.transform.GetChild(0).gameObject;
                GameObject colTileTextObject = colTileCanvas.transform.GetChild(0).gameObject;
                colTileText = colTileTextObject.GetComponent<TMP_Text>(); 
            }
        }
    }
}
