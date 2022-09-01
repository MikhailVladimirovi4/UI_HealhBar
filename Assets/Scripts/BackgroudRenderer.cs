using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class BackgroudRenderer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepOffsetX;

    private MeshRenderer _meshRenderer;
    private Vector2 _meshOffset;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshOffset = _meshRenderer.sharedMaterial.mainTextureOffset;
    }

    private void OnDisable()
    {
        _meshRenderer.sharedMaterial.mainTextureOffset = _meshOffset;
    }

     private void Update()
    {
        float offsetX = Mathf.Repeat(Time.time * _speed, _stepOffsetX);
        Vector2 offset = new Vector2(offsetX, _meshOffset.y);
        _meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }
}
