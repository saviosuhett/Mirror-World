using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Teleporte : MonoBehaviour {

    public Transform getPortal;
    public bool paraTeto;
    public bool paraChao;
    public float pushPlayer;

    void Start() {
    }

    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (paraTeto)
        {
            //SoundManager.PlaySound("teleport");
            other.transform.localScale = new Vector2(1, -1);
            other.GetComponent<Rigidbody2D>().gravityScale = -1;
            other.transform.position = new Vector2(getPortal.transform.position.x + pushPlayer, getPortal.transform.position.y);
            SoundManager.PlaySound("teleport");
        }
        if (paraChao)
        {   
            other.transform.localScale = new Vector2(1, 1);
            other.GetComponent<Rigidbody2D>().gravityScale = 1;
            other.transform.position = new Vector2(getPortal.transform.position.x + pushPlayer, getPortal.transform.position.y);
            SoundManager.PlaySound("teleport");
        }
    }


}
