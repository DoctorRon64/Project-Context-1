using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAndShrink : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ScaleOverTime(2.0f));
    }

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = gameObject.transform.localScale;
        Vector3 destinationScale = originalScale * 5.5f; // Scale the object to 150% of its original size
        float currentTime = 0.0f;

        while (currentTime <= time)
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.1f); // Wait for half a second
        currentTime = 0.0f;

        while (currentTime <= time)
        {
            gameObject.transform.localScale = Vector3.Lerp(destinationScale, originalScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.localScale = originalScale; // Set the object back to its original size

        StartCoroutine(ScaleOverTime(1.0f));
    }
}
