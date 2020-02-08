using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonHandlers : MonoBehaviour
{
    public GameObject spamPrefab;
    public GameObject blennyPrefab;
    public GameObject dropZone;

    void Start()
    {
        GameMangerStatic.dragonHandlers = this;
        HideDropZone();
    }

    // Update is called once per frame
    public void SpawnDragon(string dragonName)
    {
        DisplayDropZone();
        if (dragonName == "spam")
        {
            Instantiate(spamPrefab, transform.position, Quaternion.identity);
        } else if (dragonName == "blenny")
        {
            Instantiate(blennyPrefab, transform.position, Quaternion.identity);
        }
    }

    public void DisplayDropZone()
    {
        dropZone.SetActive(true);
    }

    public void HideDropZone()
    {
        dropZone.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); //0th Finger
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(touchPosition, Vector2.zero);
                if (hitInfo)
                {
                    //Debug.Log(hitInfo.transform.gameObject.name);
                    SpawnDragon(hitInfo.transform.gameObject.name);
                }
            }
        }
    }
}
