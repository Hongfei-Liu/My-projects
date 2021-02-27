using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBullet : MonoBehaviour
{
    public BulletCharacter bulletTemplate;
    public Transform firPoint;
    public List<BulletCharacter> tempBullets;
    public float CountTime;
    public float StopTime;
    // Start is called before the first frame update
    void Start()
    {
        tempBullets = new List<BulletCharacter>();
        CountTime *= Time.deltaTime;
        StopTime += Time.deltaTime;
        StartCoroutine(FireBallBulle());
    }

    IEnumerator FireBallBulle()
    {
        Vector3 bulletDir = firPoint.transform.up;      //发射方向
        Quaternion rotateQuate = Quaternion.AngleAxis(10, Vector3.forward);//使用四元数制造绕Z轴旋转20度的旋转
        while( CountTime<StopTime)
        {
            yield return new WaitForSeconds(23f);
            float distance = 1.0f;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 36; i++)
                {
                    Vector3 creatPoint = firPoint.transform.position + bulletDir * distance;
                    BulletCharacter tempBullet = CreatBullet(bulletDir, creatPoint);
                    tempBullet.isMove = false;
                    StartCoroutine(tempBullet.DirChangeMoveMode(10.0f, 0.4f, 15));
                    bulletDir = rotateQuate * bulletDir;
                }
                yield return new WaitForSeconds(0.2f);
            }

            yield return null;
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
