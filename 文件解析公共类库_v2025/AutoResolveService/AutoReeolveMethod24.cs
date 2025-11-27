using AutoResolveService.Models;
using JKY.Models24;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

//using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace JKY.Models24
{
    public class AutoReeolveMethod24
    {
        #region 初始化变量
        List<AttrInfo> _lrAttrinfo = new List<AttrInfo>();
        List<AttrInfoItem> _lrAttrInfoItem = new List<AttrInfoItem>();
        List<AddiInfo> _lrAddiInfo = new List<AddiInfo>();
        List<AddiInfoItem> _lrAddiInfoItem = new List<AddiInfoItem>();
        List<AddiCost> _lrAddiCost = new List<AddiCost>();
        List<LabourMaterialsEquipmentsMachinesSummary> _lrLabourMaterialsEquipmentsMachinesSummary = new List<LabourMaterialsEquipmentsMachinesSummary>();
        List<LabourMaterialsEquipmentsMachinesElement> _lrLabourMaterialsEquipmentsMachinesElement = new List<LabourMaterialsEquipmentsMachinesElement>();



        List<UnitWorksSummary> _lrUnitWorksSummary = new List<UnitWorksSummary>();
        List<UnitWorksSummaryGroup> _lrUnitWorksSummaryGroup = new List<UnitWorksSummaryGroup>();
        List<UnitWorksSummaryItem> _lrUnitWorksSummaryItem = new List<UnitWorksSummaryItem>();
        List<ContingencyFeeGroup> _lrContingencyFeeGroup = new List<ContingencyFeeGroup>();
        List<ContingencyFeeItem> _lrContingencyFeeItem = new List<ContingencyFeeItem>();
        List<ProjectInstallationWorkCost> _lrProjectInstallationWorkCost = new List<ProjectInstallationWorkCost>();
        List<EquipmentProcurementCost> _lrEquipmentProcurementCost = new List<EquipmentProcurementCost>();
        List<EquipmentProcurementCostItem> _lrEquipmentProcurementCostItem = new List<EquipmentProcurementCostItem>();
        List<UnitPriceCalculationOfItem> _lrUnitPriceCalculationOfItem = new List<UnitPriceCalculationOfItem>();
        List<OtherCost> _lrOtherCost = new List<OtherCost>();
        List<SectionalWorks> _lrSectionalWorks = new List<SectionalWorks>();
        List<UnitWorks> _lrUnitWorks = new List<UnitWorks>();
        List<SummaryOfBasicCost> _lrSummaryOfBasicCost = new List<SummaryOfBasicCost>();
        List<DivisionalWorks> _lrDivisionalWorks = new List<DivisionalWorks>();
        List<WorkElement> _lrWorkElement = new List<WorkElement>();
        List<SummaryOfCost> _lrSummaryOfCost = new List<SummaryOfCost>();
        List<ExpressElement> _lrExpressElement = new List<ExpressElement>();
        List<WorkContent> _lrWorkContent = new List<WorkContent>();
        //List<UnitPriceCalculationOfItem> lrUnitPriceCalculationOfItem = new List<UnitPriceCalculationOfItem>();
        List<ProvisionalSums> _lrProvisionalSums = new List<ProvisionalSums>();
        List<ProvisionalSumsGroup> _lrProvisionalSumsGroup = new List<ProvisionalSumsGroup>();
        List<ProvisionalSumsItem> _lrProvisionalSumsItem = new List<ProvisionalSumsItem>();

        List<SpecialtyProvisionalPrice> _lrSpecialtyProvisionalPrice = new List<SpecialtyProvisionalPrice>();
        List<SpecialtyProvisionalPriceGroup> _lrSpecialtyProvisionalPriceGroup = new List<SpecialtyProvisionalPriceGroup>();
        List<SpecialtyProvisionalPriceItem> _lrSpecialtyProvisionalPriceItem = new List<SpecialtyProvisionalPriceItem>();

        List<DayWorkRate> _lrDayWorkRate = new List<DayWorkRate>();
        List<DayWorkRateGroup> _lrDayWorkRateGroup = new List<DayWorkRateGroup>();
        List<DayWorkRateItem> _lrDayWorkRateItem = new List<DayWorkRateItem>();

        List<MainContractorAttendance> _lrMainContractorAttendance = new List<MainContractorAttendance>();
        List<MainContractorAttendanceGroup> _lrMainContractorAttendanceGroup = new List<MainContractorAttendanceGroup>();
        List<MainContractorAttendanceItem> _lrMainContractorAttendanceItem = new List<MainContractorAttendanceItem>();

        List<ClaimsCostItem> _lrClaimsCostItem = new List<ClaimsCostItem>();
        List<Preliminaries> _lrPreliminaries = new List<Preliminaries>();
        List<Sundry> _lrSundry = new List<Sundry>();
        List<PriceAnalysis> _lrPriceAnalysis = new List<PriceAnalysis>();
        List<OriginalPriceItem> _lrOriginalPriceItem = new List<OriginalPriceItem>();
        List<PriceItem> _lrPriceItem = new List<PriceItem>();

        List<OtherContents> _lrOtherContents = new List<OtherContents>();
        List<OtherContentsGroup> _lrOtherContentsGroup = new List<OtherContentsGroup>();
        List<OtherContentsItem> _lrOtherContentsItem = new List<OtherContentsItem>();

        List<FundraisingFeeGroup> _lrFundraisingFeeGroup = new List<FundraisingFeeGroup>();
        List<FundraisingFeeItem> _lrFundraisingFeeItem = new List<FundraisingFeeItem>();

        List<WorkingCapitalGroup> _lrWorkingCapitalGroup = new List<WorkingCapitalGroup>();
        List<WorkingCapitalItem> _lrWorkingCapitalItem = new List<WorkingCapitalItem>();

        List<OtherInvestmentOfConstructionProjectGroup> _lrOtherInvestmentOfConstructionProjectGroup = new List<OtherInvestmentOfConstructionProjectGroup>();
        List<OtherInvestmentOfConstructionProjectItem> _lrOtherInvestmentOfConstructionProjectItem = new List<OtherInvestmentOfConstructionProjectItem>();

        //EquipmentProcurementCost equipmentProcurementCost = null;

        List<SundryCosts> _lrSundryCosts = new List<SundryCosts>();
        List<SundryCostsGroup> _lrSundryCostsGroup = new List<SundryCostsGroup>();
        List<SundryCostsItem> _lrSundryCostsItem = new List<SundryCostsItem>();

        #endregion

        #region xml解析上传
        public AutoReeolveCollection24 SaveXmlToDB(System.Xml.XmlDocument xmlFile)
        {
            AutoReeolveCollection24 ret = new AutoReeolveCollection24 { ExsultMessage = "" };

            ConstructionProject constructionProject = null;
            JKY.Models24.Option option = null;
            ProjectInfo projectInfo = null;
            JKY.Models24.TendererInfo tendererInfo = null;
            BidderInfo bidderInfo = null;
            SummaryOfCost summaryOfCost = null;
            WorkingCapital workingCapital = null;
            ConstructionCost constructionCost = null;
            FundraisingFee fundraisingFee = null;
            OtherInvestmentOfConstructionProject otherInvestmentOfConstructionProject = null;
            ContingencyFee contingencyFee = null;
            ConstructionSummary constructionSummary = null;
            ConstructionInfo constructionInfo = null;
            ProjectInstallationWorkCost projectInstallationWorkCost = null;
            SystemInfo systemInfo = null;
            string errMessageTemp = "";
            string errMessageList = "";

            string errDateMessageList = "";
            try
            {
                #region ConstructionProject,SystemInfo节点
                XmlNode CPNode = xmlFile.SelectSingleNode("/ConstructionProject");
                XmlNode SysInfoNode = xmlFile.SelectSingleNode("/ConstructionProject/SystemInfo");
                if (CPNode != null && SysInfoNode != null)
                {
                    constructionProject = XAttrConvert<ConstructionProject>.Model(CPNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 建设项目表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }

                    systemInfo = XAttrConvert<SystemInfo>.Model(SysInfoNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += errMessageTemp;
                    }

                    constructionProject.ID1 = systemInfo.ID1;
                    constructionProject.ID2 = systemInfo.ID2;
                    constructionProject.FileMakeDate = systemInfo.MakeDate;

                    if (constructionProject.ValuationMethod != 1)
                    {
                        if (constructionProject.ValuationMethod != 2)
                        {
                            errDateMessageList += "您提交的文件缺少计价类型，请检查！\n";
                            return ret;
                        }
                    }

                    constructionProject.Id = Guid.NewGuid();
                    constructionProject.XmlName = constructionProject.Name;
                    constructionProject.CreateDate = System.DateTime.Now;
                    constructionProject.State = 0;
                }
                #endregion

                #region ConstructionInfo
                XmlNode ConstructionInfoNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo");
                if (ConstructionInfoNode != null)
                {
                    constructionInfo = XAttrConvert<ConstructionInfo>.Model(ConstructionInfoNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 工程信息表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    constructionInfo.ConstructionProjectId = constructionProject.Id;
                    constructionInfo.SortNum = 1;
                }
                #endregion

                #region Option,ProjectInfo,TendererInfo
                XmlNode OptionsNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/Option");
                XmlNode PInfoNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/ProjectInfo");
                XmlNode TBNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/TendererInfo");

                if (OptionsNode != null)
                {
                    option = XAttrConvert<Option>.Model(OptionsNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 费用精度表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    option.ProjectNumber = constructionProject.Number;
                    option.SortNum = 1;
                    option.ProjectId = constructionProject.Id;
                    option.CreateDate = DateTime.Now;
                }
                if (PInfoNode != null)
                {
                    projectInfo = XAttrConvert<ProjectInfo>.Model(PInfoNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 估（概、预、结）信息表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    projectInfo.ConstructionProjectId = constructionProject.Id;
                    projectInfo.SortNum = 1;
                    constructionProject.MakeDate = projectInfo.CompileDate;
                }
                if (TBNode != null)
                {
                    tendererInfo = XAttrConvert<TendererInfo>.Model(TBNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 招标信息表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    tendererInfo.ConstructionProjectId = constructionProject.Id;
                    tendererInfo.SortNum = 1;
                }
                #endregion

                #region BidderInfo
                XmlNode BINode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/BidderInfo");
                if (BINode != null)
                {
                    bidderInfo = XAttrConvert<BidderInfo>.Model(BINode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 投标信息表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    bidderInfo.ConstructionProjectId = constructionProject.Id;
                    bidderInfo.SortNum = 1;
                }
                #endregion

                #region TotalCosts 树形节点，暂定为2级;AttrInfo 树形节点，暂定为2级;AddiInfo 树形节点，暂定为2级

                XmlNode AttrInfosNode1 = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/AttrInfo");
                var attrInfoList1 = GetTreeNodes<AttrInfoItem>(constructionProject.Id, AttrInfosNode1, constructionProject.Id, ref errMessageTemp);
                if (attrInfoList1 != null)
                {
                    if (errMessageTemp != "")
                        errMessageList += "❑ 工程特征信息表中字段格式不正确；\n";
                    _lrAttrInfoItem.AddRange(attrInfoList1);
                }

                XmlNode AddInfosNode1 = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/AddiInfo");
                var addInfoList1 = GetTreeNodes<AddiInfoItem>(constructionProject.Id, AddInfosNode1, constructionProject.Id, ref errMessageTemp);
                if (addInfoList1 != null)
                {
                    if (errMessageTemp != "")
                        errMessageList += "❑ 补充信息表中字段格式不正确；\n";
                    _lrAddiInfoItem.AddRange(addInfoList1);
                }

                #endregion

                #region SummaryOfCost 费用汇总表
                XmlNode SOCNode = xmlFile.SelectSingleNode("/ConstructionProject/SummaryOfCost");
                if (SOCNode != null)
                {
                    summaryOfCost = XAttrConvert<SummaryOfCost>.Model(SOCNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 费用汇总表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    summaryOfCost.Id = Guid.NewGuid();
                    summaryOfCost.ProjectId = constructionProject.Id;
                    summaryOfCost.MainProjectId = constructionProject.Id;
                }
                XmlNode AddiInfosNode1 = xmlFile.SelectSingleNode("/ConstructionProject/SummaryOfCost/AddiInfo");
                var addiInfoList1 = GetTreeNodes<AddiInfoItem>(constructionProject.Id, AddInfosNode1, constructionProject.Id, ref errMessageTemp);
                if (addInfoList1 != null)
                {
                    if (errMessageTemp != "")
                        errMessageList += "❑ 补充信息表中字段格式不正确；\n";
                    _lrAddiInfoItem.AddRange(addInfoList1);
                }
                #endregion

                #region  ConstructionProject-ConstructionSummary 费用组成
                XmlNode constructionSummaryNodes = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionSummary");
                if (constructionSummaryNodes != null)
                {
                    constructionSummary = XAttrConvert<ConstructionSummary>.Model(constructionSummaryNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 费用组成表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    constructionSummary.ConstructionProjectsId = constructionProject.Id;
                    constructionSummary.Id = Guid.NewGuid();


                }
                #endregion

                #region ConstructionCost 费用组成-工程费用

                XmlNode ConstructionCostNodes = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionSummary/ConstructionCost");

                if (ConstructionCostNodes != null)
                {
                    constructionCost = XAttrConvert<ConstructionCost>.Model(ConstructionCostNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ " + constructionCost.Name + "工程费用表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    constructionCost.Id = Guid.NewGuid();
                    constructionCost.ConstructionProjectId = constructionProject.Id;
                    constructionCost.ConstructionSummaryId = constructionSummary.Id;

                    if (ConstructionCostNodes.ChildNodes.Count > 0)
                    {
                        int sortP = 1;
                        int sortE = 1;
                        foreach (XmlNode node in ConstructionCostNodes.ChildNodes)
                        {
                            switch (node.Name.ToLower())
                            {
                                case "projectinstallationworkcost":
                                    var projectInstallationWorkCostModel = XAttrConvert<ProjectInstallationWorkCost>.Model(node.Attributes, ref errMessageTemp);
                                    if (projectInstallationWorkCostModel != null)
                                    {
                                        if (errMessageTemp != "")
                                        {
                                            errMessageList += "❑ " + projectInstallationWorkCostModel.Name + "建筑安装工程费表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        }
                                        projectInstallationWorkCostModel.Id = Guid.NewGuid();
                                        projectInstallationWorkCostModel.ConstructionCost = constructionCost.Id;
                                        projectInstallationWorkCostModel.ConstructionSummaryId = constructionSummary.Id;
                                        projectInstallationWorkCostModel.SortNum = sortP;
                                        _lrProjectInstallationWorkCost.Add(projectInstallationWorkCostModel);
                                        ProjectInstallationWorkCostConvert(node, projectInstallationWorkCostModel.Id, constructionProject.Id, Convert.ToInt32(constructionProject.ValuationMethod), ref errMessageTemp);//检查子节点
                                        if (errMessageTemp != "")
                                            errMessageList += errMessageTemp;
                                        sortP++;
                                    }
                                    break;
                                case "equipmentprocurementcost":
                                    {
                                        var ecostsumModel = XAttrConvert<EquipmentProcurementCost>.Model(node.Attributes, ref errMessageTemp);
                                        if (errMessageTemp != "")
                                        {
                                            errMessageList += "❑ " + ecostsumModel.Name + "设备及工器具购置费表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        }
                                        ecostsumModel.ConstructionCost = constructionCost.Id;
                                        ecostsumModel.ConstructionSummaryId = constructionSummary.Id;
                                        ecostsumModel.Id = Guid.NewGuid();
                                        ecostsumModel.SortNum = sortE;
                                        _lrEquipmentProcurementCost.Add(ecostsumModel);
                                        if (node.ChildNodes.Count > 0)
                                        {
                                            _lrEquipmentProcurementCostItem = new List<EquipmentProcurementCostItem>(node.ChildNodes.Count);
                                            int sortETwo = 1;
                                            foreach (XmlNode node1 in node.ChildNodes)
                                            {
                                                EquipmentProcurementCostItem item = XAttrConvert<EquipmentProcurementCostItem>.Model(node1.Attributes, ref errMessageTemp);
                                                if (errMessageTemp != "")
                                                {
                                                    errMessageList += "❑ " + item.Name + "设备及工器具购置费明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                }
                                                item.EquipmentId = ecostsumModel.Id;
                                                item.Id = Guid.NewGuid();
                                                item.SortNum = sortETwo;
                                                _lrEquipmentProcurementCostItem.Add(item);
                                                sortETwo++;
                                                if (node1.ChildNodes.Count > 0 /*&& node1.FirstChild.ChildNodes.Count > 0*/)
                                                {
                                                    int sortEThree = 1;
                                                    foreach (XmlNode node3 in node1.ChildNodes)
                                                    {
                                                        UnitPriceCalculationOfItem chargeitem = XAttrConvert<UnitPriceCalculationOfItem>.Model(node3.Attributes, ref errMessageTemp);
                                                        if (errMessageTemp != "")
                                                        {
                                                            errMessageList += "❑ " + chargeitem.Name + "子目单价计算表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                        }
                                                        chargeitem.CItemFatherId = item.Id;
                                                        chargeitem.MainProjectId = constructionProject.Id;
                                                        chargeitem.SortNum = sortEThree;
                                                        _lrUnitPriceCalculationOfItem.Add(chargeitem);
                                                        sortEThree++;
                                                    }
                                                }
                                            }
                                        }
                                        sortE++;
                                        break;
                                    }
                                case "othercost":
                                    {
                                        var list = GetTreeNodes<OtherCost>(constructionProject.Id, node, constructionCost.Id, ref errMessageTemp, "ConstructionCostId");
                                        if (list != null)
                                        {
                                            if (errMessageTemp != "")
                                            {
                                                errMessageList += "❑ 扩展项表中字段格式不正确；\n";
                                            }
                                            _lrOtherCost.AddRange(list);
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
                #endregion

                #region  FundraisingFee 穿透2级,SpecifyCostSum 穿透2级 =资金筹措费
                XmlNode fundraiserNodes = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionSummary/FundraisingFee");
                if (fundraiserNodes != null)
                {
                    fundraisingFee = XAttrConvert<FundraisingFee>.Model(fundraiserNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ 资金筹措费表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    fundraisingFee.ConstructionProjectsId = constructionProject.Id;
                    fundraisingFee.ConstructionSummaryId = constructionSummary.Id;
                    fundraisingFee.Id = Guid.NewGuid();
                    GroupItemConvert<FundraisingFeeGroup, FundraisingFeeItem>(ref _lrFundraisingFeeGroup, ref _lrFundraisingFeeItem, constructionProject.Id,
                        fundraiserNodes, fundraisingFee.Id, "FundraisingFeeGroupId", ref errMessageTemp, "FundraisingFeeId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "❑ 资金筹措费汇总及成员表中字段格式不正确；\n" + errMessageTemp + "\n";

                }
                #endregion

                #region ContingencyFee 穿透2级,SCSModel1 穿透2级,SCSModel2 穿透2级,SCSModel3 穿透2级   预备费
                XmlNode CFNodes = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionSummary/ContingencyFee");
                if (CFNodes != null)
                {
                    contingencyFee = XAttrConvert<ContingencyFee>.Model(CFNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ " + contingencyFee.Name + "预备费表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    contingencyFee.ConstructionProjectsId = constructionProject.Id;
                    contingencyFee.ConstructionSummaryId = constructionSummary.Id;
                    contingencyFee.Id = Guid.NewGuid();
                    GroupItemConvert<ContingencyFeeGroup, ContingencyFeeItem>(ref _lrContingencyFeeGroup, ref _lrContingencyFeeItem, constructionProject.Id,
                        CFNodes, contingencyFee.Id, "ContingencyFeeGroupId", ref errMessageTemp, "ContingencyFeeId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "❑ 预备费汇总及成员表中字段格式不正确；\n" + errMessageTemp + "\n";

                }
                #endregion

                #region OtherInvestmentOfConstructionProject 穿透2级,SCSModel1 穿透2级,SCSModel2 穿透2级,SCSModel3 穿透2级   工程建设及其他费
                XmlNode OOCPNodes = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionSummary/OtherInvestmentOfConstructionProject");
                if (CFNodes != null)
                {
                    otherInvestmentOfConstructionProject = XAttrConvert<OtherInvestmentOfConstructionProject>.Model(OOCPNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ " + contingencyFee.Name + "工程建设及其他费表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    otherInvestmentOfConstructionProject.ConstructionProjectsId = constructionProject.Id;
                    otherInvestmentOfConstructionProject.ConstructionSummaryId = constructionSummary.Id;
                    otherInvestmentOfConstructionProject.Id = Guid.NewGuid();
                    GroupItemConvert<OtherInvestmentOfConstructionProjectGroup, OtherInvestmentOfConstructionProjectItem>(ref _lrOtherInvestmentOfConstructionProjectGroup, ref _lrOtherInvestmentOfConstructionProjectItem, constructionProject.Id,
                        OOCPNodes, contingencyFee.Id, "OtherInvestmentOfConstructionProjectGroupId", ref errMessageTemp, "OtherInvestmentOfConstructionProjectId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "❑ 工程建设及其他费汇总及成员表中字段格式不正确；\n" + errMessageTemp + "\n";

                }
                #endregion

                #region WorkingCapital 穿透2级,SCSModel1 穿透2级,SCSModel2 穿透2级,SCSModel3 穿透2级 流动资金
                //XmlNode IDCRNodes = xmlFile.SelectSingleNode("/ConstructionProject/InterestDuringConstructionPeriod");
                //if (IDCRNodes != null)
                //{
                //    SCSModel1 = XAttrConvert<SpecifyCostSum>.Model(IDCRNodes.Attributes, ref errMessageTemp);
                //    if (errMessageTemp != "")
                //        errMessageList += "❑ " + SCSModel1.Name + "建设期贷款利息表中字段格式不正确；\n" +errMessageTemp + "\n";

                //    SCSModel1.ConstructionProjectsId = CProjectModel.Id;
                //    SCSModel1.Id = Guid.NewGuid();
                //    SCSModel1.Type = 1;
                //    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList1, ref statutoryFeesItemList1, CProjectModel.Id,
                //        IDCRNodes, SCSModel1.Id, "SCS_SCG_Id", ref errMessageTemp, "SpecifyCostSumId", 2);
                //    if (errMessageTemp != "")
                //        errMessageList += "❑ 建设期贷款利息表中字段格式不正确；\n" +errMessageTemp + "\n";
                //}

                XmlNode IWCNodes = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionSummary/WorkingCapital");
                if (IWCNodes != null)
                {
                    workingCapital = XAttrConvert<WorkingCapital>.Model(IWCNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "❑ " + workingCapital.Name + "流动资金表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    workingCapital.ConstructionProjectsId = constructionProject.Id;
                    workingCapital.ConstructionSummaryId = constructionSummary.Id;
                    workingCapital.Id = Guid.NewGuid();
                    workingCapital.Type = 2;
                    GroupItemConvert<WorkingCapitalGroup, WorkingCapitalItem>(ref _lrWorkingCapitalGroup, ref _lrWorkingCapitalItem, constructionProject.Id,
                        IWCNodes, workingCapital.Id, "WorkingCapitalGroupId", ref errMessageTemp, "WorkingCapitalId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "❑ 流动资金汇总及成员表中字段格式不正确；\n" + errMessageTemp + "\n";
                }

                //XmlNode RTFINodes = xmlFile.SelectSingleNode("/ConstructionProject/RegulationTaxOfFixedAssetsInvestment");
                //if (RTFINodes != null)
                //{
                //    SCSModel3 = XAttrConvert<SpecifyCostSum>.Model(RTFINodes.Attributes, ref errMessageTemp);
                //    if (errMessageTemp != "")
                //    {
                //        errMessageList += "❑ " + SCSModel3.Name + "固定资产投资方向调节税表中字段格式不正确；\n" +errMessageTemp + "\n";
                //    }
                //    SCSModel3.ConstructionProjectsId = CProjectModel.Id;
                //    SCSModel3.Id = Guid.NewGuid();
                //    SCSModel3.Type = 3;
                //    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList3, ref statutoryFeesItemList3, CProjectModel.Id,
                //        RTFINodes, SCSModel3.Id, "SCS_SCG_Id", ref errMessageTemp, "SpecifyCostSumId", 2);
                //    if (errMessageTemp != "")
                //        errMessageList += "❑ 固定资产投资方向调节税表中字段格式不正确；\n" +errMessageTemp + "\n";
                //}
                #endregion

                #region 赋值
                ret.constructionProject = constructionProject;
                //=========================2 工程信息
                constructionInfo.Option = option;
                constructionInfo.ProjectInfo = projectInfo;
                constructionInfo.TendererInfo = tendererInfo;
                constructionInfo.BidderInfo = bidderInfo;
                constructionInfo.AttrInfo = new List<AttrInfo>() { new AttrInfo() { AttrInfoItem = _lrAttrInfoItem } };
                constructionInfo.AddiInfo = new List<AddiInfo>() { new AddiInfo() { AddiInfoItem = _lrAddiInfoItem } };

                ret.constructionInfo = constructionInfo;
                ret.systemInfo = systemInfo;
                ret.option = option;
                ret.projectInfo = projectInfo;
                ret.tendererInfo = tendererInfo;
                ret.bidderInfo = bidderInfo;
                //ret.attrInfos = null;
                ret.attrInfoItems = _lrAttrInfoItem;
                //ret.addiInfo = null;
                ret.addiInfoItems = _lrAddiInfoItem;

                //=========================3 费用汇总
                ret.addiCosts = _lrAddiCost;
                ret.summaryOfCost = _lrSummaryOfCost;
                //=========================4 费用组成
                ret.constructionSummary = constructionSummary;
                //=========================4.1 工程费用
                ret.constructionCost = constructionCost;
                //=========================4.1.1 建筑安装工程费
                ret.projectInstallationWorkCosts = _lrProjectInstallationWorkCost;
                //=========================4.1.2 设备及工器具购置费
                ret.equipmentProcurementCosts = _lrEquipmentProcurementCost;
                ret.equipmentProcurementCostItems = _lrEquipmentProcurementCostItem;
                ret.unitPriceCalculationOfItems = _lrUnitPriceCalculationOfItem;
                //=========================4.1.2.1 单项工程 //待补充
                ret.sectionalWorks = _lrSectionalWorks;
                ret.unitWorks = _lrUnitWorks;
                //ret.summaryOfBasicCosts = _lrSummaryOfBasicCost;

                ret.unitWorksSummarys = _lrUnitWorksSummary;
                ret.unitWorksSummaryGroups = _lrUnitWorksSummaryGroup;
                ret.unitWorksSummaryItems = _lrUnitWorksSummaryItem;
                //ret.divisionalAndElementalWorkss = _lrDivisionalAndElementalWorks;
                ret.divisionalWorkss = _lrDivisionalWorks;
                ret.expressElements = _lrExpressElement;
                ret.workContents = _lrWorkContent;
                ret.priceAnalyses = _lrPriceAnalysis;
                ret.originalPriceItems = _lrOriginalPriceItem;
                ret.priceItems = _lrPriceItem;


                //=========================4.1.2.1 措施项目 
                ret.preliminariess = _lrPreliminaries;
                ret.summaryOfBasicCosts = _lrSummaryOfBasicCost;
                ret.workElements = _lrWorkElement;
                //=========================4.1.2.1 其它项目
                ret.sundrys = _lrSundry;
                ret.sundryCostss = _lrSundryCosts;
                ret.sundryCostsGroups = _lrSundryCostsGroup;
                ret.sundryCostsItems = _lrSundryCostsItem;

                ret.preliminariess = _lrPreliminaries;
                ret.provisionalSums = _lrProvisionalSums;
                ret.provisionalSumsGroups = _lrProvisionalSumsGroup;
                ret.provisionalSumsItems = _lrProvisionalSumsItem;

                ret.specialtyProvisionalPrices = _lrSpecialtyProvisionalPrice;
                ret.specialtyProvisionalPriceGroups = _lrSpecialtyProvisionalPriceGroup;
                ret.specialtyProvisionalPriceItems = _lrSpecialtyProvisionalPriceItem;

                ret.dayWorkRates = _lrDayWorkRate;
                ret.dayWorkRateGroups = _lrDayWorkRateGroup;
                ret.dayWorkRateItems = _lrDayWorkRateItem;

                ret.mainContractorAttendances = _lrMainContractorAttendance;
                ret.mainContractorAttendanceGroups = _lrMainContractorAttendanceGroup;
                ret.mainContractorAttendanceItems = _lrMainContractorAttendanceItem;

                ret.otherContentss = _lrOtherContents;
                ret.otherContentsGroups = _lrOtherContentsGroup;
                ret.otherContentsItems = _lrOtherContentsItem;
                //=========================4.1.2.1 扩展项
                ret.otherCosts = _lrOtherCost;

                //=========================4.1.2.1 工料机汇总
                ret.labourMaterialsEquipmentsMachinesSummarys = _lrLabourMaterialsEquipmentsMachinesSummary;


                //=========================4.2 工程建设及其它费用
                ret.otherInvestmentOfConstructionProject = otherInvestmentOfConstructionProject;
                ret.otherInvestmentOfConstructionProjectGroups = _lrOtherInvestmentOfConstructionProjectGroup;
                ret.otherInvestmentOfConstructionProjectItems = _lrOtherInvestmentOfConstructionProjectItem;
                //=========================4.3 预备费
                ret.contingencyFee = contingencyFee;
                ret.contingencyFeeGroups = _lrContingencyFeeGroup;
                ret.contingencyFeeItems = _lrContingencyFeeItem;

                //=========================4.4 资金筹措费
                ret.fundraisingFee = fundraisingFee;
                ret.fundraisingFeeGroups = _lrFundraisingFeeGroup;
                ret.fundraisingFeeItems = _lrFundraisingFeeItem;
                //=========================4.5 流动资金
                ret.workingCapital = workingCapital;
                ret.workingCapitalGroups = _lrWorkingCapitalGroup;
                ret.workingCapitalItems = _lrWorkingCapitalItem;

                constructionSummary.WorkingCapital = workingCapital;
                constructionSummary.FundraisingFee = fundraisingFee;
                constructionSummary.ContingencyFee = contingencyFee;
                constructionSummary.OtherInvestmentOfConstructionProject = otherInvestmentOfConstructionProject;
                constructionSummary.ConstructionCost = constructionCost;
                ret.constructionSummary = constructionSummary;

                #endregion

                if (errMessageList != "")
                    errMessageList = "【错误提示】\n" + errMessageList + "请联系计价软件公司！\n";
                if (errDateMessageList != "")
                {
                    errMessageList = errMessageList + errDateMessageList;
                }

                ret.ExsultMessage = errMessageList;
            }
            catch (Exception ex)
            {
                ret.HidErrMessage = ex.ToString();
                ret.ExsultMessage = ex.Message.Contains("是必填字段，不能为空，请补充") ? ex.Message : "您提交的xml文件格式不符合交换标准，第一步：请您确认是否按照造价监测数据接口导出的XML文件；第二步：如果确认第一步没有问题，请联系北京建科研软件技术有限公司：400-825-113进行咨询。";
            }
            XB.Framework.Common.SystemLog.WriteDebugLog("AutoResolveService", Newtonsoft.Json.JsonConvert.SerializeObject(ret));
            return ret;
        }

        public AutoReeolveCollection24 EditXmlToDB(Guid projectId, System.Xml.XmlDocument xmlFile)
        {
            AutoReeolveCollection24 ret = new AutoReeolveCollection24 { ExsultMessage = "" };

            /// TODO:待完善 在AutoReeolveMethod中的EditXmlToDB方法中添加修改功能 zhangxiaobin 2025-9-13 10:51:49 edit

            return ret;
        }
        #endregion


        #region xml解析基础方法
        /// <summary>
        /// 解析建筑安装工程费节点下
        /// </summary>
        /// <param name="ResourceNode">Resource节点</param>
        /// <param name="ptablepk">Resource节点的父表主键</param>
        private void ProjectInstallationWorkCostConvert(XmlNode ResourceNode, Guid ptablepk, Guid mainProjectId, int valuationMethod, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (ResourceNode != null && ResourceNode.ChildNodes.Count > 0)
            {
                int num = 1;
                int sortB = 1;
                int sortGLJ = 1;
                foreach (XmlNode node in ResourceNode.ChildNodes)
                {
                    switch (node.Name.ToLower())
                    {
                        //单项工程
                        case "sectionalworks":
                            var sectionalWorksModel = XAttrConvert<SectionalWorks>.Model(node.Attributes, ref errMessageTemp);
                            if (sectionalWorksModel != null)
                            {
                                if (errMessageTemp != "")
                                {
                                    errMessage += "❑ " + sectionalWorksModel.Name + "单项工程表中字段格式不正确；\n" + errMessageTemp + "\n";
                                }
                                sectionalWorksModel.Id = Guid.NewGuid();
                                sectionalWorksModel.ProjectfeeId = ptablepk;
                                sectionalWorksModel.SortNum = num;
                                sectionalWorksModel.MainProjectId = mainProjectId;
                                //插入数据库时出错，去掉 ' 和 -- 
                                sectionalWorksModel.Name = sectionalWorksModel.Name.Replace("'", "").Replace("--", "");
                                sectionalWorksModel.Segment = sectionalWorksModel.Segment.Replace("'", "").Replace("--", "");
                                _lrSectionalWorks.Add(sectionalWorksModel);
                                SectionalWorksConvert(node, sectionalWorksModel.Id, mainProjectId, valuationMethod, sectionalWorksModel.Id, ref errMessageTemp);//检查子节点
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;
                                num++;
                            }
                            break;
                        //扩展项
                        case "othercost":
                            var list = GetTreeNodes<OtherCost>(mainProjectId, node, ptablepk, ref errMessageTemp, "ConstructionCostId");
                            if (list != null)
                            {
                                if (errMessageTemp != "")
                                {
                                    errMessage += "❑ 扩展项表中字段格式不正确；\n";
                                }
                                _lrOtherCost.AddRange(list);

                            }
                            break;
                        //措施项目费
                        case "preliminaries":
                            var listpre = GetTreeNodes<Preliminaries>(mainProjectId, node, ptablepk, ref errMessageTemp, "ConstructionCostId");
                            if (listpre != null)
                            {
                                if (errMessageTemp != "")
                                {
                                    errMessage += "❑ 措施项目费表中字段格式不正确；\n";
                                }
                                _lrPreliminaries.AddRange(listpre);
                            }
                            break;
                        //其他项目费
                        case "sundry":
                            var lrsundrys = GetTreeNodes<Sundry>(mainProjectId, node, ptablepk, ref errMessageTemp, "ConstructionCostId");
                            if (lrsundrys != null)
                            {
                                if (errMessageTemp != "")
                                {
                                    errMessage += "❑ 其他项目费表中字段格式不正确；\n";
                                }
                                _lrSundry.AddRange(lrsundrys);
                            }
                            SundryConvert(node, ptablepk, mainProjectId, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;

                            break;
                        //工料机汇总
                        case "labourmaterialsequipmentsmachinessummary":
                            var labourMachinesSummarysModel = XAttrConvert<LabourMaterialsEquipmentsMachinesSummary>.Model(node.Attributes, ref errMessageTemp);
                            if (labourMachinesSummarysModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ " + labourMachinesSummarysModel.Name + "工料机汇总表中字段格式不正确；\n" + errMessageTemp + "\n";

                                ResourceConvert(node, ptablepk, mainProjectId, sortGLJ, ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;

                                sortGLJ++;
                            }
                            break;


                            ////评标主要材料
                            //case "bidevaluationmainmaterial":
                            //    var bidEvaluationMainMaterialModel = XAttrConvert<BidEvaluationMainMaterial>.Model(node.Attributes, ref errMessageTemp);
                            //    if (bidEvaluationMainMaterialModel != null)
                            //    {
                            //        if (errMessageTemp != "")
                            //            errMessage += "❑ " + bidEvaluationMainMaterialModel.Name + "评标主要材料表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //        bidEvaluationMainMaterialModel.Id = Guid.NewGuid();
                            //        bidEvaluationMainMaterialModel.ProjectId = ptablepk;
                            //        bidEvaluationMainMaterialModel.MainProjectId = mainProjectId;
                            //        bidEvaluationMainMaterialModel.SortNum = sortB;
                            //        BEMMList.Add(bidEvaluationMainMaterialModel);
                            //        sortB++;
                            //    }
                            //    break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析单项工程节点下
        /// </summary>
        /// <param name="ResourceNode">Resource节点</param>
        /// <param name="ptablepk">Resource节点的父表主键</param>
        private void SectionalWorksConvert(XmlNode ResourceNode, Guid ptablepk, Guid mainProjectId, int valuationMethod, Guid swId, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (ResourceNode != null && ResourceNode.ChildNodes.Count > 0)
            {
                int num = 1;
                int sortSC = 1;
                int sortSW = 1;
                foreach (XmlNode node in ResourceNode.ChildNodes)
                {
                    switch (node.Name.ToLower())
                    {
                        //费用汇总
                        case "summaryofcost":
                            var SOCModel = XAttrConvert<SummaryOfCost>.Model(node.Attributes, ref errMessageTemp);
                            if (SOCModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ " + "费用汇总表中字段格式不正确；\n" + errMessageTemp + "\n";
                                SOCModel.Id = Guid.NewGuid();
                                SOCModel.ProjectId = ptablepk;
                                SOCModel.MainProjectId = mainProjectId;
                                SOCModel.SortNum = sortSC;
                                _lrSummaryOfCost.Add(SOCModel);
                                sortSC++;
                                if (node.ChildNodes != null && node.ChildNodes.Count > 0)
                                {
                                    //---AddiInfoItem 补充费用
                                    var addiCosts = GetTreeNodes<AddiCost>(mainProjectId, node, mainProjectId, ref errMessageTemp);
                                    if (addiCosts != null)
                                    {
                                        if (errMessageTemp != "")
                                            errMessage += "❑ 补充费用表中字段格式不正确；\n";
                                        _lrAddiCost.AddRange(addiCosts);
                                    }
                                }
                            }
                            break;
                        //单项工程
                        case "sectionalworks":
                            var sectionalWorksModel = XAttrConvert<SectionalWorks>.Model(node.Attributes, ref errMessageTemp);
                            if (sectionalWorksModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ " + sectionalWorksModel.Name + "单项工程表中字段格式不正确；\n" + errMessageTemp + "\n";
                                sectionalWorksModel.Id = Guid.NewGuid();
                                sectionalWorksModel.ProjectfeeId = ptablepk;
                                sectionalWorksModel.SortNum = sortSW;
                                sectionalWorksModel.MainProjectId = mainProjectId;
                                //插入数据库时出错，去掉 ' 和 -- 
                                sectionalWorksModel.Name = sectionalWorksModel.Name.Replace("'", "").Replace("--", "");
                                sectionalWorksModel.Segment = sectionalWorksModel.Segment.Replace("'", "").Replace("--", "");
                                _lrSectionalWorks.Add(sectionalWorksModel);
                                sortSW++;
                                SectionalWorksConvert(node, sectionalWorksModel.Id, mainProjectId, valuationMethod, swId, ref errMessageTemp);//检查子节点
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;
                            }
                            break;
                        //单位工程
                        case "unitworks":
                            var unitWorksModel = XAttrConvert<UnitWorks>.Model(node.Attributes, ref errMessageTemp);
                            if (unitWorksModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ " + unitWorksModel.Name + "单位工程表中字段格式不正确；\n" + errMessageTemp + "\n";
                                unitWorksModel.Id = Guid.NewGuid();
                                unitWorksModel.SortNum = num;
                                unitWorksModel.SectionalWorksId = ptablepk;
                                //插入数据库时出错，去掉 ' 和 -- 
                                unitWorksModel.Name = unitWorksModel.Name.Replace("'", "").Replace("--", "");
                                unitWorksModel.Segment = unitWorksModel.Segment.Replace("'", "").Replace("--", "");
                                _lrUnitWorks.Add(unitWorksModel);
                                num++;
                                UnitWorksConvert(node, unitWorksModel.Id, mainProjectId, valuationMethod, swId, ref errMessageTemp);//检查子节点
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;
                            }
                            break;
                        //扩展项
                        case "othercost":
                            var list = GetTreeNodes<OtherCost>(mainProjectId, node, ptablepk, ref errMessageTemp, "SectionalWorksId");
                            if (list != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 扩展项表中字段格式不正确；\n" + errMessageTemp + "\n";
                                _lrOtherCost.AddRange(list);
                            }
                            break;
                        //措施项目
                        case "LabourMaterialsEquipmentsMachinesSummary":
                            var lrLMEMS = GetTreeNodes<LabourMaterialsEquipmentsMachinesSummary>(mainProjectId, node, ptablepk, ref errMessageTemp, "SectionalWorksId");
                            if (lrLMEMS != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 工料机汇总表中字段格式不正确；\n" + errMessageTemp + "\n";
                                _lrLabourMaterialsEquipmentsMachinesSummary.AddRange(lrLMEMS);
                            }
                            break;
                        //措施项目
                        case "preliminaries":
                            PreliminariesConvert(node, ptablepk, mainProjectId, valuationMethod, swId, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            break;

                        //工程特征信息
                        case "AttrInfo":
                            var attrInfo = XAttrConvert<AttrInfo>.Model(node.Attributes, ref errMessageTemp);
                            var attrInfoList1 = GetTreeNodes<AttrInfoItem>(mainProjectId, node, mainProjectId, ref errMessageTemp);
                            if (attrInfoList1 != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 工程特征信息表中字段格式不正确；\n";
                                _lrAttrInfoItem.AddRange(attrInfoList1);
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析措施项目节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void PreliminariesConvert(XmlNode node, Guid pTablePk, Guid mainProjectId, int valuationMethod, Guid swId, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                int numDivisionalWorks = 1;
                int numWorkElement = 1;
                int sortSBC = 1;
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    switch (node1.Name.ToLower())
                    {
                        case "summaryofbasiccost":
                            {
                                var cost = XAttrConvert<SummaryOfBasicCost>.Model(node1.Attributes, ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += "❑ 合计费用表中字段格式不正确；\n" + errMessageTemp + "\n";
                                cost.Id = Guid.NewGuid();
                                cost.CostFacherId = pTablePk;
                                cost.FatherNode = "Preliminaries";
                                cost.SortNum = sortSBC;
                                cost.MainProjectId = mainProjectId;

                                _lrSummaryOfBasicCost.Add(cost);
                                sortSBC++;
                                int sortSBCTwo = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    var addiCost = XAttrConvert<AddiCost>.Model(node2.Attributes, ref errMessageTemp);
                                    if (addiCost != null)
                                    {
                                        if (errMessageTemp != "")
                                            errMessage += "❑ " + addiCost.Name + "补充费用表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        addiCost.Id = Guid.NewGuid();
                                        addiCost.CostId = cost.Id;
                                        addiCost.SortNum = sortSBCTwo;
                                        _lrAddiCost.Add(addiCost);
                                        sortSBCTwo++;
                                    }
                                }
                                break;
                            }
                        case "divisionalworks":
                            {
                                var works = XAttrConvert<DivisionalWorks>.Model(node1.Attributes, ref errMessageTemp);
                                if (works != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ " + works.Name + "分部工程表中字段格式不正确；\n" + errMessageTemp + "\n";
                                    works.Id = Guid.NewGuid();
                                    works.MainProjectId = mainProjectId;
                                    works.SortNum = numDivisionalWorks;
                                    works.DWorksFatherId = pTablePk;
                                    works.FatherNodeName = "Preliminaries";
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    works.Name = works.Name.Replace("'", "").Replace("--", "");
                                    _lrDivisionalWorks.Add(works);
                                    numDivisionalWorks++;
                                    DivisionalAndElementalWorksConvart(node1, works.Id, "divisionalworks", mainProjectId, valuationMethod, swId, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                                break;
                            }
                        case "workelement":
                            {
                                var workElement = XAttrConvert<WorkElement>.Model(node1.Attributes, ref errMessageTemp);
                                if (workElement != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ " + workElement.Name + "清单项目表中字段格式不正确；\n" + errMessageTemp + "\n";
                                    workElement.Id = Guid.NewGuid();
                                    workElement.SortNum = numWorkElement;
                                    workElement.WorksEleFatherId = pTablePk;
                                    workElement.FatherNodeName = "Preliminaries";
                                    workElement.MainProjectId = mainProjectId;
                                    workElement.SectionalWorksId = swId;
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    workElement.Name = workElement.Name.Replace("'", "").Replace("--", "");
                                    workElement.Attr = workElement.Attr.Replace("'", "").Replace("--", "");
                                    workElement.WorkContent = workElement.WorkContent.Replace("'", "").Replace("--", "");
                                    _lrWorkElement.Add(workElement);
                                    numWorkElement++;
                                    //DivisionalAndElementalWorksConvart(node1, workElement.Id, "divisionalworks", mainProjectId, valuationMethod, swId, ref errMessageTemp);
                                    WorkElementConvert(node1, workElement.Id, "WorkElement", mainProjectId, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// 解析单位工程节点下
        /// </summary>
        /// <param name="ResourceNode">Resource节点</param>
        /// <param name="ptablepk">Resource节点的父表主键</param>
        private void UnitWorksConvert(XmlNode ResourceNode, Guid ptablepk, Guid mainProjectId, int valuationMethod, Guid swId, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (ResourceNode != null && ResourceNode.ChildNodes.Count > 0)
            {
                int summaryofcostSortNum = 1;
                int unitworkssummarySortNum = 1;
                int clSortNum = 1;
                foreach (XmlNode node in ResourceNode.ChildNodes)
                {
                    switch (node.Name.ToLower())
                    {
                        //工程特征信息
                        case "attrinfo":
                            if (ResourceNode.ChildNodes.Count > 0)
                            {
                                var attrInfoList1 = GetTreeNodes<AttrInfoItem>(mainProjectId, ResourceNode, ptablepk, ref errMessageTemp, "ProjectId", 3);
                                if (attrInfoList1 != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ 工程特征信息表中字段格式不正确；\n";
                                    _lrAttrInfoItem.AddRange(attrInfoList1);
                                }
                            }
                            break;
                        //补充信息
                        case "addiinfo":
                            var addInfoList1 = GetTreeNodes<AddiInfoItem>(mainProjectId, node, ptablepk, ref errMessageTemp);
                            if (addInfoList1 != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 补充信息表中字段格式不正确；\n";
                                _lrAddiInfoItem.AddRange(addInfoList1);
                            }
                            break;
                        //费用汇总
                        case "summaryofcost":
                            var SOCModel = XAttrConvert<SummaryOfCost>.Model(node.Attributes, ref errMessageTemp);
                            if (SOCModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 费用汇总表中字段格式不正确；\n" + errMessageTemp + "\n";
                                SOCModel.Id = Guid.NewGuid();
                                SOCModel.ProjectId = ptablepk;
                                SOCModel.MainProjectId = mainProjectId;
                                SOCModel.SortNum = summaryofcostSortNum;
                                _lrSummaryOfCost.Add(SOCModel);
                                summaryofcostSortNum++;
                            }
                            break;
                        //单位工程费用汇总
                        case "unitworkssummary":
                            var unitWorksSummaryModel = XAttrConvert<UnitWorksSummary>.Model(node.Attributes, ref errMessageTemp);
                            if (unitWorksSummaryModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 费用汇总表中字段格式不正确；\n" + errMessageTemp + "\n";
                                unitWorksSummaryModel.Id = Guid.NewGuid();
                                unitWorksSummaryModel.ProjectId = ptablepk;
                                unitWorksSummaryModel.MainProjectId = mainProjectId;
                                unitWorksSummaryModel.SortNum = unitworkssummarySortNum;
                                _lrUnitWorksSummary.Add(unitWorksSummaryModel);
                                unitworkssummarySortNum++;
                                if (node.ChildNodes.Count > 0)
                                {
                                    SummaryItemConvert(node, ptablepk, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                            }

                            break;
                        //分部分项工程
                        case "divisionalandelementalworks":
                            DivisionalAndElementalWorksConvart(node, ptablepk, "divisionalandelementalworks", mainProjectId, valuationMethod, swId, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            break;
                        ////措施项目
                        //case "preliminaries":
                        //    PreliminariesConvert(node, ptablepk, mainProjectId, valuationMethod, swId, ref errMessageTemp);
                        //    if (errMessageTemp != "")
                        //        errMessage += errMessageTemp;
                        //    break;
                        ////其他项目
                        //case "sundry":
                        //    SundryConvert(node, ptablepk, mainProjectId, ref errMessageTemp);
                        //    if (errMessageTemp != "")
                        //        errMessage += errMessageTemp;
                        //    break;
                        ////规费
                        //case "statutoryfees":
                        //    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList, ref statutoryFeesItemList, mainProjectId,
                        //        node, ptablepk, "SFG_UW_Id", ref errMessageTemp);
                        //    if (errMessageTemp != "")
                        //        errMessage += "❑ 规费表中字段格式不正确；\n" +errMessageTemp + "\n";
                        //    break;
                        ////税金/增值税销项税额
                        //case "tax":
                        //    GroupItemConvert<TaxGroup, TaxItem>(ref taxGroupList, ref taxItemList, mainProjectId, node, ptablepk, "TG_UW_Id", ref errMessageTemp);
                        //    if (errMessageTemp != "")
                        //        errMessage += "❑ 税金/增值税销项税额表中字段格式不正确；\n" +errMessageTemp + "\n";
                        //    break;
                        //工料机汇总
                        case "labourmaterialsequipmentsmachinessummary":
                            ResourceConvert(node, ptablepk, mainProjectId, clSortNum, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            clSortNum++;
                            break;
                            ////评标主要材料
                            //case "bidevaluationmainmaterial":
                            //    if (node != null && node.ChildNodes.Count > 0)
                            //    {
                            //        int bmSortNum = 1;
                            //        foreach (XmlNode node1 in node.ChildNodes)
                            //        {
                            //            BidEvaluationMainMaterial item = XAttrConvert<BidEvaluationMainMaterial>.Model(node1.Attributes, ref errMessageTemp);
                            //            if (item != null)
                            //            {
                            //                if (errMessageTemp != "")
                            //                    errMessage += "❑ 评标主要材料表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //                item.ProjectId = ptablepk;
                            //                item.MainProjectId = mainProjectId;
                            //                item.SortNum = bmSortNum;
                            //                BEMMList.Add(item);
                            //                bmSortNum++;
                            //            }
                            //        }
                            //    }
                            //    break;
                    }
                }
            }
        }

        private void SummaryItemConvert(XmlNode node, Guid pTablePk, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                int numSummaryItem = 1;
                int numSummaryGroup = 1;
                foreach (XmlNode node2 in node.ChildNodes)
                {

                    if (node2.Name.ToLower() == "unitworkssummaryitem")
                    {
                        var item = XAttrConvert<UnitWorksSummaryItem>.Model(node2.Attributes, ref errMessageTemp);
                        if (item != null)
                        {
                            if (errMessageTemp != "")
                                errMessage += "❑ 单位工程费用汇总明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                            item.Id = Guid.NewGuid();
                            item.SortNum = numSummaryItem;
                            item.UnitWorksId = pTablePk;
                            _lrUnitWorksSummaryItem.Add(item);

                            numSummaryItem++;
                        }
                    }
                    if (node2.Name.ToLower() == "unitworkssummarygroup")
                    {
                        var item = XAttrConvert<UnitWorksSummaryGroup>.Model(node2.Attributes, ref errMessageTemp);
                        if (item != null)
                        {
                            if (errMessageTemp != "")
                                errMessage += "❑ 单位工程费用汇总标题表中字段格式不正确；\n" + errMessageTemp + "\n";
                            item.Id = Guid.NewGuid();
                            item.SortNum = numSummaryGroup;
                            item.UnitWorksId = pTablePk;
                            _lrUnitWorksSummaryGroup.Add(item);
                            SummaryItemConvert(node2, item.Id, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            numSummaryGroup++;
                        }
                    }
                }
            }
        }

        private void SundryGroupConvert(XmlNode node, Guid pTablePk, Guid mainProjectId, int pSortNum, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                var group1 = XAttrConvert<SundryCostsGroup>.Model(node.Attributes, ref errMessageTemp);
                if (group1 != null)
                {
                    if (errMessageTemp != "")
                        errMessage += "❑ " + group1.Name + "其他项目费标题表中字段格式不正确；\n" + errMessageTemp + "\n";
                    group1.Id = Guid.NewGuid();
                    group1.UnitWorksId = pTablePk;
                    group1.MainProjectId = mainProjectId;
                    group1.SortNum = pSortNum;
                    _lrSundryCostsGroup.Add(group1);
                    pSortNum++;
                    int numSundryCostsItem = 1;
                    int numSundrycostsgroup = 1;
                    foreach (XmlNode node2 in node.ChildNodes)
                    {
                        if (node2.Name.ToLower() == "sundrycostsitem")
                        {
                            var item = XAttrConvert<SundryCostsItem>.Model(node2.Attributes, ref errMessageTemp);
                            if (item != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ " + item.Name + "其他项目费明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                item.Id = Guid.NewGuid();
                                item.SortNum = numSundryCostsItem;
                                item.SundryCostsGroupId = group1.Id;
                                _lrSundryCostsItem.Add(item);
                                numSundryCostsItem++;
                            }
                        }
                        if (node2.Name.ToLower() == "sundrycostsgroup")
                        {
                            SundryGroupConvert(node2, group1.Id, mainProjectId, numSundrycostsgroup, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            numSundrycostsgroup++;
                        }
                    }
                }
            }
            else
            {
                var group1 = XAttrConvert<SundryCostsGroup>.Model(node.Attributes, ref errMessageTemp);
                if (group1 != null)
                {
                    if (errMessageTemp != "")
                        errMessage += "❑ " + group1.Name + "其他项目费标题表中字段格式不正确；\n" + errMessageTemp + "\n";
                    group1.Id = Guid.NewGuid();
                    group1.UnitWorksId = pTablePk;
                    group1.MainProjectId = mainProjectId;
                    _lrSundryCostsGroup.Add(group1);
                }
            }
        }

        /// <summary>
        /// 解析其他项目节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void SundryConvert(XmlNode node, Guid pTablePk, Guid mainProjectId, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                int sundrycostsSortNum = 1;
                int provisionalsumsSortNum = 1;
                int provisionalmaterialSortNum = 1;
                int specialtyprovisionalpriceSortNum = 1;
                int dayworkrateSortNum = 1;
                int maincontractorattendanceSortNum = 1;
                int claimscostSortNum = 1;
                int siteinstructioncostSortNum = 1;
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    switch (node1.Name.ToLower())
                    {
                        //其他项目费
                        case "sundrycosts":
                            var sundrycosts = XAttrConvert<SundryCosts>.Model(node1.Attributes, ref errMessageTemp);
                            if (sundrycosts != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 其他项目费表中字段格式不正确；\n" + errMessageTemp + "\n";
                                sundrycosts.Id = Guid.NewGuid();
                                sundrycosts.UnitWorksId = pTablePk;
                                sundrycosts.MainProjectId = mainProjectId;
                                _lrSundryCosts.Add(sundrycosts);
                                if (node1.ChildNodes != null && node1.ChildNodes.Count > 0)
                                {
                                    foreach (XmlNode node1_1 in node1.ChildNodes)
                                    {
                                        var group = XAttrConvert<SundryCostsGroup>.Model(node1_1.Attributes, ref errMessageTemp);
                                        if (group != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ " + group.Name + "其他项目费表中字段格式不正确；\n" + errMessageTemp + "\n";
                                            group.Id = Guid.NewGuid();
                                            group.UnitWorksId = pTablePk;
                                            group.MainProjectId = mainProjectId;
                                            group.SortNum = sundrycostsSortNum;
                                            _lrSundryCostsGroup.Add(group);
                                            sundrycostsSortNum++;
                                            int numSundryCostsItem = 1;
                                            int numSundrycostsgroup = 1;
                                            foreach (XmlNode node2 in node1_1.ChildNodes)
                                            {
                                                if (node2.Name.ToLower() == "sundrycostsitem")
                                                {
                                                    var item = XAttrConvert<SundryCostsItem>.Model(node2.Attributes, ref errMessageTemp);
                                                    if (item != null)
                                                    {
                                                        if (errMessageTemp != "")
                                                            errMessage += "❑ " + item.Name + "其他项目费明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                        item.Id = Guid.NewGuid();
                                                        item.SortNum = numSundryCostsItem;
                                                        item.SundryCostsGroupId = group.Id;
                                                        _lrSundryCostsItem.Add(item);
                                                        numSundryCostsItem++;
                                                    }
                                                }
                                                if (node2.Name.ToLower() == "sundrycostsgroup")
                                                {
                                                    SundryGroupConvert(node2, group.Id, mainProjectId, numSundrycostsgroup, ref errMessageTemp);
                                                    if (errMessageTemp != "")
                                                        errMessage += errMessageTemp;
                                                    numSundrycostsgroup++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        //暂列金额
                        case "provisionalsums":
                            var provisionalsums = XAttrConvert<ProvisionalSums>.Model(node1.Attributes, ref errMessageTemp);
                            if (provisionalsums != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 暂列金额表中字段格式不正确；\n" + errMessageTemp + "\n";
                                provisionalsums.Id = Guid.NewGuid();
                                provisionalsums.UnitWorksId = pTablePk;
                                provisionalsums.MainProjectId = mainProjectId;
                                _lrProvisionalSums.Add(provisionalsums);

                                if (node1.ChildNodes != null && node1.ChildNodes.Count > 0)
                                {
                                    foreach (XmlNode node1_1 in node1.ChildNodes)
                                    {

                                        var pgroup = XAttrConvert<ProvisionalSumsGroup>.Model(node1_1.Attributes, ref errMessageTemp);
                                        if (pgroup != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ " + pgroup.Name + "暂列金额表中字段格式不正确；\n" + errMessageTemp + "\n";
                                            pgroup.Id = Guid.NewGuid();
                                            pgroup.UnitWorksId = pTablePk;
                                            pgroup.SortNum = provisionalsumsSortNum;
                                            pgroup.MainProjectId = mainProjectId;
                                            _lrProvisionalSumsGroup.Add(pgroup);
                                            provisionalsumsSortNum++;
                                            int itemSortNum = 1;
                                            foreach (XmlNode node2 in node1_1.ChildNodes)
                                            {
                                                if (node2.Name.ToLower() == "provisionalsumsitem")
                                                {
                                                    var item = XAttrConvert<ProvisionalSumsItem>.Model(node2.Attributes, ref errMessageTemp);
                                                    if (item != null)
                                                    {
                                                        if (errMessageTemp != "")
                                                            errMessage += "❑ " + pgroup.Name + "暂列金额明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                        item.Id = Guid.NewGuid();
                                                        item.ProvisionalGroupId = pgroup.Id;
                                                        item.MainProjectId = mainProjectId;
                                                        item.SortNum = itemSortNum;
                                                        _lrProvisionalSumsItem.Add(item);
                                                        itemSortNum++;
                                                    }
                                                }
                                            }
                                            GroupItemConvert<ProvisionalSumsGroup, ProvisionalSumsItem>(ref _lrProvisionalSumsGroup, ref _lrProvisionalSumsItem, mainProjectId,
                                                node1, pgroup.Id, "ProvisionalGroupId", ref errMessageTemp);
                                            if (errMessageTemp != "")
                                                errMessage += "❑ 暂列金额表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        }
                                    }
                                }
                            }
                            break;
                        //暂估价材料
                        //case "provisionalmaterial":
                        //    var pmgroup = XAttrConvert<ProvisionalMaterialGroup>.Model(node1.Attributes, ref errMessageTemp);
                        //    if (pmgroup != null)
                        //    {
                        //        if (errMessageTemp != "")
                        //            errMessage += "❑ " + pmgroup.Name + "暂估价材料表中字段格式不正确；\n" +errMessageTemp + "\n";
                        //        pmgroup.Id = Guid.NewGuid();
                        //        pmgroup.UnitWorksId = pTablePk;
                        //        pmgroup.SortNum = provisionalmaterialSortNum;
                        //        pmgroup.MainProjectId = mainProjectId;
                        //        provisionalMaterialGroupList.Add(pmgroup);
                        //        provisionalmaterialSortNum++;
                        //        int itemSortNum = 1;
                        //        foreach (XmlNode node2 in node1.ChildNodes)
                        //        {
                        //            if (node2.Name.ToLower() == "provisionalmaterialitem")
                        //            {
                        //                var item = XAttrConvert<ProvisionalMaterialItem>.Model(node2.Attributes, ref errMessageTemp);
                        //                if (item != null)
                        //                {
                        //                    if (errMessageTemp != "")
                        //                        errMessage += "❑ " + pmgroup.Name + "暂估价材料明细表中字段格式不正确；\n" +errMessageTemp + "\n";
                        //                    item.Id = Guid.NewGuid();
                        //                    item.ProvisionalMaterialGroupId = pmgroup.Id;
                        //                    item.MainProjectId = mainProjectId;
                        //                    item.SortNum = itemSortNum;
                        //                    provisionalMaterialItemList.Add(item);
                        //                    itemSortNum++;
                        //                }
                        //            }
                        //        }
                        //        GroupItemConvert<ProvisionalMaterialGroup, ProvisionalMaterialItem>(ref provisionalMaterialGroupList, ref provisionalMaterialItemList, mainProjectId,
                        //            node1, pmgroup.Id, "ProvisionalMaterialGroupId", ref errMessageTemp);
                        //        if (errMessageTemp != "")
                        //            errMessage += "❑ 暂估价材料表中字段格式不正确；\n" +errMessageTemp + "\n";
                        //    }
                        //    break;
                        //专业工程暂估价
                        case "specialtyprovisionalprice":
                            var specialtyprovisionalprice = XAttrConvert<SpecialtyProvisionalPrice>.Model(node1.Attributes, ref errMessageTemp);
                            if (specialtyprovisionalprice != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 专业工程暂估价表中字段格式不正确；\n" + errMessageTemp + "\n";
                                specialtyprovisionalprice.Id = Guid.NewGuid();
                                specialtyprovisionalprice.UnitWorksId = pTablePk;
                                specialtyprovisionalprice.MainProjectId = mainProjectId;
                                _lrSpecialtyProvisionalPrice.Add(specialtyprovisionalprice);

                                if (node1.ChildNodes != null && node1.ChildNodes.Count > 0)
                                {
                                    foreach (XmlNode node1_1 in node1.ChildNodes)
                                    {
                                        var sppgroup = XAttrConvert<SpecialtyProvisionalPriceGroup>.Model(node1_1.Attributes, ref errMessageTemp);
                                        if (sppgroup != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ " + sppgroup.Name + "专业工程暂估价表中字段格式不正确；\n" + errMessageTemp + "\n";
                                            sppgroup.Id = Guid.NewGuid();
                                            sppgroup.UnitWorksId = pTablePk;
                                            sppgroup.SortNum = specialtyprovisionalpriceSortNum;
                                            sppgroup.MainProjectId = mainProjectId;
                                            _lrSpecialtyProvisionalPriceGroup.Add(sppgroup);
                                            specialtyprovisionalpriceSortNum++;
                                            int itemSortNum = 1;
                                            foreach (XmlNode node2 in node1_1.ChildNodes)
                                            {
                                                if (node2.Name.ToLower() == "specialtyprovisionalpriceitem")
                                                {
                                                    var item = XAttrConvert<SpecialtyProvisionalPriceItem>.Model(node2.Attributes, ref errMessageTemp);
                                                    if (item != null)
                                                    {
                                                        if (errMessageTemp != "")
                                                            errMessage += "❑ " + item.Name + "专业工程暂估价明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                        item.Id = Guid.NewGuid();
                                                        item.SpecialtyProvisionalPriceGroupId = sppgroup.Id;
                                                        item.MainProjectId = mainProjectId;
                                                        item.SortNum = itemSortNum;
                                                        _lrSpecialtyProvisionalPriceItem.Add(item);
                                                        itemSortNum++;
                                                    }
                                                }
                                            }
                                            GroupItemConvert<SpecialtyProvisionalPriceGroup, SpecialtyProvisionalPriceItem>(ref _lrSpecialtyProvisionalPriceGroup, ref _lrSpecialtyProvisionalPriceItem, mainProjectId,
                                                node1, sppgroup.Id, "SpecialtyProvisionalPriceGroupId", ref errMessageTemp);
                                            if (errMessageTemp != "")
                                                errMessage += "❑ " + sppgroup.Name + "专业工程暂估价表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        }
                                    }
                                }
                            }
                            break;
                        //计日工
                        case "dayworkrate":
                            var dayworkRate = XAttrConvert<DayWorkRate>.Model(node1.Attributes, ref errMessageTemp);
                            if (dayworkRate != null && node1.ChildNodes != null && node1.ChildNodes.Count > 0)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 专业工程暂估价表中字段格式不正确；\n" + errMessageTemp + "\n";
                                dayworkRate.Id = Guid.NewGuid();
                                dayworkRate.UnitWorksId = pTablePk;
                                dayworkRate.MainProjectId = mainProjectId;
                                _lrDayWorkRate.Add(dayworkRate);
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "dayworkrategroup")
                                    {
                                        var dwrggroup = XAttrConvert<DayWorkRateGroup>.Model(node2.Attributes, ref errMessageTemp);
                                        if (dwrggroup != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ " + dwrggroup.Name + "计日工标题表中字段格式不正确；\n" + errMessageTemp + "\n";
                                            dwrggroup.Id = Guid.NewGuid();
                                            dwrggroup.UnitWorksId = pTablePk;
                                            dwrggroup.MainProjectId = mainProjectId;
                                            dwrggroup.SortNum = dayworkrateSortNum;
                                            _lrDayWorkRateGroup.Add(dwrggroup);
                                            dayworkrateSortNum++;
                                            int itemSortNum = 1;
                                            foreach (XmlNode node3 in node2.ChildNodes)
                                            {
                                                if (node3.Name.ToLower() == "dayworkrateitem")
                                                {
                                                    var item = XAttrConvert<DayWorkRateItem>.Model(node3.Attributes, ref errMessageTemp);
                                                    if (item != null)
                                                    {
                                                        if (errMessageTemp != "")
                                                            errMessage += "❑ " + item.Name + "计日工明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                        item.Id = Guid.NewGuid();
                                                        item.DayWorkRateGroupId = dwrggroup.Id;
                                                        item.MainProjectId = mainProjectId;
                                                        item.SortNum = itemSortNum;
                                                        _lrDayWorkRateItem.Add(item);
                                                        itemSortNum++;
                                                    }
                                                }
                                            }
                                            GroupItemConvert<DayWorkRateGroup, DayWorkRateItem>(ref _lrDayWorkRateGroup, ref _lrDayWorkRateItem, mainProjectId,
                                                node1, dwrggroup.Id, "DayWorkRateGroupId", ref errMessageTemp);
                                            if (errMessageTemp != "")
                                                errMessage += "❑ 计日工表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        }
                                    }
                                }
                            }

                            break;
                        //总承包服务费
                        case "maincontractorattendance":
                            var maincontractorattendance = XAttrConvert<MainContractorAttendance>.Model(node1.Attributes, ref errMessageTemp);
                            if (maincontractorattendance != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 总承包服务费表中字段格式不正确；\n" + errMessageTemp + "\n";
                                maincontractorattendance.Id = Guid.NewGuid();
                                maincontractorattendance.UnitWorksId = pTablePk;
                                maincontractorattendance.MainProjectId = mainProjectId;
                                _lrMainContractorAttendance.Add(maincontractorattendance);

                                if (node1.ChildNodes != null && node1.ChildNodes.Count > 0)
                                {
                                    foreach (XmlNode node1_1 in node1.ChildNodes)
                                    {
                                        var magggroup = XAttrConvert<MainContractorAttendanceGroup>.Model(node1_1.Attributes, ref errMessageTemp);
                                        if (magggroup != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ 总承包服务费标题表中字段格式不正确；\n" + errMessageTemp + "\n";
                                            magggroup.Id = Guid.NewGuid();
                                            magggroup.UnitWorksId = pTablePk;
                                            magggroup.MainProjectId = mainProjectId;
                                            magggroup.SortNum = maincontractorattendanceSortNum;
                                            _lrMainContractorAttendanceGroup.Add(magggroup);
                                            maincontractorattendanceSortNum++;
                                            int itemSortNum = 1;
                                            foreach (XmlNode node2 in node1_1.ChildNodes)
                                            {
                                                if (node2.Name.ToLower() == "maincontractorattendanceitem")
                                                {
                                                    var item = XAttrConvert<MainContractorAttendanceItem>.Model(node2.Attributes, ref errMessageTemp);
                                                    if (item != null)
                                                    {
                                                        if (errMessageTemp != "")
                                                            errMessage += "❑ 总承包服务费明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                        item.Id = Guid.NewGuid();
                                                        item.MainContractorAttendanceGroupId = magggroup.Id;
                                                        item.MainProjectId = mainProjectId;
                                                        item.SortNum = itemSortNum;
                                                        _lrMainContractorAttendanceItem.Add(item);
                                                        itemSortNum++;
                                                    }
                                                }
                                            }
                                            GroupItemConvert<MainContractorAttendanceGroup, MainContractorAttendanceItem>(ref _lrMainContractorAttendanceGroup, ref _lrMainContractorAttendanceItem, mainProjectId,
                                                node1, magggroup.Id, "MainContractorAttendanceGroupId", ref errMessageTemp);
                                            if (errMessageTemp != "")
                                                errMessage += "❑ 总承包服务费表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        }
                                    }
                                }
                            }
                            break;
                        //合同中约定的其他项目
                        case "othercontents":
                            var othercontents = XAttrConvert<OtherContents>.Model(node1.Attributes, ref errMessageTemp);
                            if (othercontents != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 合同中约定的其他项目表中字段格式不正确；\n" + errMessageTemp + "\n";
                                othercontents.Id = Guid.NewGuid();
                                othercontents.UnitWorksId = pTablePk;
                                othercontents.MainProjectId = mainProjectId;
                                _lrOtherContents.Add(othercontents);

                                if (node1.ChildNodes != null && node1.ChildNodes.Count > 0)
                                {
                                    foreach (XmlNode node1_1 in node1.ChildNodes)
                                    {
                                        var ccgroup = XAttrConvert<OtherContentsGroup>.Model(node1_1.Attributes, ref errMessageTemp);
                                        if (ccgroup != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ 合同中约定的其他项目表中字段格式不正确；\n" + errMessageTemp + "\n";
                                            ccgroup.Id = Guid.NewGuid();
                                            ccgroup.UnitWorksId = pTablePk;
                                            ccgroup.MainProjectId = mainProjectId;
                                            ccgroup.SortNum = claimscostSortNum;
                                            _lrOtherContentsGroup.Add(ccgroup);
                                            claimscostSortNum++;
                                            int itemSortNum = 1;
                                            foreach (XmlNode node2 in node1_1.ChildNodes)
                                            {
                                                if (node2.Name.ToLower() == "othercontentsitem")
                                                {
                                                    var item = XAttrConvert<OtherContentsItem>.Model(node2.Attributes, ref errMessageTemp);
                                                    if (item != null)
                                                    {
                                                        item.Id = Guid.NewGuid();
                                                        item.OtherContentsGroupId = ccgroup.Id;
                                                        item.MainProjectId = mainProjectId;
                                                        item.SortNum = itemSortNum;
                                                        _lrOtherContentsItem.Add(item);
                                                        itemSortNum++;
                                                    }
                                                }
                                            }
                                            GroupItemConvert<OtherContentsGroup, OtherContentsItem>(ref _lrOtherContentsGroup, ref _lrOtherContentsItem, mainProjectId,
                                                node1, ccgroup.Id, "OtherContentsGroupId", ref errMessageTemp);
                                            if (errMessageTemp != "")
                                                errMessage += "❑ 合同中约定的其他项目表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        }
                                    }
                                }
                            }
                            break;
                            ////索赔费用
                            //case "claimscost":
                            //    var ccgroup = XAttrConvert<ClaimsCostGroup>.Model(node1.Attributes, ref errMessageTemp);
                            //    if (ccgroup != null)
                            //    {
                            //        if (errMessageTemp != "")
                            //            errMessage += "❑ 索赔费用标题表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //        ccgroup.Id = Guid.NewGuid();
                            //        ccgroup.UnitWorksId = pTablePk;
                            //        ccgroup.MainProjectId = mainProjectId;
                            //        ccgroup.SortNum = claimscostSortNum;
                            //        claimsCostGroupList.Add(ccgroup);
                            //        claimscostSortNum++;
                            //        int itemSortNum = 1;
                            //        foreach (XmlNode node2 in node1.ChildNodes)
                            //        {
                            //            if (node2.Name.ToLower() == "claimscostitem")
                            //            {
                            //                var item = XAttrConvert<ClaimsCostItem>.Model(node2.Attributes, ref errMessageTemp);
                            //                if (item != null)
                            //                {
                            //                    item.Id = Guid.NewGuid();
                            //                    item.ClaimsCostGroupId = ccgroup.Id;
                            //                    item.MainProjectId = mainProjectId;
                            //                    item.SortNum = itemSortNum;
                            //                    claimsCostItemList.Add(item);
                            //                    itemSortNum++;
                            //                }
                            //            }
                            //        }
                            //        GroupItemConvert<ClaimsCostGroup, ClaimsCostItem>(ref claimsCostGroupList, ref claimsCostItemList, mainProjectId,
                            //            node1, ccgroup.Id, "ClaimsCostGroupId", ref errMessageTemp);
                            //        if (errMessageTemp != "")
                            //            errMessage += "❑ 索赔费用表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //    }
                            //    break;
                            ////现场签证费用
                            //case "siteinstructioncost":
                            //    var sicgroup = XAttrConvert<SiteInstructionCostGroup>.Model(node1.Attributes, ref errMessageTemp);
                            //    if (sicgroup != null)
                            //    {
                            //        if (errMessageTemp != "")
                            //            errMessage += "❑ 现场签证标题表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //        sicgroup.Id = Guid.NewGuid();
                            //        sicgroup.UnitWorksId = pTablePk;
                            //        sicgroup.MainProjectId = mainProjectId;
                            //        sicgroup.SortNum = siteinstructioncostSortNum;
                            //        siteInstructionCostGroupList.Add(sicgroup);
                            //        siteinstructioncostSortNum++;
                            //        int itemSortNum = 1;
                            //        foreach (XmlNode node2 in node1.ChildNodes)
                            //        {
                            //            if (node2.Name.ToLower() == "siteinstructioncostitem")
                            //            {
                            //                var item = XAttrConvert<SiteInstructionCostItem>.Model(node2.Attributes, ref errMessageTemp);
                            //                if (item != null)
                            //                {
                            //                    if (errMessageTemp != "")
                            //                        errMessage += "❑ 现场签证明细表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //                    item.Id = Guid.NewGuid();
                            //                    item.SiteInstructionCostGroupId = sicgroup.Id;
                            //                    item.MainProjectId = mainProjectId;
                            //                    item.SortNum = itemSortNum;
                            //                    siteInstructionCostItemList.Add(item);
                            //                    itemSortNum++;
                            //                }
                            //            }
                            //        }
                            //        GroupItemConvert<SiteInstructionCostGroup, SiteInstructionCostItem>(ref siteInstructionCostGroupList, ref siteInstructionCostItemList, mainProjectId,
                            //            node1, sicgroup.Id, "SiteInstructionCostGroupId", ref errMessageTemp);
                            //        if (errMessageTemp != "")
                            //            errMessage += "❑ 现场签证表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //    }
                            //    break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析分部分项工程节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void DivisionalAndElementalWorksConvart(XmlNode node, Guid pTablePk, string pTablePkName, Guid mainProjectId, int valuationMethod, Guid swId, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                int numDivisionalWorks = 1;
                int numWorkElement = 1;
                int numNorm = 1;
                int numCost = 1;
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    switch (node1.Name.ToLower())
                    {
                        case "summaryofbasiccost":
                            {
                                var cost = XAttrConvert<SummaryOfBasicCost>.Model(node1.Attributes, ref errMessageTemp);
                                if (cost != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ 合计费用表中字段格式不正确；\n" + errMessageTemp + "\n";

                                    cost.Id = Guid.NewGuid();
                                    cost.CostFacherId = pTablePk;
                                    cost.FatherNode = pTablePkName;
                                    cost.MainProjectId = mainProjectId;
                                    cost.SortNum = numCost;
                                    _lrSummaryOfBasicCost.Add(cost);
                                    numCost++;
                                    int childNodesCostSortNum = 1;
                                    foreach (XmlNode node2 in node1.ChildNodes)
                                    {
                                        var addiCost = XAttrConvert<AddiCost>.Model(node2.Attributes, ref errMessageTemp);
                                        if (addiCost != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ " + addiCost.Name + "补充费用表中字段格式不正确；\n" + errMessageTemp + "\n";
                                            addiCost.Id = Guid.NewGuid();
                                            addiCost.CostId = cost.Id;
                                            addiCost.SortNum = childNodesCostSortNum;
                                            _lrAddiCost.Add(addiCost);
                                            childNodesCostSortNum++;
                                        }
                                    }
                                }
                                break;
                            }
                        //分部工程
                        case "divisionalworks":
                            {
                                var works = XAttrConvert<DivisionalWorks>.Model(node1.Attributes, ref errMessageTemp);
                                if (works != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ " + works.Name + "分部工程表中字段格式不正确；\n" + errMessageTemp + "\n";
                                    works.Id = Guid.NewGuid();
                                    works.MainProjectId = mainProjectId;
                                    works.SortNum = numDivisionalWorks;
                                    works.DWorksFatherId = pTablePk;
                                    works.FatherNodeName = pTablePkName;
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    works.Name = works.Name.Replace("'", "").Replace("--", "");
                                    _lrDivisionalWorks.Add(works);
                                    numDivisionalWorks++;
                                    DivisionalWorksConvart(node1, works.Id, mainProjectId, valuationMethod, swId, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                                break;
                            }
                        //清单项目
                        case "workelement":
                            {
                                var workElement = XAttrConvert<WorkElement>.Model(node1.Attributes, ref errMessageTemp);
                                if (workElement != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ " + workElement.Name + "清单项目表中字段格式不正确；\n" + errMessageTemp + "\n";
                                    workElement.Id = Guid.NewGuid();
                                    workElement.SortNum = numWorkElement;
                                    workElement.MainProjectId = mainProjectId;
                                    workElement.SectionalWorksId = swId;
                                    workElement.WorksEleFatherId = pTablePk;
                                    workElement.FatherNodeName = pTablePkName;
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    workElement.Name = workElement.Name.Replace("'", "").Replace("--", "");
                                    workElement.Attr = workElement.Attr.Replace("'", "").Replace("--", "");
                                    workElement.WorkContent = workElement.WorkContent.Replace("'", "").Replace("--", "");
                                    _lrWorkElement.Add(workElement);
                                    numWorkElement++;
                                    WorkElementConvert(node1, workElement.Id, "WorkElement", mainProjectId, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                                break;
                            }
                            ////定额计价项目
                            //case "norm":
                            //    //判断是否为清单计价
                            //    if (valuationMethod == 2)
                            //    {
                            //        var norm = XAttrConvert<Norm>.Model(node1.Attributes, ref errMessageTemp);
                            //        if (norm != null)
                            //        {
                            //            if (errMessageTemp != "")
                            //                errMessage += "❑ " + norm.Name + "定额子目表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //            norm.Id = Guid.NewGuid();
                            //            norm.SortNum = numNorm;
                            //            norm.NormFatherId = pTablePk;
                            //            norm.FatherNodeName = pTablePkName;
                            //            norm.MainProjectId = mainProjectId;
                            //            normList.Add(norm);
                            //            numNorm++;
                            //            NormConvert(node1, norm.Id, "Norm", mainProjectId, ref errMessageTemp);
                            //            if (errMessageTemp != "")
                            //                errMessage += errMessageTemp;
                            //        }
                            //    }
                            //    break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析分部工程节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void DivisionalWorksConvart(XmlNode node, Guid pTablePk, Guid mainProjectId, int valuationMethod, Guid swId, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                int numDivisionalWorks = 1;
                int numWorkElement = 1;
                int numNorm = 1;
                int numCost = 1;
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    switch (node1.Name.ToLower())
                    {
                        case "summaryofbasiccost":
                            {
                                var cost = XAttrConvert<SummaryOfBasicCost>.Model(node1.Attributes, ref errMessageTemp);
                                if (cost != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ 合计费用表中字段格式不正确；\n" + errMessageTemp + "\n";

                                    cost.Id = Guid.NewGuid();
                                    cost.CostFacherId = pTablePk;
                                    cost.FatherNode = "DivisionalWorks";
                                    cost.MainProjectId = mainProjectId;
                                    cost.SortNum = numCost;
                                    _lrSummaryOfBasicCost.Add(cost);
                                    numCost++;
                                    int childNodesSortNum = 1;
                                    foreach (XmlNode node2 in node1.ChildNodes)
                                    {
                                        var addiCost = XAttrConvert<AddiCost>.Model(node2.Attributes, ref errMessageTemp);
                                        if (addiCost != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ " + addiCost.Name + "补充费用表中字段格式不正确；\n" + errMessageTemp + "\n";

                                            addiCost.Id = Guid.NewGuid();
                                            addiCost.CostId = cost.Id;
                                            addiCost.SortNum = childNodesSortNum;
                                            _lrAddiCost.Add(addiCost);
                                            childNodesSortNum++;
                                        }
                                    }
                                }
                                break;
                            }
                        case "divisionalworks":
                            {
                                var works = XAttrConvert<DivisionalWorks>.Model(node1.Attributes, ref errMessageTemp);
                                if (works != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ " + works.Name + "分部工程表中字段格式不正确；\n" + errMessageTemp + "\n";

                                    works.Id = Guid.NewGuid();
                                    works.MainProjectId = mainProjectId;
                                    works.SortNum = numDivisionalWorks;
                                    works.DWorksFatherId = pTablePk;
                                    works.FatherNodeName = "DivisionalWorks";
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    works.Name = works.Name.Replace("'", "").Replace("--", "");
                                    _lrDivisionalWorks.Add(works);
                                    numDivisionalWorks++;
                                    DivisionalAndElementalWorksConvart(node1, works.Id, "divisionalworks", mainProjectId, valuationMethod, swId, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                                break;
                            }
                        //清单项目
                        case "workelement":
                            {
                                if (valuationMethod == 1)
                                {
                                    var workElement = XAttrConvert<WorkElement>.Model(node1.Attributes, ref errMessageTemp);
                                    if (workElement != null)
                                    {
                                        if (errMessageTemp != "")
                                            errMessage += "❑ " + workElement.Name + "清单项目表中字段格式不正确；\n" + errMessageTemp + "\n";
                                        workElement.Id = Guid.NewGuid();
                                        workElement.MainProjectId = mainProjectId;
                                        workElement.SortNum = numWorkElement;
                                        workElement.SectionalWorksId = swId;
                                        workElement.WorksEleFatherId = pTablePk;
                                        workElement.FatherNodeName = "DivisionalWorks";
                                        //插入数据库时出错，去掉 ' 和 -- 
                                        workElement.Name = workElement.Name.Replace("'", "").Replace("--", "");
                                        workElement.Attr = workElement.Attr.Replace("'", "").Replace("--", "");
                                        workElement.WorkContent = workElement.WorkContent.Replace("'", "").Replace("--", "");
                                        _lrWorkElement.Add(workElement);
                                        numWorkElement++;
                                        WorkElementConvert(node1, workElement.Id, "WorkElement", mainProjectId, ref errMessageTemp);
                                        if (errMessageTemp != "")
                                            errMessage += errMessageTemp;
                                    }
                                }
                                break;
                            }
                            //定额计价项目
                            //case "norm":
                            //    //判断是否为清单计价
                            //    if (valuationMethod == 2)
                            //    {
                            //        var norm = XAttrConvert<Norm>.Model(node1.Attributes, ref errMessageTemp);
                            //        if (norm != null)
                            //        {
                            //            if (errMessageTemp != "")
                            //                errMessage += "❑ " + norm.Name + "定额计价项目表中字段格式不正确；\n" +errMessageTemp + "\n";
                            //            norm.Id = Guid.NewGuid();
                            //            norm.SortNum = numNorm;
                            //            norm.NormFatherId = pTablePk;
                            //            norm.FatherNodeName = "DivisionalWorks";
                            //            norm.MainProjectId = mainProjectId;
                            //            normList.Add(norm);
                            //            numNorm++;
                            //            NormConvert(node1, norm.Id, "Norm", mainProjectId, ref errMessageTemp);
                            //            if (errMessageTemp != "")
                            //                errMessage += errMessageTemp;
                            //        }
                            //    }
                            //    break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析清单项目节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void WorkElementConvert(XmlNode node, Guid pTablePk, string fatherNodeName, Guid mainProjectId, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                int numNorm = 1;
                int numCost = 1;
                int numExpresselement = 1;
                int numWorkContent = 1;
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    switch (node1.Name.ToLower())
                    {
                        //合计费用
                        case "summaryofbasiccost":
                            {
                                var cost = XAttrConvert<SummaryOfBasicCost>.Model(node1.Attributes, ref errMessageTemp);
                                if (cost != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ 合计费用表中字段格式不正确；\n" + errMessageTemp + "\n";

                                    cost.Id = Guid.NewGuid();
                                    cost.CostFacherId = pTablePk;
                                    cost.FatherNode = fatherNodeName;
                                    cost.MainProjectId = mainProjectId;
                                    cost.SortNum = numCost;
                                    _lrSummaryOfBasicCost.Add(cost);
                                    numCost++;
                                    int childNodesSortNum = 1;
                                    foreach (XmlNode node2 in node1.ChildNodes)
                                    {
                                        var addiCost = XAttrConvert<AddiCost>.Model(node2.Attributes, ref errMessageTemp);
                                        if (addiCost != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "❑ 补充费用表中字段格式不正确；\n" + errMessageTemp + "\n";
                                            addiCost.Id = Guid.NewGuid();
                                            addiCost.CostId = cost.Id;
                                            addiCost.SortNum = childNodesSortNum;
                                            _lrAddiCost.Add(addiCost);
                                            childNodesSortNum++;
                                        }
                                    }
                                }
                                break;
                            }
                        //工程量计算表
                        case "expresselement":
                            var expressElement = XAttrConvert<ExpressElement>.Model(node1.Attributes, ref errMessageTemp);
                            if (expressElement != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 工程量计算表中字段格式不正确；\n" + errMessageTemp + "\n";
                                expressElement.Id = Guid.NewGuid();
                                expressElement.ExpItemFatherId = pTablePk;
                                expressElement.FatherNodeName = fatherNodeName;
                                expressElement.MainProjectId = mainProjectId;
                                expressElement.SortNum = numExpresselement;
                                _lrExpressElement.Add(expressElement);
                                numExpresselement++;
                            }
                            break;
                        //工作内容
                        case "workcontent":
                            var workContent = XAttrConvert<WorkContent>.Model(node1.Attributes, ref errMessageTemp);
                            if (workContent != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 工作内容表中字段格式不正确；\n" + errMessageTemp + "\n";

                                workContent.Id = Guid.NewGuid();
                                workContent.WorkElementId = pTablePk;
                                workContent.MainProjectId = mainProjectId;
                                workContent.SortNum = numWorkContent;
                                _lrWorkContent.Add(workContent);
                                numWorkContent++;
                                int numNorm2 = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "workcontent")
                                    {
                                        WorkElementConvert(node2, workContent.Id, "WorkContent", mainProjectId, ref errMessageTemp);
                                        if (errMessageTemp != "")
                                            errMessage += errMessageTemp;
                                    }
                                    ////定额子目
                                    //if (node2.Name.ToLower() == "norm")
                                    //{
                                    //    var norm2 = XAttrConvert<Norm>.Model(node2.Attributes, ref errMessageTemp);
                                    //    if (norm2 != null)
                                    //    {
                                    //        if (errMessageTemp != "")
                                    //            errMessage += "❑ " + norm2.Name + "定额子目表中字段格式不正确；\n" +errMessageTemp + "\n";

                                    //        norm2.Id = Guid.NewGuid();
                                    //        norm2.MainProjectId = mainProjectId;
                                    //        norm2.SortNum = numNorm2;
                                    //        norm2.NormFatherId = pTablePk;
                                    //        norm2.FatherNodeName = fatherNodeName;
                                    //        normList.Add(norm2);
                                    //        numNorm2++;
                                    //        NormConvert(node2, workContent.Id, "norm", mainProjectId, ref errMessageTemp);
                                    //        if (errMessageTemp != "")
                                    //            errMessage += errMessageTemp;
                                    //    }
                                    //}
                                }
                            }
                            break;
                        ////定额子目
                        //case "norm":
                        //    var norm = XAttrConvert<Norm>.Model(node1.Attributes, ref errMessageTemp);
                        //    if (norm != null)
                        //    {
                        //        if (errMessageTemp != "")
                        //            errMessage += "❑ " + norm.Name + "定额子目表中字段格式不正确；\n" +errMessageTemp + "\n";

                        //        norm.Id = Guid.NewGuid();
                        //        norm.SortNum = numNorm;
                        //        norm.NormFatherId = pTablePk;
                        //        norm.FatherNodeName = fatherNodeName;
                        //        norm.MainProjectId = mainProjectId;
                        //        normList.Add(norm);
                        //        numNorm++;
                        //        NormConvert(node1, norm.Id, "Norm", mainProjectId, ref errMessageTemp);
                        //        if (errMessageTemp != "")
                        //            errMessage += errMessageTemp;
                        //    }
                        //    break;
                        //单价分析
                        case "priceanalysis":
                            var priceAnalysis = XAttrConvert<PriceAnalysis>.Model(node1.Attributes, ref errMessageTemp);
                            if (priceAnalysis != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 单价分析表中字段格式不正确；\n" + errMessageTemp + "\n";

                                priceAnalysis.Id = Guid.NewGuid();
                                priceAnalysis.WorkElementId = pTablePk;
                                priceAnalysis.MainProjectId = mainProjectId;
                                priceAnalysis.SortNum = numWorkContent;
                                _lrPriceAnalysis.Add(priceAnalysis);
                                numWorkContent++;
                                int numNorm2 = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.Equals("OriginalPriceItem", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var lrOriginalPriceItem = GetTreeNodes<OriginalPriceItem>(mainProjectId, node, mainProjectId, ref errMessageTemp, "ProjectId", 3);
                                        if (lrOriginalPriceItem != null && lrOriginalPriceItem.Count > 0)
                                        {
                                            foreach (var item in lrOriginalPriceItem)
                                            {
                                                var originalPriceItem = XAttrConvert<OriginalPriceItem>.Model(node2.Attributes, ref errMessageTemp);
                                                if (originalPriceItem != null)
                                                {
                                                    if (errMessageTemp != "")
                                                        errMessage += "❑ 调整前单价明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                    originalPriceItem.Id = Guid.NewGuid();
                                                    originalPriceItem.PriceAnalysisId = priceAnalysis.Id;
                                                    originalPriceItem.AttrId = item.Id;
                                                    originalPriceItem.AttrName = item.AttrName;
                                                    originalPriceItem.MainProjectId = mainProjectId;
                                                    originalPriceItem.SortNum = numNorm2;
                                                    _lrOriginalPriceItem.Add(originalPriceItem);
                                                    numNorm2++;
                                                }
                                            }
                                        }
                                        if (errMessageTemp != "")
                                            errMessage += errMessageTemp;
                                    }
                                    if (node2.Name.Equals("PriceItem", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var priceItems = GetTreeNodes<PriceItem>(mainProjectId, node, mainProjectId, ref errMessageTemp, "ProjectId", 3);
                                        if (priceItems != null && priceItems.Count > 0)
                                        {
                                            foreach (var item in priceItems)
                                            {
                                                var priceItem = XAttrConvert<PriceItem>.Model(node2.Attributes, ref errMessageTemp);
                                                if (priceItem != null)
                                                {
                                                    if (errMessageTemp != "")
                                                        errMessage += "❑ 单价明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                    priceItem.Id = Guid.NewGuid();
                                                    priceItem.PriceAnalysisId = priceAnalysis.Id;
                                                    priceItem.AttrId = item.Id;
                                                    priceItem.AttrName = item.AttrName;
                                                    priceItem.MainProjectId = mainProjectId;
                                                    priceItem.SortNum = numNorm2;
                                                    _lrPriceItem.Add(priceItem);
                                                    numNorm2++;
                                                }
                                            }
                                        }
                                        if (errMessageTemp != "")
                                            errMessage += errMessageTemp;
                                    }
                                    if (node2.Name.Equals("LabourMaterialsEquipmentsMachinesElement", StringComparison.OrdinalIgnoreCase))
                                    {
                                        var labourMaterialsEquipmentsMachinesElements = GetTreeNodes<LabourMaterialsEquipmentsMachinesElement>(mainProjectId, node, mainProjectId, ref errMessageTemp, "ProjectId", 3);
                                        if (labourMaterialsEquipmentsMachinesElements != null && labourMaterialsEquipmentsMachinesElements.Count > 0)
                                        {
                                            foreach (var item in labourMaterialsEquipmentsMachinesElements)
                                            {
                                                var labourMaterials = XAttrConvert<LabourMaterialsEquipmentsMachinesElement>.Model(node2.Attributes, ref errMessageTemp);
                                                if (labourMaterials != null)
                                                {
                                                    if (errMessageTemp != "")
                                                        errMessage += "❑ 工料机汇总表中字段格式不正确；\n" + errMessageTemp + "\n";
                                                    labourMaterials.Id = Guid.NewGuid();
                                                    labourMaterials.PriceAnalysisId = priceAnalysis.Id;
                                                    labourMaterials.AttrId = item.Id;
                                                    labourMaterials.AttrName = item.AttrName;
                                                    labourMaterials.MainProjectId = mainProjectId;
                                                    labourMaterials.SortNum = numNorm2;
                                                    _lrLabourMaterialsEquipmentsMachinesElement.Add(labourMaterials);
                                                    numNorm2++;
                                                }
                                            }
                                        }
                                        if (errMessageTemp != "")
                                            errMessage += errMessageTemp;
                                    }
                                    ////定额子目
                                    //if (node2.Name.ToLower() == "norm")
                                    //{
                                    //    var norm2 = XAttrConvert<Norm>.Model(node2.Attributes, ref errMessageTemp);
                                    //    if (norm2 != null)
                                    //    {
                                    //        if (errMessageTemp != "")
                                    //            errMessage += "❑ " + norm2.Name + "定额子目表中字段格式不正确；\n" +errMessageTemp + "\n";

                                    //        norm2.Id = Guid.NewGuid();
                                    //        norm2.MainProjectId = mainProjectId;
                                    //        norm2.SortNum = numNorm2;
                                    //        norm2.NormFatherId = pTablePk;
                                    //        norm2.FatherNodeName = fatherNodeName;
                                    //        normList.Add(norm2);
                                    //        numNorm2++;
                                    //        NormConvert(node2, workContent.Id, "norm", mainProjectId, ref errMessageTemp);
                                    //        if (errMessageTemp != "")
                                    //            errMessage += errMessageTemp;
                                    //    }
                                    //}
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析定额子目节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void NormConvert(XmlNode node, Guid pTablePk, string fatherNodeName, Guid mainProjectId, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                int gljSortNum = 1;
                int expresselementSortNum = 1;
                int combinednormSortNum = 1;
                int unitpricecalculationofitemSortNum = 1;
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    switch (node1.Name.ToLower())
                    {
                        //工料机含量明细
                        case "labourmaterialsequipmentsmachineselement":
                            {
                                var item2 = XAttrConvert<LabourMaterialsEquipmentsMachinesElement>.Model(node1.Attributes, ref errMessageTemp);
                                if (item2 != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "❑ 工料机含量明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                                    item2.Id = Guid.NewGuid();
                                    item2.LMEMS_ID = pTablePk;
                                    item2.SortNum = gljSortNum;
                                    _lrLabourMaterialsEquipmentsMachinesElement.Add(item2);
                                    gljSortNum++;
                                }
                                break;
                            }
                        //工程量计算表
                        case "expresselement":
                            var expressElement = XAttrConvert<ExpressElement>.Model(node1.Attributes, ref errMessageTemp);
                            if (expressElement != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 工程量计算表中字段格式不正确；\n" + errMessageTemp + "\n";
                                expressElement.Id = Guid.NewGuid();
                                expressElement.ExpItemFatherId = pTablePk;
                                expressElement.FatherNodeName = fatherNodeName;
                                expressElement.MainProjectId = mainProjectId;
                                expressElement.SortNum = expresselementSortNum;
                                _lrExpressElement.Add(expressElement);
                                expresselementSortNum++;
                            }
                            break;
                        ////组合定额
                        //case "combinednorm":
                        //    var combinedNorm = XAttrConvert<CombinedNorm>.Model(node1.Attributes, ref errMessageTemp);
                        //    if (combinedNorm != null)
                        //    {
                        //        if (errMessageTemp != "")
                        //            errMessage += "❑ 组合定额表中字段格式不正确；\n" +errMessageTemp + "\n";
                        //        combinedNorm.Id = Guid.NewGuid();
                        //        combinedNorm.NormId = pTablePk;
                        //        combinedNorm.SortNum = combinednormSortNum;
                        //        combinedNormList.Add(combinedNorm);
                        //        combinednormSortNum++;
                        //    }
                        //    break;
                        //子目单价计算
                        case "unitpricecalculationofitem":
                            var unitPriceCalculationOfItem = XAttrConvert<UnitPriceCalculationOfItem>.Model(node1.Attributes, ref errMessageTemp);
                            if (unitPriceCalculationOfItem != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "❑ 子目单价计算表中字段格式不正确；\n" + errMessageTemp + "\n";
                                unitPriceCalculationOfItem.Id = Guid.NewGuid();
                                unitPriceCalculationOfItem.CItemFatherId = pTablePk;
                                unitPriceCalculationOfItem.MainProjectId = mainProjectId;
                                unitPriceCalculationOfItem.SortNum = unitpricecalculationofitemSortNum;
                                _lrUnitPriceCalculationOfItem.Add(unitPriceCalculationOfItem);
                                unitpricecalculationofitemSortNum++;
                                //NormConvert(node1, unitPriceCalculationOfItem.Id,"");//迭代
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// SundryTable,ProvisionalSums,ProvisionalMaterial,
        /// SpecialtyAppraisals,DayWorks,MainContractorAttendance,
        /// ClaimsCosts,SiteInstructionCosts,
        /// StatutoryFees,Tax
        /// OtherCostSums,SpecifyCostSum,节点解析
        /// </summary>
        /// <typeparam name="TG">Group节点Model</typeparam>
        /// <typeparam name="TI">Item节点Model</typeparam>
        /// <param name="node">节点</param>
        /// <param name="grouppId">group的父表在group表中的Id值</param>
        /// <param name="itempIdname">Group表主键在Item表中名称</param>
        /// <param name="grouppIdname">group的父表在group表中的Id名称</param>
        /// <param name="level">节点级次</param>
        /// <param name="TGList">TG类型列表</param>
        /// <param name="TIList">TI类型列表</param>
        private void GroupItemConvert<TG, TI>(ref List<TG> TGList, ref List<TI> TIList, Guid mainProjectId, XmlNode node,
            Guid grouppId, string itempIdname, ref string errMessage, string grouppIdname = "UnitWorksId", int level = 2)
            where TG : class, new()
            where TI : class, new()
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                int sortOne = 1;
                foreach (XmlNode node1 in node.ChildNodes)
                {
                    if (node1.Name.ToLower() == typeof(TG).Name.ToLower())
                    {
                        Guid itemId = Guid.NewGuid();
                        TG item = XAttrConvert<TG>.Model(node1.Attributes, ref errMessageTemp);
                        if (errMessageTemp != "")
                            errMessage += errMessageTemp;
                        item.GetType().GetProperty(grouppIdname).SetValue(item, grouppId);
                        item.GetType().GetProperty("Id").SetValue(item, itemId);
                        //item.GetType().GetProperty("ParentId").SetValue(item, null);
                        item.GetType().GetProperty("MainProjectId").SetValue(item, mainProjectId);
                        item.GetType().GetProperty("SortNum").SetValue(item, sortOne);
                        TGList.Add(item);

                        #region 2级
                        if (node1.ChildNodes.Count > 0)
                        {
                            int sortTwo = 1;
                            foreach (XmlNode node2 in node1.ChildNodes)
                            {
                                if (node2.Name.ToLower() == typeof(TG).Name.ToLower())
                                {
                                    Guid gItem2Id = Guid.NewGuid();
                                    TG gItem2 = XAttrConvert<TG>.Model(node2.Attributes, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                    gItem2.GetType().GetProperty("UnitWorksId").SetValue(gItem2, grouppId);
                                    gItem2.GetType().GetProperty("Id").SetValue(gItem2, gItem2Id);
                                    gItem2.GetType().GetProperty("ParentId").SetValue(gItem2, itemId);
                                    gItem2.GetType().GetProperty("MainProjectId").SetValue(gItem2, mainProjectId);
                                    gItem2.GetType().GetProperty("SortNum").SetValue(item, sortTwo);
                                    TGList.Add(gItem2);
                                    #region  3级
                                    if (node2.ChildNodes.Count > 0 && level > 2)
                                    {
                                        int sortThree = 1;
                                        foreach (XmlNode node3 in node2.ChildNodes)
                                        {
                                            if (node3.Name.ToLower() == typeof(TG).Name.ToLower())
                                            {
                                                TG gItem3 = XAttrConvert<TG>.Model(node3.Attributes, ref errMessageTemp);
                                                if (errMessageTemp != "")
                                                    errMessage += errMessageTemp;
                                                gItem3.GetType().GetProperty("UnitWorksId").SetValue(gItem3, grouppId);
                                                gItem3.GetType().GetProperty("Id").SetValue(gItem3, Guid.NewGuid());
                                                gItem3.GetType().GetProperty("ParentId").SetValue(gItem3, gItem2Id);
                                                gItem3.GetType().GetProperty("MainProjectId").SetValue(gItem3, mainProjectId);
                                                gItem3.GetType().GetProperty("SortNum").SetValue(gItem3, sortThree);
                                                TGList.Add(gItem3);
                                            }
                                            else
                                            {
                                                TI Item3 = XAttrConvert<TI>.Model(node2.Attributes, ref errMessageTemp);
                                                if (errMessageTemp != "")
                                                    errMessage += errMessageTemp;
                                                Item3.GetType().GetProperty(itempIdname).SetValue(Item3, gItem2Id);
                                                Item3.GetType().GetProperty("MainProjectId").SetValue(Item3, mainProjectId);
                                                Item3.GetType().GetProperty("SortNum").SetValue(Item3, sortThree);
                                                TIList.Add(Item3);
                                            }
                                            sortThree++;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    TI Item2 = XAttrConvert<TI>.Model(node2.Attributes, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                    Item2.GetType().GetProperty(itempIdname).SetValue(Item2, itemId);
                                    Item2.GetType().GetProperty("MainProjectId").SetValue(Item2, mainProjectId);
                                    Item2.GetType().GetProperty("SortNum").SetValue(Item2, sortTwo);
                                    TIList.Add(Item2);
                                }
                                sortTwo++;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        TI Item = XAttrConvert<TI>.Model(node1.Attributes, ref errMessageTemp);
                        if (errMessageTemp != "")
                            errMessage += errMessageTemp;
                        Item.GetType().GetProperty(itempIdname).SetValue(Item, grouppId);
                        Item.GetType().GetProperty("MainProjectId").SetValue(Item, mainProjectId);
                        Item.GetType().GetProperty("SortNum").SetValue(Item, sortOne);
                        TIList.Add(Item);
                    }
                    sortOne++;
                }
            }
        }

        /// <summary>
        /// 解析Resource节点
        /// </summary>
        /// <param name="ResourceNode">Resource节点</param>
        /// <param name="ptablepk">Resource节点的父表主键</param>
        private void ResourceConvert(XmlNode ResourceNode, Guid ptablepk, Guid mainProjectId, int pSortNum, ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (ResourceNode != null)
            {
                var item = XAttrConvert<LabourMaterialsEquipmentsMachinesSummary>.Model(ResourceNode.Attributes, ref errMessageTemp);
                if (item != null)
                {
                    if (errMessageTemp != "")
                    {
                        errMessage += "❑ " + item.Name + "工料机汇总表中字段格式不正确；\n" + errMessageTemp + "\n";
                    }
                    item.Id = Guid.NewGuid();
                    item.ProjectId = ptablepk;
                    item.MainProjectId = mainProjectId;
                    item.SortNum = pSortNum;
                    _lrLabourMaterialsEquipmentsMachinesSummary.Add(item);

                    int sortNum = 1;
                    foreach (XmlNode node2 in ResourceNode.ChildNodes)
                    {
                        LabourMaterialsEquipmentsMachinesElement item2 = XAttrConvert<LabourMaterialsEquipmentsMachinesElement>.Model(node2.Attributes, ref errMessageTemp);
                        if (errMessageTemp != "")
                        {
                            errMessage += "❑ " + item.Name + "工料机含量明细表中字段格式不正确；\n" + errMessageTemp + "\n";
                        }
                        item2.LMEMS_ID = item.Id;
                        item2.SortNum = sortNum;
                        _lrLabourMaterialsEquipmentsMachinesElement.Add(item2);
                        sortNum++;
                    }
                }
            }
        }

        /// <summary>
        /// 将父节点和子节点名称相同的xmlNode转换为List
        /// </summary>
        /// <typeparam name="T">List的成员类型</typeparam>
        /// <param name="fNode">要转化的节点</param>
        /// <param name="FatherTablePk">父表的主键值</param>
        /// <param name="FatherTableName">父表主键在子表中的名称 默认ProjectId</param>
        /// <param name="level">节点有几级 默认2级</param>
        /// <returns></returns>
        private List<T> GetTreeNodes<T>(Guid mainProjectId, XmlNode fNode, Guid FatherTablePk, ref string errMessage, String FatherTableName = "ProjectId", int level = 2) where T : class, new()
        {
            List<T> attrList = new List<T>();
            errMessage = "";
            string errMessageTemp = "";
            try
            {
                Func<XmlNode, Guid?, int, T> AddList = (a, p, s) =>
                {
                    T item = XAttrConvert<T>.Model(a.Attributes, ref errMessageTemp);

                    item.GetType().GetProperty(FatherTableName).SetValue(item, FatherTablePk);
                    item.GetType().GetProperty("Id").SetValue(item, Guid.NewGuid());
                    item.GetType().GetProperty("MainProjectId").SetValue(item, mainProjectId);
                    item.GetType().GetProperty("SortNum").SetValue(item, s);
                    if (item.GetType().GetProperty("ParentId") != null)
                    {
                        item.GetType().GetProperty("ParentId").SetValue(item, p);
                    }
                    return item;

                };
                if (fNode != null && fNode.ChildNodes.Count > 0)
                {
                    int sortOne = 1;
                    foreach (XmlNode node1 in fNode.ChildNodes)
                    {
                        T item1 = AddList(node1, null, sortOne);
                        item1.GetType().GetProperty("MainProjectId").SetValue(item1, mainProjectId);
                        attrList.Add(item1);
                        sortOne++;
                        if (node1.ChildNodes.Count > 0)
                        {
                            int sortTwo = 1;
                            foreach (XmlNode node2 in node1.ChildNodes)
                            {
                                Guid fId = (Guid)(item1.GetType().GetProperty("Id").GetValue(item1));
                                T item2 = AddList(node2, fId, sortTwo);
                                attrList.Add(item2);
                                sortTwo++;
                                if (level > 2 && node2.ChildNodes.Count > 0)
                                {
                                    int sortThree = 1;
                                    foreach (XmlNode node3 in node2.ChildNodes)
                                    {
                                        Guid fId2 = (Guid)(item2.GetType().GetProperty("Id").GetValue(item2));
                                        T item3 = AddList(node3, fId2, sortThree);
                                        attrList.Add(item3);
                                        sortThree++;
                                        if (level > 3 && node3.ChildNodes.Count > 0)
                                        {
                                            int sortFour = 1;
                                            foreach (XmlNode node4 in node3.ChildNodes)
                                            {
                                                Guid fId3 = (Guid)(item3.GetType().GetProperty("Id").GetValue(item3));
                                                T item4 = AddList(node4, fId3, sortFour);
                                                attrList.Add(item4);
                                                sortFour++;
                                            }

                                        }
                                    }

                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                errMessage = "err";
            }
            return attrList;
        }
        #endregion

        #region 底层公共方法
        public class XAttrConvert<T> where T : class, new()
        {
            /// <summary>
            /// 数据类型转换System.Xml.Linq.XAttribute 转换为Model
            /// </summary>
            /// <param name="attrs">System.Xml.Linq.XAttribute列表</param>
            /// <param name="Model">要转换为的Model</param>
            /// <returns>异常返回null</returns>
            public static T Model(IEnumerable<System.Xml.Linq.XAttribute> attrs, T Model = null)
            {
                try
                {
                    T model = null;
                    if (Model != null)
                    {
                        model = Model;
                    }
                    else
                    {
                        model = new T();
                    }

                    if (attrs != null)
                    {
                        foreach (PropertyInfo property in model.GetType().GetProperties())
                        {
                            var val = attrs.Where(a => a.Name.LocalName.ToLower() == property.Name.ToLower()).FirstOrDefault();
                            if (val != null)
                            {
                                property.SetValue(model, Convert.ChangeType(val.Value, property.PropertyType));
                            }
                        }
                    }

                    return model;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            /// <summary>
            /// 数据类型转换System.Xml.Linq.XAttribute 转换为Model
            /// </summary>
            /// <param name="attrs">System.Xml.XmlAttributeCollection</param>
            /// <param name="Model">要转换为的Model</param>
            /// <returns>异常返回null</returns>
            public static T Model(System.Xml.XmlAttributeCollection attrs, ref string errMessage, T Model = null)
            {
                string valueType = "";
                errMessage = "";
                var limit = "       ☆";
                try
                {

                    T model = Model ?? Activator.CreateInstance<T>();
                    var lrAttr = XB.Framework.Common.Util.ReflectUtil.GetPropertiesKeyDescription<T>(model);
                    var pos = 1;
                    if (attrs != null)
                    {
                        foreach (PropertyInfo property in model.GetType().GetProperties())
                        {
                            // 检查是否有[Required]特性
                            bool isRequired = Attribute.IsDefined(property, typeof(RequiredAttribute));
                            var val = attrs.GetNamedItem(property.Name);
                            object value = null;
                            if (val != null)
                            {
                                value = ConvertTo(val.Value, property.PropertyType, ref valueType);
                            }
                            else
                            {
                                if (property.Name.ToLower() == "id")
                                {
                                    value = Guid.NewGuid();
                                }
                                else
                                {
                                    value = ConvertTo(null, property.PropertyType, ref valueType);

                                }
                            }
                            // 检查必填字段
                            if (isRequired && (value == null || (value is string str && string.IsNullOrEmpty(str))))
                            {
                                errMessage += $"{limit}{model.GetType().Name}表中字段格式不正确：{property.Name} 是必填字段，不能为空，请补充！" + "\n";
                                pos++;
                                //throw new Exception($"{model.GetType().Name}.{property.Name} 是必填字段，不能为空，请补充！");

                            }
                            try
                            {
                                property.SetValue(model, value);
                            }
                            catch (Exception ex)
                            {
                                errMessage += $"{limit}{model.GetType().Name}表中字段数据类型不正确：{property.Name}数据类型为：{valueType}； 当前值为：{val.Value}" + "\n";
                                pos++;
                                //errMessage += $"{property.Name} 数据类型为：{valueType}；当前值为：{value}；";
                            }

                        }
                    }

                    return model;
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    throw; // 重新抛出异常，让调用者处理
                }
            }

            private static object ConvertTo(string convertibleValue, Type t, ref string valueType)
            {
                try
                {
                    if (null == convertibleValue)
                    {
                        object value = null;
                        string typename = t.Name.ToLower();
                        if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            Type baseType = Nullable.GetUnderlyingType(t);
                            typename = baseType.Name.ToLower();
                        }
                        valueType = typename;
                        switch (typename)
                        {
                            case "double":
                                value = 0d;
                                break;
                            case "int16":
                            case "int32":
                            case "int64":
                                value = 0;
                                break;
                            case "boolean":
                                value = false;
                                break;
                            case "string":
                                value = "";
                                break;
                            default:
                                break;
                        }

                        return value;
                    }

                    if (!t.IsGenericType)
                    {
                        valueType = t.Name.ToLower();
                        switch (t.Name.ToLower())
                        {
                            case "double":
                                return (double?)Convert.ChangeType(convertibleValue == "" ? "0" : convertibleValue, typeof(double));
                            case "guid":
                                return (Guid?)Convert.ChangeType(convertibleValue, typeof(Guid));
                            case "int16":
                            case "int32":
                            case "int64":
                                return (int?)Convert.ChangeType(convertibleValue == "" ? "0" : convertibleValue, typeof(int));
                            case "boolean":
                                if (convertibleValue == "0" || convertibleValue == "")
                                    convertibleValue = "false";
                                if (convertibleValue == "1")
                                    convertibleValue = "true";
                                return (bool?)Convert.ChangeType(convertibleValue, typeof(bool));
                            case "datetime":
                                return Convert.ChangeType(convertibleValue, typeof(DateTime));
                            default:
                                return Convert.ChangeType(convertibleValue, typeof(string));
                        }
                    }
                    else
                    {
                        Type genericTypeDefinition = t.GetGenericTypeDefinition();
                        if (genericTypeDefinition == typeof(Nullable<>))
                        {
                            Type baseType = Nullable.GetUnderlyingType(t);
                            valueType = baseType.Name.ToLower();
                            switch (baseType.Name.ToLower())
                            {
                                case "double":
                                    return (double?)Convert.ChangeType(convertibleValue == "" ? "0" : convertibleValue, typeof(double));
                                case "guid":
                                    return (Guid?)Convert.ChangeType(convertibleValue, typeof(Guid));
                                case "int16":
                                case "int32":
                                case "int64":
                                    return (int?)Convert.ChangeType(convertibleValue == "" ? "0" : convertibleValue, typeof(int));
                                case "boolean":
                                    if (convertibleValue == "0" || convertibleValue == "")
                                        convertibleValue = "false";
                                    if (convertibleValue == "1")
                                        convertibleValue = "true";
                                    return (bool?)Convert.ChangeType(convertibleValue, typeof(bool));
                                case "datetime":
                                    if (convertibleValue == "")
                                        return null;
                                    return Convert.ChangeType(convertibleValue, typeof(DateTime));
                                default:
                                    return Convert.ChangeType(convertibleValue, typeof(string));
                            }
                        }
                        else
                            return convertibleValue;
                    }
                    //throw new InvalidCastException(string.Format("Invalid cast from type \"{0}\" to type \"{1}\".", convertibleValue.GetType().FullName, typeof(T).FullName));
                }
                catch (Exception ex)
                {
                    return convertibleValue;
                    throw ex;
                }
            }

        }
        #endregion
    }
}