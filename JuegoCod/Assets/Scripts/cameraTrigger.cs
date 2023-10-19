using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject CameraOne;
    public GameObject CameraTwo;
    public bool camOn = false;
    public int cameraNumber;

    void Start()
    {
        cameraNumber = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraTwo.SetActive(true);
            CameraOne.SetActive(false);
        }
    }
}

