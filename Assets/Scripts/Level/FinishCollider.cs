using Game;
using UnityEngine;

namespace Level
{
    public sealed class FinishCollider : MonoBehaviour
    {
        public bool PlayerEntered { get; private set; }
        
        private void OnCollisionEnter(Collision other)
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                PlayerEntered = true;
            }
        }
    }
}