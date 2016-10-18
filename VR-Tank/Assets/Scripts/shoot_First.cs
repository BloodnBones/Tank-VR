using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shoot_First : MonoBehaviour
{

    bool canShoot = true;
    float fireRate = 0.1f;
    public Transform Bullet;
    public float Firepower = 10;
    public GameObject turret;
    Quaternion Nrotation;
    public GameObject BarrelEnd;
    // Use this for initialization
    public List<GameObject> enemies;


    public float bulletSpeed = 10;
    public bool empstart = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Nrotation = BarrelEnd.transform.localRotation;//transform.rotation;
        //Nrotation.x = BarrelEnd.transform.localRotation.x;
        //transform.rotation = Nrotation;

        //Debug.DrawLine(transform.position, Vector3.forward, Color.red, 5.0f);
        fireRate -= Time.deltaTime;
        if (fireRate > 0)
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EMP();
        }
    }
    void EMP()
    {
        empstart = true;
        FindCloseEnemies();
        foreach (GameObject obj in enemies)
        {
            obj.GetComponent<TankEMP>().empGo = true;
        }
        StartCoroutine("stopEMP");
    }

    void shoot()
    {
        //GameObject bulletClone;
        //Quaternion CloneRotation = Nrotation;
        //CloneRotation.x = BarrelEnd.transform.rotation.x;
        //bulletClone = Instantiate(Bullet, transform.position, CloneRotation) as GameObject;
        //bulletClone.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
        //Vector3 SpawnPos = transform.position;
        //Vector3 power = new Vector3(0, 0.1f, 0);


        Transform bulletClone;
        Quaternion CloneRotation = turret.transform.rotation;
        CloneRotation.x = BarrelEnd.transform.rotation.x /*+ (Mathf.Deg2Rad * -90)*/;
        bulletClone = Instantiate(Bullet, transform.position, CloneRotation) as Transform;
        bulletClone.GetComponent<Rigidbody>().AddForce((transform.forward) * Firepower, ForceMode.Impulse);
    }

    void FindCloseEnemies()
    {
        enemies.Clear();
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Hard");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                enemies.Add(go);
            }
        }
    }
    IEnumerator stopEMP()
    {
        yield return new WaitForSeconds(5);
        empstart = false;
    }
}
