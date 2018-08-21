using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAxe : MonoBehaviour {
    public float speed = 0.0f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f);
	}
}
