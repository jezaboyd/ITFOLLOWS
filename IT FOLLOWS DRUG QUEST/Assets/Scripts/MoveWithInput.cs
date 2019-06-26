using UnityEngine;


public class MoveWithInput : MonoBehaviour
{
	public float speed = 1f;

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    public int health { get { return currentHealth; } }
    public int currentHealth;
    public bool isInvincible;
    float invincibleTimer;


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

   public void Update()
    {
        input = new Vector2(0f, 0f);

        if (Input.GetKey(leftButton))
            input.x = -0.1f;

		if (Input.GetKey(rightButton))
            input.x = 0.1f;

        if (Input.GetKey(upButton))
            input.y = 0.1f;

        if (Input.GetKey(downButton))
            input.y = -0.1f;


        float amount = speed * Time.deltaTime;
        Vector2 rbPosition = rigidbody2d.position;

        rigidbody2d.MovePosition(rbPosition + input);


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

    }


    //private void FixedUpdate()
    //{
    //    float amount = speed * Time.deltaTime;
    //    Vector2 rbPosition = rigidbody2d.position;

    //    rigidbody2d.MovePosition(rbPosition + input);
       

    //}


    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = false;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" +maxHealth);
      

    }

}

