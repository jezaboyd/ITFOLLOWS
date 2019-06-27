using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrol : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }


        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            spriteRenderer.flipX = direction < 0;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            spriteRenderer.flipX = direction < 0;
        }

        rigidbody2D.MovePosition(position);


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        MoveWithInput player = other.gameObject.GetComponent<MoveWithInput>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
