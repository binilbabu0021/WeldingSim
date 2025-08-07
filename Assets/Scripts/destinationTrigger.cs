using UnityEngine;

public class destinationTrigger : MonoBehaviour
{
    public GameObject arrowObject;
    public GameObject nextCanvas;

    private bool hasTriggered = false;

    private void Start()
    {
        // Ensure the next canvas is hidden at start
        if (nextCanvas != null)
            nextCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered || !other.CompareTag("Player")) return;

        hasTriggered = true;

        if (arrowObject != null)
            Destroy(arrowObject);

        if (nextCanvas != null)
            nextCanvas.SetActive(true);
    }
}
