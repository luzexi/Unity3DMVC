using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//  SingletonMono.cs
//  Author: Lu Zexi
//  2014-09-15



/// <summary>
/// The MonoBehavior Singleton.
/// </summary>
public abstract class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
{
  private static readonly string dontDestroyObjectName = "DontDestroyObject_" + typeof(T).Name;
  private static T mInstance = null;
  public static T sInstance
  {
    get
    {
      if (mInstance == null)
      {
        GameObject go = GameObject.Find(dontDestroyObjectName);
        if (go == null)
        {
          go = new GameObject(dontDestroyObjectName);
        }
        mInstance = go.AddComponent<T>() as T;
      }
      return mInstance;
    }
  }
  
  void Awake()
  {
    if (mInstance == null)
    {
      GameObject go = GameObject.Find(dontDestroyObjectName);
      if (go != gameObject)
      {
        Destroy(gameObject);
      }
      else
      {
        mInstance = this as T;
        gameObject.name = dontDestroyObjectName;
        DontDestroyOnLoad(gameObject);
        init();
      }
    }
    else
    {
      if (mInstance.gameObject != gameObject)
      {
        Destroy(gameObject);
      }
      Destroy(this);
    }
  }
  
  public virtual void init() {}
}
