using UnityEngine;
using System.Collections;

public class HRPlayer : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float attackPower = 10f;
    [SerializeField]
    float attackRange = 1f;

    Rigidbody2D rb;

    GameObject kan = null;
    Rigidbody2D kanrb = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        kan = GameObject.Find("Kan");
        if (kan != null)
        {
            kanrb = kan.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            vec.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vec.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec.x += 1;
        }
        vec = vec.normalized * speed;
        rb.AddForce(vec);


        if (Input.GetKeyDown(KeyCode.Space)
            || Input.GetMouseButtonDown(0))
        {
            if (kan != null)
            {
                Vector2 direction = kan.transform.position - transform.position;
                if (direction.magnitude <= attackRange)
                {
                    direction = direction.normalized * attackPower;
                    kanrb.AddForce(direction, ForceMode2D.Impulse);
                }
            }
        }
    }
}
