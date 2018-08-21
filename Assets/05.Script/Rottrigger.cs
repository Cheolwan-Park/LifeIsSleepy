using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rottrigger : MonoBehaviour {
    private bool entered = false;
    private bool triggered = false;
    public GameObject disable;
    public Transform target;

    private void Update()
    {
        if (entered && Input.GetMouseButtonDown(0))
            triggered = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerCtrlScript>().rottriggerarea = true;
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(triggered)
            {
                disable.SetActive(false);
                other.GetComponent<PlayerCtrlScript>().Turn(target);
            }
            other.GetComponent<PlayerCtrlScript>().rottriggerarea = false;
            entered = false;
        }
    }
}
