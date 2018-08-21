using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeFirst : MonoBehaviour {
    public Axe axe;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            axe.StartTrap();
        }
    }
}
