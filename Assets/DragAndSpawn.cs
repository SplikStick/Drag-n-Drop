using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndSpawn : MonoBehaviour
{
    public GameObject dragonHoldPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                    Debug.Log(hitInfo.transform.gameObject.name);
                    Instantiate(dragonHoldPrefab, touchPosition, Quaternion.identity);
            }
        }
    }
}

