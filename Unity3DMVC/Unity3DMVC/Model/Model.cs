//using UnityEngine;
//using System;
//using System.Collections;


///// <summary>
///// Model
///// </summary>
//public class Model : IModel
//{
//    protected Hashtable DB;

//    public Model()
//    {
//        string key = GetKey();
//        object o = DataBase.Instance.Get(key);
//        if (o == null)
//        {
//            DataBase.Instance.Set(key, new Hashtable());
//        }
//        DB = (Hashtable)DataBase.Instance.Get(key);
//    }

//    public Model (Hashtable db) { DB = db; }

//    public Model (object db) { DB = db as Hashtable; }

//    public void		Set (object key, object value) { DB[key] = value; }
//    public object	Get (object key) { return DB.ContainsKey(key) ? DB[key] : null; }
//    public void		Delete (object key) { if (DB.ContainsKey(key)) DB.Remove(key); }
//    public bool		HasKey (object key) { return DB.ContainsKey(key); }
//    public void		Clear () { DB.Clear(); }
//    public int		Count () { return DB.Count; }
//    public Hashtable GetDB () { return DB; }

//    public void DeleteModel()
//    {
//        DataBase.Instance.Delete( GetKey() );
//    }

//    protected virtual string GetKey() { return String.Empty; }
//}
