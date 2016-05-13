using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class OddAttribute : DataTypeAttribute
    {
        
        public OddAttribute()
            :base("odd")//父類別
        {

        }
        /*
        public override bool IsValid(object value)//是否偶數?
        {
            //第一種方法
            
            try//可不用try catch 如果沒數字會報錯 
            {
                int n;
                if (int.TryParse(value.ToString(), out n))//嘗試轉換
                {
                    if(n % 2 == 0)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
            
            
        }*/
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {//第二種方法 可自訂錯誤訊息
            try
            {
                if (int.Parse(value.ToString()) % 2 == 0)
                {
                    return ValidationResult.Success;
                }
            }
            catch
            {

            }

            string sErrorMsg = "必須為偶數!!!!";

            if (String.IsNullOrEmpty(ErrorMessage))
            {
                ErrorMessage = validationContext.DisplayName + sErrorMsg;
            }

            return new ValidationResult(ErrorMessage);
            
        }
            

        


        

    }

}