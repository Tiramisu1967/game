using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Chain : Projectile
{
    private int chain;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ddddddddddd2222");
        if (collision.tag == "Player")
        {
            Debug.Log("dddd");
            seal();
            
        }
    }

    public void seal()
    {
        PlayerUI ui = GameManager.Instance.Player.GetComponent<PlayerUI>();
        chain = Random.Range(0, 3);
        Debug.Log(chain);
        if (GameManager.Instance.Player.Chainbomb || GameManager.Instance.Player.Chainfreeze || GameManager.Instance.Player.Chainprotact || GameManager.Instance.Player.Chainrepair)
        { Destroy(gameObject); Debug.Log("전부 잠금"); }
            switch (chain)
        {
            case 0:
                
                GameManager.Instance.Player.Chainbomb = true;
                ui.UpdateChain(chain);
                Debug.Log(chain);
                Destroy(gameObject);
                break;
            case 1:
                
                GameManager.Instance.Player.Chainfreeze = true;
                ui.UpdateChain(chain);
                Debug.Log(chain);
                Destroy(gameObject);
                break;
            case 2:
                
                GameManager.Instance.Player.Chainprotact = true;
                ui.UpdateChain(chain);
                Debug.Log(chain);
                Destroy(gameObject);
                break;
            case 3:
                
                GameManager.Instance.Player.Chainrepair = true;
                ui.UpdateChain(chain);
                Debug.Log(chain);
                Destroy(gameObject);
                break;
        }
    }

    

}
