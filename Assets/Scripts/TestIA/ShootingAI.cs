using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TestIA
{
    public class ShootingAi : MonoBehaviour
    {
        public NavMeshAgent agent;

        public Transform player;
        public GameObject gun;

        //Stats
        public int health;
        public int maxhealth;
        [SerializeField] FloatingHealthBar healthBar;

        //Check for Ground/Obstacles
        public LayerMask whatIsGround, whatIsPlayer;

        //Patroling
        public List<GameObject> points;
        public int current = 0;

        //Attack Player
        public float timeBetweenAttacks;
        bool alreadyAttacked;

        //States
        public bool isDead;
        public float sightRange, attackRange;
        public bool playerInSightRange, playerInAttackRange;

        //Special
        public Material green, red, yellow;
        public GameObject projectile;

        private void Awake()
        {
            player = GameObject.Find("PlayerArmature").transform;
            agent = GetComponent<NavMeshAgent>();
            healthBar = GetComponentInChildren<FloatingHealthBar>();
        }

        public void Start()
        {
            healthBar.UpdateHealthBar(health, maxhealth);
        }

        private void Update()
        {
            if (!isDead)
            {
                //Check if Player in sightrange
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

                //Check if Player in attackrange
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (!playerInSightRange && !playerInAttackRange) Patrol();
                if (playerInSightRange && !playerInAttackRange) ChasePlayer();
                if (playerInAttackRange && playerInSightRange) AttackPlayer();
            }
        }


        public void Patrol()
        {
            if (Vector3.Distance(transform.position, points[current].transform.position) > 5)
            {
                agent.SetDestination(points[current].transform.position);
            }
            else
            {
                current = (current + 1) % points.Count;
                agent.SetDestination(points[current].transform.position);
            }
        }
        private void ChasePlayer()
        {
            if (isDead) return;

            agent.SetDestination(player.position);

            GetComponent<MeshRenderer>().material = yellow;
        }
        private void AttackPlayer()
        {
            if (isDead) return;

            //Make sure enemy doesn't move
            agent.SetDestination(transform.position);

            transform.LookAt(player);

            if (!alreadyAttacked){

                //Attack
                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 3, ForceMode.Impulse);

                alreadyAttacked = true;
                Invoke("ResetAttack", timeBetweenAttacks);
            }

            GetComponent<MeshRenderer>().material = red;
        }
        private void ResetAttack()
        {
            if (isDead) return;

            alreadyAttacked = false;
        }
        public void TakeDamage(int damage)
        {
            health -= damage;
            healthBar.UpdateHealthBar(health, maxhealth);
            if (health < 0){
                isDead = true;
                Invoke("Destroyy", 2.8f);
            }
        }
        private void Destroyy()
        {
            Destroy(gameObject);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
}
