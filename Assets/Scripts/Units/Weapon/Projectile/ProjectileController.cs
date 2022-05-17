using System;
using Units.Health;
using UnityEngine;

namespace Units.Weapon.Projectile
{
    public abstract class ProjectileController : MonoBehaviour, IDamageContainer
    {
        [SerializeField]
        private int _damage = 20;

        public int Damage => _damage;
        
        public abstract void Fire(Vector3 force, Action onDone);
    }
}