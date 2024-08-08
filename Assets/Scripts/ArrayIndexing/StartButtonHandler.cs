using UnityEngine;
using UnityEngine.UI;

public class StartButtonHandler : MonoBehaviour
{
    public Button button;
    public GameObject panel;

    public void OnStartButtonClick()
    {
        // Activate the panel
        panel.SetActive(true);
        button.gameObject.SetActive(false);
    }
}
