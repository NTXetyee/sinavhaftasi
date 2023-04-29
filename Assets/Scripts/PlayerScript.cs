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
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector2 movement = new Vector3(moveX, moveY).normalized * Speed * Time.deltaTime;
        rb.position += movement;
    }


}