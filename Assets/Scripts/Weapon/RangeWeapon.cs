using System.Threading.Tasks;
using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "RangeWeapon", menuName = "My Game/RangeWeapon")]
    public class RangeWeapon : Weapon
    {
        public int Damage;
        public int ReloadTime;
        public int TimeBetweenShots;
        public int Capacity;
        public int Ammo;
        public int range;

        public RangeWeapon(string name, int damage, int reloadTime, int timeBetweenShots, int capacity)
        {
            Name = name;
            Damage = damage;
            ReloadTime = reloadTime;
            TimeBetweenShots = timeBetweenShots;
            Capacity = capacity;
            Ammo = capacity;
        }

        public bool Shot()
        {
            if (Ammo > 0)
            {
                Ammo -= 1;
                Task.Delay(TimeBetweenShots);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reload(int ammo)
        {
            Task.Delay(ReloadTime);
            Ammo = Capacity;
        }
    }
}