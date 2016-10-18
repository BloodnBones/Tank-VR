using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    public float RespawnTimer = 0.0f;
    public float RespawnDeplete = 0.0f;
    public bool IsActive = true;
    public GameObject Child;
    public GameObject Secondary;
    public WeaponType Weapon = WeaponType.MACHINE_GUN;
 
    bool created = false;
	// Use this for initialization
	void Start () {
        RespawnDeplete = RespawnTimer;
    }
	
	// Update is called once per frame
	void Update () {

        if(!created)
        {
            Create();
        }

        if(IsActive == false)
        {
            RespawnDeplete -= Time.deltaTime;
        }

        if(RespawnDeplete <= 0.0f)
        {
            IsActive = true;
            RespawnDeplete = RespawnTimer;
            Child.gameObject.SetActive(IsActive);
        }


	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && IsActive == true)
        {
            Debug.Log("Hit Player");
            //Give the player the pickup
            for(int i = 0; i < Secondary.transform.childCount; ++i)
            {
                if (Secondary.transform.GetChild(i).gameObject.activeSelf)
                {
                    Secondary.transform.GetChild(i).gameObject.SetActive(false);
                }                  
            }
            Secondary.transform.GetChild((int)Weapon).gameObject.SetActive(true);
            //Disable the pickup
            IsActive = false;
            Child.gameObject.SetActive(IsActive);
        }
    }

    void Create()
    {
        GameObject newChild;

        newChild = Instantiate(Child, transform.position, transform.rotation) as GameObject;

        newChild.transform.SetParent(this.transform);
        Child = newChild;

        created = true;
    }
}
