using UnityEngine;

public class movements : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jump;
    private bool isGrounded = false;
    public Animator animator;
    private float moveInput;
    public AudioSource eA;
    public float basePitch = 0.8f;
    public float boostPitch = 1.3f;

    void Start()
    {
    }

    void Update()
    {
        // پرش
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = Vector2.up * jump;
            isGrounded = false;
        }

        // فقط وقتی کلید D یا RightArrow گرفته شده باشه
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
	    eA.pitch = boostPitch;
        }
        else
        {
            moveInput = 0f;
	    eA.pitch = basePitch;
        }

        // اعمال حرکت
        //rb.linearVelocity = new Vector2(moveInput * 5f, rb.linearVelocity.y); // مقدار ۵ سرعت افقیه

        // انیمیشن فقط روی زمین
        if (isGrounded)
        {
            animator.SetFloat("speed", moveInput); // فقط ۰ یا ۱ می‌فرسته
        }
        else
        {
            animator.SetFloat("speed", -1); // انیمیشن متوقف بشه توی هوا
	    eA.pitch = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
