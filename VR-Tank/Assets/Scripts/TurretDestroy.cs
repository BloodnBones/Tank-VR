using UnityEngine;
using System.Collections;

public class TurretDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            transform.parent.gameObject.GetComponent<EnemyHit>().Dead = true;
        }
    }

}
