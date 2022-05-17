namespace Game
{
    public class EnemyController : UnitController
    {
        protected override void OnDeadInternal()
        {
            base.OnDeadInternal();
            
            Destroy(gameObject);
        }
    }
}