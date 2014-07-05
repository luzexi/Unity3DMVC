//using UnityEngine;
//using System;
//using System.Collections;




///// <summary>
///// ListModel
///// </summary>
//public class ListModel : Model, IListModel
//{
	
//    public ListModel () : base () { }
//    public ListModel (Hashtable db) : base (db) { }
//    public ListModel (object db) : base (db) { }
	
//    public Hashtable Add ()
//    {
//        return Add(GetDB().Count + 1);
//    }
	
//    public Hashtable Add (int index)
//    {
//        Set(index, new Hashtable());
//        return (Hashtable)Get(index);
//    }
	
//    public Hashtable Add (string key)
//    {
//        Set(key, new Hashtable());
//        return (Hashtable)Get(key);
//    }
//}


