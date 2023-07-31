using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class UnityExtern
{
    public static T Find<T>(this GameObject parent, string path)
    {
        return parent.transform.Find(path).GetComponent<T>();
    }
}

