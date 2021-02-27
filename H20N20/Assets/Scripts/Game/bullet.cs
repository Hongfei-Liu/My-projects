using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public bool isPlayer = true;    //该值是用来判断是否是玩家射出的子弹

   

    //public Transform HpUp;

    [Range(6f,10f)] [SerializeField] public float speed = 8f;    //子弹速度

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);    //创建子弹后,1.25秒后消除
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {  
            transform.Translate(Vector3.up * speed * Time.deltaTime);//up   
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy"||collision.tag=="EnemyLeft"||collision.tag=="EnemyRight"||collision.tag=="Boss" || collision.tag == "Boss2" || collision.tag == "Boss3")
        {
            if (!collision.GetComponent<enemy>().IsDeath)
            {
                collision.gameObject.SendMessage("Hit");
                GameObject.Destroy(this.gameObject);//撞到飞机后子弹消失 
            }
        }         
    }



    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.transform.CompareTag("Enemy"))
    //    {
    //        int whichPowerUp = Random.Range(1, 2);
    //        if (whichPowerUp == 1)
    //        {
    //            Instantiate(HpUp, other.transform.position, other.transform.rotation);
    //        }
    //        if (whichPowerUp == 2)
    //        {
    //            Instantiate(HpUp, other.transform.position, other.transform.rotation);
    //        }
    //        Behavior behavior = other.gameObject.GetComponent<Behavior>();
    //    }
    //}
}
