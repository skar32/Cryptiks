using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleSelectionScreenSlider : MonoBehaviour
{
    public Slider puzzleSlider;
    public TMP_Text puzzleTitle;

    void Update()
    {
        float sliderValue = 1 - puzzleSlider.value;
        puzzleTitle.color = new Color(puzzleTitle.color.r, puzzleTitle.color.g, puzzleTitle.color.b, sliderValue);
    }
}
