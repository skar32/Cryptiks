 using UnityEngine;
 using System.Collections;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using TMPro;

public class Scroller4x4 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject rows, columns;
    public ScrollRect OtherScrollRect1, OtherScrollRect2, OtherScrollRect3, OtherScrollRect4;
    public GameObject Tile11, Tile12, Tile13, Tile14, Tile21, Tile22, Tile23, Tile24, Tile31, Tile32, Tile33, Tile34, Tile41, Tile42, Tile43, Tile44;
    private ScrollRect _myScrollRect;
    public static bool scrollOther; //This tracks if the other one should be scrolling instead of the current one.
    private bool scrollOtherHorizontally; //This tracks whether the other one should scroll horizontally or vertically.
    private bool scroll1, scroll2, scroll3, scroll4;
    public HighlightingManager4x4 highlightingScript;

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

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.pressPosition), Vector2.zero, 10.0f, LayerMask.GetMask("TileDetector"));

        float xPos = hit.collider.gameObject.GetComponent<RectTransform>().localPosition.x;
        float yPos = hit.collider.gameObject.GetComponent<RectTransform>().localPosition.y;

        Debug.Log("X: " + xPos);
        Debug.Log("Y: " + yPos);

        if (scrollOtherHorizontally) // if the other scroll rect should be scrolled horizontally
        {
            if (horizontal > vertical)
            {
                scrollOther = true;
                Debug.Log("Switching to horizontal");
                _myScrollRect.enabled = false; //disable the current scroll rect so it doesnt move.

                UpdateRowTiles(); // update the row tiles with the right letters before switching to it

                rows.GetComponent<CanvasGroup>().alpha = 1f;
                rows.GetComponent<CanvasGroup>().blocksRaycasts = true;
                columns.GetComponent<CanvasGroup>().alpha = 0f;
                columns.GetComponent<CanvasGroup>().blocksRaycasts = false;

                if (yPos == -300) { // if row 1 should be scrolled
                    ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect1.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row1");
                    scroll1 = true;
                } else if (yPos == -100) { // if row 2 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect2.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row2");
                    scroll2 = true;
                } else if (yPos == 100) { // if row 3 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect3.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row3");
                    scroll3 = true;
                } else if (yPos == 300) { // if row 4 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect4.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row4");
                    scroll4 = true;
                }
            }
        }
        else if (vertical > horizontal) // if the other scroll rect should be scrolled vertically
        {
            scrollOther = true;
            Debug.Log("Switching to vertical");
            _myScrollRect.enabled = false; //disable the current scroll rect so it doesnt move.

            UpdateColumnTiles(); // update the column tiles with the right letters before switching to it

            rows.GetComponent<CanvasGroup>().alpha = 0f;
            rows.GetComponent<CanvasGroup>().blocksRaycasts = false;
            columns.GetComponent<CanvasGroup>().alpha = 1f;
            columns.GetComponent<CanvasGroup>().blocksRaycasts = true;

            if (xPos == -300) { // if col 1 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect1.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col1");
                scroll1 = true;
            } else if (xPos == -100) { // if col 2 should be scrolled 
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect2.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col2");
                scroll2 = true;
            } else if (xPos == 100) { // if col 3 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect3.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col3");
                scroll3 = true;
            } else if (xPos == 300) { // if col 4 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect4.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col4");
                scroll4 = true;
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
            } else if (scroll4) {
                ExecuteEvents.Execute<IEndDragHandler> (OtherScrollRect4.gameObject, eventData, ExecuteEvents.endDragHandler);
                scroll4 = false;
            }
        }

        if (rows.GetComponent<CanvasGroup>().alpha == 0f) {
            UpdateRowTiles();
        } else if (columns.GetComponent<CanvasGroup>().alpha == 0f) {
            UpdateColumnTiles();
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
            } else if (scroll4) {
            	//Debug.Log("scrolling");
                OtherScrollRect4.OnDrag(eventData);
            }
        }
    }

    public void UpdateRowTiles() // once a mouse drag ends and a shift is made in the column grid, update the positions of the letters in the row grid underneath
    {
        Debug.Log("updating row tiles");
        
        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile11.transform.position.x, Tile11.transform.position.y), 0.5f); // Tile11
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile12.transform.position.x, Tile12.transform.position.y), 0.5f); // Tile12
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile13.transform.position.x, Tile13.transform.position.y), 0.5f); // Tile13
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile14.transform.position.x, Tile14.transform.position.y), 0.5f); // Tile14
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile21.transform.position.x, Tile21.transform.position.y), 0.5f); // Tile21
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile22.transform.position.x, Tile22.transform.position.y), 0.5f); // Tile22
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile23.transform.position.x, Tile23.transform.position.y), 0.5f); // Tile23
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile24.transform.position.x, Tile24.transform.position.y), 0.5f); // Tile24
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile31.transform.position.x, Tile31.transform.position.y), 0.5f); // Tile31
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile32.transform.position.x, Tile32.transform.position.y), 0.5f); // Tile32
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile33.transform.position.x, Tile33.transform.position.y), 0.5f); // Tile33
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile34.transform.position.x, Tile34.transform.position.y), 0.5f); // Tile34
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile41.transform.position.x, Tile41.transform.position.y), 0.5f); // Tile41
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile42.transform.position.x, Tile42.transform.position.y), 0.5f); // Tile42
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile43.transform.position.x, Tile43.transform.position.y), 0.5f); // Tile43
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile44.transform.position.x, Tile44.transform.position.y), 0.5f); // Tile44
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;
    }

    public void UpdateColumnTiles() // once a mouse drag ends and a shift is made in the row grid, update the positions of the letters in the column grid underneath
    {
        Debug.Log("updating column tiles");

        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile11.transform.position.x, Tile11.transform.position.y), 0.5f); // Tile11
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile12.transform.position.x, Tile12.transform.position.y), 0.5f); // Tile12
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile13.transform.position.x, Tile13.transform.position.y), 0.5f); // Tile13
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile14.transform.position.x, Tile14.transform.position.y), 0.5f); // Tile14
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile21.transform.position.x, Tile21.transform.position.y), 0.5f); // Tile21
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile22.transform.position.x, Tile22.transform.position.y), 0.5f); // Tile22
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile23.transform.position.x, Tile23.transform.position.y), 0.5f); // Tile23
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile24.transform.position.x, Tile24.transform.position.y), 0.5f); // Tile24
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile31.transform.position.x, Tile31.transform.position.y), 0.5f); // Tile31
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile32.transform.position.x, Tile32.transform.position.y), 0.5f); // Tile32
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile33.transform.position.x, Tile33.transform.position.y), 0.5f); // Tile33
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile34.transform.position.x, Tile34.transform.position.y), 0.5f); // Tile34
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile41.transform.position.x, Tile41.transform.position.y), 0.5f); // Tile41
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile42.transform.position.x, Tile42.transform.position.y), 0.5f); // Tile42
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile43.transform.position.x, Tile43.transform.position.y), 0.5f); // Tile43
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile44.transform.position.x, Tile44.transform.position.y), 0.5f); // Tile44
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;
    }

    private void FindText(Collider2D[] results, out TMP_Text rowText, out TMP_Text colText) // helper method for updating tile text after mouse drag ends and a shift occurs
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
}
