using UnityEngine;

/*
    Disclaimer: This behaviour wont work properly if the sprite have parents with the scale modified.

    Setup: Tag the camera with MainCamera.
 */

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererCameraFitter : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float _WidthMultiplier = 1f;

    [Range(0f, 5f)]
    [SerializeField] float _HeigthMultiplier = 1f;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Camera camera = Camera.main != null ? Camera.main : FindAnyObjectByType<Camera>();

        switch (spriteRenderer.drawMode)
        {
            case SpriteDrawMode.Simple:
                transform.localScale = new Vector3(camera.orthographicSize * camera.aspect * 2 * _WidthMultiplier, camera.orthographicSize * 2 * _HeigthMultiplier, transform.localScale.z); 
                break;

            case SpriteDrawMode.Sliced:
            case SpriteDrawMode.Tiled:
                spriteRenderer.size = new Vector2(camera.orthographicSize * camera.aspect * 2 * _WidthMultiplier, camera.orthographicSize * 2 * _HeigthMultiplier);
                break;

            default:
                Debug.LogError($"Case {spriteRenderer.drawMode} not implemented");
                break;
        }
    }

}
