using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform weaponPos;
    private float CooldownTime = 1f;
    private bool canShoot = true;

    void Update(){
        if(Input.GetKey(KeyCode.Space) && canShoot){
            Instantiate(projectile, weaponPos.position, transform.rotation);
            StartCoroutine(CooldowTimer());
        } 
    }

    IEnumerator CooldowTimer(){
        canShoot = false;
        yield return new WaitForSeconds(CooldownTime);
        canShoot = true;
    }
}