using System.Collections;
using Pills;
using Powerups;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class MoveWithInput : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
	public float speed = 1f;
   
    public TextMeshProUGUI myPillText;
    public int maxPill = 10;
    public int pill { get { return currentPill; } }
    public int currentPill;


    public TextMeshProUGUI myHealthText;
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

    public void Consume(ConfusionPill pill)
    {
        confusedLevel += 1;
        StartCoroutine(ReduceEffect(pill));
    }
    
    public void Consume(SpeedPill pill)
    {
        speedBoost += pill.speedBoost;
        StartCoroutine(ReduceEffect(pill));
    }
    
    public void Consume(ReducedSpeedPill pill)
    {
        speedBoost -= pill.speedSlowdown;
        StartCoroutine(ReduceEffect(pill));
    }

    private Vector2 input;
    private int confusedLevel;
    private float speedBoost = 1.0f;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;

        currentPill = 0;

    }

   public void Update()
    {
        input = new Vector2(0f, 0f);

        if (IsConfused() ? Input.GetKey(rightButton) : Input.GetKey(leftButton))
            input.x = -1f;

		if (IsConfused() ? Input.GetKey(leftButton) : Input.GetKey(rightButton))
            input.x = 1f;

        if (IsConfused() ? Input.GetKey(downButton) : Input.GetKey(upButton))
            input.y = 1f;

        if (IsConfused() ? Input.GetKey(upButton) : Input.GetKey(downButton))
            input.y = -1f;


        float amount = (speed * speedBoost) * Time.deltaTime;
        Vector2 rbPosition = rigidbody2d.position;

        rigidbody2d.MovePosition(rbPosition + input * amount);
        if (!Mathf.Approximately(input.x, 0.0f))
        {
            spriteRenderer.flipX = input.x > 0;
        }

        myHealthText.SetText(health + "/" + maxHealth);
        myPillText.SetText(currentPill + "/" + maxPill);


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

        if (currentHealth == 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
        Debug.Log(currentHealth + "/" +maxHealth);
      

    }

    public void ChangePill(int pillAmount)
    {

        currentPill = Mathf.Clamp(currentPill + pillAmount, 0, maxPill);
        Debug.Log(currentPill + "/zhhh" + maxPill);

        if (currentPill >= maxPill)
        {
            SceneManager.LoadScene("WinScene");


        }
    }

    private IEnumerator ReduceEffect(ConfusionPill pill)
    {
        yield return new WaitForSeconds(pill.effectTime);
        confusedLevel -= 1;
    }
    
    private IEnumerator ReduceEffect(SpeedPill pill)
    {
        yield return new WaitForSeconds(pill.effectTime);
        speedBoost -= pill.speedBoost;
    }
    
    private IEnumerator ReduceEffect(ReducedSpeedPill pill)
    {
        yield return new WaitForSeconds(pill.effectTime);
        speedBoost += pill.speedSlowdown;
    }
    
    private bool IsConfused()
    {
        return confusedLevel > 0;
    }

}

