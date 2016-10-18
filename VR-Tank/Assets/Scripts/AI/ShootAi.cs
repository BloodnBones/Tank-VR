using UnityEngine;
using System.Collections;

public class ShootAi : MonoBehaviour
{
    public GameObject BarrelParticle;
    public GameObject Barrel2Particle;
    GameObject target;
    public Transform bullet;
    public float projectileSpeed = 20;
    public float FireRate = 2.0f;
    public bool canShoot = true;
    float randomChance = 0;
    public float distance;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        target = FindClosestEnemy();
        distance = Vector3.Distance(target.transform.position, transform.position);
        randomChance = Random.Range(0, 100);
        if (target != null)
        {
            if (Vector3.Distance(target.transform.position , transform.position) < 30 && canShoot)
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
       
        Quaternion looktarget = Quaternion.LookRotation(target.transform.position - transform.position);
        Quaternion targetHorizontal = transform.rotation;

        targetHorizontal = looktarget;
       // targetHorizontal.w = looktarget.w;

        transform.rotation = targetHorizontal;

        
        clone = Instantiate(bullet, transform.position, transform.rotation) as Transform;
        
        // Add force to the cloned object in the object's forward direction
        clone.gameObject.GetComponent<Rigidbody>().AddForce(clone.forward * projectileSpeed);

   //     BarrelParticle.GetComponent<ParticleSystem>().Play();
   //     Barrel2Particle.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(FireRate);
        canShoot = true;

    }

    GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}


