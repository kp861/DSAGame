using UnityEngine;

public class ResourcesOpen : MonoBehaviour
{
    public string url;
    public void Open()
    {
        Application.OpenURL(url);
    }
}
