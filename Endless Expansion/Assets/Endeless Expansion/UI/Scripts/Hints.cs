using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hints : MonoBehaviour, IPointerEnterHandler ,IPointerExitHandler
{
    [SerializeField] private GameObject hint;
    public void OnPointerEnter(PointerEventData eventData)
    { 
        hint.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hint.SetActive(false);
    }
}
