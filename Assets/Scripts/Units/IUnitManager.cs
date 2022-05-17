namespace Game
{
    public interface IUnitManager
    {
        int GetUnitsCount<T>() where T : UnitController;
        
        void Register(UnitController unitController);

        void Unregister(UnitController unitController);
    }
}