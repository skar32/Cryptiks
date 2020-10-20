using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private Grid grid;
    public string[] letters;
    public int columns;
    public int rows;
    private bool mouseClicked = false;
    private bool waiting = false;

    private void Start() {
        grid = new Grid(columns, rows, 10f, new Vector3(0, 0), letters);
        Camera.main.transform.position = new Vector3((columns * 10f)/2, (rows * 10f)/2, -10);
    }

    private void Update() 
    {
        if (Input.GetMouseButtonDown(0)) {
            mouseClicked = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            mouseClicked = false;
        }

        if (Input.GetAxis("Mouse X") > 0.0 || Input.GetAxis("Mouse X") < 0.0) {
            if (mouseClicked && Input.GetAxis("Mouse X") > 0.2 && !waiting) { // shifting right
                Debug.Log("right");
                waiting = true;
                grid.ShiftRight(UtilsClass.GetMouseWorldPosition());
                StartCoroutine(Wait());
            } else if (mouseClicked && Input.GetAxis("Mouse X") < -0.2 && !waiting) { // shifting left
                Debug.Log("left");
                waiting = true;
                grid.ShiftLeft(UtilsClass.GetMouseWorldPosition());
                StartCoroutine(Wait());
            }
        } else if (Input.GetAxis("Mouse Y") > 0.0 || Input.GetAxis("Mouse Y") < 0.0) {
            if (mouseClicked && Input.GetAxis("Mouse Y") > 0.2 && !waiting) { // shifting up
                Debug.Log("up");
                waiting = true;
                grid.ShiftUp(UtilsClass.GetMouseWorldPosition());
                StartCoroutine(Wait());
            } else if (mouseClicked && Input.GetAxis("Mouse Y") < -0.2 && !waiting) { // shifting down
                Debug.Log("down");
                waiting = true;
                grid.ShiftDown(UtilsClass.GetMouseWorldPosition());
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(0.3f);
        waiting = false;
    }
}
