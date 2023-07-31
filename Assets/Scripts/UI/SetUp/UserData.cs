using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class SelectRoleInfo
{
    public string playerName;
    public string roleModlePath;
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
    

    public List<SelectRoleInfo> AllRole = new List<SelectRoleInfo>();
    
    public UserData()
    {
        AllRole.Add(new SelectRoleInfo { playerName = "老一", roleModlePath = "空" });
        AllRole.Add(new SelectRoleInfo { playerName = "大二", roleModlePath = "空" });
        AllRole.Add(new SelectRoleInfo { playerName = "三哥", roleModlePath = "空" });
    }
}

