using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMotor : MonoBehaviour {

    public float speed =7.0f;
    private CharacterController controller;
    private Vector3 moveVector;
	private Animator anim;
	private Rigidbody playerbody;
    private int coins = 0;
    public Text coinText;
    public GameObject gameOverText;
    private GameObject restartBtn;
	// Use this for initialization
	void Start () {
        gameOverText.SetActive(false);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        playerbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
        restartBtn = GameObject.FindGameObjectWithTag("restartBtn");
        restartBtn.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        moveVector = Vector3.zero;
		moveVector.z = speed;
        moveVector.x = Input.GetAxisRaw ("Horizontal") * speed * 0.1f;
        //moveVector.x = Input.acceleration.x * speed;// * 0.1f; ;
        if (Input.GetKeyDown("space") && controller.isGrounded){	
			//moveVector += (Vector3.up * 400.0f);
			moveVector.y = 75.0f;                       			
			anim.Play("JUMP00",-1,0.4f);
			controller.Move(moveVector * Time.deltaTime );
		}
		else{
			controller.Move(moveVector * Time.deltaTime );

		}
        if(transform.position.y  < -3)
        {
            Time.timeScale = 0;
            restartBtn.SetActive(true);
            gameOverText.SetActive(true);
            //Application.LoadLevel(0);
        }
		
	}
    public void SetSpeed(int modifier)
    {
        speed = 5.0f + modifier*2 ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coins++;
            coinText.text = "Coins : " + coins.ToString();
            other.gameObject.SetActive(false);
        }
    }
}           
