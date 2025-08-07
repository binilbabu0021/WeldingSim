using UnityEngine;
using UnityEngine.UI;

public class TutorialStepMaskGlove : MonoBehaviour
{
    public Button nextButton;
    public GameObject canvasToHide;

    public GameObject weldingMask;
    public GameObject gloves;

    private Outline weldingMaskOutline;
    private Outline glovesOutline;

    void Start()
    {
        nextButton.onClick.AddListener(OnNextPressed);

        // Get Outline components
        if (weldingMask != null)
        {
            weldingMaskOutline = weldingMask.GetComponent<Outline>();
            if (weldingMaskOutline != null)
                weldingMaskOutline.enabled = false;
        }

        if (gloves != null)
        {
            glovesOutline = gloves.GetComponent<Outline>();
            if (glovesOutline != null)
                glovesOutline.enabled = false;
        }
    }

    void OnNextPressed()
    {
        if (canvasToHide != null)
            canvasToHide.SetActive(false);

        if (weldingMaskOutline != null)
            weldingMaskOutline.enabled = true;

        if (glovesOutline != null)
            glovesOutline.enabled = true;
    }
}
