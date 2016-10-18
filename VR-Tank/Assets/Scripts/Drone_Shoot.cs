using UnityEngine;
using System.Collections;

public class Drone_Shoot : MonoBehaviour
{


    GameObject target;
    public Transform RotationObj;
    public Transform bullet;
    Vector3 newPos;
    DroneDeath dead;
    public float projectileSpeed = 20;
    public float FireRate = 0.8f;
    public bool isShooting = false;
    bool canShoot = true;


    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        dead = transform.parent.gameObject.GetComponent<DroneDeath>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead.isDead)
        {
            newPos = RotationObj.position;
            transform.position = newPos;
            if (target != null)
            {

                if (Vector3.Distance(transform.position, target.transform.position) < 50 && canShoot)
                {
                    isShooting = true;

                    StartCoroutine("Shoot");
                }
                else
                {
                    isShooting = false;

                }
            }
        }

    }

    IEnumerator Shoot()
    {
        
        canShoot = false;
        // Instantiate the projectile at the position and rotation of this transform
        Transform clone;
        Vector3 spawnPos = transform.position;
        clone = Instantiate(bullet, spawnPos, RotationObj.rotation) as Transform;
        
        // Add force to the cloned object in the object's forward direction
       // clone.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
        clone.gameObject.GetComponent<Rigidbody>().velocity  = clone.forward* projectileSpeed;
      //  Debug.DrawLine(clone.position, clone.forward, Color.green, 0.1f);
        yield return new WaitForSeconds(FireRate);
        canShoot = true;

    }
}
