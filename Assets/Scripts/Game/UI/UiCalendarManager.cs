using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class UiCalendarManager : MonoBehaviour
    {

        public TextMeshProUGUI text;


        public void UpdateCalendarInfo(string date)
        {
            text.text = date;
        }
    }
}
    