using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ChainedSwitchPress : MonoBehaviour
{
    public GameObject instructionCanvas;
    public GameObject instructionCanvasAfter;

    public GameObject weldingMachine;
    public GameObject weldingSwitch;       // First switch
    public GameObject nextGlowObject;      // Second switch
    public GameObject finalGlowObject;     // Third object to glow

    public XRSimpleInteractable secondSwitchInteractable;

    private XRSimpleInteractable interactable;

    void Start()
    {
        interactable = weldingSwitch.GetComponent<XRSimpleInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(OnFirstSwitchPressed);

        if (secondSwitchInteractable != null)
            secondSwitchInteractable.selectEntered.AddListener(OnSecondSwitchPressed);

        // Turn off all glows initially
        SetGlow(weldingMachine, false);
        SetGlow(weldingSwitch, false);
        SetGlow(nextGlowObject, false);
        SetGlow(finalGlowObject, false);
    }

    void OnFirstSwitchPressed(SelectEnterEventArgs args)
    {
        if (instructionCanvas != null)
            instructionCanvas.SetActive(false);

        SetGlow(weldingMachine, false);
        SetGlow(weldingSwitch, false);
        SetGlow(nextGlowObject, true);

        // Optional: disable first switch
        weldingSwitch.SetActive(false);
    }

    void OnSecondSwitchPressed(SelectEnterEventArgs args)
    {
        SetGlow(nextGlowObject, false);
        SetGlow(finalGlowObject, true);

        if (instructionCanvasAfter != null)
            instructionCanvasAfter.SetActive(true); // Show the second canvas

        secondSwitchInteractable.enabled = false;
    }



    void SetGlow(GameObject obj, bool state)
    {
        if (obj == null) return;
        var outline = obj.GetComponent<Outline>();
        if (outline != null)
            outline.enabled = state;
    }

    void OnDestroy()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnFirstSwitchPressed);

        if (secondSwitchInteractable != null)
            secondSwitchInteractable.selectEntered.RemoveListener(OnSecondSwitchPressed);
    }
}
