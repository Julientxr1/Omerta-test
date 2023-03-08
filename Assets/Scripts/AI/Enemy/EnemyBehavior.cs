using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public Enemy enemy;
    public Transform playerTransform;
    public Player player;
    public bool isAttacking;

    void Start()
    {
        if (navAgent == null)
        {
            navAgent = GetComponent<NavMeshAgent>();
        }
        if (enemy != null)
        {
            LoadEnemy(enemy);
        }

        current = 0;
    }
    
    private void LoadEnemy(Enemy _data)
    {
        // Supprime tous les child de l'empty s'il y en a 
        foreach (Transform child in transform)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(child.gameObject);
            }
            else
            {
                Destroy(child.gameObject);
            }
        }

        navAgent.speed = enemy.speed;
    }

    
    
    public void patrol()
    {
        navAgent.speed = enemy.speed;
        if (transform.position != points[current].position)
        {
            navAgent.SetDestination(points[current].position);
        }
        else
        {
            current = (current + 1) % points.Length;
            navAgent.SetDestination(points[current].position);
        }
    }

    public void chase()
    {
        navAgent.speed = 2 * enemy.speed;
        navAgent.SetDestination(playerTransform.position);
    }

    public void attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;

            navAgent.SetDestination(transform.position);
            transform.LookAt(playerTransform);
            enemy.Attack(player);
            
            isAttacking = false;
        }
    }
    
    
    public bool playerInSightRange, playerInAttackRange;
    public Transform[] points;
    private int current;

    void Update()
    {
        if (enemy.isAlive)
        {
            if (player.isAlive)
            {
                //bool obstacle = true if there is an object that hide the player from the enemy, else false
                var playerPosition = playerTransform.position;
                var enemyPosition = transform.position;
                playerInSightRange = Vector3.Distance(enemyPosition, playerPosition) < enemy.sightRange;
                playerInAttackRange = Vector3.Distance(enemyPosition, playerPosition) < enemy.rangeWeapon.range;

                if (playerInAttackRange) // && !obstacle
                {
                    attack();
                }
                else if (playerInSightRange) // && !obstacle
                {
                    chase();
                }
                else
                {
                    patrol();
                }
            }
            else
            {
                patrol();
            }
        }
    }
}