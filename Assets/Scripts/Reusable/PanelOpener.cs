using System.Collections;
using UnityEngine;
using Unity.UI;


public class PanelOpener : MonoBehaviour
{
    public GameObject panel;
   
    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            StartCoroutine(ClosePanelAfterDelay(3f)); // Start the coroutine to close the panel after 3 seconds
        }
    }

    private IEnumerator ClosePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        if (panel != null)
        {
            panel.SetActive(false); // Deactivate the panel
        }
    }
}
