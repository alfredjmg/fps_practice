using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor001 : MonoBehaviour
{

    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject TheDoor;
    public GameObject TextDisplay;

    public GameObject ObjectiveComplete;

    // Update is called once per frame
    void Update()
    {

        TheDistance = PlayerCasting.DistanceFromTarget;
    }



    private void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            TextDisplay.GetComponent<Text>().text = "Press button";
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                StartCoroutine(OpenTheDoor());
                ObjectiveComplete.SetActive(true);
            }
        }
    }

    private void OnMouseExit()
    {
        TextDisplay.GetComponent<Text>().text = "";
    }

    IEnumerator OpenTheDoor()
    {
        TheDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        TheDoor.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(5);
        TheDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        TheDoor.GetComponent<Animator>().enabled = false;
    }
}
