using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespaw : MonoBehaviour
{
    GameObject player;
    // public GameObject playerPrefab;
    public Transform playerWhiteSpawPoint;
    public Transform playerDarkSpawPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Player Death
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.GetComponent<Player>().darkSide)
            {
                // Destroy(other.gameObject);
                other.transform.position = playerDarkSpawPoint.position;
            }
            if (player.GetComponent<Player>().whiteSide)
            {
                // Destroy(other.gameObject);
                other.transform.position = playerWhiteSpawPoint.position;
            }
        }
    }

    // // Spaw Player
    // public void SpawPlayer(Transform spawpoint)
    // {
    //     Instantiate(playerPrefab, spawpoint.position, Quaternion.identity);
    // }
}
