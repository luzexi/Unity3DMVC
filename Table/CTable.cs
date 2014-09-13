using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;


//  CTable.cs
//  Author: Lu Zexi
//  2014-07-05



/// <summary>
/// CTable类
/// </summary>
public abstract class CTable : ScriptableObject , IEnumerable
{
	protected List<CTable> s_lstData;
	
	public CTable()
	{
		Type t = this.GetType();
		this.s_lstData = TableMgr.sInstance.Get(t.FullName);
		if (this.s_lstData == null)
		{
			this.s_lstData = new List<CTable>();
			TableMgr.sInstance.Add(t.FullName, this.s_lstData);
		}
	}
	
	public int Count
	{
		get { return s_lstData.Count; }
	}
	
	/// <summary>
	/// get the instance.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="index"></param>
	/// <returns></returns>
	public T Get<T>(int index) where T : CTable
	{
		if (index >= this.s_lstData.Count)
			return default(T);
		return this.s_lstData[index] as T;
	}
	
	public CTable this[int index]
	{
		get { if (index >= s_lstData.Count||index<0) return null; return s_lstData[index]; }
	}
	
	/// <summary>
	/// get the enumerator.
	/// </summary>
	/// <returns></returns>
	public IEnumerator GetEnumerator()
	{
		foreach (CTable item in s_lstData)
			yield return item;
	}

	/// <summary>
	/// Read the specified content.
	/// </summary>
	/// <param name="content">Content.</param>
	public virtual void Read(string content)
	{
		this.s_lstData.Clear();
		string[,] vecStr = SplitCsvGrid(content);
		for (int j = 2; j < vecStr.GetLength(1)-1; j++)
		{
			Type tableType = GetType();
			CTable tb = ScriptableObject.CreateInstance(tableType) as CTable;
			FieldInfo[] fis = tableType.GetFields(BindingFlags.Public | BindingFlags.Instance);
			for (int i = 0; i < vecStr.GetLength(0)-1; i++)
			{
				FieldInfo f = fis[i];
				Type t = f.FieldType;
				if (t.IsPrimitive)
				{
					if (t.Equals (typeof (int))) f.SetValue(tb,int.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (uint))) f.SetValue(tb,uint.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (float))) f.SetValue(tb,float.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (double))) f.SetValue(tb,double.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (long))) f.SetValue(tb,long.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (ulong))) f.SetValue(tb, ulong.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (bool))) f.SetValue(tb, bool.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (byte))) f.SetValue(tb, byte.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (sbyte))) f.SetValue(tb, sbyte.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (short))) f.SetValue(tb, short.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (ushort))) f.SetValue(tb, ushort.Parse(vecStr[i, j]));
					else if (t.Equals (typeof (char))) f.SetValue(tb, char.Parse(vecStr[i, j]));
					else if (t.Equals (typeof(string))) f.SetValue(tb, vecStr[i, j]);
					else
					{
						Debug.LogError(t.Name);
					}
				} else if( t.Equals(typeof(string)))
				{
					f.SetValue(tb,vecStr[i, j]);
				}

			}
			tb.Add(tb);
		}
	}

	/// <summary>
	/// add the model instance.
	/// </summary>
	/// <param name="model"></param>
	public void Add(CTable model)
	{
		s_lstData.Add(model);
	}
	
	/// <summary>
	/// Remove this instance.
	/// </summary>
	public void Remove()
	{
		s_lstData.Clear();
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
	public void Remove(CTable model)
	{
		s_lstData.Remove(model);
	}

	// splits a CSV file into a 2D string array
	private string[,] SplitCsvGrid(string csvText)
	{
		string[] lines = csvText.Split("\n"[0]);
		Debug.Log("lines " + lines.Length);
		
		// finds the max width of row
		int width = 0;
		for (int i = 0; i < lines.Length; i++)
		{
			string[] row = SplitCsvLine(lines[i]);
			width = Mathf.Max(width, row.Length);
		}
		
		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1];
		for (int y = 0; y < lines.Length; y++)
		{
			string[] row = SplitCsvLine(lines[y]);
			for (int x = 0; x < row.Length; x++)
			{
				outputGrid[x, y] = row[x];
				
				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				outputGrid[x, y] = outputGrid[x, y].Replace("\"\"", "\"");
			}
		}
		
		return outputGrid;
	}
	
	/// <summary>
	/// 分离解析CSV行
	/// </summary>
	/// <param name="line"></param>
	/// <returns></returns>
	private string[] SplitCsvLine(string line)
	{
		return (
			from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches
			(
			line,@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
			System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
		        select m.Groups[1].Value).ToArray();
	}
}

