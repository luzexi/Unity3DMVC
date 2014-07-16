using UnityEngine;
using System.Collections;

//	BaseScene.cs
//	Author: Lu Zexi
//	2014-07-16

 
/// <summary>
/// Base scene.
/// </summary>
public class CScene
{
	protected static CScene s_cCurrentScene;

	public static void Switch<T>()
		where T : CScene , new()
	{
		if(s_cCurrentScene != null )
			s_cCurrentScene.OnExit();
		s_cCurrentScene = new T();
		s_cCurrentScene.OnEnter();
	}

	/// <summary>
	/// Raises the enter event.
	/// </summary>
	public virtual void OnEnter()
	{
		//
	}

	/// <summary>
	/// Raises the exit event.
	/// </summary>
	public virtual void OnExit()
	{
		//
	}
}
