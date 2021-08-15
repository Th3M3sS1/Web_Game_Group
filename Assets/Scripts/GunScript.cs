using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

    public float damaga = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactStoneEffect;
    public GameObject impactFleshEffect;
    public AudioSource audio;

    private float nextTimeToFire = 0f;


    public void Shoot()
    {
        muzzleFlash.Play();
        //SoundManager.PlaySound("firing");
        //audio = GetComponent<AudioSource>();
        audio.Play();
        RaycastHit Hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out Hit, range))
        {
           
            ZombieBehaviour zb = Hit.transform.GetComponent<ZombieBehaviour>();
            if(zb != null)
            {
                zb.TakeDamage(damaga);
                GameObject impactFlesh = Instantiate(impactFleshEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
                Destroy(impactFlesh, 2f);
            }
            else
            {
                GameObject impactGO = Instantiate(impactStoneEffect, Hit.point, Quaternion.LookRotation(Hit.normal));
                Destroy(impactGO, 2f);
            }

            if(Hit.rigidbody !=null)
            {
                Hit.rigidbody.AddForce(Hit.normal * impactForce);
            }


        }
    }

    public void Fire()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
            SoundManager.PlaySound("firing");
        }

    }
}
