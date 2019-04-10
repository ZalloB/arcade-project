using System;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace UI
{
    public class LevelManager : MonoBehaviour
    {

        public void LoadLevel(string name)
        {
            SceneManager.LoadScene(name);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
