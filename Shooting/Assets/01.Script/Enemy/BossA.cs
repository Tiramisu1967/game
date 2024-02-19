using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class BossA : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject vim;
    public float ProjectileMoveSpeed = 5.0f;
    public float FireRate = 2.0f;
    public float MoveSpeed = 2.0f;
    public float MoveDistance = 5.0f;

    private int _currentPatternIndex = 0;
    private bool _movingRight = true;
    private bool _bCanMove = false;
    private Vector3 _originPosition;

    private void Start()
    {
        Enemy enemy = GetComponent<Enemy>();
        enemy.bMustSpawnItem = true;
        _originPosition = transform.position; 
        StartCoroutine(MoveDownAndStartPattern()); 
    }

    private IEnumerator MoveDownAndStartPattern()
    {
        while (transform.position.y > _originPosition.y - 3f)
        {
            transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
            yield return null;
        }
        NextPattern();
        _bCanMove = true;
    }

    private void Update()
    {
        
        if (_bCanMove)
            MoveSideways();
    }

    private void NextPattern()
    {
      
        _currentPatternIndex = Random.Range(0, 2);
        Debug.Log(_currentPatternIndex);
    
        switch (_currentPatternIndex)
        {
            case 0:
                Pattern1();
                break;
            case 1:
                StartCoroutine(Pattern2());
                break;
            case 2:
                Pattern3();
                break;
        }
    }


    private void MoveSideways()
    {
        if (_movingRight)
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
            if (transform.position.x > MoveDistance)
            {
                _movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);
            if (transform.position.x < -MoveDistance)
            {
                _movingRight = true;
            }
        }
    }

    private void StartMovingSideways()
    {
        StartCoroutine(MovingSidewaysRoutine());
    }

    private IEnumerator MovingSidewaysRoutine()
    {
        while (true)
        {
            MoveSideways();
            yield return null;
        }
    }

    public void ShootProjectile(Vector3 position, Vector3 direction)
    {
        GameObject instance = Instantiate(Projectile, position, Quaternion.identity);
        Projectile projectile = instance.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.MoveSpeed = ProjectileMoveSpeed;
            projectile.SetDirection(direction.normalized);
        }
    }

    private void Pattern1()
    {
        Vector3 position = this.transform.position;
            for (int i = 0; i < 370; i += 10)
            {
                float angle = i * Mathf.Deg2Rad;
                Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                ShootProjectile(position, direction);
            }
        NextPattern();

    }

    IEnumerator Pattern2()
    {
        Vector3 position = this.transform.position;
        for (int n = 0; n < 5; n++)
        {
            for (int i = 0; i < 370; i += 10)
            {
                float angle = i * Mathf.Deg2Rad;
                Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
                ShootProjectile(position, direction);
            }
            yield return new WaitForSeconds(1f);
        }
        NextPattern();
    }

    public void Pattern3()
    {
        if(this.GetComponent<Enemy>().Health == 1)
        {
            this.GetComponent<Enemy>().Health += 1;
        }
        NextPattern();
    }

    private void OnDestroy()
    {
        GameManager.Instance.StageClear();
    }

}
