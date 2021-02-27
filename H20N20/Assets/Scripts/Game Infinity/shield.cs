using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    [SerializeField] private int shieldHp = 10;
    [SerializeField] public bool IsActive = true;


    public void ShieldBeHit()
    {

        shieldHp -= 1;
        if (shieldHp <= 0)
        {
            IsActive = false;
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
