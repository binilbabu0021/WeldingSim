using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SafetyChecker : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable mask;
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable gloves;

    public GameObject messageCanvas; // "Thanks for following safety" message

    private bool maskGrabbed = false;
    private bool glovesGrabbed = false;

    void Start()
    {
        if (mask != null)
            mask.selectEntered.AddListener(OnMaskGrabbed);

        if (gloves != null)
            gloves.selectEntered.AddListener(OnGlovesGrabbed);

        if (messageCanvas != null)
            messageCanvas.SetActive(false); // Hide message initially
    }

    void OnMaskGrabbed(SelectEnterEventArgs args)
    {
        if (!maskGrabbed)
        {
            maskGrabbed = true;
            Invoke(nameof(HideMask), 1f);
            CheckSafetyComplete();
        }
    }

    void OnGlovesGrabbed(SelectEnterEventArgs args)
    {
        if (!glovesGrabbed)
        {
            glovesGrabbed = true;
            Invoke(nameof(HideGloves), 1f);
            CheckSafetyComplete();
        }
    }

    void HideMask()
    {
        if (mask != null)
            mask.gameObject.SetActive(false);
    }

    void HideGloves()
    {
        if (gloves != null)
            gloves.gameObject.SetActive(false);
    }

    void CheckSafetyComplete()
    {
        if (maskGrabbed && glovesGrabbed && messageCanvas != null)
        {
            messageCanvas.SetActive(true);
        }
    }

    void OnDestroy()
    {
        if (mask != null)
            mask.selectEntered.RemoveListener(OnMaskGrabbed);
        if (gloves != null)
            gloves.selectEntered.RemoveListener(OnGlovesGrabbed);
    }
}
