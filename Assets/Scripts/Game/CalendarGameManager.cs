using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class CalendarGameManager : MonoBehaviour
    {
        private readonly DateTime _initialDate = new DateTime(1991, 1, 1);

        private DateTime _actualDate;
        public int timeVelocity = 5;
        private void Start()
        {
            _actualDate = _initialDate;
            StartCoroutine(nameof(UpdateCalendar));
        }


        private IEnumerator UpdateCalendar()
        {
            while (true)
            {
                _actualDate = _actualDate.AddDays(1);
//                SendMessage("");
                
                Debug.Log("UpdateCalendar: " + (int) Time.time);
                Debug.Log(transformDate());
                yield return new WaitForSeconds(timeVelocity);
            }
        }


        private string transformDate()
        {
            return $"Day {_actualDate.Day:D} - {_actualDate.Month:G} {_actualDate.Year:D}";
        }
    }
}