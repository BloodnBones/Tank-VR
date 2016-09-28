using UnityEngine;
using System.Collections;

public class FireAnimator : MonoBehaviour {


    public Animator Anim;

    // Use this for initialization
    void Start () {
        Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Fire") > 0)
        {
            Anim.Play("Tank_2", -1, 0f);
        }

    }
}
