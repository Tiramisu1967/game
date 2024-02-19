using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemypatten2 : Enemy
{
    
    public float AttackStopTime;
    public float MoveTime;
    public float ProjectileMoveSpeed;
    public GameObject Projectile;

    private bool _isAttack = false;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private void Update()
    {
        if (false == _isAttack && !bIsFreeze)
            Move();
    }

    IEnumerator Attack()
    {
        if (!bIsFreeze)
        {
            while (true)
            {
                if (GameManager.Instance.Player != null)
                {
                    yield return new WaitForSeconds(1f);
                    GameObject manager = GameObject.Find("Managers");
                    
                    
                    Vector3 position = GameManager.Instance.Player.transform.position;
                    Vector3 direction = position - this.transform.position;
                    direction.Normalize();

                    var projectile = Instantiate(Projectile,transform.position,Quaternion.identity);
                    projectile.GetComponent<Projectile>().SetDirection(direction);
                    projectile.GetComponent<Projectile>().MoveSpeed = ProjectileMoveSpeed;



                     
                    _isAttack = true;
                    yield return new WaitForSeconds(AttackStopTime);

                    _isAttack = false;
                    yield return new WaitForSeconds(MoveTime);
                }
            }
        }
    }

    void Move()
    {
        transform.position -= new Vector3(0f, MoveSpeed * Time.deltaTime, 0f);
    }
}
