using UnityEngine;
using System.Collections;

public class barrelMove : MonoBehaviour
{
    // Use this for initialization
    public float backTime = 1f;
    public float forwardTime = 0f;
    bool Fired = false;
    Vector3 Barrel_Local;
    //private boolean goForward;
    void Start()
    {
        Barrel_Local = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) || Fired)
        {
            Fired = true;
            if (backTime > 0)
            {
                backTime -= 0.08f;
                transform.Translate(Vector3.back * Time.deltaTime);
            }
            else
            {
                if (forwardTime < 10.35)
                {
                 
                    forwardTime += 0.16f; 
                    transform.Translate(Vector3.forward * Time.deltaTime * 0.2f);
                }
                else
                {
                    transform.localPosition = Barrel_Local;
                    Fired = false;
                    forwardTime = 0.0f;
                    backTime = 1.0f;
                }


            }
        }



        //transform.Translate(Vector3.forward * 0.1f);

    }
    /*
         IEnumerator Example() {
            transform.Translate(Vector3.back * reloadTime * 5f);
            yield return new WaitForSeconds(5);
            transform.Translate(Vector3.forward * reloadTime * 1f);
        }
        */

}