using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile,muzzleFlash;
    public Transform weaponPos;
    private int frames = 1;
    private float CooldownTime = 1f;
    private bool canShoot = true,isFlashing = false;

    private void Start() {
        muzzleFlash.SetActive(false);
    }

    void Update(){
        if(Input.GetKey(KeyCode.Space) && canShoot){
            Instantiate(projectile, weaponPos.position, transform.rotation);
            StartCoroutine(CooldowTimer());

            if(!isFlashing){
                StartCoroutine(MakeFlash());
            }
        } 
        
    }

    IEnumerator MakeFlash(){
        muzzleFlash.SetActive(true);
        var framesPassed = 0;
        isFlashing = true;

        while(framesPassed <= frames){
            framesPassed++;
            yield return null;
        }

        muzzleFlash.SetActive(false);
        isFlashing = false;
    }

    IEnumerator CooldowTimer(){
        canShoot = false;
        yield return new WaitForSeconds(CooldownTime);
        canShoot = true;
    }
}