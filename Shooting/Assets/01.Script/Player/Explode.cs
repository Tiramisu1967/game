using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private Animator _animator;
    private bool biscool;
    private float coolcount;

    void Start()
    {
        Destroy(this.gameObject, 1f);
        Debug.Log(111);
    }
    private void Update()
    {
        if (biscool)
        {
            coolcount += Time.deltaTime;
            if(coolcount == 1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
