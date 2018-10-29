using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        CursorMode mode = CursorMode.ForceSoftware;
        float xspot = cursorTexture.width / 2;
        float yspot = cursorTexture.height / 2;
        Vector2 hotSpot = new Vector2(xspot, yspot);
        Cursor.SetCursor(cursorTexture, hotSpot, mode);
    }

    void OnMouseEnter()
    {
        print("hello");
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        print("bye");
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
