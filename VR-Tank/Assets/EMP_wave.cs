using UnityEngine;
using System.Collections;

public class EMP_wave : MonoBehaviour {

    public Vector3 scale;
    public shoot_First emptrigger;
    float timer = 0;
    public float growFactor = 20;
    // Use this for initialization
    void Start () {
        emptrigger = transform.parent.GetComponent<shoot_First>();
	}
	
	// Update is called once per frame
	void Update () {
        if (emptrigger.empstart)
        {
            if (scale.x > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(15, 15, 15) * Time.deltaTime * growFactor;
            }
        }
        else
        {
            timer = 0;
            timer += Time.deltaTime;
            if (transform.localScale.x > 1)
            {
                transform.localScale -= new Vector3(20, 20, 20) * Time.deltaTime * growFactor;
            }
            else
            {
                transform.localScale = Vector3.zero;
            }
        }
	}
}
