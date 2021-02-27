using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransform : MonoBehaviour
{
    public static float speed = 2f;


    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        Vector3 position = this.transform.position;
        if(position.y <= -9.9f)
        {
            this.transform.position = new Vector3(position.x, position.y + 9.9f * 2, position.z);
        }
    }
}
