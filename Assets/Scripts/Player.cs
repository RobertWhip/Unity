using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private bool parachuteOpened = false;
	private SpriteRenderer parachute = null;
	private Rigidbody playerRb = null;
	void Start() {
		this.parachute = transform.Find("parachute").GetComponent<SpriteRenderer>();
		playerRb = GetComponent<Rigidbody>();
		
		Debug.Log(Vector3.Angle(new Vector3(1, 5, -7), new Vector3(8, 0, -6)));
	}
	
    void Update() {
        if (Input.GetKeyDown("space")) {
            openParachute(true);
        }
    }

    void OnCollisionEnter(Collision collision) {
		if (parachuteOpened) {
			Debug.Log("You could make it");
			openParachute(false);
		} else {
			Debug.Log("You broke your legs");
		}
    }
	
	bool openParachute(bool open){
        this.parachuteOpened = open;
		this.parachute.enabled = open;
		playerRb.drag = open ? 1.7F : 0F;
		
		return true;
	}
}
