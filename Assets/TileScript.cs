using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using TMPro;

public class TileScript : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData pointerEventData) 
    {
        Scroller.currDraggedTile = this.gameObject;
    }
}
