using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HideAfterGrab : MonoBehaviour
{
    public GameObject messageCanvas;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;

    void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (!isGrabbed)
        {
            isGrabbed = true;
            Invoke("HideObject", 1f);
        }
    }

    private void HideObject()
    {
        gameObject.SetActive(false);

        if (messageCanvas != null)
            messageCanvas.SetActive(true);

        // Optional: Display a message like "You have put on the mask"
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}
