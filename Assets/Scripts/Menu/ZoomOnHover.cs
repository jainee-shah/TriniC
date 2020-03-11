using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ZoomOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject text = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Transform>().localScale = new Vector3(1.3f, 1.3f, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
    }

    public void OnClick()
    {
        GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        if (text != null)
            text.SetActive(false);
    }
}