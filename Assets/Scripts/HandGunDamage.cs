using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour
{

    public int DamageAmount = 5;
    public float TargetDistance;
    public float AllowedRange = 15;
    public RaycastHit hit;
    public GameObject TheBullet;
    void Update()
    {
        Vector3 forward1 = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward1, Color.red);
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit Shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
                {
                    TargetDistance = Shot.distance;
                    Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                    Debug.DrawRay(transform.position, forward, Color.green);
                    if (TargetDistance < AllowedRange)
                    {
                        Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                        {
                            Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                        }

                    }
                }
            }
        }
    }
}
