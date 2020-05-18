using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


    private Touch touch;
    private float speedModifire;



    // Start is called before the first frame update
    void Start()
    {
        speedModifire = 0.0001f;


    }


    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.touchCount > 0) {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved) {

                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifire,
                    transform.position.y + touch.deltaPosition.y * speedModifire,
                    transform.position.z + touch.deltaPosition.y * 0.0001f
                    ) ;
            }
        }
    }
}
