using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbeBullet : MonoBehaviour
{
    public BulletCharacter bulletTemplate;
    public Transform firPoint;
    public List<BulletCharacter> tempBullets;
    public float CountTime = 1;
    public float StopTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        tempBullets = new List<BulletCharacter>();
        CountTime *= Time.deltaTime;
        StopTime += Time.deltaTime;
        while(CountTime < StopTime)
        {           
            StartCoroutine(FireTurbine());
        }
       

    }

    IEnumerator FirRound(int number, Vector3 creatPoint)
    {
        Vector3 bulletDir = firPoint.transform.up;
        Quaternion rotateQuate = Quaternion.AngleAxis(90, Vector3.forward);//使用四元数制造绕Z轴旋转10度的旋转
        for (int i = 0; i < number; i++)    //发射波数
        {
            for (int j = 0; j < 4; j++)
            {
                CreatBullet(bulletDir, creatPoint);
                bulletDir = rotateQuate * bulletDir; //让发射方向旋转10度，到达下一个发射方向
            }
            yield return new WaitForSeconds(0.5f); //协程延时，0.5秒进行下一波发射
        }
        yield return null;
    }
    IEnumerator FireTurbine()
    {
        Vector3 bulletDir = firPoint.transform.up;      //发射方向
        Quaternion rotateQuate = Quaternion.AngleAxis(20, Vector3.forward);//使用四元数制造绕Z轴旋转20度的旋转
        while(CountTime<StopTime)
        {
            yield return new WaitForSeconds(21f);
            float radius = 0.6f;        //生成半径
            float distance = 0.2f;      //每生成一次增加的距离
            for (int i = 0; i < 18; i++)
            {
                Vector3 firePoint = firPoint.transform.position + bulletDir * radius;   //使用向量计算生成位置
                StartCoroutine(FirRound(1, firePoint));     //在算好的位置生成一波圆形弹幕
                yield return new WaitForSeconds(0.05f);      //延时较小的时间（为了表现效果），计算下一步
                bulletDir = rotateQuate * bulletDir;        //发射方向改变
                radius += distance;     //生成半径增加
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
