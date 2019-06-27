using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Rotate : MonoBehaviour
{
    public float degreesPerSecond = 360.0f;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var rotation = degreesPerSecond * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotation);
    }
}
