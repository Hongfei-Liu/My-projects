using Assets.Scripts.weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{
    public Firearms mainWeapon;
    public Firearms secondaryWeapon;
    public GameObject crossHair;

    [SerializeField]private FPSCharacterControllerMovement fPSCharacterControllerMovement;
    private Firearms carriedWeapon;

    private void Start()
    {
        carriedWeapon = mainWeapon;   
        fPSCharacterControllerMovement.SetUpAnimator(carriedWeapon.GunAnimator);
    }

    private void Update()
    {
        if (!carriedWeapon) return;

        SwitchWeapon();
        
        if (Input.GetMouseButton(0))
        {
            //Hold the trigger
            carriedWeapon.HoldTrigger();
           
        }
        if(Input.GetMouseButtonUp(0))
        {
            //TODo release trigger
            carriedWeapon.ReleaseTrigger();
           
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reload Ammo
            carriedWeapon.ReloadAmmo();

        }
        if (Input.GetMouseButtonDown(1))
        {
            //to aim
            carriedWeapon.Aiming(true);
            crossHair.SetActive(false);

        }

        if (Input.GetMouseButtonUp(1))
        {

            carriedWeapon.Aiming(false);
            crossHair.SetActive(true);
        }

    }

    private void SwitchWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            //switch to main weapon
            carriedWeapon.gameObject.SetActive(false);
            carriedWeapon = mainWeapon;
            carriedWeapon.gameObject.SetActive(true);
            fPSCharacterControllerMovement.SetUpAnimator(carriedWeapon.GunAnimator);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            //switch to secondary weapon
            carriedWeapon.gameObject.SetActive(false);
            carriedWeapon = secondaryWeapon;
            carriedWeapon.gameObject.SetActive(true);
            fPSCharacterControllerMovement.SetUpAnimator(carriedWeapon.GunAnimator);
        }

        
    }

}
