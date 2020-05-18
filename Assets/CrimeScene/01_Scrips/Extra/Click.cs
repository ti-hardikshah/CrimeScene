using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        // Do action

        Debug.Log("Click");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Do action
    }
}