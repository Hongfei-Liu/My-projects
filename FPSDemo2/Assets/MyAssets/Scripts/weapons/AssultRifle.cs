using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.weapons
{
    public class AssultRifle : Firearms
    {

        private IEnumerator ReloadAmmoCheckerCoroutine;

        public Text ammoInMage;
        public Text ammoRemain;
        public GameObject BulletImpactPrefeb;
        public GameObject BulletHolePrefb;

        private FPSMouseMovement mouseMovement;


        protected override void Awake()
        {
            base.Awake();
            ReloadAmmoCheckerCoroutine = CheckReloadAnimationEnd();
            
            mouseMovement = FindObjectOfType<FPSMouseMovement>();
  
        }
        protected override void Reload()
        {
            GunAnimator.SetLayerWeight(2, 1);
            GunAnimator.SetTrigger(CurrentAmmo > 0 ? "ReloadLeft" : "ReloadOutOf");

            ammoUsed = AmmoInMag - CurrentAmmo;
            ammoLeft = CurrentAmmo + CurrentMaxAmmoCarried;
            CurrentAmmo = AmmoInMag;


            if (ammoLeft>AmmoInMag)
            {
                CurrentMaxAmmoCarried = (ammoLeft - AmmoInMag);

            }
            else if(ammoLeft<= AmmoInMag)
            {
                CurrentAmmo = CurrentMaxAmmoCarried;
                CurrentMaxAmmoCarried = 0;               
            }


            if (ReloadAmmoCheckerCoroutine == null)
            {
                ReloadAmmoCheckerCoroutine = CheckReloadAnimationEnd();
                StartCoroutine(ReloadAmmoCheckerCoroutine);
            }
            else
            {
                StopCoroutine(ReloadAmmoCheckerCoroutine);
                ReloadAmmoCheckerCoroutine = null;
                ReloadAmmoCheckerCoroutine = CheckReloadAnimationEnd();
                StartCoroutine(ReloadAmmoCheckerCoroutine);
            }
            FirearmsReloadingAudioSource.clip = CurrentAmmo > 0 ? 
                firearmsAudioData.ReloadLeft : 
                firearmsAudioData.ReloadOutOf;
            FirearmsReloadingAudioSource.Play();
        }


        protected override void Shooting()
        {
            
            if (CurrentAmmo <= 0) return;
            if (!IsAllowShooting()) return;
            //MuzzlePartical.Play();
            CurrentAmmo -= 1;
            GunAnimator.Play("fire", isAiming?1:0, 0);
            FirearmsShootingAudioSource.clip = firearmsAudioData.ShootingAudio;
            FirearmsShootingAudioSource.Play();
            CreateBullet();
            mouseMovement.FiringForTest();
            //CasingPartical.Play();
            lastFireTime = Time.time; // record the last fire
            
            
        }

        private void Update()
        {        
            ammoInMage.text = CurrentAmmo.ToString();
            ammoRemain.text = CurrentMaxAmmoCarried.ToString();
        }



        

    protected void CreateBullet()
        {
            GameObject tmp_Bullet = Instantiate(bulletPrefb, MuzzlePoint.position, MuzzlePoint.rotation);

            tmp_Bullet.transform.eulerAngles += CalculateSpreadOffest();

            var tmp_bulletScript = tmp_Bullet.AddComponent<Bullet>();
            tmp_bulletScript.ImpactPrefab = BulletImpactPrefeb;
            tmp_bulletScript.ImpactAudioData = impactAudioData;         
            tmp_bulletScript.bulletSpeed = 200;
            
           
            Destroy(tmp_Bullet, 3f);
        }

        

        //protected override void Aim()
        //{
        //    GunAnimator.SetBool("Aim", isAiming);
        //    if(doAminCoroutine == null)
        //    {
        //        doAminCoroutine = DoAim();
        //        StartCoroutine(doAminCoroutine);
        //    }
        //    else
        //    {
        //        StopCoroutine(doAminCoroutine);
        //        doAminCoroutine = null;
        //        doAminCoroutine = DoAim();
        //        StartCoroutine(doAminCoroutine);
        //    }
        //}
    }
}
