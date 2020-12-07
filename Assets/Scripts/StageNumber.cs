using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNumber : MonoBehaviour
{
    private int stageNumber = 0;

    public void SetStageNumber(int newStageNumber)
    {
        stageNumber = newStageNumber;
    }

    public int GetStageNumber()
    {
        return stageNumber;
    }
}
