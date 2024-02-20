using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BossB : BossA
{ 
    public GameObject mini;
    public GameObject chainseal;
    public float ChainMoveSpeed = 10.0f;

    public override void Pattern4()
    {
        Instantiate(mini, transform.position, Quaternion.identity);
        mini.transform.localScale = new Vector3(0, -4, 0);
        base.Pattern4();
    }
    public override void Pattern5()
    {
        Vector3 direction = this.transform.position - this.transform.position;
        GameObject instance = Instantiate(chainseal, this.transform.position, Quaternion.identity);
        Chain chain = instance.GetComponent<Chain>();
        SoundManager.instance.PlaySFX("Shoot");
        if (chain != null)
        {
            chain.MoveSpeed = ProjectileMoveSpeed;
            chain.SetDirection(direction.normalized);
        }
        base.Pattern4();
    }
}
