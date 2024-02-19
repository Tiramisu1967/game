using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameInstance instance;

    public float GameStartTime = 0f;
    public float CurrentPlayerFuel = 100f;
    public int Score = 0;
    public int CurrentStageLevel = 1;
    public int CurrentPlayerHP = 3;
    public int CurrentPlayerWeaponLevel = 0;
    public int CurrentPlayerAddOnCount = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        GameStartTime = Time.time;
    }
}
