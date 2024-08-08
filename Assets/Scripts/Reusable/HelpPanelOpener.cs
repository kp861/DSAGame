using UnityEngine;

public class HelpPanelOpener : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }
}
