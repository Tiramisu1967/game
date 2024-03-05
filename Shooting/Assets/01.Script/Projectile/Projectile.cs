using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [HideInInspector]
    public float MoveSpeed = 2f;
    
    private Vector3 _direction;
    
    public GameObject ExplodeFX;
    
    public float _lifeTime = 3f;

    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifeTime);    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * MoveSpeed * Time.deltaTime);
        
            if (IsOutOfScreen())
            {
                Destroy(gameObject);
            }
     }

        bool IsOutOfScreen()
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            return (screenPos.x < 0  || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height);
        }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnDestroy()
    {
        SoundManager.instance.PlaySFX("Explosion");
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
