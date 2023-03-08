using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health;
    public float Speed;
    public int Damage;
    public bool isAlive;

    public Player(int health, float speed, int damage)
    {
        Health = health;
        Speed = speed;
        Damage = damage;
        isAlive = health >= 0;
    }
    
    
}
