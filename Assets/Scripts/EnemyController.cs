using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float speed;


    GameController game;
    Animator animator;
    CharacterController controller;
    GameObject target;

    public void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameController>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        target = GameObject.Find("Player");
        animator.Play("walk");
    }

    public void Update()
    {
        transform.LookAt(target.transform);
        Vector3 movement = Vector3.zero;//transform.forward * Time.deltaTime * speed;
        movement.y = -9.81f;
        controller.Move(movement);
    }

    public void Die()
    {
        game.AddScore();
        animator.Play("die");
        Destroy(gameObject, 1.0f);
    }
}
