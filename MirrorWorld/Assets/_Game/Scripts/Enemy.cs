using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // void FixedUpdate()
    // {
    //     float distancia = Vector3.Distance(transform.position, player.transform.position);
    //     if (distancia < 3) {
    //         if (!player.GetComponent<Player>().isNegative)
    //         {
    //             player.GetComponent<Player>().TakeDamage(5);
    //         }
    //     }
    // }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!other.GetComponent<Player>().isNegative)
            {
              
                other.GetComponent<Player>().TakeDamage(1);
                 StartCoroutine(ExampleCoroutine());
            }
        }

    }


    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
    }

}
