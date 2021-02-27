using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSPCBullet : MonoBehaviour
{
    public GameObject specialBullet;

    [SerializeField] private float bulletRate=5;
    [SerializeField] private float speed = 2;

    public void CreateBoomb()
    {
       GameObject.Instantiate(specialBullet, transform.position, Quaternion.identity);
        if (this.gameObject.tag == "SPCBullet")
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(0, -5, 0), step);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBoomb", 4, bulletRate);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
