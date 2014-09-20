using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


//	CPage.cs
//	Author: Lu Zexi
//	2014-09-19



/// <summary>
/// page.
/// </summary>
public class CPage<P,V,C> : MonoBehaviour
	where P : MonoBehaviour
	where V : CView
	where C : CController
{
	public static V s_cView = null;		//view
	public static C s_cController = null;	//controller
	private static P s_cInstance;	//instance

	public bool IsShow{get;private set;}	//is show

	public static P sInstance
	{
		get
		{
			if( s_cInstance == null )
			{
				Type t = typeof(P);
				GameObject obj = new GameObject(t.Name);
				s_cInstance = obj.AddComponent<P>();
				s_cView = obj.AddComponent<V>();
				s_cController = obj.AddComponent<C>();
			}
			return s_cInstance;
		}
	}

	/// <summary>
	/// Raises the load complete event.
	/// </summary>
	/// <param name="resMap">Res map.</param>
	public virtual void OnLoadComplete(Dictionary<string , object> resMap)
	{
		s_cView.m_mapRes = resMap;
		s_cController.Init();
	}

	/// <summary>
	/// Show this instance.
	/// </summary>
	public virtual void Show()
	{
		IsShow = true;
	}

	/// <summary>
	/// Init this instance.
	/// </summary>
	public virtual void Init()
	{
		s_cController.Init();
	}

	/// <summary>
	/// Hiden this instance.
	/// </summary>
	public virtual void Hiden()
	{
		GameObject.Destroy(this.gameObject);
		Resources.UnloadUnusedAssets();
	}

	/// <summary>
	/// Raises the destroy event.
	/// </summary>
	void OnDestroy()
	{
		IsShow = false;
		s_cInstance = null;
		s_cView = null;
		s_cController = null;
	}
}
