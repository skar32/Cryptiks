using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid 
{
    private int columns;
    private int rows;
    private float cellSize;
    private Vector3 originPosition;
    private string[,] gridArray;
    private TextMesh[,] debugTextArray;
    private string[] letters;

    public Grid(int columns, int rows, float cellSize, Vector3 originPosition, string[] letters) {
        this.columns = columns;
        this.rows = rows;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        this.letters = letters;
        gridArray = new string[columns, rows];
        debugTextArray = new TextMesh[columns, rows];

         int count = 0;
         for (int x = 0; x < gridArray.GetLength(0); x++ ) {
            for (int y = 0; y < gridArray.GetLength(1); y++ ) {
                gridArray[x, y] = letters[count];
                count++;
            }
        }
        
        count = 0;
        for (int row = 0; row < gridArray.GetLength(0); row++ ) {
            for (int col = 0; col < gridArray.GetLength(1); col++ ) {
                debugTextArray[row, col] = UtilsClass.CreateWorldText(letters[count], null, GetWorldPosition(row, col) + new Vector3(cellSize, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                count++;
                Debug.DrawLine(GetWorldPosition(row, col), GetWorldPosition(row, col + 1), Color.white, 10000f);
                Debug.DrawLine(GetWorldPosition(row, col), GetWorldPosition(row + 1, col), Color.white, 10000f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, rows), GetWorldPosition(columns, rows), Color.white, 10000f);
        Debug.DrawLine(GetWorldPosition(columns, 0), GetWorldPosition(columns, rows), Color.white, 10000f);
    }

    public Vector3 GetWorldPosition(float x, float y) {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetValue(int x, int y, string value) {
        gridArray[x, y] = value;
        debugTextArray[x, y].text = gridArray[x, y].ToString();
    }

    public void SetValue(Vector3 worldPosition, string value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public void ShiftRight(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        string last = gridArray[columns - 1, y];
        for (int i = columns - 2; i >= 0; i--) {
            string curr = gridArray[i, y];
            SetValue(i + 1, y, curr);
        }
        SetValue(0, y, last);
    }

    public void ShiftLeft(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        string first = gridArray[0, y];
        for (int i = 0; i < columns - 1; i++) {
            string curr = gridArray[i + 1, y];
            SetValue(i, y, curr);
        }
        SetValue(columns - 1, y, first);
    }

    public void ShiftUp(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        string last = gridArray[x, rows - 1];
        for (int j = rows - 2; j >= 0; j--) {
            string curr = gridArray[x, j];
            SetValue(x, j + 1, curr);
        }
        SetValue(x, 0, last);
    }

    public void ShiftDown(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        string first = gridArray[x, 0];
        for (int j = 0; j < rows - 1; j++) {
            string curr = gridArray[x, j + 1];
            SetValue(x, j, curr);
        }
        SetValue(x, rows - 1, first);
    }

    public string GetValue(int x, int y) {
        return gridArray[x, y];
    }

    public string GetValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

}
