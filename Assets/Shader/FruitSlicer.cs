using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSlicer : MonoBehaviour
{
    [Header("Shader Settings")]
    [Range(-1f, 1f)] 
    public float sliceHeight = 0.5f;
    
    [SerializeField] private Color innerColor = Color.white;

    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;

    private static readonly int SliceHeightID = Shader.PropertyToID("_SliceHeight");

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _propBlock = new MaterialPropertyBlock();
    }

    void Update()
    {
        UpdateSlicer();
    }

    private void UpdateSlicer()
    {
        _renderer.GetPropertyBlock(_propBlock);
        
        _propBlock.SetFloat(SliceHeightID, sliceHeight);
        
        _renderer.SetPropertyBlock(_propBlock);
    }
    
    public void AnimateSlice(float targetHeight, float duration)
    {
        
    }
}
