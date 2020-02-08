using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWhileDragged : MonoBehaviour
{
    public GameObject fallingPrefab;
    public bool overDropZone = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); //0th Finger
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = touchPosition;

                
                //Check if dragon over dropable space
                RaycastHit2D hitInfo = Physics2D.Raycast(touchPosition, Vector2.zero);
                if (hitInfo && hitInfo.transform.gameObject.name == "DropZone")
                {
                    overDropZone = true;
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
                else {
                    if (overDropZone)
                    {
                        GetComponent<SpriteRenderer>().color = Color.red;
                        overDropZone = false;
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(touchPosition, Vector2.zero);
                if (hitInfo)
                    Debug.Log(hitInfo.transform.gameObject.name);

                //Check if dragon in dropable space
                if (hitInfo && hitInfo.transform.gameObject.name == "DropZone")
                    //insantiate falling dragon
                    Instantiate(fallingPrefab, touchPosition, Quaternion.identity);

                //destroy itself
                GameMangerStatic.dragonHandlers.HideDropZone();
                Destroy(gameObject);
            }
        }
    }
}
