using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRayCast : MonoBehaviour
{
    [SerializeField] Camera _FPSCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _dealingDamageToEnemy;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] Ammo _ammoSlot;
    [SerializeField] bool _canShoot = true;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float _amountOfSecondsToshootBeweenOneBullentAndAnother = 2f;

    private void Start()
    {
        _ammoSlot = GetComponent<Ammo>();
    }
    private void OnEnable()
    {
        _canShoot = true;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canShoot == true)
        {
            Debug.Log("Shooting;");
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        _canShoot = false;
        if (_ammoSlot.AmountOfAmmReturned(ammoType) > 0)
        {
            PlayMuzzleFlash();
            RaycastingPro();
            _ammoSlot.ReduceCurrentAmmo(ammoType);

        }
        yield return new WaitForSeconds(_amountOfSecondsToshootBeweenOneBullentAndAnother);
        _canShoot = true;

    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void RaycastingPro()
    {
        RaycastHit InfromationThatGotFromHittingTheEnemy;
        if (Physics.Raycast(_FPSCamera.transform.position, _FPSCamera.transform.forward, out InfromationThatGotFromHittingTheEnemy, _range))
        {
            CreateHitImpact(InfromationThatGotFromHittingTheEnemy);
            //Debug.Log("Shoot" + InfromationThatGotFromHittingTheEnemy.transform.name);
            EnemyHealth Healthtaget = InfromationThatGotFromHittingTheEnemy.transform.GetComponent<EnemyHealth>();
            if (Healthtaget == null) { return; }
            Healthtaget.TakeDamage(_dealingDamageToEnemy);

        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit infromationThatGotFromHittingTheEnemy)
    {
        GameObject Impact = Instantiate(_hitEffect, infromationThatGotFromHittingTheEnemy.point, Quaternion.LookRotation(infromationThatGotFromHittingTheEnemy.normal));
        Destroy(Impact, 1f);
    }
}
