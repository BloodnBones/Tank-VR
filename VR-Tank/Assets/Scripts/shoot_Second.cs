<<<<<<< Updated upstream
﻿using UnityEngine;
using System.Collections;

public class shoot_Second : MonoBehaviour
{

    bool canShoot = true;
    float fireRate = 1.0f;
    public Transform Bullet;
    public float Firepower = 10;
    public GameObject turret;
    Quaternion Nrotation;
    public GameObject BarrelEnd;
    // Use this for initialization
    
    public float bulletSpeed = 10;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Nrotation = BarrelEnd.transform.localRotation;//transform.rotation;
        //Nrotation.x = BarrelEnd.transform.localRotation.x;
        //transform.rotation = Nrotation;


        fireRate -= Time.deltaTime;
        if(fireRate > 0)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
        if (canShoot)
        {
            if (Input.GetAxis("Fire") > 0)
            {
                GetComponent<AudioSource>().Play();
                shoot();
                fireRate = 1.0f;
            }
        }
    }


    void shoot()
    {
        //GameObject bulletClone;
        //Quaternion CloneRotation = Nrotation;
        //CloneRotation.x = BarrelEnd.transform.rotation.x;
        //bulletClone = Instantiate(Bullet, transform.position, CloneRotation) as GameObject;

        //bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;


        //Vector3 SpawnPos = transform.position;
        Transform bulletClone;
        //Vector3 power = new Vector3(0, 0.1f, 0);
        Quaternion CloneRotation = turret.transform.rotation;
        CloneRotation.x = BarrelEnd.transform.rotation.x/* + (Mathf.Deg2Rad * -90)*/;
        bulletClone = Instantiate(Bullet, transform.position, CloneRotation) as Transform;

        bulletClone.GetComponent<Rigidbody>().AddForce((transform.forward) * Firepower, ForceMode.Impulse);
    }
}
=======
﻿using UnityEngine;
using System.Collections;

public class shoot_Second : MonoBehaviour
{

    bool canShoot = true;
    float fireRate = 1.0f;
    public Transform Bullet;
    public float Firepower = 10;
    public GameObject turret;
    Quaternion Nrotation;
    public GameObject BarrelEnd;
    // Use this for initialization
    
    public float bulletSpeed = 10;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Nrotation = BarrelEnd.transform.localRotation;//transform.rotation;
        //Nrotation.x = BarrelEnd.transform.localRotation.x;
        //transform.rotation = Nrotation;


        fireRate -= Time.deltaTime;
        if(fireRate > 0)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
        if (canShoot)
        {
            if (Input.GetAxis("Fire") > 0)
            {
                GetComponent<AudioSource>().Play();
                shoot();
                fireRate = 0.1f;
            }
        }
    }


    void shoot()
    {
        //GameObject bulletClone;
        //Quaternion CloneRotation = Nrotation;
        //CloneRotation.x = BarrelEnd.transform.rotation.x;
        //bulletClone = Instantiate(Bullet, transform.position, CloneRotation) as GameObject;

        //bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;


        //Vector3 SpawnPos = transform.position;
        Transform bulletClone;
        //Vector3 power = new Vector3(0, 0.1f, 0);
        Quaternion CloneRotation = BarrelEnd.transform.localRotation;
        //CloneRotation.x = BarrelEnd.transform.rotation.x + (Mathf.Deg2Rad * -90);
        bulletClone = Instantiate(Bullet, transform.position, CloneRotation) as Transform;

        bulletClone.GetComponent<Rigidbody>().AddForce((transform.forward) * Firepower, ForceMode.Impulse);
    }
}
>>>>>>> Stashed changes
