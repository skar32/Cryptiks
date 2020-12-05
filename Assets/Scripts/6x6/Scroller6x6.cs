 using UnityEngine;
 using System.Collections;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using TMPro;

public class Scroller6x6 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject rows, columns;
    public ScrollRect OtherScrollRect1, OtherScrollRect2, OtherScrollRect3, OtherScrollRect4, OtherScrollRect5, OtherScrollRect6;
    public GameObject Tile11, Tile12, Tile13, Tile14, Tile15, Tile16, Tile21, Tile22, Tile23, Tile24, Tile25, Tile26, Tile31, Tile32, Tile33, Tile34, Tile35, Tile36, Tile41, Tile42, Tile43, Tile44, Tile45, Tile46, Tile51, Tile52, Tile53, Tile54, Tile55, Tile56, Tile61, Tile62, Tile63, Tile64, Tile65, Tile66;
    private ScrollRect _myScrollRect;
    public static bool scrollOther; //This tracks if the other one should be scrolling instead of the current one.
    private bool scrollOtherHorizontally; //This tracks whether the other one should scroll horizontally or vertically.
    private bool scroll1, scroll2, scroll3, scroll4, scroll5, scroll6;
    public HighlightingManager6x6 highlightingScript;

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

                if (yPos == 335) { // if row 1 should be scrolled
                    ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect1.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row1");
                    scroll1 = true;
                } else if (yPos == 200) { // if row 2 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect2.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row2");
                    scroll2 = true;
                } else if (yPos == 65) { // if row 3 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect3.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row3");
                    scroll3 = true;
                } else if (yPos == -65) { // if row 4 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect4.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row4");
                    scroll4 = true;
                } else if (yPos == -200) { // if row 5 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect5.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row5");
                    scroll5 = true;
                } else if (yPos == -335) { // if row 6 should be scrolled
                     ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect6.gameObject, eventData, ExecuteEvents.beginDragHandler);
                    //Debug.Log("row6");
                    scroll6 = true;
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

            if (xPos == -336) { // if col 1 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect1.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col1");
                scroll1 = true;
            } else if (xPos == -201) { // if col 2 should be scrolled 
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect2.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col2");
                scroll2 = true;
            } else if (xPos == -66) { // if col 3 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect3.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col3");
                scroll3 = true;
            } else if (xPos == 68) { // if col 4 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect4.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col4");
                scroll4 = true;
            } else if (xPos == 201) { // if col 5 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect5.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col5");
                scroll5 = true;
            } else if (xPos == 333) { // if col 6 should be scrolled
                ExecuteEvents.Execute<IBeginDragHandler> (OtherScrollRect6.gameObject, eventData, ExecuteEvents.beginDragHandler);
                //Debug.Log("col6");
                scroll6 = true;
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
            } else if (scroll5) {
                ExecuteEvents.Execute<IEndDragHandler> (OtherScrollRect5.gameObject, eventData, ExecuteEvents.endDragHandler);
                scroll5 = false;
            } else if (scroll6) {
                ExecuteEvents.Execute<IEndDragHandler> (OtherScrollRect6.gameObject, eventData, ExecuteEvents.endDragHandler);
                scroll6 = false;
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
            } else if (scroll5) {
            	//Debug.Log("scrolling");
                OtherScrollRect5.OnDrag(eventData);
            } else if (scroll6) {
            	//Debug.Log("scrolling");
                OtherScrollRect6.OnDrag(eventData);
            }
        }
    }

    public void UpdateRowTiles() // once a mouse drag ends and a shift is made in the column grid, update the positions of the letters in the row grid underneath
    {
        Debug.Log("updating row tiles");
        
        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile11.transform.position.x, Tile11.transform.position.y), 0.1f); // Tile11
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile12.transform.position.x, Tile12.transform.position.y), 0.1f); // Tile12
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile13.transform.position.x, Tile13.transform.position.y), 0.1f); // Tile13
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile14.transform.position.x, Tile14.transform.position.y), 0.1f); // Tile14
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile15.transform.position.x, Tile15.transform.position.y), 0.1f); // Tile15
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile16.transform.position.x, Tile16.transform.position.y), 0.1f); // Tile16
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile21.transform.position.x, Tile21.transform.position.y), 0.1f); // Tile21
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile22.transform.position.x, Tile22.transform.position.y), 0.1f); // Tile22
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile23.transform.position.x, Tile23.transform.position.y), 0.1f); // Tile23
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile24.transform.position.x, Tile24.transform.position.y), 0.1f); // Tile24
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile25.transform.position.x, Tile25.transform.position.y), 0.1f); // Tile25
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile26.transform.position.x, Tile26.transform.position.y), 0.1f); // Tile26
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile31.transform.position.x, Tile31.transform.position.y), 0.1f); // Tile31
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile32.transform.position.x, Tile32.transform.position.y), 0.1f); // Tile32
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile33.transform.position.x, Tile33.transform.position.y), 0.1f); // Tile33
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile34.transform.position.x, Tile34.transform.position.y), 0.1f); // Tile34
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile35.transform.position.x, Tile35.transform.position.y), 0.1f); // Tile35
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile36.transform.position.x, Tile36.transform.position.y), 0.1f); // Tile36
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile41.transform.position.x, Tile41.transform.position.y), 0.1f); // Tile41
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile42.transform.position.x, Tile42.transform.position.y), 0.1f); // Tile42
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile43.transform.position.x, Tile43.transform.position.y), 0.1f); // Tile43
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile44.transform.position.x, Tile44.transform.position.y), 0.1f); // Tile44
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile45.transform.position.x, Tile45.transform.position.y), 0.1f); // Tile45
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile46.transform.position.x, Tile46.transform.position.y), 0.1f); // Tile46
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile51.transform.position.x, Tile51.transform.position.y), 0.1f); // Tile51
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile52.transform.position.x, Tile52.transform.position.y), 0.1f); // Tile52
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile53.transform.position.x, Tile53.transform.position.y), 0.1f); // Tile53
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile54.transform.position.x, Tile54.transform.position.y), 0.1f); // Tile54
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile55.transform.position.x, Tile55.transform.position.y), 0.1f); // Tile55
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile56.transform.position.x, Tile56.transform.position.y), 0.1f); // Tile56
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile61.transform.position.x, Tile61.transform.position.y), 0.1f); // Tile61
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile62.transform.position.x, Tile62.transform.position.y), 0.1f); // Tile62
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile63.transform.position.x, Tile63.transform.position.y), 0.1f); // Tile63
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile64.transform.position.x, Tile64.transform.position.y), 0.1f); // Tile64
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile65.transform.position.x, Tile65.transform.position.y), 0.1f); // Tile65
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile66.transform.position.x, Tile66.transform.position.y), 0.1f); // Tile66
        FindText(results, out rowTileText, out colTileText);
        rowTileText.text = colTileText.text;
    }

    public void UpdateColumnTiles() // once a mouse drag ends and a shift is made in the row grid, update the positions of the letters in the column grid underneath
    {
        Debug.Log("updating column tiles");

        Collider2D[] results;
        TMP_Text rowTileText = null;
        TMP_Text colTileText = null;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile11.transform.position.x, Tile11.transform.position.y), 0.1f); // Tile11
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile12.transform.position.x, Tile12.transform.position.y), 0.1f); // Tile12
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile13.transform.position.x, Tile13.transform.position.y), 0.1f); // Tile13
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile14.transform.position.x, Tile14.transform.position.y), 0.1f); // Tile14
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile15.transform.position.x, Tile15.transform.position.y), 0.1f); // Tile15
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile16.transform.position.x, Tile16.transform.position.y), 0.1f); // Tile16
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile21.transform.position.x, Tile21.transform.position.y), 0.1f); // Tile21
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile22.transform.position.x, Tile22.transform.position.y), 0.1f); // Tile22
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile23.transform.position.x, Tile23.transform.position.y), 0.1f); // Tile23
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile24.transform.position.x, Tile24.transform.position.y), 0.1f); // Tile24
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile25.transform.position.x, Tile25.transform.position.y), 0.1f); // Tile25
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile26.transform.position.x, Tile26.transform.position.y), 0.1f); // Tile26
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile31.transform.position.x, Tile31.transform.position.y), 0.1f); // Tile31
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile32.transform.position.x, Tile32.transform.position.y), 0.1f); // Tile32
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile33.transform.position.x, Tile33.transform.position.y), 0.1f); // Tile33
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile34.transform.position.x, Tile34.transform.position.y), 0.1f); // Tile34
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile35.transform.position.x, Tile35.transform.position.y), 0.1f); // Tile35
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile36.transform.position.x, Tile36.transform.position.y), 0.1f); // Tile36
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile41.transform.position.x, Tile41.transform.position.y), 0.1f); // Tile41
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile42.transform.position.x, Tile42.transform.position.y), 0.1f); // Tile42
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile43.transform.position.x, Tile43.transform.position.y), 0.1f); // Tile43
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile44.transform.position.x, Tile44.transform.position.y), 0.1f); // Tile44
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile45.transform.position.x, Tile45.transform.position.y), 0.1f); // Tile45
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile46.transform.position.x, Tile46.transform.position.y), 0.1f); // Tile46
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile51.transform.position.x, Tile51.transform.position.y), 0.1f); // Tile51
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile52.transform.position.x, Tile52.transform.position.y), 0.1f); // Tile52
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile53.transform.position.x, Tile53.transform.position.y), 0.1f); // Tile53
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile54.transform.position.x, Tile54.transform.position.y), 0.1f); // Tile54
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile55.transform.position.x, Tile55.transform.position.y), 0.1f); // Tile55
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile56.transform.position.x, Tile56.transform.position.y), 0.1f); // Tile56
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile61.transform.position.x, Tile61.transform.position.y), 0.1f); // Tile61
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile62.transform.position.x, Tile62.transform.position.y), 0.1f); // Tile62
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile63.transform.position.x, Tile63.transform.position.y), 0.1f); // Tile63
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile64.transform.position.x, Tile64.transform.position.y), 0.1f); // Tile64
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile65.transform.position.x, Tile65.transform.position.y), 0.1f); // Tile65
        FindText(results, out rowTileText, out colTileText);
        colTileText.text = rowTileText.text;

        results = Physics2D.OverlapCircleAll(new Vector2(Tile66.transform.position.x, Tile66.transform.position.y), 0.1f); // Tile66
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
