using UnityEngine;
using System.Collections;

public class DebugDraw : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, transform.forward, Color.red, 0.1f);

    }
}
