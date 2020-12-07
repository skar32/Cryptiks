using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    RectTransform wheel;
    public float rotationSpeed;

    void Awake()
    {
        wheel = GetComponent<RectTransform>();
    }

    void Update()
    {
        wheel.Rotate(new Vector3(0, 0, 1) * (rotationSpeed * Time.deltaTime));
    }
}
