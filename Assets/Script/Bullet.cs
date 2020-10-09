using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float VerticalSpeed;
    public Bullet_Mana bulletMana;
    public float verticalBound;

    // Start is called before the first frame update
    void Start()
    {
        bulletMana = FindObjectOfType<Bullet_Mana>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(0, VerticalSpeed, 0);
    }

    private void CheckBounds()
    {
        if(transform.position.y > verticalBound)
        {
            bulletMana.ReturnBullet(gameObject);
        }
    }
}
