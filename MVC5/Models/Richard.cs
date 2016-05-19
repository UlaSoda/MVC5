using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public static class Peter
    {
        /// <summary>
        ///  傳回字串長度   ~註解
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int Richard(this String str) //擴充方法
        {
            return str.Length;
        }
        //TODO 我在這裡   ~工作清單

        public static int Dana(this String str)
        {
            return str.Split(',').Length;
        }
    }
    class AA
    {
        public void SetRichard()
        {

        }
    }
    
}