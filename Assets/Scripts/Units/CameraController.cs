using UnityEngine;

namespace Game
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform _cameraTransform = null;

        [SerializeField]
        private bool _invertVerticalAxis = false;

        [SerializeField]
        private bool _invertHorizontalAxis = false;
        
        [SerializeField]
        private float _sensitivity = 1f;

        [SerializeField]
        private float _yMinRotationAngle = -90f;

        [SerializeField]
        private float _yMaxRotationAngle = 90f;

        private Vector2 _rotationAngles;
        private Vector3 _horizontalAxis;
        private Vector3 _verticalAxis;
        
        private void Awake()
        {
            _verticalAxis.x = _invertVerticalAxis ? 1f : -1f;
            _horizontalAxis.y = _invertHorizontalAxis ? -1f : 1f;

            _rotationAngles = _cameraTransform.transform.localRotation.eulerAngles;
        }

        public void Rotate(Vector3 direction)
        {
            _rotationAngles.x += direction.x * _sensitivity;
            var horizontal = Quaternion.AngleAxis(_rotationAngles.x, _horizontalAxis);
            
            _rotationAngles.y += direction.y * _sensitivity;
            _rotationAngles.y = Mathf.Clamp(_rotationAngles.y, _yMinRotationAngle, _yMaxRotationAngle);
            var vertical = Quaternion.AngleAxis(_rotationAngles.y, _verticalAxis);
            
            _cameraTransform.localRotation = horizontal * vertical;
        }
    }
}