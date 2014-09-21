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
public abstract class CModel : ScriptableObject , IEnumerable
{
    protected List<CModel> s_lstData;

    public CModel()
    {
        Type t = this.GetType();
		this.s_lstData = CModelMgr.sInstance.Get(t.FullName);
        if (this.s_lstData == null)
        {
			this.s_lstData = new List<CModel>();
            CModelMgr.sInstance.Add(t.FullName, this.s_lstData);
        }
    }

	//count
    public int Count
    {
        get { return s_lstData.Count; }
    }

	//get index
	public T Get<T>(int index)
		where T : CModel
	{
		if (index >= s_lstData.Count||index<0)
			return default(T);
		return s_lstData[index] as T;
	}

	//get index
	public CModel this[int index]
    {
        get { if (index >= s_lstData.Count||index<0) return null; return s_lstData[index]; }
    }

    /// <summary>
    /// get the enumerator.
    /// </summary>
    /// <returns></returns>
    public IEnumerator GetEnumerator()
    {
		foreach (CModel item in s_lstData)
            yield return item;
    }

    /// <summary>
    /// add the model instance.
    /// </summary>
    /// <param name="model"></param>
	public void Add(CModel model)
    {
        s_lstData.Add(model);
    }

	/// <summary>
	/// Remove this instance.
	/// </summary>
	public void Clear()
	{
		s_lstData.Clear();
	}

	/// <summary>
	/// Gets the array.
	/// </summary>
	/// <returns>The array.</returns>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public T[] ToArray<T>()
	{
		return this.s_lstData.ToArray() as T[];
	}

    /// <summary>
    /// remove the index instance.
    /// </summary>
    /// <param name="index"></param>
    public void Remove(int index)
    {
        if (index >= s_lstData.Count)
            return;
        s_lstData.RemoveAt(index);
    }

    /// <summary>
    /// remove the instance in the list.
    /// </summary>
    /// <param name="model"></param>
	public void Remove(CModel model)
    {
        s_lstData.Remove(model);
    }
}

