using UnityEngine;
using UnityEngine.UI;

public class TutorialStepOne : MonoBehaviour
{
    [Header("References")]
    public CanvasGroup tutorialCanvas;      // Add CanvasGroup to the canvas
    public GameObject groundArrow;
    public Button nextButton;

    void Start()
    {
        tutorialCanvas.alpha = 1;
        tutorialCanvas.interactable = true;
        tutorialCanvas.blocksRaycasts = true;

        groundArrow.SetActive(false); // Hide arrow at start
        nextButton.onClick.AddListener(OnNextClicked);
    }

    void OnNextClicked()
    {
        // Hide the UI
        tutorialCanvas.alpha = 0;
        tutorialCanvas.interactable = false;
        tutorialCanvas.blocksRaycasts = false;

        // Show the arrow
        groundArrow.SetActive(true);
    }
}
