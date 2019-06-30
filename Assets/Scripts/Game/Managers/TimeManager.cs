using Game.UI;
using UnityEngine;

namespace Game.Managers
{
    public class TimeManager : MonoBehaviour
    {

        #region keymappings names
            private const string Pause = "Pause";
            private const string Play = "Play";
            private const string Fast1 = "Fast 1";
            private const string Fast2 = "Fast 2";
        #endregion

        private CalendarGameManager _calendarGameManager;
        private UiTimeManager _uiTimeManager;
      
        private void Start()
        {
            _calendarGameManager = FindObjectOfType<CalendarGameManager>().GetComponent<CalendarGameManager>();
            _uiTimeManager = GameObject.FindGameObjectWithTag("uiManager").GetComponent<UiTimeManager>();
        }
        
        private void Update()
        {

            if (Input.GetButtonDown(Pause))
            {
                Time.timeScale = 0;
                _uiTimeManager.EnabledPauseButton();
                _uiTimeManager.DisabledPlayButton();
                _uiTimeManager.DisabledFastButton();
                _uiTimeManager.DisabledFast2Button();
            }else if (Input.GetButtonDown(Play))
            {
                Time.timeScale = 1;
                _uiTimeManager.EnabledPlayButton();
                _uiTimeManager.DisabledPauseButton();
                _uiTimeManager.DisabledFastButton();
                _uiTimeManager.DisabledFast2Button();
            }else if (Input.GetButtonDown(Fast1))
            {
                Time.timeScale = 2;
                _uiTimeManager.EnabledFastButton();
                _uiTimeManager.DisabledPauseButton();
                _uiTimeManager.DisabledPlayButton();
                _uiTimeManager.DisabledFast2Button();
            }else if (Input.GetButtonDown(Fast2))
            {
                Time.timeScale = 3;
                _uiTimeManager.EnabledFast2Button();
                _uiTimeManager.DisabledPauseButton();
                _uiTimeManager.DisabledPlayButton();
                _uiTimeManager.DisabledFastButton();
            }
        }
    }
}
