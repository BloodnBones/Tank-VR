using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour
{

    public GameObject HitParticle;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        GameObject hit = Instantiate(HitParticle, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
    }
}
