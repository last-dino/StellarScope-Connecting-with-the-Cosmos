using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class GrabDetection : MonoBehaviour
{
    public GameObject[] actGrab;
    public GameObject[] deactGrab;
    public GameObject[] actRelease;
    public GameObject[] deactRelease;
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to grab and ungrab events
        if (grabInteractable)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrab);
            grabInteractable.onSelectExited.AddListener(OnRelease);
        }
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        Debug.Log("Object grabbed!");
        // Do something when the object is grabbed
        foreach (GameObject obj in actGrab)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in deactGrab)
        {
            obj.SetActive(false);
        }

    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        Debug.Log("Object released!");
        // Do something when the object is released
        foreach (GameObject obj in actRelease)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in deactRelease)
        {
            obj.SetActive(false);
        }
    }
}