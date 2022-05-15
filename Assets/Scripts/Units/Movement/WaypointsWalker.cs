using System.Collections.Generic;
using UnityEngine;

namespace Game.Units.Movement
{
    public sealed class WaypointsWalker : MonoBehaviour
    {
        [SerializeField]
        private MovementController _movementController = null;
        
        [SerializeField] 
        private List<Transform> _waypoints = new List<Transform>();

        private int _waypointIndex;
        private Transform _currentWaypoint;

        private void Awake()
        {
            RemoveEmptyWaypoints();
            _currentWaypoint = GetCurrentWaypoint();
        }

        private void LateUpdate()
        {
            if (_currentWaypoint == null)
            {
                return;
            }

            var position = _movementController.transform.position;
            position.y = 0f;
            
            var waypointPosition = _currentWaypoint.position;
            waypointPosition.y = 0f;
            
            var distance = Vector3.Distance(position, waypointPosition);
            if (distance > 0.1f)
            { 
                var heading = waypointPosition - position;
                var moveDirection = heading / heading.magnitude;
                
                _movementController.Move(moveDirection);
            }
            else
            {
                _waypointIndex++;
                _currentWaypoint = GetCurrentWaypoint();
            }
        }

        private Transform GetCurrentWaypoint()
        {
            var waypointsCount = _waypoints.Count;
            if (_waypointIndex >= waypointsCount)
            {
                _waypointIndex = 0;
            }

            return _waypointIndex < waypointsCount 
                ? _waypoints[_waypointIndex] 
                : null;
        }
        
        private void RemoveEmptyWaypoints()
        {
            for (var i = 0; i < _waypoints.Count; ++i)
            {
                if (_waypoints[i] != null)
                {
                    continue;
                }

                _waypoints.RemoveAt(i);
                --i;
            }
        }
    }
}