using UnityEngine;

public class TutorialScreen : MonoBehaviour
    {
        public void ToTutorial()
        {
            GameManager.Instance.GameStateToPaused();
            GameManager.Instance.UICanvas.ShowHelpMenu();
            Destroy(GameManager.Instance.UICanvas.IntroScreen);

        }

        public void Exit()
        {
            Destroy(GameManager.Instance.UICanvas.IntroScreen);
        }
    }

