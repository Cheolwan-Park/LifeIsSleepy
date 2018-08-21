using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walltrap_first : MonoBehaviour {

    [SerializeField]
    Mesh mesh;

    [SerializeField]
    GameObject one;
    [SerializeField]
    GameObject two;
    [SerializeField]
    GameObject three;
    [SerializeField]
    GameObject four;

    MeshFilter thisMeshfilter;
    Mesh thisMesh;

	// Use this for initialization
	void Start () {
        thisMeshfilter = gameObject.GetComponent<MeshFilter>();
        thisMesh = thisMeshfilter.mesh;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTrap();
        }
    }

    void StartTrap()
    {
        thisMeshfilter.mesh = mesh;
        one.GetComponent<Arrow>().StartTrap();
        two.GetComponent<Arrow>().StartTrap();
        three.GetComponent<Arrow>().StartTrap();
        four.GetComponent<Arrow>().StartTrap();
        Invoke("Default", 1.0f);
    }

    void Default()
    {
        thisMeshfilter.mesh = thisMesh;
    }

}
