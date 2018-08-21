using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour {

    [SerializeField] private GameObject player;
    private PlayerCtrlScript playerScript;
    private float lastYpos, nowRot;
    private Vector3 cameraVec3;
    private int wRot;

	void Start () {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrlScript>();
        cameraVec3 = new Vector3(player.transform.position.x, lastYpos, player.transform.position.z - 8);
    }
	
	void Update ()
    {
        if (!playerScript.isTurnning)
        {
            if (!playerScript.isJumping)
            {
                cameraVec3 = new Vector3(player.transform.position.x, player.transform.position.y+1.76f, 0) + (player.transform.localRotation * new Vector3(0, 0, -10));
            }
            else if (playerScript.isJumping)
            {
                cameraVec3 = new Vector3(player.transform.position.x, 0, 0) + (player.transform.localRotation * new Vector3(0, 0, -10));
            }
            transform.position = cameraVec3;
        }


    }

}
