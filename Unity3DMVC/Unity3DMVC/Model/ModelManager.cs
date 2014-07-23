using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;


//	ModelManager.cs
//	Author: Lu Zexi
//	2014-07-23



/// <summary>
/// Model管理类
/// </summary>
public class ModelManager
{
    private Dictionary<string, List<Model>> m_mapData = new Dictionary<string, List<Model>>();

    private static ModelManager s_cInstance;
    public static ModelManager sInstance
    {
        get
        {
            if (s_cInstance == null)
            {
                s_cInstance = new ModelManager();
            }
            return s_cInstance;
        }
    }

    public ModelManager()
    { 
        //
    }

    /// <summary>
    /// get the model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetModel<T>() where T : Model , new()
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
	/// Save this instance.
	/// </summary>
	public void Save(string pathFile)
	{
		JSONClass json = new JSONClass();
		foreach( KeyValuePair<string , List<Model>> item in this.m_mapData )
		{
			if(item.Value.Count > 0 )
			{
				JSONArray arrayNode = new JSONArray();
				foreach( Model mod in item.Value )
				{
					JSONClass classNode = new JSONClass();
					Type t = mod.GetType();
					FieldInfo[] fis = t.GetFields(BindingFlags.Public | BindingFlags.Instance);
					foreach (FieldInfo f in fis)
					{
						classNode[f.Name] = f.GetValue(mod).ToString();
						//Type fieldType = f.FieldType;
					}
					arrayNode.Add(classNode);
				}
				json[item.Key] = arrayNode;
			}
		}
		json.SaveToFile(pathFile);
	}

	/// <summary>
	/// Load the specified pathFile.
	/// </summary>
	/// <param name="pathFile">Path file.</param>
	public void Load(string pathFile)
	{
		this.m_mapData.Clear();
		JSONClass json = JSONNode.LoadFromFile(pathFile) as JSONClass;
		foreach( KeyValuePair<string , JSONNode> item in json )
		{
			this.m_mapData.Add(item.Key , new List<Model>());
			JSONArray arrayJson = item.Value.AsArray;
			foreach( JSONNode node in arrayJson )
			{
				Type modt = Type.GetType(item.Key);
				Model mod = ScriptableObject.CreateInstance(modt) as Model;
				//Model mod = FormatterServices.GetUninitializedObject(modt) as Model;
				FieldInfo[] fis = modt.GetFields(BindingFlags.Public | BindingFlags.Instance);
				foreach (FieldInfo f in fis)
				{
					Type t = f.FieldType;
					JSONNode valueJson = node[f.Name];
					if(valueJson == null)
						continue;
					if (t.IsPrimitive)
					{
						if (t.Equals (typeof (int))) f.SetValue(mod,int.Parse(valueJson.Value));
						else if (t.Equals (typeof (uint))) f.SetValue(mod,uint.Parse(valueJson.Value));
						else if (t.Equals (typeof (float))) f.SetValue(mod,float.Parse(valueJson.Value));
						else if (t.Equals (typeof (double))) f.SetValue(mod,double.Parse(valueJson.Value));
						else if (t.Equals (typeof (long))) f.SetValue(mod,long.Parse(valueJson.Value));
						else if (t.Equals (typeof (ulong))) f.SetValue(mod, ulong.Parse(valueJson.Value));
						else if (t.Equals (typeof (bool))) f.SetValue(mod, bool.Parse(valueJson.Value));
						else if (t.Equals (typeof (byte))) f.SetValue(mod, byte.Parse(valueJson.Value));
						else if (t.Equals (typeof (sbyte))) f.SetValue(mod, sbyte.Parse(valueJson.Value));
						else if (t.Equals (typeof (short))) f.SetValue(mod, short.Parse(valueJson.Value));
						else if (t.Equals (typeof (ushort))) f.SetValue(mod, ushort.Parse(valueJson.Value));
						else if (t.Equals (typeof (char))) f.SetValue(mod, char.Parse(valueJson.Value));
						else if (t.Equals (typeof(string))) f.SetValue(mod, valueJson.Value);
						else
						{
							Debug.LogError(t.Name);
						}
					} else if( t.Equals(typeof(string)))
					{
						f.SetValue(mod,valueJson.Value);
					}
				}
				mod.Add(mod);
			}
		}
	}

    /// <summary>
    /// get the map data
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    internal List<Model> Get(string name)
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
	internal void Add(string name, List<Model> lst)
    {
        this.m_mapData.Add(name, lst);
    }

    /// <summary>
    /// remove model
    /// </summary>
    /// <param name="name"></param>
	internal void Remove(string name)
    {
        if (!this.m_mapData.ContainsKey(name))
            return;
        this.m_mapData.Remove(name);
    }
}
