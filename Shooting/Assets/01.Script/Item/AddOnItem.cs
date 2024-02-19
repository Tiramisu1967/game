using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AddOnItem : BaseItem
{


    public GameObject Prefab;
    public override void OnGetItem(PlayerCharater playerCharater)
    {
        base.OnGetItem(playerCharater);
        if (GameInstance.instance.CurrentPlayerAddOnCount < 2)
        {
            SpawnAddOn(Prefab, playerCharater.AddOnPos[GameInstance.instance.CurrentPlayerAddOnCount]);
            GameInstance.instance.CurrentPlayerAddOnCount += 1;
        }

    }


    public static void SpawnAddOn(GameObject Add, Transform transform)
    {
        GameObject instance = Instantiate(Add, transform.position, Quaternion.identity);
        instance.GetComponent<AddOn>().PlayerPos = transform;
    }
}
