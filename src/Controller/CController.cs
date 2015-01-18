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
public abstract class CController : MonoBehaviour
{
	/// <summary>
	/// Gets the layer.
	/// </summary>
	/// <returns>The layer.</returns>
	public virtual UILAYER GetLayer(){return UILAYER.NONE;}

	/// <summary>
	/// Gets the root path.
	/// </summary>
	/// <returns>The root path.</returns>
	public abstract GameObject GetAnchor();

	/// <summary>
	/// Init this instance.
	/// </summary>
	public virtual void Init()
	{
		this.transform.parent = GetAnchor().transform;
		this.transform.localPosition = Vector3.zero;
		this.transform.localScale = Vector3.one;
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
		SET_PARENT(child.transform,parent.transform, layerfix);
	}

	/// <summary>
	/// set the parent.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="parent">Parent.</param>
	/// <param name="layerfix">If set to <c>true</c> layerfix.</param>
	public void SET_PARENT( MonoBehaviour child , GameObject parent, bool layerfix = false)
	{
		SET_PARENT(child.transform,parent.transform, layerfix);
	}

	/// <summary>
	/// set the parent.
	/// </summary>
	/// <param name="child">Child.</param>
	/// <param name="parent">Parent.</param>
	/// <param name="layerfix">If set to <c>true</c> layerfix.</param>
	public void SET_PARENT( GameObject child , GameObject parent , bool layerfix = false)
	{
		SET_PARENT(child.transform,parent.transform , layerfix);
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
		{
			pos = Vector3.zero;
		}
		child.localPosition = pos;
        child.localScale = Vector3.one;
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
//
//========================================================================
}

