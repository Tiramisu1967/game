using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protactile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")
            && !GameManager.Instance.Player.Invincibility
            && !GameManager.Instance.bStageCleared
            && !collision.GetComponent<BossA>()
            && !collision.GetComponent<BossB>())
        {
            Destroy(collision.gameObject);
        }
    }
    
}
