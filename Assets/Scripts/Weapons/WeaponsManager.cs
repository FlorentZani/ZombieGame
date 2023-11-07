using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> weapons = null;

    [SerializeField]
    GameObject crosshair = null;

    public enum Weapon { AR15, Handgun, SniperRifle, Grenade};
    public Weapon currentWeapon = Weapon.AR15;

    public Action<Weapon, int> WeaponSwitched;

    bool canSwitchWeapon = true;

    Grenade grenadeScript;

    void Awake()
    {
        grenadeScript = weapons[3].GetComponent<Grenade>();
    }

    void Update()
    {
        if (weapons[2].GetComponent<SniperRifle>().isZoomMode)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Z) && canSwitchWeapon)
        {
            currentWeapon = Weapon.AR15;
            ToggleWeapon(0, currentWeapon);
            crosshair.SetActive(true);
            grenadeScript.DestroyGrenade();
        }
        else if(Input.GetKey(KeyCode.X) && canSwitchWeapon)
        {
            currentWeapon = Weapon.Handgun;
            ToggleWeapon(1, currentWeapon);
            crosshair.SetActive(true);
            grenadeScript.DestroyGrenade();
        }
        else if(Input.GetKey(KeyCode.C) && canSwitchWeapon)
        {
            currentWeapon = Weapon.SniperRifle;
            ToggleWeapon(2, currentWeapon);
            crosshair.SetActive(true);
            grenadeScript.DestroyGrenade();
        }
        else if(Input.GetKey(KeyCode.V) && canSwitchWeapon)
        {
            currentWeapon = Weapon.Grenade;
            ToggleWeapon(3, currentWeapon);
            crosshair.SetActive(false);
            grenadeScript.ToggleGrenade();
        }
    }

    void ToggleWeapon(int i, Weapon weapon)
    {
        for (int j = 0; j < weapons.Count; j++)
        {
            weapons[j].SetActive(false);
        }

        weapons[i].SetActive(true);

        WeaponSwitched?.Invoke(weapon, i);
    }

    public void HandleMenuOpened()
    {
        canSwitchWeapon = false;
    }

    public void HandleMenuClosed()
    {
        canSwitchWeapon = true;
    }
}

