using System;
using System.Collections.Generic;
using UnityEngine;


//  INPUT_INFO.cs
//  Author: Lu Zexi
//  2014-07-06


/// <summary>
/// input type
/// </summary>
public enum INPUT_TYPE
{ 
	NONE = 0,
	HOVER,
	PRESS,
	SELECT,
	CLICK,
	DOUBLE_CLICK,
	DRAG,
	DROP,
	INPUT,
	TOOLTIP,
	SCROLL,
	KEY,
	MAX
}

/// <summary>
/// the info of the input.
/// </summary>
public class INPUT_INFO
{
	public INPUT_TYPE m_eType;
	public float m_fDelta;
	public Vector2 m_vecDelta;
	public Vector2 m_vecPos;
	public bool m_bDone;
	public GameObject m_cTarget;
	public string m_strText;
	public KeyCode m_eKey;
}
