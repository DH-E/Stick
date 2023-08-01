using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameMgr : BaseMgr<GameMgr>
{

    public void Init()
    {
        //启动游戏引擎：

        //跳转第一个逻辑界面
        SceneManager.LoadScene("Main");
    }
}
