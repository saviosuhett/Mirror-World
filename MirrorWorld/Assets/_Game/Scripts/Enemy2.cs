using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPosition;
    Vector3 nextPosition;

    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;


    public GameObject prefabBullet;
    public Transform bulletSpaw;

    // public GameObject player;
    Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = startPosition.position;
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position) {
            nextPosition = pos2.position;
            spriteRenderer.flipX = false;
        }

        if (transform.position == pos2.position) {
            nextPosition = pos1.position;
            spriteRenderer.flipX = true;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!other.GetComponent<Player>().isNegative)
            {

                Instantiate(prefabBullet, bulletSpaw.position, Quaternion.identity);
            }
        }
    }






}
