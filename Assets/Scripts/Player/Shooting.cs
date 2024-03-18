using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile,muzzleFlash,muzzleFlash_2;
    public Transform weaponPos,secondWeaponPos;
    [SerializeField]private int frames = 1;
    private float CooldownTime = 0.8f;
    public AudioSource audioSource;
    private bool canShoot = true,isFlashing = false;

    private void Start() {
        muzzleFlash.SetActive(false);
        muzzleFlash_2.SetActive(false);
    }

    void Update(){
        if(Input.GetKey(KeyCode.Space) && canShoot){
            Instantiate(projectile, weaponPos.position, transform.rotation);
            Instantiate(projectile, secondWeaponPos.position, transform.rotation);
            StartCoroutine(CooldowTimer());
            audioSource.Play();

            if(!isFlashing){
                StartCoroutine(MakeFlash());
            }
        } 
        
    }

    IEnumerator MakeFlash(){
        muzzleFlash.SetActive(true);
        muzzleFlash_2.SetActive(true);
        var framesPassed = 0;
        isFlashing = true;

        while(framesPassed <= frames){
            framesPassed++;
            yield return null;
        }

        muzzleFlash.SetActive(false);
        muzzleFlash_2.SetActive(false);
        isFlashing = false;
    }

    IEnumerator CooldowTimer(){
        canShoot = false;
        yield return new WaitForSeconds(CooldownTime);
        canShoot = true;
    }
}