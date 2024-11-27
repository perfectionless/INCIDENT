using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject targetObject; // The object to enable/disable
    public string newTag = "UsedLever";

    public void Toggle()
    {
        if (targetObject != null)
        {
            bool isActive = targetObject.activeSelf;
            targetObject.SetActive(!isActive); // Toggle the active state
        }

        this.tag = newTag;

        // Optional: Add animations or effects for lever toggle
        Debug.Log("Lever toggled!");
    }
}
