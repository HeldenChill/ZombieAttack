using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    AnimationModule anim;
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.Deactivate("Normal");
        anim.Deactivate("Disable");
        anim.Activate("Highlight");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.Deactivate("Normal");
        anim.Deactivate("Highlight");
        anim.Activate("Disable");
    }

}
