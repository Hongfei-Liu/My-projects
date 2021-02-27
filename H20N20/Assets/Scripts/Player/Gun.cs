using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float speed = 0.2f;//speed of bullet
    public GameObject bullet;
    private GameObject skill3;
    public Image forskill;
    [SerializeField] private AudioSource audio;

    private void Start()
    {
        skill3 = GameObject.FindGameObjectWithTag("Player");
        
    }
    public void Fire()
    {
        audio.Play();
        GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
    }
    public void OnFire()
    {
        InvokeRepeating("Fire", 1, speed);
    }

    public void OnFireH()
    {
        InvokeRepeating("Fire", 1, 0.1f);
    }

    public void stopFire()
    {
        CancelInvoke("Fire");
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }
}
