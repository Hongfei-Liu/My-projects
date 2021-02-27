using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public bool isPlayer = false;
    [Range(6f, 10f)] [SerializeField] private float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "EnemyBullet")
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (gameObject.tag == "SPCBullet")
        {

        }

        if (this.transform.position.y < -5.6f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SendMessage("BeHit");
            GameObject.Destroy(this.gameObject);//撞到玩家后子弹消失 
        }
        if (collision.tag == "Shield")
        {
            //collision.gameObject.SendMessage("ShieldBeHit");
            GameObject.Destroy(this.gameObject);
        }
    }
}
