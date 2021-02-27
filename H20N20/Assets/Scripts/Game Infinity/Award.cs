using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Award : MonoBehaviour
{
    public int type = 0;// 1 more gun

    public float speed = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
          this.transform.Translate(Vector3.down * Time.deltaTime * speed);
          if (this.transform.position.y < -5.6f)
          {
            Destroy(this.gameObject);
          }
      
    }
}
