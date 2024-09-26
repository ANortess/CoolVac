using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public int velocidad;
    public bool mover = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mover == true)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 position = rigidbody2d.position;
            position.x = position.x + velocidad * horizontal * Time.deltaTime;
            position.y = position.y + velocidad * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);

        }
    }
}
