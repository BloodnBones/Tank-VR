using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeenShot : MonoBehaviour {

    [SerializeField]
    private StatArmour armour;


    // Use this for initialization
    void Start () {
        armour.Initialise();
       
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnCollisionEnter(Collision other)                  //This is temporary for testing with the damage/heal boxes
    {
       // Debug.Log("Hit");
        if (other.gameObject.name == "Debug-Damage")
        {
            armour.CurrentVal -= 1;
        }
        if (other.gameObject.name == "Debug-Heal")
        {
            armour.CurrentVal += 1;
        }
        if (other.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("Shot");
            armour.currentVal -= 1;
        }
    }
}
