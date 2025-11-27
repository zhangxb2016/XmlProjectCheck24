using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using JKY.Models24;


namespace JKY.XMLProjectCheck
{

    public class CheckMain24
    {
        #region 初始化变量
        AutoReeolveMethod24 armMethod = new AutoReeolveMethod24();
        AutoReeolveCollection24 retArc = null;
        #endregion
        public ReturnModel<ConstructionProject> SaveXmlToDB(System.Xml.XmlDocument xml, string projectFeatureId,
    string projectFeatureName, string BuildTypeId, string fileName, string ProjectId, string HTID, string One, string Two, string Three, out string projectName, out string UploadMsg, out List<string> list, out CheckReport report)
        {
            ReturnModel<ConstructionProject> ret = new ReturnModel<ConstructionProject> { IsSuccess = 0 };
            ret.Msg = "";//初始化
            list = new List<string>();
            report = new CheckReport();
            projectName = "";
            UploadMsg = "";
            var cm_xml = new CheckItemModel() { Caption = "XML文件业务检查结果" };
            try
            {


                XmlNode CPNode = xml.SelectSingleNode("/ConstructionProject");
                XmlNode SysInfoNode = xml.SelectSingleNode("/ConstructionProject/SystemInfo");
                string tmpUnit = "";
                var ReadXMLstart = Environment.TickCount;
                if (CPNode != null && SysInfoNode != null)
                {
                    retArc = armMethod.SaveXmlToDB(xml);
                    if (retArc.ExsultMessage != "")
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = retArc.ExsultMessage;
                        list.Add(retArc.ExsultMessage);
                        var lr = retArc.ExsultMessage.Split('❑');
                        int pos = 0;
                        foreach (var item in lr)
                        {

                            if (!string.IsNullOrEmpty(item))
                            {
                                if (pos == 0)
                                {
                                    report.Header = item.Trim();
                                }
                                else
                                {
                                    var cap = item.Substring(0, item.IndexOf('\n')).Replace("❑", "").Trim();
                                    if (report.ModelItems.Count(x => x.Caption.Equals(cap)) == 0)
                                    {

                                        var rpItem = new CheckItemModel() { Caption = cap };
                                        var lr2 = item.Split('\n');
                                        var lrItem = new List<string>();
                                        foreach (var it in lr2)
                                        {
                                            var it2 = it.Replace("☆", "").Trim();
                                            if (!string.IsNullOrEmpty(it2) && it.Trim() != cap.Trim() && lrItem.Count(x => x.Equals(it2)) == 0)
                                            {
                                                lrItem.Add(it2);
                                            }
                                        }
                                        rpItem.FieldTip = lrItem.Distinct().ToList();
                                        report.ModelItems.Add(rpItem);
                                    }
                                }
                                pos++;
                            }

                        }
                    }
                }
                else
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "XML数据格式不符合交换标准，请检查!";
                    list.Add("XML数据格式不符合交换标准，请检查!");
                }
                #region ConstructionProjects 单项成果文件校验
                if (retArc.constructionProject == null)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的XML文件里项目名称为空，请补充项目名称后再重新上传！";
                    //return ret;
                    list.Add("您提交的XML文件里项目名称为空，请补充项目名称后再重新上传！");
                }
                else
                {

                    //判断材料价格时间 MaterialPriceDate="2018-02" 年-月格式 
                    if (retArc.constructionProject.MaterialPriceDate == null)
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = "您提交的XML文件里项目信息表材料价格时间，数据格式不正确，标准格式如：2018-02";
                        //return ret;
                        list.Add("您提交的XML文件里项目信息表材料价格时间，数据格式不正确，标准格式如：2018-02");
                        cm_xml.FieldTip.Add("您提交的XML文件里项目信息表材料价格时间，数据格式不正确，标准格式如：2018-02");
                    }



