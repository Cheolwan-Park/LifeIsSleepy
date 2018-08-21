using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {
    public float speed = 0.0f;
    Vector3 defaultTrans;

    // Use this for initialization
    void Start()
    {
        defaultTrans = transform.position;
    }

    public void StartTrap()
    {
        StopAllCoroutines();
        StartCoroutine("cor");
    }

    IEnumerator cor()
    {
        while (defaultTrans.x - transform.position.x < 30)
        {
            transform.localPosition += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
            yield return null;
        }
        transform.position = defaultTrans;
    }
}
