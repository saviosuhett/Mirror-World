using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed;
    Vector3 nextPosition;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    private GameObject player;

    public bool fire;
    // Start is called before the first frame update
    void Start()
    {
        // playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        nextPosition = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
        
    }   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!other.GetComponent<Player>().isNegative)
            {
                other.GetComponent<Player>().TakeDamage(30);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }



}