                    #region 单项成果文件 单位校验
                    tmpUnit = retArc.constructionProject.ScaleUnit;
                    if (tmpUnit.Length > 10)
                    {
                        //返回错误信息
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件里项目建设规模单位\"{0}\"有误！请您修改正确后重新上传。", tmpUnit);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件里项目建设规模单位\"{0}\"有误！请您修改正确后重新上传。", tmpUnit));
                        cm_xml.FieldTip.Add(string.Format("您提交的xml文件里项目建设规模单位\"{0}\"有误！请您修改正确后重新上传。", tmpUnit));
                    }
                    retArc.constructionProject.ScaleUnit = TransferUnit(tmpUnit);
                }
                #endregion

                #endregion

                var ReadXMLend = Environment.TickCount;

                #region  校验数据
                var CheckXMLstart = Environment.TickCount;

                if (retArc.constructionProject != null && retArc.constructionProject.StandardName.Trim() != "建设工程造价数据交换标准")
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "上传文件格式不符，请重新上传符合《建设工程造价数据交换标准》的造价文件。";
                    //return ret;
                    list.Add("上传文件格式不符，请重新上传符合《建设工程造价数据交换标准》的造价文件。");
                    cm_xml.FieldTip.Add("上传文件格式不符，请重新上传符合《建设工程造价数据交换标准》的造价文件。");
                }

                if (retArc.projectInfo == null)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的XML文件里项目信息中编制信息为空，请补充完整后再上传！";
                    //return ret;
                    list.Add("您提交的XML文件里项目信息中编制信息为空，请补充完整后再上传！");
                    cm_xml.FieldTip.Add("您提交的XML文件里项目信息中编制信息为空，请补充完整后再上传！");
                }
                else
                {
                    if (retArc.projectInfo.CompileCompany == "")
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = "您提交的XML文件里项目信息中编制单位为空，请补充完整后再上传！";
                        //return ret;
                        list.Add("您提交的XML文件里项目信息中编制单位为空，请补充完整后再上传！");
                    }
                    if (retArc.projectInfo.CompileDate == null)
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = "您提交的XML文件里项目信息中编制时间为空，请补充完整后再上传！";
                        //return ret;
                        list.Add("您提交的XML文件里项目信息中编制时间为空，请补充完整后再上传！");
                        cm_xml.FieldTip.Add("您提交的XML文件里项目信息中编制时间为空，请补充完整后再上传！");
                    }
                    else
                    {
                        DateTime date;
                        bool flag = DateTime.TryParse(retArc.projectInfo.CompileDate.ToString(), out date);
                        if (!flag)
                        {
                            ret.IsSuccess = 1;
                            ret.Msg = "您提交的XML文件里项目信息中编制时间格式不正确，标准格式如：2018-02-01";
                            //return ret;
                            list.Add("您提交的XML文件里项目信息中编制时间格式不正确，标准格式如：2018-02-01");
                            cm_xml.FieldTip.Add("您提交的XML文件里项目信息中编制时间格式不正确，标准格式如：2018-02-01");
                        }
                        else
                        {
                            retArc.projectInfo.CompileDate = date;
                        }
                    }
                }




                #region 单项工程专业分类、单项工程编码
                if (retArc.sectionalWorks == null || retArc.sectionalWorks.Count == 0)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的xml文件单项工程信息为空，请补充完整后重新上传！";
                    //return ret;
                    list.Add("您提交的xml文件单项工程信息为空，请补充完整后重新上传！");
                    cm_xml.FieldTip.Add("您提交的xml文件单项工程信息为空，请补充完整后重新上传！");
                }
                int code = 0;
                string tmpCode = "";
                //单项工程 单项工程编码2位 限制
                for (int i = 0; i < retArc.unitWorks.Count; i++)
                {
                    tmpCode = retArc.unitWorks[i].Specialty;
                    if (tmpCode.Length != 4 || !int.TryParse(tmpCode, out code))
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件中的单位工程:{0}的编码\"{1}\"必须为4位数字！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpCode);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件中的单位工程:{0}的编码\"{1}\"必须为4位数字！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpCode));
                        cm_xml.FieldTip.Add(string.Format("您提交的xml文件中的单位工程:{0}的编码\"{1}\"必须为4位数字！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpCode));
                    }
                }

                #region 单项工程 单位校验
                retArc.sectionalWorks = retArc.sectionalWorks ?? new List<SectionalWorks>();
                for (int i = 0; i < retArc.sectionalWorks.Count; i++)
                {
                    tmpUnit = retArc.sectionalWorks[i].ScaleUnit;
                    if (tmpUnit.Length > 10)
                    {
                        //返回错误信息
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件中的单项工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", retArc.sectionalWorks[i].Name, tmpUnit);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件中的单项工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", retArc.sectionalWorks[i].Name, tmpUnit));
                        cm_xml.FieldTip.Add(string.Format("您提交的xml文件中的单项工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", retArc.sectionalWorks[i].Name, tmpUnit));
                    }
                    retArc.sectionalWorks[i].ScaleUnit = TransferUnit(tmpUnit);
                }
                #endregion
                if (retArc.constructionProject != null)
                {
                    string dxProjectNameTemp = retArc.constructionProject.Name; //拼接单项工程名称
                    dxProjectNameTemp = retArc.sectionalWorks[0].Name;
                    for (int i = 0; i < retArc.sectionalWorks.Count; i++)
                    {
                        dxProjectNameTemp += "/" + retArc.sectionalWorks[i].Name;
                    }
                    retArc.constructionProject.Name = dxProjectNameTemp;
                }
               
                #endregion

                #region 单位工程专业分类、单位工程编码
                retArc.unitWorks = retArc.unitWorks ?? new List<UnitWorks>();
                if (retArc.unitWorks.Count == 0)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的xml文件里单位工程信息为空，请补充单位工程信息后再上传！";
                    //return ret;
                    list.Add("您提交的xml文件里单位工程信息为空，请补充单位工程信息后再上传！");
                    cm_xml.FieldTip.Add("您提交的xml文件里单位工程信息为空，请补充单位工程信息后再上传！");
                }

                //判断xml是否只有一个单项工程
                if (retArc.sectionalWorks.Count != 1)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "一个XML文件只能包含一个单项工程，请核对后再次上传！";
                    //return ret;
                    list.Add("一个XML文件只能包含一个单项工程，请核对后再次上传！");
                }
                ///单位专业类别和单项工程专业类别对应关系是否应该建立呢？@李恺平 2019-08-29
                if (CheckSpecialty(retArc.unitWorks))
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您上传的XML文件在制作或导出过程中，单位工程未对应正确的专业类别，请修改您的文件，导出新的XML文件后，重新上传。";
                    //return ret;
                    list.Add("您上传的XML文件在制作或导出过程中，单位工程未对应正确的专业类别，请修改您的文件，导出新的XML文件后，重新上传。");
                    cm_xml.FieldTip.Add("您上传的XML文件在制作或导出过程中，单位工程未对应正确的专业类别，请修改您的文件，导出新的XML文件后，重新上传。");
                }
                //单位工程 单位工程编码4位 限制
                for (int i = 0; i < retArc.unitWorks.Count; i++)
                {
                    tmpCode = retArc.unitWorks[i].Specialty;
                    if (tmpCode.Length != 4 || !int.TryParse(tmpCode, out code))
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件中的单位工程:{0}的编码\"{1}\"必须为4位数字！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpCode);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件中的单位工程:{0}的编码\"{1}\"必须为4位数字！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpCode));
                        cm_xml.FieldTip.Add(string.Format("您提交的xml文件中的单位工程:{0}的编码\"{1}\"必须为4位数字！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpCode));
                    }
                }
                decimal unitWorksTotal = 0;

                #region 单位工程 单位校验
                for (int i = 0; i < retArc.unitWorks.Count; i++)
                {
                    unitWorksTotal += Convert.ToDecimal(retArc.unitWorks[i].Total);
                    tmpUnit = retArc.unitWorks[i].ScaleUnit;
                    if (tmpUnit.Length > 10)
                    {
                        //返回错误信息
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件中的单位工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpUnit);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件中的单位工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpUnit));
                        cm_xml.FieldTip.Add(string.Format("您提交的xml文件中的单位工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", retArc.unitWorks[i].Name, tmpUnit));
                    }
                    retArc.unitWorks[i].ScaleUnit = TransferUnit(tmpUnit);
                }
                #endregion

                //1.您上传的成果文件，建筑安装工程费与单项工程金额不等，请核对后再次上传。
                //2.您上传的成果文件，单项工程金额与单位工程金额合计不等，请核对后再次上传。
                if (CheckMoney(Convert.ToDecimal(retArc.sectionalWorks[0].Total), Convert.ToDecimal(retArc.projectInstallationWorkCosts[0].Total)))
                {
                    ret.IsSuccess = 1;
                    ret.Msg = string.Format("您上传的成果文件，建筑安装工程费\"{1}\"与单项工程金额\"{0}\"不等，请核对后再次上传。", retArc.sectionalWorks[0].Total, retArc.projectInstallationWorkCosts[0].Total);
                    //return ret;
                    list.Add(string.Format("您上传的成果文件，建筑安装工程费\"{1}\"与单项工程金额\"{0}\"不等，请核对后再次上传。", retArc.sectionalWorks[0].Total, retArc.projectInstallationWorkCosts[0].Total));
                    cm_xml.FieldTip.Add(string.Format("您上传的成果文件，建筑安装工程费\"{1}\"与单项工程金额\"{0}\"不等，请核对后再次上传。", retArc.sectionalWorks[0].Total, retArc.projectInstallationWorkCosts[0].Total));
                }
                if (CheckMoney(unitWorksTotal, Convert.ToDecimal(retArc.sectionalWorks[0].Total)))
                {
                    ret.IsSuccess = 1;
                    ret.Msg = string.Format("您上传的成果文件，单项工程金额\"{1}\"与单位工程金额合计\"{0}\"不等，请核对后再次上传。", unitWorksTotal, retArc.sectionalWorks[0].Total);
                    //return ret;
                    list.Add(string.Format("您上传的成果文件，单项工程金额\"{1}\"与单位工程金额合计\"{0}\"不等，请核对后再次上传。", unitWorksTotal, retArc.sectionalWorks[0].Total));
                    cm_xml.FieldTip.Add(string.Format("您上传的成果文件，单项工程金额\"{1}\"与单位工程金额合计\"{0}\"不等，请核对后再次上传。", unitWorksTotal, retArc.sectionalWorks[0].Total));
                }

                int uwSpecialtyNum = 0;
                foreach (UnitWorks modelUW in retArc.unitWorks)
                {
                    if (modelUW.Specialty != null && modelUW.Specialty != "")
                    {
                        uwSpecialtyNum += 1;
                    }
                }

                if (uwSpecialtyNum == 0)
                {
                    cm_xml.FieldTip.Add("您提交的xml文件里单位工程没有专业类别，请补充完整后再上传！");
                }
                #endregion

                if (retArc.constructionProject.ScaleUnit == "" || retArc.constructionProject.ScaleUnit == null)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的xml文件里建设规模单位为空，请选择建设规模单位后再上传！";
                    cm_xml.FieldTip.Add("您提交的xml文件里建设规模单位为空，请选择建设规模单位后再上传！");
                  
                }

                if (retArc.unitPriceCalculationOfItems.Count == 0)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的xml文件里子目单价计算信息为空，请联系计价软件公司！";
                    //return ret;
                    cm_xml.FieldTip.Add("您提交的xml文件里子目单价计算信息为空，请联系计价软件公司！");

                }
                if (retArc.constructionProject.Scale <= 0)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的xml文件里建设规模为空，请输入建设规模！";
                    //return ret;
                    list.Add("您提交的xml文件里建设规模为空，请输入建设规模！");
                    cm_xml.FieldTip.Add("您提交的xml文件里建设规模为空，请输入建设规模！");
                }


                var CheckXMLend = Environment.TickCount;
                #endregion

                #region   保存数据


                ret.Data = retArc.constructionProject;
                UploadMsg = " 读取信息时间：" + (ReadXMLend - ReadXMLstart).ToString() + "毫秒;" + "验证时间：" + (CheckXMLend - CheckXMLstart).ToString() + "毫秒。";// + "保存信息时间：" + (SaveCpend - SaveCpstart).ToString() + "毫秒。";
                #endregion
            }
            //catch (Exception ex)
            catch (Exception ex)
            {
                ret.IsSuccess = 2;
                ret.Msg = "您提交的xml文件格式不符合交换标准，第一步：请您确认是否按照造价监测数据接口导出的XML文件；第二步：如果确认第一步没有问题，请联系北京建科研软件技术有限公司：400-825-113进行咨询。";
                list.Add("您提交的xml文件格式不符合交换标准，第一步：请您确认是否按照造价监测数据接口导出的XML文件；第二步：如果确认第一步没有问题，请联系北京建科研软件技术有限公司：400-825-113进行咨询。");
                cm_xml.FieldTip.Add("您提交的xml文件格式不符合交换标准，第一步：请您确认是否按照造价监测数据接口导出的XML文件；第二步：如果确认第一步没有问题，请联系北京建科研软件技术有限公司：400-825-113进行咨询。");
            }
            if (cm_xml.FieldTip.Count > 0) report.ModelItems.Add(cm_xml);
            return ret;
        }
        //平台
        //List<string> FJ_unitWorks = new List<string>() { "0101", "0102", "0301", "0302", "0303", "0304", "0305", "0306", "0307", "0308" };
        //List<string> SZ_unitWorks = new List<string>() { "0401", "0402", "0403", "0404", "0405", "0406", "0407", "0408", "0409" };
        //List<string> GD_unitWorks = new List<string>() { "0801", "0802", "0803", "0804", "0805", "0806", "0807", "0808", "0809" };
        //List<string> YL_unitWorks = new List<string>() { "0501", "0502", "0503" };
        //List<string> KS_unitWorks = new List<string>() { "0601", "0602" };
        //标准
        //List<string> FJ_unitWorks = new List<string>() { "0101", "0102", "0103", "0104", "0105", "0106", "0301", "0302", "0303", "0304", "0305", "0306", "0307", "0308", "0309", "0310", "0311", "0312", "0313", "0314", "0315" };
        //List<string> FG_unitWorks = new List<string>() { "0201", "0202" };
        //List<string> AZ_unitWorks = new List<string>() { "0301", "0302", "0303", "0304", "0305", "0306", "0307", "0308", "0309", "0310", "0311", "0312", "0313", "0314", "0315" };
        //List<string> SZ_unitWorks = new List<string>() { "0401", "0402", "0403", "0404", "0405", "0406", "0407", "0408", "0409", "0410" };
        //List<string> YL_unitWorks = new List<string>() { "0501", "0502" };
        //List<string> KS_unitWorks = new List<string>() { "0601", "0602" };
        //List<string> GD_unitWorks = new List<string>() { "0801", "0802", "0803", "0804", "0805", "0806", "0807", "0808", "0809" };
        //List<string> BP_unitWorks = new List<string>() { "0901", "0902", "0903", "0904", "0905", "0906" };
        //List<string> XS_unitWorks = new List<string>() { "3101", "3102", "3103", "3104" };
        List<string> lrSpecialty = new List<string>() { "0101","0102","0201","0202","0301","0302","0303","0304","0305","0306","0307","0308","0309","0310","0311","0312","0313","0314",
"0401","0402","0403","0404","0405","0406","0407","0408","0501","0502","0503","0601","0602","0603","0701","0702","0801","0802",
"0803","0804","0805","0806","0807","0808","0809","0810","0811","0901","0902","0903","0904","0905","0906","3101","3102","3103",
"3104","9901" };
        /// <summary>
        /// 检测 unitWorksList 是否与单项工程对应
        /// </summary>
        /// <param name="unitWorksList"></param>
        /// <returns>false:专业类别编码不存在    true:专业类别编码存在</returns>
        private bool CheckSpecialty(List<UnitWorks> unitWorksList)
        {

            for (int i = 0; i < unitWorksList.Count; i++)
            {
                var b = lrSpecialty.Count(x => x.Equals(unitWorksList[i].Specialty)) > 0;
                if (!b)
                {
                    return b;
                }
            }
            return false;
        }
        //--统一单位：
        //--米、M             -->m
        //--千米、公里、㎞    -->km
        //--公顷              -->hm2
        //--吨                -->t
        //--平方米、M2、㎡、平米、Ｍ2、m²、Ｍ２、m 2、m^2    --》m2
        //--立方米、M3、m³        --》m3
        private string TransferUnit(string unit)
        {
            switch (unit)
            {
                case "米":
                case "Ｍ":
                    {
                        unit = "m";
                        break;
                    }
                case "千米":
                case "公里":
                case "㎞":
                    {
                        unit = "km";
                        break;
                    }
                case "公顷":
                    {
                        unit = "hm2";
                        break;
                    }
                case "吨":
                    {
                        unit = "t";
                        break;
                    }
                case "平方米":
                case "㎡":
                case "平米":
                case "Ｍ2":
                case "m²":
                case "Ｍ２":
                case "m 2":
                case "m^2":
                    {
                        unit = "m2";
                        break;
                    }
                case "立方米":
                //case "M3":
                case "m³":
                    {
                        unit = "m3";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return unit.ToLower();
        }

        public T TransModel<T>(object model, T mutatorData)
        {
            //数据集合
            Type type = model.GetType();//获取类型
            PropertyInfo[] pi = type.GetProperties(BindingFlags.Instance | BindingFlags.Public); ;//获取属性集合

            //所要赋值的集合
            Type mutType = mutatorData.GetType();//获取类型
            PropertyInfo[] mutPi = mutType.GetProperties(BindingFlags.Instance | BindingFlags.Public); ;//获取属性集合

            //数据集合
            foreach (PropertyInfo p in pi)
            {
                //所要赋值的集合
                foreach (PropertyInfo mutP in mutPi)
                {
                    if (p.Name == mutP.Name)
                    {
                        mutP.SetValue(mutatorData, p.GetValue(model, null));
                    }
                }
            }
            return mutatorData;
        }


        private bool CheckMoney(decimal unitWorksTotal, decimal total)
        {
            decimal num = (unitWorksTotal > total) ? (unitWorksTotal - total) : (total - unitWorksTotal);
            return num > 1;
        }
    }
}
