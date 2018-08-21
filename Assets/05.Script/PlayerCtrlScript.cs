using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrlScript : MonoBehaviour {

    [SerializeField] private float acceleration;
    [SerializeField] private float jumpPower;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Collider background;
    [SerializeField] private GameObject gameoverTx;
    [SerializeField] private Image fadeOutPanel;
    public float rottime = 0.0f;
    public Animator animator;
    [HideInInspector]public bool rottriggerarea = false;

    [HideInInspector] public bool isTurnning = false;
    [HideInInspector] public bool isJumping = false;
    private float time = 0;
    private float defaultX;

    private Rigidbody thisRig;
    private SpriteRenderer thisRen;
    private bool isGameover = false, isGameclear = false;
    private float a = 0;

    [SerializeField] private Image[] images = new Image[4];

    void Start () {
        thisRig = GetComponent<Rigidbody>();
        thisRen = GetComponentInChildren<SpriteRenderer>();
	}
	
	void Update ()
    {
        if (!isGameover && !isGameclear)
        {
            Move();
            Gravity();
        }
        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void Turn(Transform dest)
    {   isTurnning = true;  
        StartCoroutine(turning(dest));
    }

    IEnumerator turning(Transform rotdest)
    {
        float t = 0.0f;
        float speed = 90.0f / rottime;
        Vector3 startpos = transform.position;
        while (t < rottime)
        {
            t += Time.deltaTime;
            transform.Rotate(0.0f, -Time.deltaTime * speed, 0.0f);
            transform.position = Vector3.Lerp(startpos, rotdest.position, t / rottime);
            yield return null;
        }
        transform.position = rotdest.position;
        isTurnning = false;
    }
    

    IEnumerator FadeOutCo()
    {
        while (a < 1)
        {
            fadeOutPanel.color = new Color(0, 0, 0, a);
            a += 0.02f;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Title");
    }

    void Move()
    {
        if (!isTurnning)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            //transform.Translate(Time.deltaTime * moveSpeed, 0, 0);
        }
    }

    void Gravity()
    {
        if (isJumping && !isTurnning)
        {
            time += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, (-acceleration / 2) * time * time + jumpPower * time + defaultX, transform.position.z);
        }
        //else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width/2 && Input.mousePosition.x < Screen.height / 2)
        else if(!isTurnning&&!rottriggerarea&&Input.GetMouseButtonDown(0))
        {
            thisRig.useGravity = false;
            time = 0;
            isJumping = true;
            defaultX = transform.position.y;
            animator.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("background"))
        {
            thisRig.useGravity = true;
            isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arm"))
        {
            StartCoroutine(hit());
        }
        if (other.CompareTag("clear"))
        {
            GameClear();
        }
    }

    private void GameClear()
    {
        StartCoroutine(FadeOutCo());
    }

    IEnumerator hit()
    {
        animator.SetTrigger("isDie");
        thisRig.isKinematic = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        StartCoroutine(YouDiedFade());
        isGameover = true;
        yield return new WaitForSeconds(0.1f);
        thisRen.color = Color.gray;
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator YouDiedFade()
    {
        while (a < 1)
        {
            for (int i = 0; i < 4; i++)
            {
                images[i].color = new Color(1, 1, 1, a);
            }
            a += 0.02f;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
