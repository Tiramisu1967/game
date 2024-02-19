using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PrimarySkill : BaseSkill
{
    public float ProjectileMoveSpeed;
    public GameObject Projectile;

    private Weapon[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        CooldownTime = 0.2f;
        Debug.Log(CooldownTime);

        weapons = new Weapon[4];

        weapons[0] = new Level1Weapon();
        weapons[1] = new Level2Weapon();
        weapons[2] = new Level3Weapon();
        weapons[3] = new Level4Weapon();
    
    }

    public override void Activate()
    {
        base.Activate();
        weapons[GameInstance.instance.CurrentPlayerWeaponLevel].Activate(this, GameManager.Instance.Player);
    }

    public void ShootProjectile(Vector3 position, Vector3 direction)
    {
        GameObject instance = Instantiate(Projectile, position, Quaternion.identity);
        Projectile projectile = instance.GetComponent<Projectile>();
        
        if(projectile != null)
        {
            projectile.MoveSpeed = ProjectileMoveSpeed;
            projectile.SetDirection(direction.normalized);
        }
    }
}

public interface Weapon
{
    void Activate(PrimarySkill primarySkill, PlayerCharater playerCharater);
}

public class Level1Weapon : Weapon
{
    public void Activate(PrimarySkill primarySkill, PlayerCharater playerCharater)
    {
        Vector3 position = GameManager.Instance.Player.transform.position;
        primarySkill.ShootProjectile(position, Vector3.up);
    }
}

public class Level2Weapon : Weapon
{
    public void Activate(PrimarySkill primarySkill, PlayerCharater playerCharater)
    {
        Vector3 position = GameManager.Instance.Player.transform.position;
        position.x -= 0.1f;
        for(int i = 0; i < 2; i++)
        {
            primarySkill.ShootProjectile(position, Vector3.up);
            position.x += 0.2f;
        }
    }
}

public class Level3Weapon : Weapon
{
    public void Activate(PrimarySkill primarySkill, PlayerCharater playerCharater)
    {
        Vector3 position = GameManager.Instance.Player.transform.position;
        primarySkill.ShootProjectile(position, Vector3.up);
        primarySkill.ShootProjectile(position, new Vector3(-0.3f,1,0));
        primarySkill.ShootProjectile(position, new Vector3(0.3f,1,0));

    }
}
public class Level4Weapon : Weapon
{
    public void Activate(PrimarySkill primarySkill, PlayerCharater playerCharater)
    {
        Vector3 position = GameManager.Instance.Player.transform.position;
        for(int i = 0; i < 180; i += 10)
        {
            float angle = i * Mathf.Deg2Rad;
            Vector3 direction= new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            primarySkill.ShootProjectile(position, direction);
        }
        GameInstance.instance.CurrentPlayerWeaponLevel = 3;
    }
}

