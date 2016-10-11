using UnityEngine;
using System.Collections;

public enum WeaponType : int
{
    CANNON,
    MACHINE_GUN,
    LAZER_BEAM,
    RAIL_GUN
}
public class Pickup_Weapon_Model : MonoBehaviour
{
    public WeaponType PickupType = WeaponType.CANNON;

    public float RotationSpeed = 0.0f;

    public float BobHeight = 0.0f;

    public float BobSpeed = 0.0f;

    public float OffSet;

    bool bUp = true;

    // Use this for initialization
    void Start()
    {
        transform.localPosition += new Vector3(0.0f, OffSet, 0.0f);
        PickupType = transform.parent.GetComponent<Pickup>().Weapon;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), Time.deltaTime * RotationSpeed);

        if (transform.localPosition.y >= (BobHeight + OffSet))
        {
            bUp = false;
        }
        if (transform.localPosition.y <= (OffSet))
        {
            bUp = true;
        }

        if (bUp == true)
        {
            transform.localPosition += new Vector3(0, (BobSpeed * Time.deltaTime), 0);
        }
        else
        {
            transform.localPosition += new Vector3(0, -(BobSpeed * Time.deltaTime), 0);
        }
    }
}
