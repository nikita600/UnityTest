using Units.Weapon;
using UnityEngine;

namespace Game
{
    public sealed class EnemyController : UnitController
    {
        [SerializeField]
        private WeaponController _weaponController = null;

        [SerializeField]
        private EyesSensorController _eyesSensorController = null;
        
        private void FixedUpdate()
        {
            if (_eyesSensorController.IsTargetVisible)
            {
                _weaponController.Fire();
            }
        }

        protected override void OnDeadInternal()
        {
            base.OnDeadInternal();
            
            Destroy(gameObject);
        }
    }
}