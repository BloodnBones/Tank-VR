using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour
{
    public GameObject wreck;
    public bool Dead = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
        {
            Explode();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Dead = true;
        }
    }
    void Explode()
    {
        GameObject hit = Instantiate(wreck, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
    }
}