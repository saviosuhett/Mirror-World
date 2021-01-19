using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    GameObject player;
    public GameObject chaveUI;
  // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().chavesColetadas++;
            VoiceClips.PlaySound("keyCollected");
            Destroy(this.gameObject); 
            print("Peguei a chave: "+other.GetComponent<Player>().chavesColetadas);
            chaveUI.SetActive(true);
        }
    }
}
