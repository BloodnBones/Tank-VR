﻿using UnityEngine;
using System.Collections;

public class SecondaryWeapon : MonoBehaviour {

    public GameObject Barrell;




    bool canShoot = true;
    float fireRate = 0.1f;
    //public Transform Bullet;
    //public float Firepower = 10;
    //public GameObject turret;
    //Quaternion Nrotation;
    //public GameObject BarrelEnd;
    
    //public float bulletSpeed = 10;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //fireRate -= Time.deltaTime;
        //if (fireRate > 0)
        //{
        //    canShoot = false;
        //}
        //else
        //{
        //    canShoot = true;
        //}
        if (canShoot)
        {
            //if (Input.GetAxis("Fire2") > 0)
            //{
            //    //GetComponent<AudioSource>().Play();
            //    shoot();
            //    fireRate = 1.0f;

            //}
        }
    }


    void shoot()
    {
        //Transform SecondarybulletClone;
        
        //Quaternion CloneRotation = turret.transform.rotation;
        //CloneRotation.x = BarrelEnd.transform.rotation.x /*+ (Mathf.Deg2Rad * -90)*/;
        //SecondarybulletClone = Instantiate(Bullet, transform.position, CloneRotation) as Transform;

        //SecondarybulletClone.GetComponent<Rigidbody>().AddForce((transform.forward) * Firepower, ForceMode.Impulse);
    }
}
