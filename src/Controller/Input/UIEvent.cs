using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



//  UIEvent.cs
//  Author: Lu Zexi
//  2014-07-06


/// <summary>
/// ui event.
/// </summary>
public class UIEvent : UnityEngine.EventSystems.EventTrigger
{
	public delegate void PointerEventDelegate ( BaseEventData eventData , GameObject go , object[] arg);
	public delegate void BaseEventDelegate ( BaseEventData eventData , GameObject go , object[] arg );
	public delegate void AxisEventDelegate ( BaseEventData eventData , GameObject go , object[] arg );

	public object[] m_vecArg = null;

	public BaseEventDelegate onDeselect = null;
	public PointerEventDelegate onDrag = null;
	public PointerEventDelegate onDrop = null;
	public AxisEventDelegate onMove = null;
	public PointerEventDelegate onClick = null;
	public PointerEventDelegate onDown = null;
	public PointerEventDelegate onEnter = null;
	public PointerEventDelegate onExit = null;
	public PointerEventDelegate onUp = null;
	public PointerEventDelegate onScroll = null;
	public PointerEventDelegate onSelect = null;
	public PointerEventDelegate onUpdateSelect = null;

	public static UIEvent Get(GameObject go)
	{
		UIEvent listener = go.GetComponent<UIEvent>();
		if (listener == null) listener = go.AddComponent<UIEvent>();
		return listener;
	}

	public static UIEvent Get(MonoBehaviour go)
	{
		UIEvent listener = go.GetComponent<UIEvent>();
		if (listener == null) listener = go.gameObject.AddComponent<UIEvent>();
		return listener;
	}

	public override void OnDeselect( BaseEventData eventData )
	{
		if(onDeselect != null) onDeselect(eventData , gameObject , this.m_vecArg);
	}

	public override void OnDrag( PointerEventData eventData )
	{
		if(onDrag != null) onDrag(eventData , gameObject , this.m_vecArg);
	}

	public override void OnDrop( PointerEventData eventData )
	{
		if(onDrop != null) onDrop(eventData , gameObject , this.m_vecArg);
	}

	public override void OnMove( AxisEventData eventData )
	{
		if(onMove != null) onMove(eventData , gameObject , this.m_vecArg);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if(onClick != null) onClick(eventData , gameObject , this.m_vecArg);
	}

	public override void OnPointerDown (PointerEventData eventData)
	{
		if(onDown != null) onDown(eventData , gameObject , this.m_vecArg);
	}

	public override void OnPointerEnter (PointerEventData eventData)
	{
		if(onEnter != null) onEnter(eventData , gameObject , this.m_vecArg);
	}

	public override void OnPointerExit (PointerEventData eventData)
	{
		if(onExit != null) onExit(eventData , gameObject , this.m_vecArg);
	}
	public override void OnPointerUp (PointerEventData eventData)
	{
		if(onUp != null) onUp(eventData , gameObject , this.m_vecArg);
	}

	public override void OnScroll( PointerEventData eventData )
	{
		if(onScroll != null) onScroll(eventData , gameObject , this.m_vecArg);
	}

	public override void OnSelect (BaseEventData eventData)
	{
		if(onSelect != null) onSelect(eventData , gameObject , this.m_vecArg);
	}

	public override void OnUpdateSelected (BaseEventData eventData)
	{
		if(onUpdateSelect != null) onUpdateSelect(eventData , gameObject , this.m_vecArg);
	}
}

