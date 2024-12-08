using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Public variable to control the duration of one day in seconds.
    public float dayDuration = 120f; // Duration of a day in seconds, editable in Inspector.

    private float timeOfDay = 0f; // Time of day in range 0 to 1.

    void Update()
    {
        // Increment timeOfDay, making it loop back to 0 after 1.
        timeOfDay += Time.deltaTime / dayDuration;

        if (timeOfDay > 1f)
        {
            timeOfDay = 0f; // Reset to 0 after a full day cycle.
        }

        // Rotate the Directional Light (the sun) to simulate the passage of time.
        transform.rotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170f, 0f));
    }
}
