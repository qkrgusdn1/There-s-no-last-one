using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IHittable
{
    public float hp;
    public float maxHp;
    public Image hpBar;
    public float moveSpeed;
    Vector3 moveDirection = Vector3.up;
    public Animator animator;

    private void Start()
    {
        hp = maxHp;

    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        animator.Play("1_Run");
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / maxHp;
        if (hp <= 0)
        {
            Die();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyTurn"))
        {
            if (moveDirection == Vector3.up)
            {
                moveDirection = Vector3.right;
            }
            else if (moveDirection == Vector3.right)
            {
                moveDirection = Vector3.down;
            }
            else if (moveDirection == Vector3.down)
            {
                moveDirection = Vector3.left;
            }
            else if (moveDirection == Vector3.left)
            {
                moveDirection = Vector3.up;
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
