using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectRole : MonoBehaviour
{
    private GameObject _roleListContent;
    private Button _btnSelect;

    private ToggleGroup _roleListToggleGroup;

    private GameObject _modelStudio;// 模型摄影棚
    private GameObject _modelPlace; // 模型的防止点

    private int _selectedRoleIndex = -1;//是初始角色为-1；
    private int _lastSelectIndex = 0;//记录上一次登录选中的角色

    private void Awake()
    {
        //查找content对象
        //_roleListContent = transform.Find("RoleList/Viewport/Content").gameObject;

        _roleListContent = gameObject.FindGameObject("RoleList/Viewport/Content");

        _roleListToggleGroup = _roleListContent.GetComponent<ToggleGroup>();
        //_btnSelect = transform.Find("BtnSelect").GetComponent<Button>();
        _btnSelect = gameObject.FindComponent<Button>("BtnSelect");
        _btnSelect.onClick.AddListener(OnBtnSelectClick);



        //处理角色的摄影棚
        _modelStudio = Instantiate(Resources.Load<GameObject>("Prefab/UI/SelectRole/ModelStudio"));
        _modelPlace = _modelStudio.FindGameObject("ModelPlace");


        //角色索引的初始值
        int i = 0;

        foreach (var roleInfo in UserData.Instance.AllRole)
        {
            var roleItem = Instantiate(Resources.Load<GameObject>("Prefab/UI/SelectRole/Role"));
            roleItem.transform.SetParent(_roleListContent.transform);
            var textName = roleItem.transform.Find("Label").GetComponent<Text>();
            var toggle = roleItem.GetComponent<Toggle>();

            toggle.group = _roleListToggleGroup;

            //确认每个角色的索引值
            var index = i;
            ++i;

            textName.text = roleInfo.playerName;
            //闭包的操作来确定Toggle的绑定
            toggle.onValueChanged.AddListener((isOn) =>
            {
                OnToggleValueChanged(index ,isOn);
             
            });

            //默认选中
            toggle.isOn = index == _lastSelectIndex;
        }
    }

    private void OnToggleValueChanged(int roleIndex, bool isOn)
    {

        if (_lastSelectIndex == roleIndex) return;
        _selectedRoleIndex = roleIndex;

        Debug.Log("删除成功");
        //先删除先前生成的模型
        if (_modelPlace.transform.childCount != 0)
        {
            Destroy(_modelPlace.transform.GetChild(0).gameObject);
        }
        
       
        //Debug.Log(string.Format("{0},{1}", roleIndex, isOn));
        //记录选中的索引
        
        //在生成所选中的模型
        var curRoleInfo = UserData.Instance.AllRole[roleIndex];
        var model = GameObject.Instantiate(Resources.Load<GameObject>(curRoleInfo.roleModlePath));
        model.transform.SetParent(_modelPlace.transform, false);
    }

    private void OnBtnSelectClick()
    {
        Debug.Log("选中了角色" + _selectedRoleIndex);
    }
}
