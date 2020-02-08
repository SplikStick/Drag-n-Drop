using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 5;
    public GameObject projPrefab;
    public GameObject oof;

    float fireRate;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 5f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            oof.SetActive(false);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
    }
}
