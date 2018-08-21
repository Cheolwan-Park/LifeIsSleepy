using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public float speed = 0.0f;
    Vector3 defaultTrans;

	// Use this for initialization
	void Start () {
        defaultTrans = transform.position;
	}
	
	public void StartTrap()
    {
        StopAllCoroutines();
        StartCoroutine("cor");
    }

    IEnumerator cor()
    {
        while (defaultTrans.z - transform.position.z < 30)
        {
            transform.localPosition += new Vector3(0.0f, 0.0f, -speed * Time.deltaTime);
            yield return null;
        }
        transform.position = defaultTrans;
    }
}
