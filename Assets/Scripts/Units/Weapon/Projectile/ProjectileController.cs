using System;
using UnityEngine;

namespace Units.Weapon.Projectile
{
    public abstract class ProjectileController : MonoBehaviour
    {
        public abstract void Fire(Vector3 force, Action onDone);
    }
}