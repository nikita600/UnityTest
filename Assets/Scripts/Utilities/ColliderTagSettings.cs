using System;
using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(menuName = "Level/Collider Tag Settings")]
    public class ColliderTagSettings : ScriptableObject
    {
        [SerializeField]
        private string _enemyColliderTag = "EnemyCollider";
        
        [SerializeField]
        private string _deathColliderTag = "DeathCollider";

        [SerializeField]
        private string _projectileColliderTag = "ProjectileCollider";

        public bool IsEnemyColliderTag(Collider collider)
        {
            return _enemyColliderTag.Equals(collider.gameObject.tag, StringComparison.Ordinal);
        }
        
        public bool IsDeathCollider(Collider collider)
        {
            return _deathColliderTag.Equals(collider.gameObject.tag, StringComparison.Ordinal);
        }

        public bool IsProjectileCollider(Collider collider)
        {
            return _projectileColliderTag.Equals(collider.gameObject.tag, StringComparison.Ordinal);
        }
    }
}