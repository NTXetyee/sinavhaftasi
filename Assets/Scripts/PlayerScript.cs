using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb;
    float moveX, moveY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public Animator animator;
    void Update()
    {
        animator.SetFloat("Speed", new Vector2(moveX, moveY).normalized.magnitude);



        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }






    Vector2 smoothVel = Vector2.zero;
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveX, moveY).normalized * Speed * Time.deltaTime;
        rb.position += movement;
        Vector2 moveDirection = new Vector2(moveX, moveY);
        if (moveDirection != Vector2.zero)
        {
            transform.up = Vector2.SmoothDamp(transform.up, moveDirection, ref smoothVel, 0.1f, 10);
        }
    }


    

}