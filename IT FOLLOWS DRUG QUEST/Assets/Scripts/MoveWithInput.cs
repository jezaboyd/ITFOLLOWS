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


    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    void Update()
    {
		float amount = speed * Time.deltaTime;

		if (Input.GetKey(leftButton))
			transform.Translate(-amount, 0f, 0f, Space.World);

		if (Input.GetKey(rightButton))
			transform.Translate(amount, 0f, 0f, Space.World);

		if (Input.GetKey(upButton))
			transform.Translate(0f, amount, 0f, Space.World);

		if (Input.GetKey(downButton))
			transform.Translate(0f, -amount, 0f, Space.World);
	}


    void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}

