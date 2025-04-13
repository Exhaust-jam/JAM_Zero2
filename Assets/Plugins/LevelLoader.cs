using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plugins
{
    public class LevelLoader : MonoBehaviour
    {
        public static void LoadMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void LoadGamePlay()
        {
            SceneManager.LoadScene(1);
        }

        public static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public static void Quit()
        {
            Application.Quit(); 
        }
    }
}