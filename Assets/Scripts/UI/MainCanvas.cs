using UnityEngine;
using UnityEngine.UI;
public class MainCanvas : MonoBehaviour
{
    public enum Hoverings { MouseInWorld, MouseInInventory };

    public GameObject MainPanel;
    public GameObject DialogueUI;
    public GameObject InventoryCanvasGO;
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuMainWindow;
    public GameObject PauseMenuHelpWindow;
    public GameObject ScreenButtonWidget;
    public GameObject IntroScreen;
    public TestScreen TestScreen;

    public GameObject DialogueLineImage;
    public GameObject ObjectDescriptionTextGO;
    public Text ObjectDescriptionText;
    public Hoverings Hovering;

    public Image InventoryPanelImage;
    public GameObject InventoryPanelSlots;
    public UIDrawer MyUIDrawer;
    public MoneyDisplay MoneyOnScreen;  //the script that arranges displaying the money on screen.
    public DialogueOptions MyDialogueOptions;

    private bool _widgetIsActive = false;
    private bool _testScreenIsOpen = false;

    public void Awake()
    {
        MainPanel = this.gameObject;

        Hovering = Hoverings.MouseInWorld;

        MyUIDrawer = MainPanel.AddComponent<UIDrawer>();

        ObjectDescriptionTextGO = GameObject.Find("ObjectDescriptionText");
        ObjectDescriptionText = ObjectDescriptionTextGO.GetComponent<Text>();

        PauseMenuCanvas = GameObject.Find("PauseMenuCanvas");
        PauseMenuMainWindow = PauseMenuCanvas.transform.FindChild("MainPanel").gameObject;
        PauseMenuHelpWindow = PauseMenuCanvas.transform.FindChild("HelpPanel").gameObject;

        if (DialogueUI == null)
        {
            Debug.LogError("couldn't find DialogueOptionsUI");
            DialogueUI = GameObject.Find("DialogueUI");
        }

        if (InventoryCanvasGO == null)
        {
            Debug.LogError("couldn't find InventoryCanvas");
            InventoryCanvasGO = GameObject.Find("InventoryCanvas");
        }

        if (InventoryPanelImage == null)
        {
            Debug.LogError("couldn't find InventoryPanelImage");
        }

        if (InventoryPanelSlots == null)
        {
            Debug.LogError("couldn't find InventoryPanelSlots");
        }

        if (ScreenButtonWidget == null)
        {
            Debug.LogError("couldn't find ScreenButtonWidget");
        }

        if (MyDialogueOptions == null)
        {
            Debug.LogError("couldn't find DialogueOptions");
        }

        if (GameManager.MyGameType != GameManager.GameType.NewGame)
            GameManager.Instance.UICanvas.WidgetActive();
    }

    public void OpenCloseInventory()
    {
        if (InventoryCanvas.InventoryIsOpen)
        {
            InventoryCanvasGO.GetComponent<InventoryCanvas>().CloseInventory();
        }
        else
        {
            InventoryCanvasGO.GetComponent<InventoryCanvas>().OpenInventory();
        }
    }

    public void OpenCloseTestScreen()
    {
        if (_testScreenIsOpen)
        {
            TestScreen.gameObject.SetActive(false);
            _testScreenIsOpen = false;
        }
        else
        {
            TestScreen.gameObject.SetActive(true);
            _testScreenIsOpen = true;

            TestScreen.EndCelebration.isOn = (WorldEvents.EndCelebration == true) ? true : false;
        }
    }

    public void ShowInventory()
    {
        InventoryPanelImage.enabled = true;
        InventoryPanelSlots.SetActive(true);
    }

    public void HideInventory()
    {
        InventoryPanelImage.enabled = false;
        InventoryPanelSlots.SetActive(false);

        if (GameManager.Instance.UICanvas.Hovering == Hoverings.MouseInInventory)
        {
            HideObjectDescriptionText();
            GameManager.Instance.UICanvas.Hovering = Hoverings.MouseInWorld;
        }
    }

    public void ShowPauseMainMenu()
    {
        PauseMenuMainWindow.GetComponent<PauseMainPanel>().MainPanelOpen = true;
    }

    public void HidePauseMainMenu()
    {
        PauseMenuMainWindow.GetComponent<PauseMainPanel>().MainPanelOpen = false;
    }

    public void ShowHelpMenu()
    {
        PauseMenuHelpWindow.GetComponent<PauseHelpPanel>().HelpPanelOpen = true;
    }

    public void HideHelpMenu()
    {
        PauseMenuHelpWindow.GetComponent<PauseHelpPanel>().HelpPanelOpen = false;
    }

    public void ShowDialogueOptionsUI()
    {
        Transform dialogueOptions = DialogueUI.transform.FindChild("DialogueOptions");
        dialogueOptions.gameObject.SetActive(true);
    }

    public void HideDialogueOptionsUI()
    {
        Transform dialogueOptions = DialogueUI.transform.FindChild("DialogueOptions");
        dialogueOptions.gameObject.SetActive(false);
    }

    public void HideScreenButtonWidget()
    {
        _widgetIsActive = ScreenButtonWidget.GetComponent<Widget>().WidgetActive;
        ScreenButtonWidget.SetActive(false);
    }

    public void ShowScreenButtonWidget()
    {
        ScreenButtonWidget.SetActive(true);
        if (_widgetIsActive)
            WidgetActive();
        else
            WidgetNotActive();
    }

    public void HideObjectDescriptionText()
    {
        ObjectDescriptionText.text = "";
        ObjectDescriptionTextGO.GetComponentInChildren<DescriptionUnderlining>().ShowNewDescription = false;
        ObjectDescriptionText.enabled = false;
    }

    public void NewObjectDescription()
    {
        ObjectDescriptionTextGO.GetComponentInChildren<DescriptionUnderlining>().ShowNewDescription = true;
    }

    public void WidgetActive()
    {
        ScreenButtonWidget.GetComponent<Widget>().WidgetActive = true;
    }

    public void WidgetNotActive()
    {
        ScreenButtonWidget.GetComponent<Widget>().WidgetActive = false;
    }
}