using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject text = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("entered");
        text.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("exited");
        text.SetActive(false);
    }
}
