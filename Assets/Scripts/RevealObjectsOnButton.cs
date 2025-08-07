using UnityEngine;
using UnityEngine.UI;

public class RevealObjectsOnButton : MonoBehaviour
{
    public Button revealButton;
    public GameObject canvasToHide;

    public GameObject object1ToShow;
    public GameObject object2ToShow;

    void Start()
    {
        if (revealButton != null)
            revealButton.onClick.AddListener(OnButtonClicked);

        // Make sure the target objects are hidden at start
        if (object1ToShow != null)
            object1ToShow.SetActive(false);
        if (object2ToShow != null)
            object2ToShow.SetActive(false);
    }

    void OnButtonClicked()
    {
        if (canvasToHide != null)
            canvasToHide.SetActive(false);

        if (object1ToShow != null)
            object1ToShow.SetActive(true);
        if (object2ToShow != null)
            object2ToShow.SetActive(true);
    }
}
