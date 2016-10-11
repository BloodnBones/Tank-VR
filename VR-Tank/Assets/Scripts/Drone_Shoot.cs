using UnityEngine;
using System.Collections;

public class Drone_Shoot : MonoBehaviour {


    GameObject target;
    public Transform bullet;
    public float projectileSpeed = 20;
    public float FireRate = 0.8f;
    public bool isShooting = false;
    bool canShoot = true;
    float randomChance = 0;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position), 10 * Time.deltaTime);
      //  Debug.DrawLine(transform.position, transform.forward, Color.blue, 0.1f);
        randomChance = Random.Range(0, 100);
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 100 && canShoot)
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

    IEnumerator Shoot()
    {
        canShoot = false;
        // Instantiate the projectile at the position and rotation of this transform
        Transform clone;
        Vector3 spawnPos = transform.position;

        spawnPos.z += 0.6f;
        clone = Instantiate(bullet, spawnPos, transform.rotation) as Transform;

        // Add force to the cloned object in the object's forward direction
        clone.gameObject.GetComponent<Rigidbody>().velocity = (target.transform.position - transform.position).normalized * projectileSpeed;
        yield return new WaitForSeconds(FireRate);
        canShoot = true;

    }
}
