using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "EnemyLeft" || collision.tag == "EnemyRight" || collision.tag == "Boss" || collision.tag == "Boss2" || collision.tag == "Boss3")
        {

            if (!collision.GetComponent<enemy>().IsDeath)
            {
                collision.gameObject.SendMessage("HitUltimate");
                //GameObject.Destroy(this.gameObject);//撞到飞机后子弹消失 
            }
        }
    }
}
