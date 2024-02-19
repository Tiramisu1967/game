using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuelSystem : MonoBehaviour
{
    public float Fuel = 100f;
    public float MaxFuel = 100f;
    public float FuelDecreaseSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Fuel = GameInstance.instance.CurrentPlayerFuel;
    }
    public void InitFuel()
    {
        Fuel = MaxFuel;
        GameInstance.instance.CurrentPlayerFuel = Fuel;
    }
    // Update is called once per frame
    void Update()
    {
        if (Fuel > MaxFuel)
            Fuel = MaxFuel;
        Fuel -= FuelDecreaseSpeed *Time.deltaTime;
        if (Fuel <= 0)
        {
            Destroy(this.gameObject);
        }
        GameInstance.instance.CurrentPlayerFuel = Fuel;
    }
}
