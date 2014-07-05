using UnityEngine;
using System;
using System.Collections.Generic;



namespace Game.MVC
{
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
            if(t.Count > 0 )
                t = t.Get<T>(0);
            return t;
        }

        /// <summary>
        /// get the map data
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Model> Get(string name)
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
        public void Add(string name, List<Model> lst)
        {
            this.m_mapData.Add(name, lst);
        }

        /// <summary>
        /// remove model
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            if (!this.m_mapData.ContainsKey(name))
                return;
            this.m_mapData.Remove(name);
        }
    }
}
