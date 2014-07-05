using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


//  Model.cs
//  Author: Lu Zexi
//  2014-07-05



namespace Game.MVC
{
    /// <summary>
    /// Model类
    /// </summary>
    public abstract class Model : ScriptableObject, IEnumerable
    {
        protected List<Model> s_lstData;

        public Model()
        {
            Type t = this.GetType();
            this.s_lstData = ModelManager.sInstance.Get(t.FullName);
            if (this.s_lstData == null)
            {
                this.s_lstData = new List<Model>();
                ModelManager.sInstance.Add(t.FullName, this.s_lstData);
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
        public T Get<T>(int index) where T : Model
        {
            if (index >= this.s_lstData.Count)
                return default(T);
            return this.s_lstData[index] as T;
        }

        //public Model this[int index]
        //{
        //    get { if (index >= s_lstData.Count) return null; return s_lstData[index]; }
        //}

        /// <summary>
        /// get the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            foreach (Model item in s_lstData)
                yield return item;
        }

        /// <summary>
        /// add the model instance.
        /// </summary>
        /// <param name="model"></param>
        public void Add(Model model)
        {
            s_lstData.Add(model);
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
        public void Remove(Model model)
        {
            s_lstData.Remove(model);
        }
    }
}
