using UnityEngine;


public class MoveWithInput : MonoBehaviour
{
	public float speed = 5f;
    public int maxHealth = 5;
    int currentHealth;

    Rigidbody2D rigidbody2d;

    public KeyCode leftButton = KeyCode.A;
	public KeyCode rightButton = KeyCode.D;
	public KeyCode upButton = KeyCode.W;
	public KeyCode downButton = KeyCode.S;

    private Vector2 input;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        input = new Vector2(0f, 0f);

        if (Input.GetKey(leftButton))
            input.x = -1f;

		if (Input.GetKey(rightButton))
            input.x = 1f;

        if (Input.GetKey(upButton))
            input.y = 1f;

        if (Input.GetKey(downButton))
            input.y = -1f;
    }


    private void FixedUpdate()
    {
        float amount = speed * Time.deltaTime;
        Vector2 rbPosition = rigidbody2d.position;

        rigidbody2d.MovePosition(rbPosition + input);
    }


    void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}

