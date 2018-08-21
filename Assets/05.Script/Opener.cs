using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : MonoBehaviour {
    public Transform pivot;
    public float speed;
    public float time;

    public void Trap()
    {
        StartCoroutine(open());
    }
	
    IEnumerator open()
    {
        float t = 0.0f;
        while(t < time)
        {
            t += Time.deltaTime;
            transform.RotateAround(pivot.position, new Vector3(0.0f, 0.0f, 1.0f), speed * Time.deltaTime);
            yield return null;
        }
    }
}
