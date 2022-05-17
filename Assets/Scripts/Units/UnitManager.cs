using System;
using System.Collections.Generic;

namespace Game
{
    public sealed class UnitManager : IUnitManager
    {
        private readonly Dictionary<Type, List<UnitController>> _units = new Dictionary<Type, List<UnitController>>();

        public int GetUnitsCount<T>() where T : UnitController
        {
            var key = typeof(T);
            return _units.TryGetValue(key, out var unitList) ? unitList.Count : 0;
        }

        public void Register(UnitController unitController)
        {
            if (unitController == null)
            {
                return;
            }
            
            var key = unitController.GetType();
            if (!_units.TryGetValue(key, out var unitList))
            {
                unitList = new List<UnitController>();
                _units.Add(key, unitList);
            }

            if (!unitList.Contains(unitController))
            {
                unitList.Add(unitController);
            }
        }

        public void Unregister(UnitController unitController)
        {
            if (unitController == null)
            {
                return;
            }
            
            var key = unitController.GetType();
            if (_units.TryGetValue(key, out var unitList))
            {
                unitList.Remove(unitController);
            }
        }
    }
}