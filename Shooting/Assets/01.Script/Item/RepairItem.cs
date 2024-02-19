using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairItem : BaseItem
{
    public override void OnGetItem(PlayerCharater playerCharater)
    {
        playerCharater.GetComponent<PlayerHPSystem>().InitHealth();
    }
}
