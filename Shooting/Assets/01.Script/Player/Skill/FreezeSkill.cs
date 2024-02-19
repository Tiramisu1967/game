using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSkill : BaseSkill
{
    public override void Activate()
    {
        base.Activate();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in enemies)
        {
            if (obj != null)
            {
                if (obj.GetComponent<BossA>())
                    return;
                Debug.Log("!!!");
                Enemy enemy = obj.GetComponent<Enemy>();
                if (enemy != null)
                {

                    Debug.Log("?");
                    enemy.bIsFreeze = true;
                }
            }
        }
    }
}
