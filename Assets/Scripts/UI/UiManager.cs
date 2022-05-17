using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class UiManager : MonoBehaviour, IUiManager
    {
        [SerializeField]
        private GameObject _winView = null;
        
        [SerializeField]
        private GameObject _failView = null;

        [SerializeField]
        private Image _crosshairView = null;

        [SerializeField]
        private Color _crosshairActive = Color.green;
        
        [SerializeField]
        private Color _crosshairDisabled = Color.white;

        public void Setup()
        {
            SetActiveCrosshair(true);
            SetCrosshairState(false);
            
            if (_winView != null)
            {
                _winView.SetActive(false);
            }
            
            if (_failView != null)
            {
                _failView.SetActive(false);
            }
        }
        
        public void SetCrosshairState(bool active)
        {
            if (_crosshairView != null)
            {
                _crosshairView.color = active ? _crosshairActive : _crosshairDisabled;
            }
        }

        public void ShowWinView()
        {
            SetActiveCrosshair(false);
            
            if (_winView != null)
            {
                _winView.SetActive(true);
            }
        }

        public void ShowFailView()
        {
            SetActiveCrosshair(false);
            
            if (_failView != null)
            {
                _failView.SetActive(true);
            }
        }

        private void SetActiveCrosshair(bool active)
        {
            if (_crosshairView != null)
            {
                _crosshairView.gameObject.SetActive(active);
            }
        }
    }
}