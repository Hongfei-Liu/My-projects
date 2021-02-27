using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private void Update()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (this.transform.position.y < -5.6f)//当gold超过-5.6时摧毁
        {
            Destroy(this.gameObject);
        }
    }
}
