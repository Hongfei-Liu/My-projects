using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemy : MonoBehaviour
{
    [SerializeField] public int hp = 1;
    [SerializeField] private float speed = 3;
    [SerializeField] private int goldscore=100;
    [SerializeField] public bool IsDeath = false;
    [SerializeField] private GameObject EnemyGun;

    public int ultimate = 0;
    //private int ultimateWait = 0;

    SkillSpace space;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Enemy")
        {
         this.transform.Translate(Vector3.down * speed * Time.deltaTime);//向下运动
        }
        else if(gameObject.tag=="EnemyLeft")
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        else if(gameObject.tag=="EnemyRight")
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        else if(gameObject.tag=="Boss")
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(2, 7, -5), step);
        }
        else if (gameObject.tag == "Boss2")
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, 5, -14), step);
        }
        else if (gameObject.tag == "Boss3")
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(2, 7, -5), step);
        }

        if (this.transform.position.y<-5.6f)//当敌人超过-5.6时摧毁
        {
            Destroy(this.gameObject);
        }

        //if (space.resetUltimate == true)
        //{
        //    ultimate = 0;
        //    space.resetUltimate = false;
        //}
    }

    public void Hit()
    {

        hp -= 1;
        //if (ultimate < 15)
        //{
        //    ultimate += 1;
        //}
        //else if (ultimate >= 15)
        //{
        //    ultimate = 15;
        //}

        //Debug.Log("Uitimate is: " + ultimate);
        //Debug.Log("Wait is: " + ultimate);
        if (hp<=0)
            {
            if(this.gameObject.tag=="Enemy"||this.gameObject.tag=="EnemyLeft"||this.gameObject.tag=="EnemyRight")
            {
                IsDeath = true;
                Destroy(this.gameObject);
                GameManager.instance.score += goldscore;

            }
            if(this.gameObject.tag=="Boss")
            {
                IsDeath = true;
                Destroy(this.gameObject);
                GameManager.instance.score += goldscore;
                SceneManager.LoadScene("BeginFlowchart");
            }
            if (this.gameObject.tag == "Boss2")
            {
                IsDeath = true;
                Destroy(this.gameObject);
                GameManager.instance.score += goldscore;
                SceneManager.LoadScene("BeginFlowchart");
            }
            if (this.gameObject.tag == "Boss3")
            {
                IsDeath = true;
                Destroy(this.gameObject);
                GameManager.instance.score += goldscore;
                StartCoroutine(WaitAndPlay());
                SceneManager.LoadScene("EndingFlowchart");
            }
        }
    }

    public void HitUltimate()
    {
        if (ultimate < 30)
        {
            ultimate += 1;
        }
        else if (ultimate >= 30)
        {
            ultimate = 30;
        }
        Debug.Log("Uitimate is: " + ultimate);
    }

    IEnumerator WaitAndPlay()
    {
        yield return new WaitForSeconds(500);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!collision.GetComponent<PlayerMove>().IsDeath)
            {
                collision.gameObject.SendMessage("BeHit");
                if(this.gameObject.tag == "Enemy" || this.gameObject.tag == "EnemyLeft" || this.gameObject.tag == "EnemyRight")
                {
                    GameObject.Destroy(this.gameObject);//撞到玩家后飞机消失 
                }
                
                if(this.gameObject.tag == "Boss"|| this.gameObject.tag == "Boss2"|| this.gameObject.tag == "Boss3")
                {

                }
            }

        }

        if (collision.tag == "Shield")
        {
            collision.gameObject.SendMessage("ShieldBeHit");
            GameObject.Destroy(this.gameObject);
        }
    }
}
