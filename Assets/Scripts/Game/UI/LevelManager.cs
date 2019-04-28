using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.UI
{
    public class LevelManager : MonoBehaviour
    {

        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
