using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityItem : BaseItem
{
    public override void OnGetItem(PlayerCharater playerCharater)
    {
        playerCharater.SetInvincibility(true);
    }
}
