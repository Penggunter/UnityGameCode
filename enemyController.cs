using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour {

	// Use this for initialization
	NavMeshAgent nav;
	public Transform Player;
	Transform tr;

	void Start () {
		tr = GetComponent<Transform> ();
		nav = GetComponent<NavMeshAgent> ();
	}
		
	// Update is called once per frame
	void Update () {
		//var enemy = GetComponent<NavMeshAgent> ().destination;
		float dist = Vector3.Distance (tr.position, Player.position);
		//Debug.Log(nav);

		if (dist <= 10f) {
			transform.LookAt (Player);
			nav.SetDestination (Player.position);
		}
	}


	void OnTriggerEnter (Collider arg){
		//Debug.Log ("asdasda");
		if (arg.gameObject.tag == "player") {
			Destroy (arg.gameObject);
		}
	}

}