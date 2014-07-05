//using UnityEngine;
//using System.Collections;

//public class DataBase : IModel
//{
//    private static DataBase s_cInstance;
//    public static DataBase Instance
//    {
//        get
//        {
//            if (s_cInstance == null)
//            {
//                s_cInstance = new DataBase();
//            }
//            return s_cInstance;
//        }
//    }

//    private static Hashtable DB = new Hashtable();

//    public void		Set (object key, object value) { DB[key] = value; }
//    public object	Get (object key) { return DB.ContainsKey(key) ? DB[key] : null; }
//    public void		Delete (object key) { if(DB.ContainsKey(key)) DB.Remove(key); }
//    public bool		HasKey (object key) { return DB.ContainsKey(key); }
//    public void		Clear () { DB.Clear(); }
//    public int		Count () { return DB.Count; }

//    public Hashtable GetDB () {
//        return DB;
//    }

//    public T GetModel<T> () {
//        return GetModel<T>(typeof(T).FullName);
//    }

//    public T GetModel<T> (object key) {
//        return (T) Get(key);
//    }

//    public void SetModel<T>(T value) {
//        Set(typeof(T).FullName, value);
//    }

//    public void SetModel<T>(object key, T value) {
//        Set(key, value);
//    }

//    public void DeleteModel<T>(){
//        Delete(typeof(T).FullName);
//    }
//}
