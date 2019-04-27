using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuGameManager : MonoBehaviour
    {

        [SerializeField]
        private Image menuItemImage;
        [SerializeField]
        private GameObject menuItemsPanel;
        
        
        public void MenuItemsVisibility()
        {
            Debug.Log("Patata.......");
            var image = menuItemImage;
            
            image.color = !menuItemsPanel.activeSelf ? new Color(253, 230,0) : Color.white;
            
            menuItemsPanel.SetActive(!menuItemsPanel.activeSelf);
            
        }
    }
}
