using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    // Serialize
    [SerializeField] private float _scrollSpeedX = 0.1f;
    [SerializeField] private float _scrollSpeedY = 0.1f;

    // Private
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        ScrollTexture();
    }

    private void ScrollTexture()
    {
        _meshRenderer.material.mainTextureOffset = new Vector2(Time.realtimeSinceStartup * _scrollSpeedX, Time.realtimeSinceStartup * _scrollSpeedY);
    }
}
