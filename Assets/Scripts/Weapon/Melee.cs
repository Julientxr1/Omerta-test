using System.Threading.Tasks;
using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "Melee", menuName = "My Game/Melee")]
    public class Melee : Weapon
    {
        public int Damage;
        public int TimeBetweenHits;

        public Melee(string name, int damage, int timeBetweenHits)
        {
            Name = name;
            Damage = damage;
            TimeBetweenHits = timeBetweenHits;
        }

        public void Hit()
        {
            Task.Delay(TimeBetweenHits);
        }
    }
}