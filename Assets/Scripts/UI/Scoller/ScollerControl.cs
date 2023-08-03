using EnhancedUI;
using EnhancedUI.EnhancedScroller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;


public class ScollerControl : MonoBehaviour, IEnhancedScrollerDelegate
{
    public GameObject _uiSystem;

    public GameObject _canvas;

    public GameObject _scrollerUI;

    public GameObject _gameTitle;

    public List<string> _uiDataName;
    //创建一个列表，接收数据
    public SmallList<ScollerData> _InterfaceData;

    //换取滚动界面的面板
    public EnhancedScroller scoller;

    //获取预制体
    public EnhancedScrollerCellView cellViewPrefab;

    private void Awake()
    {
        //生成UISystem
        _uiSystem = Instantiate(Resources.Load<GameObject>("Prefab/UI/UISystem"));
        //然后找到UISystem下的Canvas组件
        _canvas = _uiSystem.transform.Find("Canvas").gameObject;
        //加载Scoller
        _scrollerUI = Instantiate(Resources.Load<GameObject>("Prefab/UI/Scoller/Scoller"));
        
        //将Scoller设置为Canvas的子组件
        _scrollerUI.transform.SetParent(_canvas.transform);
        //调整scroller的位置
        RectTransform rectTransform = _scrollerUI.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0,-300,0);
        //再将生成的Scoller给 scoller；
        scoller = _scrollerUI.GetComponent<EnhancedScroller>();

        //生成游戏标题
        _gameTitle = Instantiate(Resources.Load<GameObject>("Prefab/UI/Scoller/Title"));
        _gameTitle.transform.SetParent(_canvas.transform);
        _gameTitle.GetComponent<RectTransform>().localPosition = new Vector3(0,300,0);
    }




    private void Start()
    {
        scoller.Delegate = this;

        _uiDataName = new List<string>() { "Play","Load","Setting","About","Exit"};

        LoadInterfaceData();
    }

    /// <summary>
    /// 加载主界面面板的数据
    /// </summary>
    public void LoadInterfaceData()
    {
        _InterfaceData = new SmallList<ScollerData>();
        for (int i = 0; i < 5; i++)
        {
            _InterfaceData.Add(new ScollerData() { text = _uiDataName[i] });
        }
    }


    /// <summary>
    /// 获取要显示的单元格。您可以有许多单元格类型，从而使列表中的单元格类型多样化。例如页眉、页脚和其他分组单元格。
    /// </summary>
    /// <param name="scroller"></param>
    /// <param name="dataIndex"></param>
    /// <param name="cellIndex"></param>
    /// <returns></returns>
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
    {
        //首先先创建预制体
        CellView cellView = scroller.GetCellView(cellViewPrefab) as CellView;

        //其次给预制体命名
        cellView.name = "Cell " + dataIndex.ToString();

        // 给该预制体的TMP_text赋值
        cellView.SetData(_InterfaceData[dataIndex]);

        //将该预制体返回出去
        return cellView;
    }


    /// <summary>
    /// 获取cellView的高度与宽度,加入监听事件，当滑动到指定index的时候，将其放大2倍
    /// </summary>
    /// <param name="scroller"></param>
    /// <param name="dataIndex"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 100f;
    }


    /// <summary>
    /// 获取格子的数量
    /// </summary>
    /// <param name="scroller"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return _InterfaceData.Count;
    }
}

