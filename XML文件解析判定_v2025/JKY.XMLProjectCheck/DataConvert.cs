using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JKY.Common
{
    public class DataConvert
    {
        public static double GetNumber(string str)
        {
            double result = 0;
            try
            {
                if (!String.IsNullOrWhiteSpace(str) && str.Length > 0)
                {
                    char point='.';
                    string reg = "0123456789";
                    bool haspoint = false;
                    char[] charlist = str.ToCharArray();
                    string floatstr = "";
                    foreach (char a in charlist) 
                    {
                        if (reg.IndexOf(a) >= 0)
                        {
                            floatstr += a.ToString();
                        }
                        else 
                        {
                            if ( a == point&& !haspoint)
                            {
                                haspoint = true;
                                floatstr += a.ToString();
                            }
                            else
                            {
                                break;
                            }
                        }
                        
                    }
                    result = floatstr == "" ? 0 : Convert.ToDouble(floatstr);
                }

            }
            catch { }
            return result;
        }

        public static string[] GetNumberUnit(string str)
        {
            string[] arry = new string[2];
            double result = 0;
            try
            {
                if (!String.IsNullOrWhiteSpace(str) && str.Length > 0)
                {
                    char point = '.';
                    string reg = "0123456789";
                    bool haspoint = false;
                    char[] charlist = str.ToCharArray();
                    string floatstr = "";
                    int num = 0;
                    foreach (char a in charlist)
                    {
                        if (reg.IndexOf(a) >= 0)
                        {
                            floatstr += a.ToString();
                        }
                        else
                        {
                            if (a == point && !haspoint)
                            {
                                haspoint = true;
                                floatstr += a.ToString();
                            }
                            else
                            {
                                break;
                            }
                        }
                        num++;
                    }
                    result = floatstr == "" ? 0 : Convert.ToDouble(floatstr);
                    arry[0] = result.ToString();
                    arry[1] = str.Substring(num);
                }

            }
            catch { }
            return arry;
        }

        //获取真实的单项工程名
        public static string GetSectionalWorkName(string name)
        {
            string trueName = "";
            name = name.Trim();
            if (name.Length <= 0)
                return name;
            string[] lst = name.Split('/');
            if (lst.Length > 1)
                trueName = lst[1];
            else
                trueName = lst[0];
            //for (int i = 0; i < lst.Length; i++)
            //{
            //    trueName = lst[i];
            //}
            return trueName;
        }

        /// <summary>
        /// 单价计算
        /// </summary>
        /// <param name="FileFormatterType"></param>
        /// <param name="Total"></param>
        /// <param name="Scale"></param>
        /// <param name="AuthorizedAmount"></param>
        /// <returns></returns>
        public static string OperateIndex(int FileFormatterType, double Total, string Scale, decimal? AuthorizedAmount)
        {
            var result = "";
            try
            {
                var Extent = Scale.Replace("m2", "");
                if (FileFormatterType == 2)
                {
                    result = String.Format("{0:F}", Math.Round(Convert.ToDouble(AuthorizedAmount) / Convert.ToDouble(Extent), 2));
                }
                else
                    result = String.Format("{0:F}", Math.Round(Total / Convert.ToDouble(Extent), 2));

                result = result.Replace("∞", "");
            }
            catch { }

            return result;
        }
    }
}
