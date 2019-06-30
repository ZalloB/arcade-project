using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UiTimeManager : MonoBehaviour
    {

        #region timebuttons

        public Image pauseButton;
        public Image playButton;
        public Image fastButton;
        public Image fast2Button;

        #endregion

        public GameObject pauseCanvas;

        public void EnabledPauseButton()
        {
            pauseButton.color = Color.red;
            ManagePauseCanvas(true);
        }

        public void DisabledPauseButton()
        {
            pauseButton.color = Color.white;
            ManagePauseCanvas(false);
        }
        
        public void EnabledPlayButton()
        {
            playButton.color = Color.red;
        }

        public void DisabledPlayButton()
        {
            playButton.color = Color.white;
        }
        
        public void EnabledFastButton()
        {
            fastButton.color = Color.red;
        }

        public void DisabledFastButton()
        {
            fastButton.color = Color.white;
        }
        
                
        public void EnabledFast2Button()
        {
            fast2Button.color = Color.red;
        }

        public void DisabledFast2Button()
        {
            fast2Button.color = Color.white;
        }

        
        private void ManagePauseCanvas(bool state)
        {
            pauseCanvas.SetActive(state);
        }
        
    }
}