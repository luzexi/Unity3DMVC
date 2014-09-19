using UnityEngine;
using System;
using System.Collections.Generic;

//using BUTTON_CALLBACK = System.Action<>


//  UIControllerBase.cs
//  Author: Lu Zexi
//  2014-07-05



/// <summary>
/// the ui controller.
/// </summary>
public abstract class UIControllerBase<T,V> : MonoBehaviour
	where T : MonoBehaviour
	where V : UIViewBase
{
	protected bool m_bShow;
	protected GameObject m_cMain;
	protected V m_cView;

	protected static T s_cInstance;
	public static T sInstance
	{
		get
		{
			if(s_cInstance == null)
			{
				Type t = typeof(T);
				GameObject obj = new GameObject(t.Name);
				s_cInstance = obj.AddComponent<T>();
			}
			return s_cInstance;
		}
	}

	/// <summary>
	/// Raises the destroy event.
	/// </summary>
	void OnDestroy()
	{
		s_cInstance = null;
	}

	/// <summary>
	/// Gets the layer.
	/// </summary>
	/// <returns>The layer.</returns>
	public abstract UILAYER GetLayer();

	/// <summary>
	/// Gets a value indicating whether this instance is show.
	/// </summary>
	/// <value><c>true</c> if this instance is show; otherwise, <c>false</c>.</value>
	public bool IsShow
	{
		get{return this.m_bShow;}
	}

	/// <summary>
	/// Show this instance.
	/// </summary>
    public virtual void Show()
	{
		this.m_bShow = true;
	}

	/// <summary>
	/// Hiden this instance.
	/// </summary>
	public virtual void Hiden()
	{
		this.m_bShow = false;
	}

	/// <summary>
	/// Destroy this instance.
	/// </summary>
	public virtual void Destroy()
	{
		this.m_bShow = false;
		GameObject.Destroy(this.gameObject);
		s_cInstance = null;
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

//============================ set parent function ==========================


	/// <summary>
	/// SEs the t_ PAREN.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="parent">Parent.</param>
	/// <param name="layerfix">If set to <c>true</c> layerfix.</param>
	public void SET_PARENT(GameObject child , MonoBehaviour parent , bool layerfix = false)
	{
		SET_PARENT(child.transform,parent.transform);
	}

	/// <summary>
	/// set the parent.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="parent">Parent.</param>
	/// <param name="layerfix">If set to <c>true</c> layerfix.</param>
	public void SET_PARENT( MonoBehaviour child , GameObject parent, bool layerfix = false)
	{
		SET_PARENT(child.transform,parent.transform);
	}

	/// <summary>
	/// set the parent.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="parent">Parent.</param>
	/// <param name="layerfix">If set to <c>true</c> layerfix.</param>
	public void SET_PARENT( GameObject child , GameObject parent , bool layerfix = false)
	{
		SET_PARENT(child.transform,parent.transform);
	}

	/// <summary>
	/// Set the parent.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="tmp_parent">Tmp_parent.</param>
	/// <param name="layerfix">If set to <c>true</c> layerfix.</param>
	public void SET_PARENT( Transform child , Transform tmp_parent , bool layerfix = false)
	{
		child.parent = tmp_parent;
		Vector3 pos = Vector3.zero;
		if( layerfix )
			pos = new Vector3(0,0,-100 * ((int)GetLayer()));
		child.localPosition = pos;
	}

//========================= FIND function ==================================

    /// <summary>
    /// find the gameobject.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public GameObject FIND(string path)
    {
        return this.transform.Find(path).gameObject;
    }

    /// <summary>
    /// find the mono scripts.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    public T FIND<T>(string path) where T : MonoBehaviour
    {
        return this.transform.Find(path).GetComponent<T>();
    }

    /// <summary>
    /// find the gameobject.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public GameObject FIND(GameObject obj, string path)
    {
        return obj.transform.Find(path).gameObject;
    }

    /// <summary>
    /// find the mono scripts
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    /// <returns></returns>
    public T FIND<T>(GameObject obj, string path) where T : MonoBehaviour
    {
        return obj.transform.Find(path).GetComponent<T>();
    }

//========================= UI EVENT Regist Function ==================================

	/// <summary>
	/// regist the mono event.
	/// </summary>
	/// <param name="mono"></param>
	/// <param name="callback"></param>
	/// <param name="arg"></param>
	public void RegistEvent(MonoBehaviour mono, UIEvent.OnCallBack callback, params object[] arg)
	{
	    Regist(mono.gameObject, callback, arg);
	}

	/// <summary>
	/// regist the gameobject event.
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="callback"></param>
	/// <param name="arg"></param>
	public void RegistEvent(GameObject obj, UIEvent.OnCallBack callback, params object[] arg)
	{
	    Regist(obj, callback, arg);
	}

	/// <summary>
	/// regist the event .
	/// </summary>
	/// <param name="obj"></param>
	/// <param name="callback"></param>
	/// <param name="arg"></param>
	protected void Regist(GameObject obj, UIEvent.OnCallBack callback, object[] arg)
	{
	    UIEvent uiEvent = obj.AddComponent<UIEvent>();
	    uiEvent.m_cEvent = callback;
	    uiEvent.m_vecArg = arg;
	}
}

