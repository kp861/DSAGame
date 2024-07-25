using UnityEngine;

public class HelpPanelClosure : MonoBehaviour
{
    public GameObject panel;
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    public void PanelClosure()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            timer.StartTimer(); 
        }
    }
}
