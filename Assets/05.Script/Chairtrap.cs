using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chairtrap : MonoBehaviour {
    public GameObject chair;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chair.GetComponent<Arrow>().StartTrap();
        }
    }
}
