using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shotGunBullet : MonoBehaviour
{
    public BulletCharacter bulletTemplate;
    public Transform firPoint;
    public List<BulletCharacter> tempBullets;

    public float CountTime;
    public float StopTime;
  
    

    void Start()
    {
        tempBullets = new List<BulletCharacter>();
        CountTime *= Time.deltaTime;
        StopTime += Time.deltaTime;
        StartCoroutine(FirShotgun());
    }

    IEnumerator FirShotgun()
    {
        Vector3 bulletDir = Vector3.down; 
        Quaternion leftRota = Quaternion.AngleAxis(-30, Vector3.forward);
        Quaternion RightRota = Quaternion.AngleAxis(30, Vector3.forward); //使用四元数制造2个旋转，分别是绕Z轴朝左右旋转30度
      while(CountTime<StopTime)
        {
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < 10; i++)     //散弹发射次数
            {
                for (int j = 0; j < 3; j++) //一次发射3颗子弹
                {
                    switch (j)
                    {
                        case 0:
                            CreatBullet(bulletDir, firPoint.transform.position);  //发射第一颗子弹，方向不需要进行旋转。参数为子弹运动方向与生成位置，函数实现未列出。
                            break;
                        case 1:
                            bulletDir = RightRota * bulletDir;//第一个方向子弹发射完毕，旋转方向到下一个发射方向
                            CreatBullet(bulletDir, firPoint.transform.position);//调用生成子弹函数，参数为发射方向与生成位置。
                            break;
                        case 2:
                            bulletDir = leftRota * (leftRota * bulletDir); //右边方向发射完毕，得向左边旋转2次相同的角度才能到达下一个发射方向
                            CreatBullet(bulletDir, firPoint.transform.position);
                            bulletDir = RightRota * bulletDir; //一轮发射完毕，重新向右边旋转回去，方便下一波使用
                            break;
                    }
                }
                yield return new WaitForSeconds(0.5f); //协程延时0.5秒进行下一波发射
            }
        }
           
        
    }

    public BulletCharacter CreatBullet(Vector3 dir, Vector3 creatPoint)
    {
        BulletCharacter bulletCharacter = Instantiate(bulletTemplate, creatPoint, Quaternion.identity);
        bulletCharacter.gameObject.SetActive(true);
        bulletCharacter.dir = dir;
        tempBullets.Add(bulletCharacter);
        return bulletCharacter;
    }
}
