using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LockWeldGunToRightHand : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public XRBaseInteractor rightHandInteractor;
    public Transform attachToRightHand; // This is on the hand

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform != rightHandInteractor.transform)
        {
            grabInteractable.interactionManager.SelectExit(args.interactorObject, grabInteractable);
            return;
        }

        grabInteractable.attachTransform = attachToRightHand;

        // Delay to allow Unity to finish its grab process
        StartCoroutine(SnapAndLock());
    }
    private System.Collections.IEnumerator SnapAndLock()
    {
        yield return null; // wait 1 frame

        grabInteractable.transform.SetPositionAndRotation(attachToRightHand.position, attachToRightHand.rotation);
        grabInteractable.transform.SetParent(rightHandInteractor.transform);

        grabInteractable.interactionLayers = 0;
        grabInteractable.movementType = XRBaseInteractable.MovementType.Kinematic;
    }


}
