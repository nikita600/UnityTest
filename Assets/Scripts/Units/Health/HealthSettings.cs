using UnityEngine;

namespace Units.Health
{
    [CreateAssetMenu(menuName = "Units/Health Settings")]
    public sealed class HealthSettings : ScriptableObject
    {
        [SerializeField]
        private int _min = 0;
        
        [SerializeField]
        private int _max = 100;

        public void ApplyTo(Health health)
        {
            health?.Setup(_max, _min, _max);
        }
    }
}