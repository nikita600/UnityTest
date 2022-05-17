using UnityEngine;

namespace Game.Units.Movement
{
    public abstract class MovementController : MonoBehaviour
    {
        public abstract Vector3 Velocity { get; }
        
        public abstract void Move(Vector3 direction);
    }
}