using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeldGunGrabHandler : MonoBehaviour
{
    public GameObject glowObject;

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        // Disable glow when grabbed
        if (glowObject != null)
        {
            var outline = glowObject.GetComponent<Outline>();
            if (outline != null) outline.enabled = false;
        }

        // Optional: Attach to hand or controller
        // The XR system should already attach the grabbed object to the interactor (controller)
        // but you can enforce it manually if needed
        // transform.SetParent(args.interactorObject.transform);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }
}