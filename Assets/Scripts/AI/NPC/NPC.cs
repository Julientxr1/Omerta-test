using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

[CreateAssetMenu(fileName = "NPC", menuName = "My Game/NPC")]
public class NPC : ScriptableObject
{
    public string name;
    public int health;
    public float speed;
    public float sightRange;
    public bool isAlive;
    public bool panic;
}