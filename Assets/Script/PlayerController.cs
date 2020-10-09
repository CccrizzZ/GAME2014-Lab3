using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Bullet_Mana bulletMana;

    public float HBoundary;
    public float HSpeed;
    public float maxSpeed;
    private Rigidbody2D m_rigidBody;
    private Vector3 touchesEnd;
    public float HTValue;

    // Start is called before the first frame update
    void Start()
    {
        touchesEnd = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
        Fire();
    }

    private void Fire()
    {
        if (Time.frameCount % 10 == 0)
        {
            bulletMana.GetBullet(transform.position);
        }
    }

    private void Move()
    {
        var direction = 0.0f;

        foreach(var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            
            if(worldTouch.x > transform.position.x)
            {
                direction = 1.0f;
            }

            if(worldTouch.x < transform.position.x)
            {
                direction = -1.0f;
            }

        }




        if (touchesEnd.x != 0.0f)
        {
           transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchesEnd.x, HTValue), transform.position.y);
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * HSpeed, 0.0f);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }

    }

    private void CheckBounds()
    {
       if(transform.position.x >= HBoundary)
        {
            transform.position = new Vector3(HBoundary, transform.position.y, 0.0f);
        }

        if (transform.position.x <= -HBoundary)
        {
            transform.position = new Vector3(-HBoundary, transform.position.y, 0.0f);
        }
    }
}
