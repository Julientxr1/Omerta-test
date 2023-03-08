using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

[CreateAssetMenu(fileName = "Enemy", menuName = "My Game/Enemy")]
public class Enemy : ScriptableObject
{
    public string name;
    public int health;
    public float speed;
    public float sightRange;
    public bool isAlive;
    public RangeWeapon rangeWeapon;
    public int ammo;
    
    public void Attack(Player player)
    {
        if (player.isAlive)
        {
            int HowMany = 0;
            if (rangeWeapon.Shot())
            {
                player.Health -= rangeWeapon.Damage;
                if (player.Health <= 0)
                {
                    player.isAlive = false;
                }
            }
            else
            {
                if (ammo > 0)
                {
                    HowMany = (ammo > rangeWeapon.Capacity ? rangeWeapon.Capacity : ammo);
                    ammo -= HowMany;
                    rangeWeapon.Reload(HowMany);
                }
            }
        }
    }
}
