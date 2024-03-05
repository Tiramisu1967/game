using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkill : BaseSkill
{
    public override void Activate()
    {
        base.Activate();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in enemies)
        {
            if (obj.GetComponent<BossA>() || obj.GetComponent<BossB>())
            { Debug.Log("qqq"); return;  }
            Enemy enemy = obj?.GetComponent<Enemy>();
            if (enemy?.bIsDestroy == false) enemy?.Dead();
        }
    }
}
