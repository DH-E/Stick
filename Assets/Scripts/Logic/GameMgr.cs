using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameMgr : BaseMgr<GameMgr>
{

    public void Init()
    {
        //������Ϸ���棺

        //��ת��һ���߼�����
        SceneManager.LoadScene("Main");
    }
}