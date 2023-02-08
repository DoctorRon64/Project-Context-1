using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    public float Speed;
    public float MaxSpeed;
    public float MinSpeed;
    public bool FlipCamera;

    // Update is called once per frame
    void Update()
    {
        float offset = -10;

        if(FlipCamera)
        {
            switch (Target.GetComponent<PlayerController>().transform.localScale.y)
            {
                case > 0:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case < 0:
                    transform.rotation = Quaternion.Euler(180, 0, 0);
                    offset = 10;
                    break;
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        Vector3 target = new Vector3 (Target.transform.position.x, Target.transform.position.y, offset);

        Speed = MinSpeed * Vector2.Distance(transform.position, target) / 2f + MinSpeed;

        if(Speed > MaxSpeed) Speed = MaxSpeed;

        transform.position = Vector2.MoveTowards(transform.position, target, Speed * (Time.deltaTime/2));

        transform.position = new Vector3(transform.position.x, transform.position.y, offset);
    }
}
