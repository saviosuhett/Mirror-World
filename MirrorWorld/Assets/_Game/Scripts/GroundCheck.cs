using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public GameObject player;
    private GameObject jump;

    void Start() {

        jump = gameObject.transform.parent.gameObject;

    }


    void Update() {

    }


    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.collider.tag == "chao") {
            jump.GetComponent<Player>().onFloor = true;
        }

        if (collision.collider.tag == "chao") {
            player.transform.parent = collision.gameObject.transform;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        player.transform.parent = null;
    }

}

