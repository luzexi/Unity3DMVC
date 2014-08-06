using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;


//	TableManager.cs
//	Author: Lu Zexi
//	2014-07-23



/// <summary>
/// Table管理类
/// </summary>
public class TableMgr
{
	private Dictionary<string, List<TableBase>> m_mapData = new Dictionary<string, List<TableBase>>();
	
	private static TableMgr s_cInstance;
	public static TableMgr sInstance
	{
		get
		{
			if (s_cInstance == null)
			{
				s_cInstance = new TableMgr();
			}
			return s_cInstance;
		}
	}
	
	public TableMgr()
	{ 
		//
	}
	
	/// <summary>
	/// get the Table.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public T GetTable<T>() where T : TableBase , new()
	{
		T t = new T();
		if( t.Count > 0 )
		{
			t = t.Get<T>(0);
			return t;
		}
		return default(T);
	}
	
	/// <summary>
	/// get the map data
	/// </summary>
	/// <param name="name"></param>
	/// <returns></returns>
	internal List<TableBase> Get(string name)
	{
		if (!this.m_mapData.ContainsKey(name))
			return null;
		return this.m_mapData[name];
	}
	
	/// <summary>
	/// add the data.
	/// </summary>
	/// <param name="name"></param>
	/// <param name="lst"></param>
	internal void Add(string name, List<TableBase> lst)
	{
		this.m_mapData.Add(name, lst);
	}
	
	/// <summary>
	/// remove table
	/// </summary>
	/// <param name="name"></param>
	internal void Remove(string name)
	{
		if (!this.m_mapData.ContainsKey(name))
			return;
		this.m_mapData.Remove(name);
	}
}
