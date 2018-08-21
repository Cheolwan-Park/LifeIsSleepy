using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walltrap_default : MonoBehaviour
{

    [SerializeField]
    Mesh mesh;

    MeshFilter thisMeshfilter;

    // Use this for initialization
    void Start()
    {
        thisMeshfilter = gameObject.GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("StartTrap", 0.5f);
        }
    }

    void StartTrap()
    {
        thisMeshfilter.mesh = mesh;
    }
}