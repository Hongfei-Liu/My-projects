using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSpace : MonoBehaviour
{
    public Gun gun5, gun8;
    public Image iconSpace;
    private bool waitActive = false;
    private bool isSpaceLock;
    private bool isStartTimerSpace;
    private bool isSpaceSkill;
    public bool resetUltimate;
    private float timerSpace;
    private float skillSpaceStopTime = 10;
    private float resetTime = 3;
    private float Max = 30;

    public GameObject skillSpaceDuration;
    public Image durationSpaceImage;
    public GameObject wingPlane;

    public enemy ene;

    public GameObject ultimateShow;

    // Start is called before the first frame update
    void Start()
    {
        //iconSpace = transform.Find("Mask").GetComponent<Image>();
        skillSpaceDuration.SetActive(false);
        wingPlane.SetActive(false);
        ene.ultimate = 0;
        ultimateShow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ene.ultimate != 30)
        {
            iconSpace.fillAmount = (Max - ene.ultimate) / Max;
            //Debug.Log("Start Count Down" + iconSpace.fillAmount);
        }
        if (ene.ultimate == 30)
        {
            //Debug.Log("Start Count Down" + iconSpace.fillAmount);
            iconSpace.fillAmount = (Max - ene.ultimate) / Max;
            waitActive = true;
            wingPlane.SetActive(true);
            ultimateShow.SetActive(true);
        }
        if (Input.GetButton("SkillSpace") && waitActive == true && isSpaceSkill == false && isStartTimerSpace == false)
        {
            //Debug.Log("111111111111");
            isSpaceSkill = true;
            waitActive = false;
            gun5.OnFire();
            gun8.OnFire();
            isStartTimerSpace = true;
            skillSpaceDuration.SetActive(true);
        }
        if (isStartTimerSpace == true)
        {
            timerSpace += Time.deltaTime;
            durationSpaceImage.fillAmount = (skillSpaceStopTime - timerSpace) / skillSpaceStopTime;
        }
        if (timerSpace >= skillSpaceStopTime)
        {
            //Debug.Log("22222222222");
            if (isSpaceSkill == true)
            {
                skillSpaceDuration.SetActive(false);
                //waitActive = true;
                gun5.stopFire();
                gun8.stopFire();

                StartCoroutine(WaitAndPlay());
                //Debug.Log("111111111111");
                ene.ultimate = 0;
                iconSpace.fillAmount = 1;
                wingPlane.SetActive(false);
                Debug.Log("WingPane = false");
                ultimateShow.SetActive(false);
                timerSpace = 0;
                isSpaceSkill = false;
                isStartTimerSpace = false;
            }
        }
    }

    IEnumerator WaitAndPlay()
    {
        yield return new WaitForSeconds(3);
    }
}
