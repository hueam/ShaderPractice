using UnityEngine;

public class Example : MonoBehaviour
{
    // Converts a GUICoordinate (afected by a group) to a Screen coordinate.

    void OnGUI()
    {
        Vector2 gPos = new Vector2(10, 10);
        GUI.BeginGroup(new Rect(10, 10, 100, 100));
        Vector2 convertedGUIPos = GUIUtility.GUIToScreenPoint(gPos);
        GUI.EndGroup();
        Debug.Log("GUI: " + gPos + " Screen: " + convertedGUIPos);
    }
}