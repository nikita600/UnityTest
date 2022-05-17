using UnityEngine;
using Utilities;

namespace Level
{
    public abstract class ColliderController : MonoBehaviour
    {
        [SerializeField]
        protected ColliderTagSettings _colliderTagSettings = null;
    }
}