using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private Transform target;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
    //    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


   public void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        var direction = target.position - transform.position;
        spriteRenderer.flipX = direction.x < 0;
    }
}
