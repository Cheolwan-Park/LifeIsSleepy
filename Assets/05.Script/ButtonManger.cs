using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManger : MonoBehaviour {
	

    public void ReStartScene()
    {
        SceneManager.LoadScene("Main");
    }

    private void Update()
    {
    }
}
