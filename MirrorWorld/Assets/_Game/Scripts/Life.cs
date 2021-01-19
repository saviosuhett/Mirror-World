using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (other.GetComponent<Player>().currentHealth == 100)
            {
                VoiceClips.PlaySound("fullEnergy");
            } 
           else { 
                other.GetComponent<Player>().IncrementoDano();
                VoiceClips.PlaySound("energyRecovery");
                Destroy(this.gameObject);
            }
        }
    }
}

