using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearOnCollide : MonoBehaviour
{
    public GameObject[] appearObj;
    public GameObject[] disappearObj;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the tag "Player"
        {
            foreach (GameObject obj in appearObj)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }

            foreach (GameObject obj in disappearObj)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}