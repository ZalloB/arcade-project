using System;
using System.Collections;
using Game.UI;
using UnityEngine;

namespace Game.Managers
{
    public class CalendarGameManager : MonoBehaviour
    {
        //Basic system alert when the month pass
        public delegate void MonthEvent();
        public static event MonthEvent OnMonthPass;
        
        private readonly DateTime _initialDate = new DateTime(1991, 1, 1);
        private DateTime _actualDate;

        public int timeVelocity = 3;

        private UiCalendarManager _uiCalendarManager;
        

        private void Start()
        {
            _uiCalendarManager = GameObject.FindGameObjectWithTag("uiManager").GetComponent<UiCalendarManager>();
            _actualDate = _initialDate;
            StartCoroutine(nameof(UpdateCalendar));
        }


        private IEnumerator UpdateCalendar()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeVelocity);
                var auxDate = _actualDate;
                _actualDate = _actualDate.AddDays(1);
                _uiCalendarManager.UpdateCalendarInfo(TransformDate());

                if (auxDate.Month < _actualDate.Month)
                {
                    Debug.Log("UpdateCalendar Month check: " + auxDate.Month + " -> "+ _actualDate.Month);
                    OnMonthPass?.Invoke();
                }
            }
        }


        private string TransformDate()
        {
            return $"Day {_actualDate.Day:D} - {getStringMonth():G} {_actualDate.Year:D}";
        }

        private string getStringMonth()
        {
            //TODO TRANSLATE 
            switch (_actualDate.Month)
            {
                case 1:
                    return "January";

                case 2:
                    return "February";

                case 3:
                    return "March";

                case 4:
                    return "April";

                case 5:
                    return "May";

                case 6:
                    return "June";

                case 7:
                    return "July";

                case 8:
                    return "August";

                case 9:
                    return "September";

                case 10:
                    return "October";

                case 11:
                    return "November";

                case 12:
                    return "December";

                default:
                    Debug.Log("<color='red'>invalid Month number....</color>");
                    break;
            }

            return null;
        }
    }
}