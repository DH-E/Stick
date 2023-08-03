using EnhancedUI.EnhancedScroller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

public class CellView: EnhancedScrollerCellView
{
    public TMP_Text text;

    public void SetData(ScollerData data)
    {
        text.text = data.text;
    }
}

