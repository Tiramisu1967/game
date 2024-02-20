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
        Move();
        StartCoroutine(ShootProjectile(this.transform.position));
    }

    public void Move()
    {
        transform.position -= new Vector3(0f, MoveSpeed * Time.deltaTime, 0f);
    }

    IEnumerator ShootProjectile(Vector3 position)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject instance = Instantiate(Projectile, position, Quaternion.identity);
        Projectile projectile = instance.GetComponent<Projectile>();
        SoundManager.instance.PlaySFX("Shoot");
        if (projectile != null)
        {
            projectile.MoveSpeed = ProjectileMoveSpeed;
            projectile._lifeTime = 0.5f;
        }
       
    }
}
