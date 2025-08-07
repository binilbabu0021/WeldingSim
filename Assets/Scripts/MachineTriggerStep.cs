using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MachineTriggerStep : MonoBehaviour
{
    public GameObject weldingMachine;          // The full machine
    public GameObject weldingSwitch;           // The switch to press
    public GameObject instructionCanvas;       // "Please switch on the machine" message

    private bool playerEntered = false;

    private void Start()
    {
        // Hide UI and switch initially
        instructionCanvas.SetActive(false);
        weldingSwitch.SetActive(false);

        // Disable glow initially
        SetGlow(weldingMachine, false);
        SetGlow(weldingSwitch, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerEntered) return;

        if (other.CompareTag("Player")) // Or use XR Rig tag
        {
            playerEntered = true;

            instructionCanvas.SetActive(true);
            weldingSwitch.SetActive(true);

            SetGlow(weldingMachine, true);
            SetGlow(weldingSwitch, true);
        }
    }

    private void SetGlow(GameObject obj, bool state)
    {
        var outline = obj.GetComponent<Outline>(); // Assuming QuickOutline or similar
        if (outline != null)
            outline.enabled = state;
    }
}
