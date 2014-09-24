using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


//  Model.cs
//  Author: Lu Zexi
//  2014-07-05



/// <summary>
/// Model类
/// </summary>
public abstract class CModel<T> : ScriptableObject , IEnumerable
{
	protected static List<object> s_lstData;
	
	public CModel()
	{
		Type t = this.GetType();
		if (s_lstData == null)
		{
			s_lstData = CModelMgr.sInstance.Get(t.FullName);
			if(s_lstData == null )
			{
				s_lstData = new List<object>();
				CModelMgr.sInstance.Add(t.FullName, s_lstData);
			}
		}
	}
	
	//count
	public static int Count
	{
		get { return s_lstData.Count; }
	}
	
	//get index
	public static T Get(int index)
	{
		if (index >= s_lstData.Count||index<0)
			return default(T);
		return (T)s_lstData[index];
	}
	
	//get index
	public T this[int index]
	{
		get
		{
			if (index >= s_lstData.Count||index<0)
				return default(T);
			return (T)s_lstData[index];
		}
	}
	
	/// <summary>
	/// get the enumerator.
	/// </summary>
	/// <returns></returns>
	public IEnumerator GetEnumerator()
	{
		foreach (object item in s_lstData)
			yield return item;
	}
	
	/// <summary>
	/// add the model instance.
	/// </summary>
	/// <param name="model"></param>
	public static void Add(T model)
	{
		s_lstData.Add(model);
	}
	
	/// <summary>
	/// Remove this instance.
	/// </summary>
	public static void Clear()
	{
		s_lstData.Clear();
	}
	
	/// <summary>
	/// Gets the array.
	/// </summary>
	/// <returns>The array.</returns>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T[] ToArray()
	{
		T[] vec = new T[s_lstData.Count];
		for(int i = 0 ; i<s_lstData.Count ; i++)
			vec[i] = (T)s_lstData[i];
		return vec;
	}
	
	/// <summary>
	/// remove the index instance.
	/// </summary>
	/// <param name="index"></param>
	public static void Remove(int index)
	{
		if (index >= s_lstData.Count)
			return;
		s_lstData.RemoveAt(index);
	}
	
	/// <summary>
	/// remove the instance in the list.
	/// </summary>
	/// <param name="model"></param>
	public static void Remove(T model)
	{
		s_lstData.Remove(model);
	}
}

