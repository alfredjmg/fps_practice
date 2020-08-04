using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfire : MonoBehaviour
{

    public GameObject Flash;

    // Update is called once per frame
    void Update()
    {
        if(GlobalAmmo.LoadedAmmo >= 1) { 
            if (Input.GetButtonDown("Fire1"))
            {
                gameObject.GetComponent<AudioSource>().Play();
                Flash.SetActive(true);
                StartCoroutine(MuzzleOff());
                gameObject.GetComponent<Animation>().Play();
                GlobalAmmo.LoadedAmmo -= 1;
            }
        }
    }

    IEnumerator MuzzleOff()
    {
        yield return new WaitForSeconds(0.1f);
        Flash.SetActive(false);
    }

}
