using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour
{
    public GameObject wreck;
    public GameObject Wavy;
    public bool Dead = false;
    public int HPnonLevelMod;
    public int TotalHP;
    bool start = true;
    // Use this for initialization
    void Start()
    {
        Wavy = GameObject.Find("EnemyController");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            TotalHP = HPnonLevelMod *Wavy.GetComponent<EnemyController>().GetLevel();
            start = false;
        }
        if(TotalHP <= 0)
        {
            Dead = true;
        }
        if (Dead)
        {
            Explode();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            TotalHP -= 10;
        }
    }
    void Explode()
    {
        GameObject hit = Instantiate(wreck, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
    }
}