using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class NpcBehavior : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public NPC npc;
    public Transform playerTransform;
    public Player player;

    void Start()
    {
        if (navAgent == null)
        {
            navAgent = GetComponent<NavMeshAgent>();
        }
        if (npc != null)
        {
            LoadNPC(npc);
        }

        current = 0;
    }
    
    private void LoadNPC(NPC _data)
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

        navAgent.speed = npc.speed;
    }

    

    public void Walk()
    {
        navAgent.speed = npc.speed;
        if (Vector3.Distance(transform.position, points[current].position) > 1 )
        {
            navAgent.SetDestination(points[current].position);
        }
        else
        {
            current = (current + 1) % points.Length;
            navAgent.SetDestination(points[current].position);
        }
    }

    public void RunAway()
    {
        navAgent.speed = npc.speed * 2;
        navAgent.SetDestination(2 * transform.position - playerTransform.position);
    }
    
    
    public Transform[] points;
    private int current;

    void Update()
    {
        if (npc.isAlive)
        {
            if (npc.panic)
            {
                RunAway();
            }
            else
            {
                Walk();
            }
        }
    }
}