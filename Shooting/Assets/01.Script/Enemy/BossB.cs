using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BossB : BossA
{ 
    public GameObject mini;
    public override void Pattern4()
    {
        Instantiate(mini, transform.position, Quaternion.identity);
        mini.transform.localScale = new Vector3(0, -4, 0);

    }
}
