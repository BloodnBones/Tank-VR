using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour
{

    public float destroytimer = 10.0f;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("Destroy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroytimer);
        Destroy(transform.gameObject);
    }
}
