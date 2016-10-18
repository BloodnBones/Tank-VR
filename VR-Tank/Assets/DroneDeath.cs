using UnityEngine;
using System.Collections;

public class DroneDeath : MonoBehaviour
{

    public bool isDead = false;
    public int index = 0;
    public float destroytimer = 10.0f;
    Flock Ai;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            GetComponent<Rigidbody>().velocity -= new Vector3(0.0f,10.0f,0f);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().mass += (9f * Time.time);
            GetComponent<Animator>().Stop();
            StartCoroutine("Destroy");
        }

    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroytimer);
        Destroy(transform.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            isDead = true;
        }
    }
    
   public void setIndex(int _index)
    {
        index = _index;
    }
}
