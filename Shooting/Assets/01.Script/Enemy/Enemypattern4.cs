using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemypattern4 : Enemy
{

    public GameObject Projectile;
    public float ProjectileMoveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!bIsFreeze)
        {
            Move();
            StartCoroutine(ShootProjectile());
        }
        
    }

    public void Move()
    {
        transform.position -= new Vector3(0f, MoveSpeed * Time.deltaTime, 0f);
    }

    IEnumerator ShootProjectile()
    {
        
        GameObject instance = Instantiate(Projectile, this.transform.position, Quaternion.identity);
        
        Chain chain = instance.GetComponent<Chain>();
        SoundManager.instance.PlaySFX("Shoot");
        if (chain != null)
        {
            chain.MoveSpeed = ProjectileMoveSpeed;
            chain._lifeTime = 0.5f;
        }
        yield return new WaitForSeconds(10f);
    }
}
