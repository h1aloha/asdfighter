using UnityEngine;
using UnityEngine.UI;

public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private RawImage rawImage;
    private Rect uvRect;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        uvRect = rawImage.uvRect;
    }

    void Update()
    {
        uvRect.y += scrollSpeed * Time.deltaTime;
        if (uvRect.y > 1) uvRect.y -= 1;
        rawImage.uvRect = uvRect;
    }
}