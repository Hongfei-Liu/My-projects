using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public float speed = 0.2f;//speed of bullet
    public GameObject Enemybullet;

    private void EnemyFire()
    {
        GameObject.Instantiate(Enemybullet, transform.position, Quaternion.identity);

    }
    public void OnFire()
    {
        InvokeRepeating("EnemyFire", 1, speed);

    }

    // Start is called before the first frame update
    void Start()
    {
        OnFire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
