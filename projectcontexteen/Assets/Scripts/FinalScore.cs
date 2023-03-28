using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public static float finalTime;

    [SerializeField] TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            text.text = finalTime.ToString("F1");
        }
    }

    public void GetFinalTime(float time)
    {
        finalTime = time;
    }
}
