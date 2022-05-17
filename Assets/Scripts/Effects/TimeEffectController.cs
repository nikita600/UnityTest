using UnityEngine;

namespace Game.Effects
{
    public sealed class TimeEffectController : EffectController
    {
        [SerializeField]
        private float _destroyTime = 1f;
        
        public override void Show()
        {
            Destroy(gameObject, _destroyTime);
        }
    }
}