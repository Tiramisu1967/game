using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefuelItem : BaseItem
{
    public override void OnGetItem(PlayerCharater playerCharater)
    {
        playerCharater.GetComponent<PlayerFuelSystem>().InitFuel();
    }
}
