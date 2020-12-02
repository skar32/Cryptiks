using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientController : MonoBehaviour
{
    [SerializeField]
    Gradient gradient;
    [SerializeField]
    float duration;
    float t = 0f;

    void Update() 
    {
        float value = Mathf.Lerp(0f, 1f, t);
        t += Time.deltaTime / duration;
        Color color = gradient.Evaluate(value);
        GetComponent<Image>().color = color;
    }
}
