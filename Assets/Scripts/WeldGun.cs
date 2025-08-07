using UnityEngine;
using UnityEngine.InputSystem;

public class WeldGun : MonoBehaviour
{
    public ParticleSystem weldEffect;
    public WeldZone weldZone; // Assign in Inspector
    public InputActionReference triggerAction; // Assign this in Inspector
    public AudioSource weldAudio; // Drag your AudioSource here

    private void Update()
    {
        bool triggerPressed = triggerAction.action.ReadValue<float>() > 0.1f;

        if (weldZone != null && weldZone.isWelding && triggerPressed)
        {
            if (!weldEffect.isPlaying)
                weldEffect.Play();

            if (weldAudio != null && !weldAudio.isPlaying)
                weldAudio.Play();
        }
        else
        {
            if (weldEffect.isPlaying)
                weldEffect.Stop();

            if (weldAudio != null && weldAudio.isPlaying)
                weldAudio.Stop();
        }
    }
}
