using UnityEngine;
using System.Collections;

//	UIController.cs
//	Author: LU Zexi
//	2014-09-15



public enum SwitchEffect
{
	None,
	Fade,
	Loading, 
	PretaskNone,
}


/// <summary>
/// page controller.
/// </summary>
public class CPageSwitch
{
	public static void SwitchUI<T>(SwitchEffect effect)
//		where T : CPage<>
	{
//		T.sInstace.Show();
	}

	public static void SwitchScene()
	{
		//
	}
}

