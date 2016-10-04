using UnityEngine;
using System.Collections;

public class ShootAi : MonoBehaviour
{
    public GameObject BarrelParticle;
    public GameObject Barrel2Particle;
    GameObject target;
    public Transform bullet;
    public float projectileSpeed = 20;
    public float FireRate = 0.8f;
    bool canShoot = true;
    float randomChance = 0;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        randomChance = Random.Range(0, 100);
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 20 && canShoot)
            {

                StartCoroutine("Shoot");
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
        clone.gameObject.GetComponent<Rigidbody>().AddForce(clone.forward * projectileSpeed);
        // clone.rigidbody.AddForce(clone.transform.forward * shootForce);

        BarrelParticle.GetComponent<ParticleSystem>().Play();
        Barrel2Particle.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(FireRate);
        canShoot = true;

    }


}


