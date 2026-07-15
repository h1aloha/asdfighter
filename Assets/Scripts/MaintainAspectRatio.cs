using UnityEngine;

public class MaintainAspectRatio : MonoBehaviour
{
    private const float aspectRatio = 16f / 10f;

    void Start()
    {
        int width = Screen.width;
        int height = Mathf.RoundToInt(width / aspectRatio);
        Screen.SetResolution(width, height, false);
    }

    void Update()
    {
        int newWidth = Screen.width;
        int newHeight = Mathf.RoundToInt(newWidth / aspectRatio);

        if (Screen.height != newHeight) Screen.SetResolution(newWidth, newHeight, false);
    }
}
