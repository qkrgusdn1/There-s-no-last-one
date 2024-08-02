using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public string characterName;
    public CharacterGrade characterType;
    public Transform atkPoint;
    public Vector2 atkRange;
    public LayerMask hittableLayerMask;
    public bool wideCharacter;
    public int atkDamage;
    public float attackCooldown;
    float lastAttackTime;
    public Animator animator;

    private void OnDrawGizmos()
    {
        if (atkPoint == null)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(atkPoint.position, atkRange);
    }

    private void Update()
    {
        AttackCount();
    }

    private void AttackCount()
    {
        if (Time.time - lastAttackTime < attackCooldown)
            return;

        Collider2D[] cols = Physics2D.OverlapBoxAll(atkPoint.position, atkRange, 0, hittableLayerMask);
        if (cols.Length > 0)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    public void Attack()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(atkPoint.position, atkRange, 0, hittableLayerMask);
        if (wideCharacter)
        {
            foreach (Collider2D col in cols)
            {
                if (!col.CompareTag("Enemy"))
                {
                    continue;
                }

                if (col.CompareTag("Enemy"))
                {
                    Enemy enemy = col.GetComponent<Enemy>();
                    enemy.TakeDamage(atkDamage);
                    animator.Play("2_Attack_Normal");
                }
            }
            return;
        }
        else
        {
            float nearestDistance = Mathf.Infinity;
            Enemy nearestEnemy = null;

            foreach (Collider2D monster in cols)
            {
                if (!monster.CompareTag("Enemy"))
                {
                    continue;
                }

                float distance = Vector3.Distance(transform.position, monster.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = monster.GetComponent<Enemy>();
                }
            }
            if (nearestEnemy != null)
            {
                nearestEnemy.TakeDamage(atkDamage);
                animator.Play("2_Attack_Normal");
            }
            return;
        }
    }
}
