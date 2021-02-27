using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillK : MonoBehaviour
{
    public Gun gun1;
    public Gun gun2;
    public Gun gun3;
    private Image iconK;
    private bool isKSkill;
    private bool isKLock;
    private bool isStartTimerK;
    private float timerK;
    public float skillKStopTime;
    public float cooldownTimeK;

    public GameObject skillKDuration;
    public Image durationKImage;

    // Start is called before the first frame update
    void Start()
    {
        gun1.OnFire();
        iconK = transform.Find("MaskK").GetComponent<Image>();
        skillKDuration.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("SkillK") && isKSkill == false && isKLock == false)
        {
            isKLock = true;
            isKSkill = true;
            gun1.stopFire();
            gun2.OnFire();
            gun3.OnFire();
            isStartTimerK = true;
            skillKDuration.SetActive(true);
        }
        if (isStartTimerK == true)
        {
            timerK += Time.deltaTime;
            durationKImage.fillAmount = (skillKStopTime - timerK) / skillKStopTime;
            iconK.fillAmount = (cooldownTimeK - timerK) / cooldownTimeK;            
        }
        if (timerK >= skillKStopTime)
        {
            if (isKSkill == true)
            {
                skillKDuration.SetActive(false);
                isKSkill = false;
                gun1.OnFire();
                gun2.stopFire();
                gun3.stopFire();
            }
        }
        if (timerK >= cooldownTimeK)
        {
            iconK.fillAmount = 0;
            timerK = 0;
            isKLock = false;
            isStartTimerK = false;
        }
    }
}
