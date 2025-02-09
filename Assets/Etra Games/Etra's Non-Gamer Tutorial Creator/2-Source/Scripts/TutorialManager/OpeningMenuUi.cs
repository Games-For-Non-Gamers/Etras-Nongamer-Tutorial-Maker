using Etra.StandardMenus;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Etra.NonGamerTutorialCreator.Level
{
    public class OpeningMenuUi : MonoBehaviour
    {

        public void backToMenu()
        {
            if (buttonIsQuit)
            {
                Quit();
            }
            else
            {
                //Enter Main Menu name here
                SceneManager.LoadScene(0); //<----- EDIT THIS LINE
            }
        }

        ///~~~~~~~~~~~~Ignore~~~~~~~~~~~~~~~~~~~~~
        public TextMeshProUGUI backToMenuText;
        bool buttonIsQuit = false;
        public void goToCredits()
        {
            SceneManager.LoadScene("CreditsNonGamerTutorial");
        }

        public GameObject firstSelectedButton;
        private void Start()
        {
            EventSystem playerSystem = FindObjectOfType<EventSystem>();
            playerSystem.firstSelectedGameObject = firstSelectedButton;

            EtraStandardMenusManager menusManager = FindObjectOfType<EtraStandardMenusManager>();
            menusManager.canFreeze = false;

            if (SceneManager.GetActiveScene().buildIndex == 0) //If this is loaded as the first scene adjust the text
            {
                backToMenuText.text = "Quit Game";
                buttonIsQuit = true;
            }
        }

        public void Quit()
        {
            // Quit the application
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
              Application.Quit();
#endif
        }

    }
}