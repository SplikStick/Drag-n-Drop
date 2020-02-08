using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    float moveSpeed = 3f;
    Player target;
    Rigidbody2D projRb;
    Vector2 moveDirection;
    public GameObject oof;

    // Start is called before the first frame update
    void Start()
    {
        projRb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        projRb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            //Player takes damage
            oof.SetActive(true);
            Destroy(gameObject);
        } else if (col.tag == "Dragon")
        {
            //Destroy projectile and dragon
            Destroy(col.gameObject); //dragon
            Destroy(gameObject); //projectile
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
