using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EvenGridSnapHelper : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private float vertical;
    private float horizontal;
    private bool scrollUp;
    private bool scrollRight;
    public EvenGridSnap evenGridSnap;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this.gameObject.tag == "ColumnScroll") {
            vertical = eventData.position.y - eventData.pressPosition.y;
            if (Mathf.Sign(vertical) == 1) {
                scrollUp = true;
            } else {
                scrollUp = false;
            }
        } else if (this.gameObject.tag == "RowScroll") {
            horizontal = eventData.position.x - eventData.pressPosition.x;
            if (Mathf.Sign(vertical) == 1) {
                scrollRight = true;
            } else {
                scrollRight = false;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (this.gameObject.tag == "ColumnScroll") {
            evenGridSnap.SnapAfterScrollY(scrollUp);
        } else if (this.gameObject.tag == "RowScroll") {
            evenGridSnap.SnapAfterScrollX(scrollRight);
        }
    }
}
