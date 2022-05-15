using System;
using Game;
using UnityEngine;

namespace Units.Health
{
    public sealed class Health
    {
        private readonly ObservableProperty<int> _current = new ObservableProperty<int>();
        private readonly ObservableProperty<int> _min = new ObservableProperty<int>();
        private readonly ObservableProperty<int> _max = new ObservableProperty<int>();
        
        public IReadOnlyObservableProperty<int> Current => _current;
        public IReadOnlyObservableProperty<int> Min => _min;
        public IReadOnlyObservableProperty<int> Max => _max;

        public bool IsDead => _current.Value <= _min.Value;

        public event Action Dead;

        public void Setup(int health, int min, int max)
        {
            _current.Value = health;
            _min.Value = min;
            _max.Value = max;
        }

        public void Damage(int damage)
        {
            UpdateCurrent(_current.Value - damage);
        }
        
        public void Death()
        {
            UpdateCurrent(_min.Value);
        }

        private void UpdateCurrent(int value)
        {
            _current.Value = Mathf.Clamp(value, _min.Value, _max.Value);
            
            if (IsDead)
            {
                Dead?.Invoke();
            }
        }
    }
}