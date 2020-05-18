using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRoom : MonoBehaviour
{

    [SerializeField]
    private Transform m_device;

    private bool m_isInRoom = false;
    private float m_swapThreshold = -0.05f;

    private bool m_EnterInStairesDoor = false;

    bool isColliding;

    private void Awake()
    {
        if (m_device == null)
        {
            m_device = Camera.main.transform;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isColliding)
            return;

        bool inRoom = IsInRoom();


        if (m_EnterInStairesDoor && inRoom != m_isInRoom)
        {
            Debug.Log("In Second Room : " + inRoom);

            m_isInRoom = inRoom;


            if (m_isInRoom)
            {
                Debug.Log("Entering Room");

            }
            else
            {
                Debug.Log("Exit Room");
            }
        }


    }

    private bool IsInRoom()
    {
        bool inRoom = (transform.InverseTransformPoint(m_device.position + m_device.forward).z > m_swapThreshold);
        return inRoom;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.transform != m_device)
            return;

        m_EnterInStairesDoor = true;

        isColliding = true;
    }


   /* private void OnTriggerExit(Collider _other)
    {
        if (_other.transform != m_device)
            return;

        if (!IsInRoom())
            m_EnterInStairesDoor = false;

        isColliding = false;

        Debug.Log("Exit From Door");

       // StartCoroutine("DelayChnageMeshRenderer");
    }*/
}
