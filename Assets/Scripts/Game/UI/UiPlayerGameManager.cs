using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UiPlayerGameManager : MonoBehaviour
    {

        public TextMeshProUGUI companyText;
        public TextMeshProUGUI moneyText;
        public Image alertImage;

        public void updateAlertVisibility()
        {
            alertImage.gameObject.SetActive(!alertImage.gameObject.activeSelf);
        }

        public void SetNameCompany(string companyName)
        {
            companyText.text = companyName;
        }
        
        public void UpdateMoney(double money, string moneyCurrency)
        {
            moneyText.text = money.ToString();
        }
    }
}
