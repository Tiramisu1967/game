using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Chain : MonoBehaviour
{

    [HideInInspector]
    public float MoveSpeed = 2f;

    private Vector3 _direction;
    public float _lifeTime = 3f;

    private int chain;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * MoveSpeed * Time.deltaTime);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            seal();
        }
    }

    public void seal()
    {
        chain = Random.Range(0, 3);
        switch (chain)
        {
            case 0:
                if (GameManager.Instance.Player.Chainbomb)
                    seal();
                GameManager.Instance.Player.Chainbomb = true;
                break;
            case 1:
                if (GameManager.Instance.Player.Chainfreeze)
                    seal();
                GameManager.Instance.Player.Chainfreeze = true;
                break;
            case 2:
                if (GameManager.Instance.Player.Chainprotact)
                    seal();
                GameManager.Instance.Player.Chainprotact = true;
                break;
            case 3:
                if (GameManager.Instance.Player.Chainrepair)
                    seal();
                GameManager.Instance.Player.Chainrepair = true;
                break;
        }
    }

    

}
