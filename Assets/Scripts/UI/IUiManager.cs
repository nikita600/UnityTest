namespace Game.UI
{
    public interface IUiManager
    {
        void Setup();
        
        void SetCrosshairState(bool active);

        void ShowWinView();

        void ShowFailView();
    }   
}
