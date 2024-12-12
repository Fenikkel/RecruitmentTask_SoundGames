/* 
    Sprite Renderer:
        - Draw Mode -> Tiled
        - Size      -> Width: OrthographicSize * AspectRatio * 2 * 4
                    -> Height: OrthographicSize * 2 * 4 
        - Tile mode -> Continuous (this mantains the aspect ratio)

    Texture 2D import settings:
        - Mesh Type -> Full Rect
        - PPU       -> Image height / (OrthographicSize * 2)
    
    PNG properties:
        - The image should be seamless
 */

/*
    ParallaxEffectMultiplier:
        - Positive  -> Moves in the same direction as the camera. It slows down the scrolling.
        - Negative  -> moves in the opposite direction to the camera. Gives speed to the scrolling.
        - Zero      -> Moves at the same speed as the camera. Neutral scrolling.
 */

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererParallaxEffect : MonoBehaviour
{
    [Header("Horizontal Parallax")]
    [SerializeField] bool _HorizontalParallaxActive = true;
    [Range(-1.0f, 0.99f)]
    [SerializeField] float _HorizontalParallaxEffectMultiplier = 0.6f;
    [Header("Vertical Parallax")]
    [SerializeField] bool _VerticalParallaxActive = false;
    [Range(-1.0f, 0.99f)]
    [SerializeField] float _VerticalParallaxEffectMultiplier = 0.6f;

    Transform _CameraTransform;
    Vector3 _LastCameraPosition;
    float _TextureUnitSizeX;
    float _TextureUnitSizeY;

    // Performace variables
    Vector3 _DeltaMovement;
    float _OffsetPositionX;
    float _OffsetPositionY;

    private void Start()
    {
        _CameraTransform = Camera.main.transform;
        _LastCameraPosition = _CameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        _TextureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        _TextureUnitSizeY = texture.height / sprite.pixelsPerUnit;

        CheckConfig();
    }

    private void LateUpdate()
    {
        _DeltaMovement = _CameraTransform.position - _LastCameraPosition;
        transform.position += new Vector3(_DeltaMovement.x * _HorizontalParallaxEffectMultiplier, _DeltaMovement.y * _VerticalParallaxEffectMultiplier);
        _LastCameraPosition = _CameraTransform.position;

        if (_HorizontalParallaxActive)
        {
            if (Mathf.Abs(_CameraTransform.position.x - transform.position.x) >= _TextureUnitSizeX)
            {
                _OffsetPositionX = (_CameraTransform.position.x - transform.position.x) % _TextureUnitSizeX;
                transform.position = new Vector3(_CameraTransform.position.x + _OffsetPositionX, transform.position.y);
            }
        }

        if (_VerticalParallaxActive)
        {
            if (Mathf.Abs(_CameraTransform.position.y - transform.position.y) >= _TextureUnitSizeY)
            {
                _OffsetPositionY = (_CameraTransform.position.y - transform.position.y) % _TextureUnitSizeY;
                transform.position = new Vector3(transform.position.x, _CameraTransform.position.y + _OffsetPositionY);
            }
        }
    }

    private void CheckConfig() 
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer.drawMode != SpriteDrawMode.Tiled)
        {
            Debug.LogWarning($"The SpriteRenderer of <b>{name}</b> should have the Draw Mode to <b>Tiled</b>");
        }
    }

}
