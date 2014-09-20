using UnityEngine;
using System.Collections;


//	IModel.cs
//	Author: Lu Zexi
//	2014-09-20


/// <summary>
/// interface model.
/// </summary>
public interface IModel
{
	//count
	int Count
	{
		get;
	}

//	T Get<T>(int index) where T : IModel;
}

