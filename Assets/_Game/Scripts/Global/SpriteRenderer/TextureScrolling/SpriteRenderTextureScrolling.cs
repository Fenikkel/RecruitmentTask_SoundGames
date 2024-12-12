using UnityEngine;
using UnityEngine.UI;

/* In the inspector, set the texture Wrap mode to Repeat (https://docs.unity3d.com/ScriptReference/TextureWrapMode.html) */

/* It works alongside with a custom shader */

public class SpriteRenderTextureScrolling : MonoBehaviour
{

    [SerializeField] Vector2 _ScrollSpeed = new Vector2(0.2f, 0f);

    SpriteRenderer _SpriteRenderer;

    void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _SpriteRenderer.material.SetVector("_ScrollSpeed", _ScrollSpeed);
    }
}
