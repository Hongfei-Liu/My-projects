using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    Text text;
    public float speed;

    // Use this for initialization
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        float r = text.color.r;
        float g = text.color.g;
        float b = text.color.b;
        float alpha = Mathf.PingPong(speed * Time.time, 1); //speed * Time.time 速率
        text.color = new Color(r, g, b, alpha);
    }
}
