using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMgr<T>  where T : new() 
{
    static T _instance;

    static BaseMgr()
    {
        _instance = new T();
    }

    public static T Instance
    { 
        get 
        { 
            return _instance; 
        } 
    }


}
