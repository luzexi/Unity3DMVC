using UnityEngine;
using System.Collections;


//	CPage.cs
//	Author: Lu Zexi
//	2014-09-19



/// <summary>
/// page.
/// </summary>
public class CPage<T>
	where T : new()
{
	private static T s_cInstance;
	public static T sInstace
	{
		get
		{
			if( s_cInstance == null )
			{
				s_cInstance = new T();
			}
			return s_cInstance;
		}
	}

	/// <summary>
	/// Show this instance.
	/// </summary>
	public virtual void Show()
	{
		//
	}

	/// <summary>
	/// Hiden this instance.
	/// </summary>
	public virtual void Hiden()
	{
		//
	}
}
