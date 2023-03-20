using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAndShrink : MonoBehaviour
{
    public float scaleFactor = 0.1f;
    public float maxScale = 12f;
    public float minScale = 10f;
    public float scaleSpeed = 3f;
    public bool STOP = false;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (!STOP)
        {
            float newScale = Mathf.PingPong(Time.time * scaleSpeed, maxScale - minScale) + minScale;
            transform.localScale = originalScale * newScale * scaleFactor;
        }
    }
}
