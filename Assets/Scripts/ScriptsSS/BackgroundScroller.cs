using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Renderer rend;
    private Vector2 offset = Vector2.zero;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        offset.y += scrollSpeed * Time.deltaTime;
        rend.material.mainTextureOffset = offset;
    }
}
