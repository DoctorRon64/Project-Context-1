using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Color startColor, endColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(ChangeEngineColour());
    }

    private IEnumerator ChangeEngineColour()
    {
        while (spriteRenderer.color != endColor)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1)); ;
            yield return null;
        }
    }
}
