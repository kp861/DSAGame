using UnityEngine;

public class HelpPanelClosureArrayIndexing : MonoBehaviour
{
    public GameObject panel;

    public void PanelClosure()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
