using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemypattern3 : Enemy
{
    // Start is called before the first frame update
    public GameObject Projectile;
    public float ProjectileMoveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (!bIsFreeze)
        {
            Move();
            StartCoroutine(Pattern());
        }
       
    }

    public void Move()
    {
        transform.position -= new Vector3(0f, MoveSpeed * Time.deltaTime, 0f);
    }
    public void ShootProjectile(Vector3 position, Vector3 direction)
    {
        GameObject instance = Instantiate(Projectile, position, Quaternion.identity);
        Projectile projectile = instance.GetComponent<Projectile>();
        SoundManager.instance.PlaySFX("Shoot");
        if (projectile != null)
        {
            projectile.MoveSpeed = ProjectileMoveSpeed;
            projectile.SetDirection(direction.normalized);
        }
    }
    IEnumerator Pattern()
    {
        yield return new WaitForSeconds(5f);
        Vector3 position = this.transform.position;
        for (int i = 0; i < 370; i += 10)
        {
            float angle = i * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            ShootProjectile(position, direction);
        }
        
    }
}
