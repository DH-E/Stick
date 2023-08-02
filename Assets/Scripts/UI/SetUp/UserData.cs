using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEditor.Progress;
using UnityEngine;


[Serializable]
public class AllRoles
{
    public List<SelectRoleInfo> roleInfo;
}


[System.Serializable]
public class SelectRoleInfo
{
    public int id;
    public string roleName;
    public string modelPath;
}



public class UserData
{
    #region 简单的单例模式
    private static UserData _instance;

    public static UserData Instance
    { 
        get
        {
            if(_instance == null)
            {
                _instance = new UserData();
            }
            return _instance;
        }
    }
    #endregion
    
    public Dictionary<int, SelectRoleInfo> _cache = new Dictionary<int, SelectRoleInfo>();

    public void Init()
    {
        string roleInfo = Resources.Load<TextAsset>("Json/RoleModelJson").text;
        AllRoles items = JsonUtility.FromJson<AllRoles>(roleInfo);


        for (int i = 0; i < items.roleInfo.Count; i++)
        {
            _cache.Add(items.roleInfo[i].id, items.roleInfo[i]);
        }
    }
    
    public UserData()
    {
       Init();
    }
}

