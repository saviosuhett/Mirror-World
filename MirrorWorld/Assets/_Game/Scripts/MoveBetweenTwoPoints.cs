using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPosition;
    Vector3 nextPosition;

    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;
    void Start() {
        nextPosition = startPosition.position;
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (transform.position == pos1.position) {
            nextPosition = pos2.position;
            spriteRenderer.flipX = true;
        }

        if (transform.position == pos2.position) {
            nextPosition = pos1.position;
            spriteRenderer.flipX = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }
}
