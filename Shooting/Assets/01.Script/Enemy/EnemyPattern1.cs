using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatten : Enemy
{
    
    public float Amplitude;

    private bool movingUP = true;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bIsFreeze)
        {
            float verticaIMovement = MoveSpeed * Time.deltaTime;

            if (movingUP && transform.position.x < startPosition.x + Amplitude)
            {
                transform.position += new Vector3(verticaIMovement, 0f, 0f);
            }
            else if (movingUP && transform.position.x < startPosition.x + Amplitude)
            {
                transform.position -= new Vector3(verticaIMovement, 0f, 0f);
            }
            else
            {
                movingUP = !movingUP;
            }

            transform.position -= new Vector3(0f, MoveSpeed * Time.deltaTime, 0f);
        }
    }
}