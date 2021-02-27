using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyBasic;
    public GameObject enemyBasic2;
    public GameObject Stone;
    public GameObject AwardBullet;
    public GameObject AwardShield;
    public GameObject Laser;
    public GameObject Boss;
    public GameManager enemyBasicRate1;
    public bool IsBoss = false;
    public AudioSource audio;


    [SerializeField] private float enemyBasicRate = 0.5f;
    [SerializeField] private float enemyBasicRate2 = 1f;
    [SerializeField] private float StoneRate = 2f;
    [SerializeField] private float AwardBulletRate = 10f;
    [SerializeField] private float AwardShieldRate = 10f;
    [SerializeField] private float LaserRate = 10f;
    private float seconds, minutes;

    public GameObject hpUp;
    [SerializeField] private float hpUpRate;
    public GameObject speedUp;
    [SerializeField] private float speedUpRate;
    public GameObject speedDown;
    [SerializeField] private float speedDownRate;
    public GameObject bulletUp;
    [SerializeField] private float bulletUpRate;
    public GameObject bulletDown;
    [SerializeField] private float bulletDownRate;

    public void CreateEnemyBasic()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(enemyBasic, new Vector3(x,transform.position.y,0), Quaternion.identity);
    }
    public void CreateEnemyBasic2()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(enemyBasic2, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateStone()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(Stone, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateAward1()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(AwardBullet, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateAwardShield()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(AwardShield, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateBoss()
    {
        audio.Play();
        float x = -1.65f;
        IsBoss = true;
        GameObject.Instantiate(Boss, new Vector3(x, transform.position.y, 0), Quaternion.identity);
        if (IsBoss == true)
        {
            CancelInvoke("CreateEnemyBasic");
            CancelInvoke("CreateEnemyBasic2");
        }
    }

    public void CreateHpUp()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(hpUp, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateSpeedUp()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(speedUp, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateSpeedDown()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(speedDown, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateBulletUp()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(bulletUp, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    public void CreateBullletDown()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(bulletDown, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }

    public void CreateLaser()
    {
        float x = Random.Range(-6.16f, 6.15f);
        GameObject.Instantiate(Laser, new Vector3(x, transform.position.y, 0), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        //enemyBasicRate = GameManager.enemyBasicRate1;
        
        InvokeRepeating("CreateEnemyBasic", 1, enemyBasicRate);
        InvokeRepeating("CreateEnemyBasic2", 6, enemyBasicRate2);
        InvokeRepeating("CreateHpUp", 1, hpUpRate);
        InvokeRepeating("CreateSpeedUp", 1, speedUpRate);
        InvokeRepeating("CreateSpeedDown", 5, speedDownRate);
        InvokeRepeating("CreateBulletUp", 3, bulletUpRate);
        InvokeRepeating("CreateBullletDown", 6, bulletDownRate);
        InvokeRepeating("CreateStone", 15, StoneRate);
        InvokeRepeating("CreateAward1", 30, AwardBulletRate);
        InvokeRepeating("CreateAwardShield", 30, AwardShieldRate);
        InvokeRepeating("CreateLaser", 30, LaserRate);
        InvokeRepeating("IncreaseEnemyRate", 10, 10);
        Invoke("CreateBoss", 90);

        

    }
    void IncreaseEnemyRate()
    {
       //GameManager.instance.enemyBasicRate1 *= 0.1f;
         enemyBasicRate *= 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        //CountTime();
    }

    /*public void CountTime()
    {
        minutes = (int)(Time.time / 60f);
        seconds = (int)(Time.time % 60f);
        if (seconds >= 10f)
        {
            enemyBasicRate *= 0.8f;
        }

    }*/
}
