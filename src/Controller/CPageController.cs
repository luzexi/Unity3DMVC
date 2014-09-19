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
public class CPageController
{
	public static void SwitchUI<T>(SwitchEffect effect)
		where T : CPage
	{
		T.Show();
	}

	public static void SwitchScene()
	{
		//
	}
}

