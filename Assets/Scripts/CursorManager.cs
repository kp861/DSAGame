using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public Texture2D cursor_normal;
    public Vector2 normalCursorHotSpot;

    public Texture2D cursor_Onbutton;
    public Vector2 onButtonCursorHotSpot;
    public void OnButtonCursorEnter()
    {
        Cursor.SetCursor(cursor_Onbutton, onButtonCursorHotSpot, CursorMode.Auto);
    }

    public void OnButtonCursorLeave() 
    {
        Cursor.SetCursor(cursor_normal, normalCursorHotSpot, CursorMode.Auto);
    }
}
