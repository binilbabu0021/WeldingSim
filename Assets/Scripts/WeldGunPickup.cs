using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeldGunPickup : MonoBehaviour
{
    public GameObject weldZone; // Assign your weld zone in inspector

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnPickedUp);
    }

    void OnPickedUp(SelectEnterEventArgs args)
    {
        if (weldZone != null)
        {
            Outline outline = weldZone.GetComponent<Outline>();
            if (outline != null)
                outline.enabled = true;
        }
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
            grabInteractable.selectEntered.RemoveListener(OnPickedUp);
    }
}
