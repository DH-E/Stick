using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class UnityExtern
{
    /// <summary>
    /// 根据路径查找对应组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="path">附着该物体的组件路径</param>
    /// <returns></returns>
    public static T FindComponent<T>(this GameObject parent, string path)
    {
        return parent.transform.Find(path).GetComponent<T>();
        
    }


    /// <summary>
    /// 根据路径查找对应对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="path">对象的对应路径</param>
    /// <returns></returns>
    public static GameObject FindGameObject(this GameObject parent, string path)
    {
        return parent.transform.Find(path).gameObject;

    }
}

