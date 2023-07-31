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

    private int _selectedRoleIndex = -1;//是初始角色为-1；
    private int _lastSelectIndex = 2;//记录上一次登录选中的角色

    private void Awake()
    {
        _roleListContent = transform.Find("RoleList/Viewport/Content").gameObject;

        _roleListToggleGroup = _roleListContent.GetComponent<ToggleGroup>();
        _btnSelect = transform.Find("BtnSelect").GetComponent<Button>();
        _btnSelect.onClick.AddListener(OnBtnSelectClick);

        //角色索引的初始值
        int i = 0;

        foreach (var roleInfo in UserData.Instance.AllRole)
        {
            var roleItem = Instantiate(Resources.Load<GameObject>("Prefb/UI/SelectRole/Role"));
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
        Debug.Log(string.Format("{0},{1}", roleIndex, isOn));
        _selectedRoleIndex = roleIndex;
    }

    private void OnBtnSelectClick()
    {
        Debug.Log("选中了角色" + _selectedRoleIndex);
    }
}
