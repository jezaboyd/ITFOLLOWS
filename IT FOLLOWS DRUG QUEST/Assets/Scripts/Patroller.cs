using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Patroller : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    SpriteRenderer spriteRenderer;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        var direction = moveSpot.position - transform.position;
        spriteRenderer.flipX = direction.x < 0;
     
       if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        { 
            if(waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    
}
