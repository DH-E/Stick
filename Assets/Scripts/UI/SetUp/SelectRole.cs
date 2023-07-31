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

    private int _selectedRoleIndex = -1;//�ǳ�ʼ��ɫΪ-1��
    private int _lastSelectIndex = 2;//��¼��һ�ε�¼ѡ�еĽ�ɫ

    private void Awake()
    {
        _roleListContent = transform.Find("RoleList/Viewport/Content").gameObject;

        _roleListToggleGroup = _roleListContent.GetComponent<ToggleGroup>();
        _btnSelect = transform.Find("BtnSelect").GetComponent<Button>();
        _btnSelect.onClick.AddListener(OnBtnSelectClick);

        //��ɫ�����ĳ�ʼֵ
        int i = 0;

        foreach (var roleInfo in UserData.Instance.AllRole)
        {
            var roleItem = Instantiate(Resources.Load<GameObject>("Prefb/UI/SelectRole/Role"));
            roleItem.transform.SetParent(_roleListContent.transform);
            var textName = roleItem.transform.Find("Label").GetComponent<Text>();
            var toggle = roleItem.GetComponent<Toggle>();

            toggle.group = _roleListToggleGroup;

            //ȷ��ÿ����ɫ������ֵ
            var index = i;
            ++i;

            textName.text = roleInfo.playerName;
            //�հ��Ĳ�����ȷ��Toggle�İ�
            toggle.onValueChanged.AddListener((isOn) =>
            {
                OnToggleValueChanged(index ,isOn);
             
            });

            //Ĭ��ѡ��
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
        Debug.Log("ѡ���˽�ɫ" + _selectedRoleIndex);
    }
}