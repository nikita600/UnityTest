using UnityEngine;

namespace Game.Units.Movement
{
    public abstract class MovementController : MonoBehaviour
    {
        public abstract void Move(Vector3 direction);
    }
}