using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(menuName = "Level/Collider Tag Settings")]
    public class ColliderTagSettings : ScriptableObject
    {
        [SerializeField]
        private string _playerColliderTag = "PlayerCollider";
        
        [SerializeField]
        private string _enemyColliderTag = "EnemyCollider";
        
        [SerializeField]
        private string _deathColliderTag = "DeathCollider";

        [SerializeField]
        private string _projectileColliderTag = "ProjectileCollider";

        public bool IsPlayerCollider(Collider collider)
        {
            return IsColliderTag(_playerColliderTag, collider);
        }
        
        public bool IsEnemyCollider(Collider collider)
        {
            return IsColliderTag(_enemyColliderTag, collider);
        }
        
        public bool IsDeathCollider(Collider collider)
        {
            return IsColliderTag(_deathColliderTag, collider);
        }

        public bool IsProjectileCollider(Collider collider)
        {
            return IsColliderTag(_projectileColliderTag, collider);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsColliderTag(string tag, Component collider)
        {
            return tag.Equals(collider.gameObject.tag, StringComparison.Ordinal);
        }
    }
}