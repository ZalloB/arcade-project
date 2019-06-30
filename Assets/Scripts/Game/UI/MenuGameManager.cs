using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class MenuGameManager : MonoBehaviour
    {

        [SerializeField]
        private Image menuItemImage;
        [SerializeField]
        private GameObject menuItemsPanel;

        public GameObject optionsUiCanvas;
        
        public void MenuItemsVisibility()
        {
            var image = menuItemImage;
            
            image.color = !menuItemsPanel.activeSelf ? new Color(253, 230,0) : Color.white;
            
            menuItemsPanel.SetActive(!menuItemsPanel.activeSelf);
            
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                optionsUiCanvas.SetActive(!optionsUiCanvas.activeSelf);
            }
        }
    }
}
