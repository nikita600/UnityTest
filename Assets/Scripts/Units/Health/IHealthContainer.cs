using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units.Health
{
    public interface IHealthContainer
    {
        Health Health { get; }
    }
}