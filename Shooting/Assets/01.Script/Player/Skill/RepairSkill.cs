using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSkill : BaseSkill
{
    public override void Activate()
    {
        base.Activate();

        PlayerHPSystem system = GameManager.Instance.Player.GetComponent<PlayerHPSystem>();
        PlayerFuelSystem Fuelsystme = GameManager.Instance.Player.GetComponent<PlayerFuelSystem>();
        if (system != null)
        {
            if (Fuelsystme.Fuel >= 11)
            {
                if (system.Health < system.MaxHealth)
                {
                    Fuelsystme.Fuel -= 10;
                    system.Health += 1;
                }
                else
                {
                    Debug.Log("체력이 이미 최대입니다.");
                }
            }
            else
            {
                Debug.Log("연료 부족!");
            }
        }
    }
}
