using UnityEngine;

namespace Utilities
{
    [CreateAssetMenu(menuName = "Level/Collider Tag Settings")]
    public class ColliderTagSettings : ScriptableObject
    {
        [SerializeField]
        private string _deathColliderTag = "DeathCollider";

        public string DeathColliderTag => _deathColliderTag;
    }
}