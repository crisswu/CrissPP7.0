using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Bowtech
{
    public class Contronls_Model
    {
       public string JoinName;// Left Join 或者 Inner Join
       public string JoinString;// A.XX = B.XX
       public string A_Name;//A B C 等索引名称 对应 OnePanel
       public string B_Name;//A B C 等索引名称 对应 TwoPanel
       public string A_TableName;//表名
       public string B_TableName;//表名
       public Panel OnePanel;
       public Panel TwoPanel;
    }
}
