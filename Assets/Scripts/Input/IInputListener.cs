using System;
using UnityEngine;

namespace Game.InputSystem
{
    public interface IInputListener
    {
        event Action Fire;
        event Action<Vector2> Move;
        event Action<Vector3> Look;
    }
}
