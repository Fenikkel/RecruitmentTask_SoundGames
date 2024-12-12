using UnityEngine;
using UnityEngine.UI;

/* In the inspector, set the texture Wrap mode to Repeat: (https://docs.unity3d.com/ScriptReference/TextureWrapMode.html) */

/* Sprite Renderers does not support Tiling and Offsetting: (https://stackoverflow.com/questions/62775643/how-do-i-get-the-texture-to-scroll-on-my-sprite)  
    Also, it doesn't work with -> propBlock.SetVector("_MainTex_ST", new Vector4(1f, 1f, _OffsetX, 0f));
 */

public class ImageTextureScrolling : MonoBehaviour
{
    [SerializeField] float _Speed = 0.2f;

    Image _Image;
    Material _Material;
    float _OffsetX;

    void Start()
    {
        _Image = GetComponent<Image>();

        _Image.mainTexture.wrapMode = TextureWrapMode.Repeat;

        _Material = Instantiate(_Image.material);
        _Image.material = _Material;
    }


    void Update()
    {
        _OffsetX += Time.deltaTime * _Speed;

        if (1f < _OffsetX)
        {
            _OffsetX -= 1f;
        }

        _Material.mainTextureOffset = new Vector2(_OffsetX, _Material.mainTextureOffset.y);
    }
}
