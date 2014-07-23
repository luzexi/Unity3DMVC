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
public class UIControllerBase<T> : MonoBehaviour
	where T : MonoBehaviour
{
	protected bool m_bShow;
	protected GameObject m_cMain;

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
	protected void Destroy()
	{
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
	public static void SET_PARENT(GameObject child , MonoBehaviour parent)
	{
		SET_PARENT(child.transform,parent.transform);
	}

	/// <summary>
	/// SEs the t_ PAREN.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="parent">Parent.</param>
	public static void SET_PARENT( MonoBehaviour child , GameObject parent)
	{
		SET_PARENT(child.transform,parent.transform);
	}

	/// <summary>
	/// SEs the t_ PAREN.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="parent">Parent.</param>
	public static void SET_PARENT( GameObject child , GameObject parent )
	{
		SET_PARENT(child.transform,parent.transform);
	}

	/// <summary>
	/// SEs the t_ PAREN.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="parent">Parent.</param>
	public static void SET_PARENT( Transform child , Transform tmp_parent )
	{
		child.parent = tmp_parent;
		child.localPosition = Vector3.zero;
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
//
//        /// <summary>
//        /// regist the mono event.
//        /// </summary>
//        /// <param name="mono"></param>
//        /// <param name="callback"></param>
//        /// <param name="arg"></param>
//        public void RegistEvent(MonoBehaviour mono, UIEvent.OnCallBack callback, params object[] arg)
//        {
//            Regist(mono.gameObject, callback, arg);
//        }
//
//        /// <summary>
//        /// regist the gameobject event.
//        /// </summary>
//        /// <param name="obj"></param>
//        /// <param name="callback"></param>
//        /// <param name="arg"></param>
//        public void RegistEvent(GameObject obj, UIEvent.OnCallBack callback, params object[] arg)
//        {
//            Regist(obj, callback, arg);
//        }
//
//        /// <summary>
//        /// regist the event .
//        /// </summary>
//        /// <param name="obj"></param>
//        /// <param name="callback"></param>
//        /// <param name="arg"></param>
//        protected void Regist(GameObject obj, UIEvent.OnCallBack callback, object[] arg)
//        {
//            UIEvent uiEvent = obj.AddComponent<UIEvent>();
//            uiEvent.m_cEvent = callback;
//            uiEvent.m_vecArg = arg;
//        }
}

