using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animWingPlane1 : MonoBehaviour
{
    public string WingPlane1;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void WingPlaneTrans()
    {
        anim.Play(WingPlane1);
    }
}
