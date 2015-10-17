using UnityEngine;

public class TutorialScreen : MonoBehaviour
    {
        public void ToTutorial()
        {
            GameManager.Instance.GameStateToPaused();
            PauseMenuScreenManager.Instance.ShowHelpMenu();
            Destroy(GameManager.Instance.UICanvas.IntroScreen);

        }

        public void Exit()
        {
            Destroy(GameManager.Instance.UICanvas.IntroScreen);
        }
    }

