using UnityEngine;

public class WeldZone : MonoBehaviour
{
    public bool isWelding = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WeldTip"))
        {
            isWelding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WeldTip"))
        {
            isWelding = false;
        }
    }
}
