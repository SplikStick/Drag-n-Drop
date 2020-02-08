using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingDragon : MonoBehaviour
{
    public Collider2D dropZoneCol;
    public Collider2D dragonCol;
    // Start is called before the first frame update
    void Start()
    {
        //Ignore the dropzone
        Physics2D.IgnoreCollision(dragonCol, dropZoneCol, true);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.name == "ground")
            Destroy(gameObject);
        else if (col.name == "enemy")
        {
            ((enemy)col.gameObject.GetComponent(typeof(enemy))).TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
