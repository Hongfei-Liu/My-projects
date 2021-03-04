using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.weapons
{
    public abstract class Firearms: MonoBehaviour,IWeapon
    {
        public Transform MuzzlePoint;
        public Transform CasingPoint;


        public Camera Eyecamera;

        public ParticleSystem MuzzlePartical;
        public ParticleSystem CasingPartical;

        public float fireRate;
        protected float lastFireTime;

        public int AmmoInMag = 30;
        public int MaxAmmoCarried = 120;

        public AudioSource FirearmsShootingAudioSource;
        public AudioSource FirearmsReloadingAudioSource;
        public FirearmsAudioData firearmsAudioData;
        public ImpactAudioData impactAudioData;

        public GameObject bulletPrefb;

        internal Animator GunAnimator;
        protected AnimatorStateInfo GunStatInfo;

        protected int CurrentAmmo;
        protected int CurrentMaxAmmoCarried;
        protected int ammoLeft;
        protected int ammoUsed;

        protected float OriginFOV;
        protected bool isAiming;
        protected bool isHoldingTrigger;

        public float SpreadAngle;


        private IEnumerator doAminCoroutine;

        protected virtual void Awake()
        {
            CurrentAmmo = AmmoInMag;
            CurrentMaxAmmoCarried = MaxAmmoCarried;
            GunAnimator = GetComponent<Animator>();
            OriginFOV = Eyecamera.fieldOfView;
            doAminCoroutine = DoAim();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
            }
        }



        public void DoAttack()
        {
            Shooting();
            //MuzzlePartical.Play();

        }

        protected abstract void Shooting();
        protected abstract void Reload();

        //protected abstract void Aim();

        internal void Aiming(bool _isAming)
        {
            isAiming = _isAming;

            GunAnimator.SetBool("Aim", isAiming);
            if (doAminCoroutine == null)
            {
                doAminCoroutine = DoAim();
                StartCoroutine(doAminCoroutine);
            }
            else
            {
                StopCoroutine(doAminCoroutine);
                doAminCoroutine = null;
                doAminCoroutine = DoAim();
                StartCoroutine(doAminCoroutine);
            }
        }
        protected bool IsAllowShooting()
        {
            //ak rate = 700/1min 11.7/1s 

             return Time.time - lastFireTime > 1 / fireRate;
             
        }

        internal void HoldTrigger()
        {
            DoAttack();
            isHoldingTrigger = true;
        }

        internal void ReleaseTrigger()
        {
            isHoldingTrigger = false;
        }

        internal void ReloadAmmo()
        {

            Reload();
        }

        protected Vector3 CalculateSpreadOffest()
        {
            float tmp_SpreadPercent = SpreadAngle / Eyecamera.fieldOfView;
            return tmp_SpreadPercent*UnityEngine.Random.insideUnitSphere;
        }
        protected IEnumerator CheckReloadAnimationEnd()//check if amin is finished
        {
            while (true)
            {
                yield return null;
                GunStatInfo = GunAnimator.GetCurrentAnimatorStateInfo(1);
                if (GunStatInfo.IsTag("ReloadAmmo"))
                {
                    if (GunStatInfo.normalizedTime >= 0.9f)
                    {
                        int tmp_NeedAmmoCount = AmmoInMag - CurrentAmmo;
                        int tmp_RemianAmmo = CurrentMaxAmmoCarried - tmp_NeedAmmoCount;
                        if (tmp_RemianAmmo <= 0)
                        {
                            CurrentAmmo += CurrentMaxAmmoCarried;
                        }
                        else
                        {
                            CurrentAmmo = AmmoInMag;
                        }

                        CurrentMaxAmmoCarried = tmp_RemianAmmo <= 0 ? 0 : tmp_RemianAmmo;
                        yield break;
                    }
                }


            }
        }

        protected IEnumerator DoAim()
        {
            while (true)
            {
                yield return null;

                float tmp_CurrentFOV = 0;
                Eyecamera.fieldOfView = Mathf.SmoothDamp(Eyecamera.fieldOfView, isAiming ? 26 : OriginFOV,
                    ref tmp_CurrentFOV, Time.deltaTime * 2);
            }
        }


    }
}
