using UnityEngine;
using System;
using System.Collections.Generic;

//using BUTTON_CALLBACK = System.Action<>


//  UIControllerBase.cs
//  Author: Lu Zexi
//  2014-07-05


namespace Game.MVC
{
    /// <summary>
    /// the ui controller.
    /// </summary>
    public class UIControllerBase : MonoBehaviour
    {
        public virtual void Show() { }
        public virtual void Hiden() { }

        /// <summary>
        /// find the gameobject.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public GameObject FIND(string path)
        {
            return this.transform.Find(path).gameObject;
        }

        /// <summary>
        /// find the mono scripts.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T FIND<T>(string path) where T : MonoBehaviour
        {
            return this.transform.Find(path).GetComponent<T>();
        }

        /// <summary>
        /// find the gameobject.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public GameObject FIND(GameObject obj, string path)
        {
            return obj.transform.Find(path).gameObject;
        }

        /// <summary>
        /// find the mono scripts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public T FIND<T>(GameObject obj, string path) where T : MonoBehaviour
        {
            return obj.transform.Find(path).GetComponent<T>();
        }

        /// <summary>
        /// regist the mono event.
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="callback"></param>
        /// <param name="arg"></param>
        public void RegistEvent(MonoBehaviour mono, UIEvent.OnCallBack callback, params object[] arg)
        {
            Regist(mono.gameObject, callback, arg);
        }

        /// <summary>
        /// regist the gameobject event.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callback"></param>
        /// <param name="arg"></param>
        public void RegistEvent(GameObject obj, UIEvent.OnCallBack callback, params object[] arg)
        {
            Regist(obj, callback, arg);
        }

        /// <summary>
        /// regist the event .
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callback"></param>
        /// <param name="arg"></param>
        protected void Regist(GameObject obj, UIEvent.OnCallBack callback, object[] arg)
        {
            UIEvent uiEvent = obj.AddComponent<UIEvent>();
            uiEvent.m_cEvent = callback;
            uiEvent.m_vecArg = arg;
        }
    }
}
