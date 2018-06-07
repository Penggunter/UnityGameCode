using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {
	Transform[] items;

	// Use this for initialization
	void Start () {
		items = new Transform[10];
	}
	public Transform key;
	public Transform hammer;

	public Transform zamok;
	public Transform doska1;
	public Transform doska2;

	bool boolHammer = false;
	bool boolKey = false;

	float i =0;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F; 
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	float camSens = 0.25f; 
	private Vector3 lastMouse = new Vector3(255, 255, 255);

	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);


		lastMouse = Input.mousePosition - lastMouse ;
		lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
		lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
		transform.eulerAngles = lastMouse;
		lastMouse =  Input.mousePosition;


		if (Input.GetKey (KeyCode.E)){
			Debug.Log (i);

			 if (Vector3.Distance(key.position, transform.position) < 2f) {
                i = Time.deltaTime * 1;
                int a = Mathf.FloorToInt(i);
				key.gameObject.SetActive(false);
                items[a] = key;
            }

			 if (Vector3.Distance(hammer.position, transform.position) < 2f) {
                i = Time.deltaTime * 1;
                int a = Mathf.FloorToInt(i);
                hammer.gameObject.SetActive(false);
                items[a] = hammer;
            }

			for(int j = 0; j < items.Length; j++){
				if (Vector3.Distance (zamok.position, transform.position) < 2f || Vector3.Distance (zamok.position, transform.position) < 2f) {
					if (items[j].gameObject.tag == "hamm") {
						doska1.gameObject.SetActive (false);
						doska2.gameObject.SetActive (false);
						boolHammer = true;
					}
					if (items[j].gameObject.tag == "keyy") {
						zamok.gameObject.SetActive (false);
						boolKey = true;
					}
					if (boolHammer == true && boolKey == true){
						Application.LoadLevel("scene2");
					}
				}
			}

			Debug.Log (items);
		}

	}
}