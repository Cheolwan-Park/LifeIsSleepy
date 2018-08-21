using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOpenTrap : MonoBehaviour {
    public Opener l;
    public Opener r;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            l.Trap();
            r.Trap();
        }
    }
}
