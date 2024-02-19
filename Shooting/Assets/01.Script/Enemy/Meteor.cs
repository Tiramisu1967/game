using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    [HideInInspector]
    public float MoveSpeed = 2f;

    private Vector3 _direction;

    public GameObject ExplodeFX;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * MoveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }



}
