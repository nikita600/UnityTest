using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera = null;
        
        [SerializeField]
        private float _rotationSpeed = 100f;
        
        public void Rotate(Vector3 direction)
        {
            
        }
    }
}