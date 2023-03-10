using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSwipePanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public event Action<Swipe> SwipeBegun;
    public event Action<Swipe> Swiping;
    public event Action<Swipe> SwipeEnded;
    private Vector2 _startPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
       _startPosition = eventData.position;
        Invoke(SwipeBegun, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Invoke(Swiping, eventData);
    }
        

    public void OnEndDrag(PointerEventData eventData)
    {
        Invoke(SwipeEnded, eventData);
        
    }
    private void Invoke(Action<Swipe> action, PointerEventData eventData)=>
        action?.Invoke(CreateSwipeFrom(_startPosition,eventData));
    private Swipe CreateSwipeFrom(Vector2 startPosition, PointerEventData eventData)=>
        new Swipe(startPosition, eventData.position, eventData.delta);

    // Start is called before the first frame update
  
}
