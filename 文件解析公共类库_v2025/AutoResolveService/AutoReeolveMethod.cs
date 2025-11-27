using AutoResolveService.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;

namespace AutoResolveService
{
    public class AutoReeolveMethod
    {
        #region 初始化变量
        List<AutoResolveService.Models.AttrInfoItem> attrInfoList = new List<AutoResolveService.Models.AttrInfoItem>();
        List<AddInfoItem> addInfoList = new List<AddInfoItem>();
        List<AddiCost> addiCostList = new List<AddiCost>();
        List<BidEvaluationMainMaterial> BEMMList = new List<BidEvaluationMainMaterial>();
        List<LabourMachinesSummary> labourMachinesSummaryList = new List<LabourMachinesSummary>();
        List<LabourMaterialsEquipmentsMachinesElement> resElementItemList = new List<LabourMaterialsEquipmentsMachinesElement>();
        List<OtherCostGroup> otherCostGroupList = new List<OtherCostGroup>();
        List<OtherCostItem> otherCostItemList = new List<OtherCostItem>();
        List<SpecifyCostGroup> specifygroupList = new List<SpecifyCostGroup>();
        List<SpecifyCostCostItem> specifyitemList = new List<SpecifyCostCostItem>();
        List<ContingencyFeeGroup> contingencyFeeGroupList = new List<ContingencyFeeGroup>();
        List<ContingencyFeeItem> contingencyFeeItemList = new List<ContingencyFeeItem>();
        List<ProjectInstallationWorkCost> projectInstallationWorkCostList = new List<ProjectInstallationWorkCost>();
        List<EquipmentProcurementCost> EquipmentCostList = new List<EquipmentProcurementCost>();
        List<EquipmentProcurementCostItem> EquipmentCostItemList = new List<EquipmentProcurementCostItem>();
        List<UnitPriceCalculationOfItem> ChargeItemList = new List<UnitPriceCalculationOfItem>();
        List<OtherCost> OtherCostList = new List<OtherCost>();
        List<StatutoryFeesGroup> statutoryFeesGroupList1 = new List<StatutoryFeesGroup>();
        List<StatutoryFeesGroup> statutoryFeesGroupList2 = new List<StatutoryFeesGroup>();
        List<StatutoryFeesGroup> statutoryFeesGroupList3 = new List<StatutoryFeesGroup>();
        List<StatutoryFeesItem> statutoryFeesItemList1 = new List<StatutoryFeesItem>();
        List<StatutoryFeesItem> statutoryFeesItemList2 = new List<StatutoryFeesItem>();
        List<StatutoryFeesItem> statutoryFeesItemList3 = new List<StatutoryFeesItem>();
        List<SectionalWorks> sectionalWorksList = new List<SectionalWorks>();
        List<UnitWorks> unitWorksList = new List<UnitWorks>();
        List<SummaryOfBasicCost> summaryOfBasicCostList = new List<SummaryOfBasicCost>();
        List<DivisionalWorks> divisionalWorksList = new List<DivisionalWorks>();
        List<WorkElement> workElementList = new List<WorkElement>();
        List<SummaryOfCost> summaryOfCostList = new List<SummaryOfCost>();
        List<SummaryItem> summaryItemList = new List<SummaryItem>();
        List<ExpressElement> expressElementList = new List<ExpressElement>();
        List<WorkContent> workContentList = new List<WorkContent>();
        List<Norm> normList = new List<Norm>();
        List<CombinedNorm> combinedNormList = new List<CombinedNorm>();
        List<UnitPriceCalculationOfItem> unitPriceCalculationOfItemList = new List<UnitPriceCalculationOfItem>();
        List<SundryCostsGroup> sundryCostsGroupList = new List<SundryCostsGroup>();
        List<SundryCostsItem> sundryCostsItemList = new List<SundryCostsItem>();
        List<ProvisionalSumsGroup> provisionalSumsGroupList = new List<ProvisionalSumsGroup>();
        List<ProvisionalSumsItem> provisionalSumsItemList = new List<ProvisionalSumsItem>();
        List<ProvisionalMaterialGroup> provisionalMaterialGroupList = new List<ProvisionalMaterialGroup>();
        List<ProvisionalMaterialItem> provisionalMaterialItemList = new List<ProvisionalMaterialItem>();
        List<SpecialtyProvisionalPriceGroup> specialtyProvisionalPriceGroupList = new List<SpecialtyProvisionalPriceGroup>();
        List<SpecialtyProvisionalPriceItem> specialtyProvisionalPriceItemList = new List<SpecialtyProvisionalPriceItem>();
        List<DayWorkRateGroup> dayWorkRateGroupList = new List<DayWorkRateGroup>();
        List<DayWorkRateItem> dayWorkRateItemList = new List<DayWorkRateItem>();
        List<MainContractorAttendanceGroup> mainContractorAttendanceGroupList = new List<MainContractorAttendanceGroup>();
        List<MainContractorAttendanceItem> mainContractorAttendanceItemList = new List<MainContractorAttendanceItem>();
        List<SiteInstructionCostGroup> siteInstructionCostGroupList = new List<SiteInstructionCostGroup>();
        List<SiteInstructionCostItem> siteInstructionCostItemList = new List<SiteInstructionCostItem>();
        List<ClaimsCostGroup> claimsCostGroupList = new List<ClaimsCostGroup>();
        List<ClaimsCostItem> claimsCostItemList = new List<ClaimsCostItem>();
        List<StatutoryFeesGroup> statutoryFeesGroupList = new List<StatutoryFeesGroup>();
        List<StatutoryFeesItem> statutoryFeesItemList = new List<StatutoryFeesItem>();
        List<TaxGroup> taxGroupList = new List<TaxGroup>();
        List<TaxItem> taxItemList = new List<TaxItem>();
        #endregion

        #region xml解析上传
        public AutoReeolveCollection SaveXmlToDB(System.Xml.XmlDocument xmlFile)
        {
            AutoReeolveCollection ret = new AutoReeolveCollection { ExsultMessage = "" };

            AutoResolveService.Models.ConstructionProjects CProjectModel = null;
            Options OpModel = null;
            ProjectInfo PinfoModel = null;
            TendererBidderInfo TBModel = null;
            BidderInfo BIModel = null;
            SummaryOfCost SOCModel = null;
            OtherCostSums OtherCSModel = null;
            ContingencyFee cfModel = null;
            ConstructionCost CCModel = null;
            SpecifyCostSum SCSModel1 = null;
            SpecifyCostSum SCSModel2 = null;
            SpecifyCostSum SCSModel3 = null;

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
                    CProjectModel = XAttrConvert<ConstructionProjects>.Model(CPNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 建设项目表中字段格式不正确；" + errMessageTemp + "\n";
                    }

                    var CProjectModel2 = XAttrConvert<ConstructionProjects>.Model(SysInfoNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += errMessageTemp;
                    }

                    CProjectModel.ID1 = CProjectModel2.ID1;
                    CProjectModel.ID2 = CProjectModel2.ID2;
                    CProjectModel.FileMakeDate = CProjectModel2.MakeDate;

                    if (CProjectModel.ValuationMethod != 1)
                    {
                        if (CProjectModel.ValuationMethod != 2)
                        {
                            errDateMessageList += "您提交的文件缺少计价类型，请检查！\n";
                            return ret;
                        }
                    }

                    CProjectModel.Id = Guid.NewGuid();
                    CProjectModel.XmlName = CProjectModel.Name;
                    CProjectModel.CreateDate = System.DateTime.Now;
                    CProjectModel.State = 0;
                }
                #endregion

                #region Option,ProjectInfo,TendererInfo
                XmlNode OptionsNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/Option");
                XmlNode PInfoNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/ProjectInfo");
                XmlNode TBNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/TendererInfo");

                if (OptionsNode != null)
                {
                    OpModel = XAttrConvert<Options>.Model(OptionsNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 费用精度表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    OpModel.ProjectNumber = CProjectModel.Number;
                    OpModel.SortNum = 1;
                    OpModel.ProjectId = CProjectModel.Id;
                    OpModel.CreateDate = DateTime.Now;
                }
                if (PInfoNode != null)
                {
                    PinfoModel = XAttrConvert<ProjectInfo>.Model(PInfoNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 估（概、预、结）信息表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    PinfoModel.ConstructionProjectId = CProjectModel.Id;
                    PinfoModel.SortNum = 1;
                    if (PinfoModel.CompileDate != "" && PinfoModel.CompileDate != null)
                        CProjectModel.MakeDate = Convert.ToDateTime(PinfoModel.CompileDate);
                }
                if (TBNode != null)
                {
                    TBModel = XAttrConvert<TendererBidderInfo>.Model(TBNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 招标信息表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    TBModel.ConstructionProjectId = CProjectModel.Id;
                    TBModel.SortNum = 1;
                }
                #endregion

                #region BidderInfo
                XmlNode BINode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/BidderInfo");
                if (BINode != null)
                {
                    BIModel = XAttrConvert<BidderInfo>.Model(BINode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 投标信息表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    BIModel.ConstructionProjectId = CProjectModel.Id;
                    BIModel.SortNum = 1;
                }
                #endregion

                #region TotalCosts 树形节点，暂定为2级;AttrInfo 树形节点，暂定为2级;AddiInfo 树形节点，暂定为2级

                XmlNode AttrInfosNode1 = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/AttrInfo");
                var attrInfoList1 = GetTreeNodes<AttrInfoItem>(CProjectModel.Id, AttrInfosNode1, CProjectModel.Id, ref errMessageTemp);
                if (attrInfoList1 != null)
                {
                    if (errMessageTemp != "")
                        errMessageList += "● 工程特征信息表中字段格式不正确；";
                    attrInfoList.AddRange(attrInfoList1);
                }

                XmlNode AddInfosNode1 = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/AddiInfo");
                var addInfoList1 = GetTreeNodes<AddInfoItem>(CProjectModel.Id, AddInfosNode1, CProjectModel.Id, ref errMessageTemp);
                if (addInfoList1 != null)
                {
                    if (errMessageTemp != "")
                        errMessageList += "● 补充信息表中字段格式不正确；";
                    addInfoList.AddRange(addInfoList1);
                }

                #endregion

                #region SummaryOfCost
                XmlNode SOCNode = xmlFile.SelectSingleNode("/ConstructionProject/SummaryOfCost");
                if (SOCNode != null)
                {
                    SOCModel = XAttrConvert<SummaryOfCost>.Model(SOCNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 费用汇总表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    SOCModel.id = Guid.NewGuid();
                    SOCModel.ProjectId = CProjectModel.Id;
                    SOCModel.MainProjectId = CProjectModel.Id;
                }
                #endregion

                #region Resource
                XmlNode LMEMNode = xmlFile.SelectSingleNode("/ConstructionProject/LabourMaterialsEquipmentsMachinesSummary");
                if (LMEMNode != null)
                {
                    ResourceConvert(LMEMNode, CProjectModel.Id, CProjectModel.Id, 1, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += errMessageTemp;
                    }
                }

                #endregion

                #region BidEvaluationMainMaterial
                XmlNode BEMMNodes = xmlFile.SelectSingleNode("/ConstructionProject/BidEvaluationMainMaterial");

                if (BEMMNodes != null && BEMMNodes.ChildNodes.Count > 0)
                {
                    int sortNum = 1;
                    foreach (XmlNode node in BEMMNodes.ChildNodes)
                    {
                        BidEvaluationMainMaterial item = XAttrConvert<BidEvaluationMainMaterial>.Model(node.Attributes, ref errMessageTemp);
                        if (errMessageTemp != "")
                        {
                            errMessageList += "● " + item.Name + "评标主要材料表中字段格式不正确；" + errMessageTemp + "\n";
                        }
                        item.ProjectId = CProjectModel.Id;
                        item.MainProjectId = CProjectModel.Id;
                        item.SortNum = sortNum;
                        BEMMList.Add(item);
                        sortNum++;
                    }
                }

                #endregion

                #region  OtherCostSums 穿透2级,SpecifyCostSum 穿透2级
                XmlNode OtherCSNodes = xmlFile.SelectSingleNode("/ConstructionProject/OtherCostSums");
                if (OtherCSNodes != null)
                {
                    OtherCSModel = XAttrConvert<OtherCostSums>.Model(OtherCSNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + OtherCSModel.Name + "扩展项表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    OtherCSModel.ConstructionProjectsId = CProjectModel.Id;
                    OtherCSModel.Id = Guid.NewGuid();
                    GroupItemConvert<OtherCostGroup, OtherCostItem>(ref otherCostGroupList, ref otherCostItemList, CProjectModel.Id,
                        OtherCSNodes, OtherCSModel.Id, "OCS_OCG_Id", ref errMessageTemp, "OtherCostSumsId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 扩展项表中字段格式不正确；" + errMessageTemp + "\n";

                }
                #endregion

                #region ContingencyFee 穿透2级,SCSModel1 穿透2级,SCSModel2 穿透2级,SCSModel3 穿透2级
                XmlNode CFNodes = xmlFile.SelectSingleNode("/ConstructionProject/ContingencyFee");
                if (CFNodes != null)
                {
                    cfModel = XAttrConvert<ContingencyFee>.Model(CFNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + cfModel.Name + "预备费表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    cfModel.ConstructionProjectsId = CProjectModel.Id;
                    cfModel.Id = Guid.NewGuid();
                    GroupItemConvert<ContingencyFeeGroup, ContingencyFeeItem>(ref contingencyFeeGroupList, ref contingencyFeeItemList, CProjectModel.Id,
                        CFNodes, cfModel.Id, "CF_CFG_Id", ref errMessageTemp, "ContingencyFeeId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 预备费表中字段格式不正确；" + errMessageTemp + "\n";

                }
                #endregion

                #region ConstructionCost

                XmlNode ConstructionCostNodes = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionSummary/ConstructionCost");

                if (ConstructionCostNodes != null)
                {
                    CCModel = XAttrConvert<ConstructionCost>.Model(ConstructionCostNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + CCModel.Name + "工程费用表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    CCModel.Id = Guid.NewGuid();
                    CCModel.ConstructionProjectId = CProjectModel.Id;

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
                                            errMessageList += "● " + projectInstallationWorkCostModel.Name + "建筑安装工程费表中字段格式不正确；" + errMessageTemp + "\n";
                                        }
                                        projectInstallationWorkCostModel.id = Guid.NewGuid();
                                        projectInstallationWorkCostModel.ConstructionCost = CCModel.Id;
                                        projectInstallationWorkCostModel.SortNum = sortP;
                                        projectInstallationWorkCostList.Add(projectInstallationWorkCostModel);
                                        ProjectInstallationWorkCostConvert(node, projectInstallationWorkCostModel.id, CProjectModel.Id, Convert.ToInt32(CProjectModel.ValuationMethod), ref errMessageTemp);//检查子节点
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
                                            errMessageList += "● " + ecostsumModel.Name + "设备及工器具购置费表中字段格式不正确；" + errMessageTemp + "\n";
                                        }
                                        ecostsumModel.ConstructionCost = CCModel.Id;
                                        ecostsumModel.id = Guid.NewGuid();
                                        ecostsumModel.SortNum = sortE;
                                        EquipmentCostList.Add(ecostsumModel);
                                        if (node.ChildNodes.Count > 0)
                                        {
                                            EquipmentCostItemList = new List<EquipmentProcurementCostItem>(node.ChildNodes.Count);
                                            int sortETwo = 1;
                                            foreach (XmlNode node1 in node.ChildNodes)
                                            {
                                                EquipmentProcurementCostItem item = XAttrConvert<EquipmentProcurementCostItem>.Model(node1.Attributes, ref errMessageTemp);
                                                if (errMessageTemp != "")
                                                {
                                                    errMessageList += "● " + item.Name + "设备及工器具购置费明细表中字段格式不正确；" + errMessageTemp + "\n";
                                                }
                                                item.EquipmentId = ecostsumModel.id;
                                                item.id = Guid.NewGuid();
                                                item.SortNum = sortETwo;
                                                EquipmentCostItemList.Add(item);
                                                sortETwo++;
                                                if (node1.ChildNodes.Count > 0 && node1.FirstChild.ChildNodes.Count > 0)
                                                {
                                                    int sortEThree = 1;
                                                    foreach (XmlNode node3 in node1.FirstChild.ChildNodes)
                                                    {
                                                        UnitPriceCalculationOfItem chargeitem = XAttrConvert<UnitPriceCalculationOfItem>.Model(node3.Attributes, ref errMessageTemp);
                                                        if (errMessageTemp != "")
                                                        {
                                                            errMessageList += "● " + chargeitem.Name + "子目单价计算表中字段格式不正确；" + errMessageTemp + "\n";
                                                        }
                                                        chargeitem.CItemFatherId = item.id;
                                                        chargeitem.MainProjectId = CProjectModel.Id;
                                                        chargeitem.SortNum = sortEThree;
                                                        ChargeItemList.Add(chargeitem);
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
                                        var list = GetTreeNodes<OtherCost>(CProjectModel.Id, node, CCModel.Id, ref errMessageTemp, "PF_SW_Id");
                                        if (list != null)
                                        {
                                            if (errMessageTemp != "")
                                            {
                                                errMessageList += "● 扩展项表中字段格式不正确；";
                                            }
                                            OtherCostList.AddRange(list);
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
                #endregion

                #region InterestDuringConstructionPeriod 穿透2级,SCSModel1 穿透2级,SCSModel2 穿透2级,SCSModel3 穿透2级
                XmlNode IDCRNodes = xmlFile.SelectSingleNode("/ConstructionProject/InterestDuringConstructionPeriod");
                if (IDCRNodes != null)
                {
                    SCSModel1 = XAttrConvert<SpecifyCostSum>.Model(IDCRNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                        errMessageList += "● " + SCSModel1.Name + "建设期贷款利息表中字段格式不正确；" + errMessageTemp + "\n";

                    SCSModel1.ConstructionProjectsId = CProjectModel.Id;
                    SCSModel1.Id = Guid.NewGuid();
                    SCSModel1.Type = 1;
                    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList1, ref statutoryFeesItemList1, CProjectModel.Id,
                        IDCRNodes, SCSModel1.Id, "SCS_SCG_Id", ref errMessageTemp, "SpecifyCostSumId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 建设期贷款利息表中字段格式不正确；" + errMessageTemp + "\n";
                }

                XmlNode IWCNodes = xmlFile.SelectSingleNode("/ConstructionProject/InitialWorkingCapital");
                if (IWCNodes != null)
                {
                    SCSModel2 = XAttrConvert<SpecifyCostSum>.Model(IWCNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + SCSModel2.Name + "铺底流动资金表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    SCSModel2.ConstructionProjectsId = CProjectModel.Id;
                    SCSModel2.Id = Guid.NewGuid();
                    SCSModel2.Type = 2;
                    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList2, ref statutoryFeesItemList2, CProjectModel.Id,
                        IWCNodes, SCSModel2.Id, "SCS_SCG_Id", ref errMessageTemp, "SpecifyCostSumId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 铺底流动资金表中字段格式不正确；" + errMessageTemp + "\n";
                }

                XmlNode RTFINodes = xmlFile.SelectSingleNode("/ConstructionProject/RegulationTaxOfFixedAssetsInvestment");
                if (RTFINodes != null)
                {
                    SCSModel3 = XAttrConvert<SpecifyCostSum>.Model(RTFINodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + SCSModel3.Name + "固定资产投资方向调节税表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    SCSModel3.ConstructionProjectsId = CProjectModel.Id;
                    SCSModel3.Id = Guid.NewGuid();
                    SCSModel3.Type = 3;
                    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList3, ref statutoryFeesItemList3, CProjectModel.Id,
                        RTFINodes, SCSModel3.Id, "SCS_SCG_Id", ref errMessageTemp, "SpecifyCostSumId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 固定资产投资方向调节税表中字段格式不正确；" + errMessageTemp + "\n";
                }
                #endregion

                #region 赋值
                ret.CProjectModel = CProjectModel;
                ret.OpModel = OpModel;
                ret.PinfoModel = PinfoModel;
                ret.TBModel = TBModel;
                ret.BIModel = BIModel;
                ret.SOCModel = SOCModel;
                ret.OtherCSModel = OtherCSModel;
                ret.cfModel = cfModel;
                ret.CCModel = CCModel;
                ret.SCSModel1 = SCSModel1;
                ret.SCSModel2 = SCSModel2;
                ret.SCSModel3 = SCSModel3;
                ret.attrInfoList = attrInfoList;
                ret.addInfoList = addInfoList;
                ret.addiCostList = addiCostList;
                ret.BEMMList = BEMMList;
                ret.labourMachinesSummaryList = labourMachinesSummaryList;
                ret.resElementItemList = resElementItemList;
                ret.otherCostGroupList = otherCostGroupList;
                ret.otherCostItemList = otherCostItemList;
                ret.specifygroupList = specifygroupList;
                ret.specifyitemList = specifyitemList;
                ret.contingencyFeeGroupList = contingencyFeeGroupList;
                ret.contingencyFeeItemList = contingencyFeeItemList;
                ret.projectInstallationWorkCostList = projectInstallationWorkCostList;
                ret.EquipmentCostList = EquipmentCostList;
                ret.EquipmentCostItemList = EquipmentCostItemList;
                ret.ChargeItemList = ChargeItemList;
                ret.OtherCostList = OtherCostList;
                ret.statutoryFeesGroupList1 = statutoryFeesGroupList1;
                ret.statutoryFeesGroupList2 = statutoryFeesGroupList2;
                ret.statutoryFeesGroupList3 = statutoryFeesGroupList3;
                ret.statutoryFeesItemList1 = statutoryFeesItemList1;
                ret.statutoryFeesItemList2 = statutoryFeesItemList2;
                ret.statutoryFeesItemList3 = statutoryFeesItemList3;
                ret.sectionalWorksList = sectionalWorksList;
                ret.unitWorksList = unitWorksList;
                ret.summaryOfBasicCostList = summaryOfBasicCostList;
                ret.divisionalWorksList = divisionalWorksList;
                ret.workElementList = workElementList;
                ret.summaryOfCostList = summaryOfCostList;
                ret.summaryItemList = summaryItemList;
                ret.expressElementList = expressElementList;
                ret.workContentList = workContentList;
                ret.normList = normList;
                ret.combinedNormList = combinedNormList;
                ret.unitPriceCalculationOfItemList = unitPriceCalculationOfItemList;
                ret.sundryCostsGroupList = sundryCostsGroupList;
                ret.sundryCostsItemList = sundryCostsItemList;
                ret.provisionalSumsGroupList = provisionalSumsGroupList;
                ret.provisionalSumsItemList = provisionalSumsItemList;
                ret.provisionalMaterialGroupList = provisionalMaterialGroupList;
                ret.provisionalMaterialItemList = provisionalMaterialItemList;
                ret.specialtyProvisionalPriceGroupList = specialtyProvisionalPriceGroupList;
                ret.specialtyProvisionalPriceItemList = specialtyProvisionalPriceItemList;
                ret.dayWorkRateGroupList = dayWorkRateGroupList;
                ret.dayWorkRateItemList = dayWorkRateItemList;
                ret.mainContractorAttendanceGroupList = mainContractorAttendanceGroupList;
                ret.mainContractorAttendanceItemList = mainContractorAttendanceItemList;
                ret.siteInstructionCostGroupList = siteInstructionCostGroupList;
                ret.siteInstructionCostItemList = siteInstructionCostItemList;
                ret.claimsCostGroupList = claimsCostGroupList;
                ret.claimsCostItemList = claimsCostItemList;
                ret.statutoryFeesGroupList = statutoryFeesGroupList;
                ret.statutoryFeesItemList = statutoryFeesItemList;
                ret.taxGroupList = taxGroupList;
                ret.taxItemList = taxItemList;
                #endregion

                if (errMessageList != "")
                    errMessageList = "错误提示：\n" + errMessageList + "请联系计价软件公司！\n";
                if (errDateMessageList != "")
                {
                    errMessageList = errMessageList + errDateMessageList;
                }

                ret.ExsultMessage = errMessageList;
            }
            catch (Exception ex)
            {
                ret.HidErrMessage = ex.ToString();
                ret.ExsultMessage = "您提交的xml文件格式不符合交换标准，第一步：请您确认是否按照造价监测数据接口导出的XML文件；第二步：如果确认第一步没有问题，请联系北京建科研软件技术有限公司：400-825-113进行咨询。";
            }

            return ret;
        }

        public AutoReeolveCollection EditXmlToDB(Guid projectId,System.Xml.XmlDocument xmlFile)
        {
            AutoReeolveCollection ret = new AutoReeolveCollection { ExsultMessage = "" };

            AutoResolveService.Models.ConstructionProjects CProjectModel = null;
            Options OpModel = null;
            ProjectInfo PinfoModel = null;
            TendererBidderInfo TBModel = null;
            BidderInfo BIModel = null;
            SummaryOfCost SOCModel = null;
            OtherCostSums OtherCSModel = null;
            ContingencyFee cfModel = null;
            ConstructionCost CCModel = null;
            SpecifyCostSum SCSModel1 = null;
            SpecifyCostSum SCSModel2 = null;
            SpecifyCostSum SCSModel3 = null;

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
                    CProjectModel = XAttrConvert<ConstructionProjects>.Model(CPNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 建设项目表中字段格式不正确；" + errMessageTemp + "\n";
                    }

                    var CProjectModel2 = XAttrConvert<ConstructionProjects>.Model(SysInfoNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += errMessageTemp;
                    }

                    CProjectModel.ID1 = CProjectModel2.ID1;
                    CProjectModel.ID2 = CProjectModel2.ID2;
                    CProjectModel.FileMakeDate = CProjectModel2.MakeDate;

                    if (CProjectModel.ValuationMethod != 1)
                    {
                        if (CProjectModel.ValuationMethod != 2)
                        {
                            errDateMessageList += "您提交的文件缺少计价类型，请检查！\n";
                            return ret;
                        }
                    }

                    CProjectModel.Id = projectId;
                    CProjectModel.XmlName = CProjectModel.Name;
                    CProjectModel.CreateDate = System.DateTime.Now;
                    CProjectModel.State = 0;
                }
                #endregion

                #region Option,ProjectInfo,TendererInfo
                XmlNode OptionsNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/Option");
                XmlNode PInfoNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/ProjectInfo");
                XmlNode TBNode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/TendererInfo");

                if (OptionsNode != null)
                {
                    OpModel = XAttrConvert<Options>.Model(OptionsNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 费用精度表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    OpModel.ProjectNumber = CProjectModel.Number;
                    OpModel.SortNum = 1;
                    OpModel.ProjectId = CProjectModel.Id;
                    OpModel.CreateDate = DateTime.Now;
                }
                if (PInfoNode != null)
                {
                    PinfoModel = XAttrConvert<ProjectInfo>.Model(PInfoNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 估（概、预、结）信息表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    PinfoModel.ConstructionProjectId = CProjectModel.Id;
                    PinfoModel.SortNum = 1;
                    if (PinfoModel.CompileDate != "" && PinfoModel.CompileDate != null)
                        CProjectModel.MakeDate = Convert.ToDateTime(PinfoModel.CompileDate);
                }
                if (TBNode != null)
                {
                    TBModel = XAttrConvert<TendererBidderInfo>.Model(TBNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 招标信息表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    TBModel.ConstructionProjectId = CProjectModel.Id;
                    TBModel.SortNum = 1;
                }
                #endregion

                #region BidderInfo
                XmlNode BINode = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/BidderInfo");
                if (BINode != null)
                {
                    BIModel = XAttrConvert<BidderInfo>.Model(BINode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 投标信息表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    BIModel.ConstructionProjectId = CProjectModel.Id;
                    BIModel.SortNum = 1;
                }
                #endregion

                #region TotalCosts 树形节点，暂定为2级;AttrInfo 树形节点，暂定为2级;AddiInfo 树形节点，暂定为2级

                XmlNode AttrInfosNode1 = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/AttrInfo");
                var attrInfoList1 = GetTreeNodes<AttrInfoItem>(CProjectModel.Id, AttrInfosNode1, CProjectModel.Id, ref errMessageTemp);
                if (attrInfoList1 != null)
                {
                    if (errMessageTemp != "")
                        errMessageList += "● 工程特征信息表中字段格式不正确；";
                    attrInfoList.AddRange(attrInfoList1);
                }

                XmlNode AddInfosNode1 = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionInfo/AddiInfo");
                var addInfoList1 = GetTreeNodes<AddInfoItem>(CProjectModel.Id, AddInfosNode1, CProjectModel.Id, ref errMessageTemp);
                if (addInfoList1 != null)
                {
                    if (errMessageTemp != "")
                        errMessageList += "● 补充信息表中字段格式不正确；";
                    addInfoList.AddRange(addInfoList1);
                }

                #endregion

                #region SummaryOfCost
                XmlNode SOCNode = xmlFile.SelectSingleNode("/ConstructionProject/SummaryOfCost");
                if (SOCNode != null)
                {
                    SOCModel = XAttrConvert<SummaryOfCost>.Model(SOCNode.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● 费用汇总表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    SOCModel.id = Guid.NewGuid();
                    SOCModel.ProjectId = CProjectModel.Id;
                    SOCModel.MainProjectId = CProjectModel.Id;
                }
                #endregion

                #region Resource
                XmlNode LMEMNode = xmlFile.SelectSingleNode("/ConstructionProject/LabourMaterialsEquipmentsMachinesSummary");
                if (LMEMNode != null)
                {
                    ResourceConvert(LMEMNode, CProjectModel.Id, CProjectModel.Id, 1, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += errMessageTemp;
                    }
                }

                #endregion

                #region BidEvaluationMainMaterial
                XmlNode BEMMNodes = xmlFile.SelectSingleNode("/ConstructionProject/BidEvaluationMainMaterial");

                if (BEMMNodes != null && BEMMNodes.ChildNodes.Count > 0)
                {
                    int sortNum = 1;
                    foreach (XmlNode node in BEMMNodes.ChildNodes)
                    {
                        BidEvaluationMainMaterial item = XAttrConvert<BidEvaluationMainMaterial>.Model(node.Attributes, ref errMessageTemp);
                        if (errMessageTemp != "")
                        {
                            errMessageList += "● " + item.Name + "评标主要材料表中字段格式不正确；" + errMessageTemp + "\n";
                        }
                        item.ProjectId = CProjectModel.Id;
                        item.MainProjectId = CProjectModel.Id;
                        item.SortNum = sortNum;
                        BEMMList.Add(item);
                        sortNum++;
                    }
                }

                #endregion

                #region  OtherCostSums 穿透2级,SpecifyCostSum 穿透2级
                XmlNode OtherCSNodes = xmlFile.SelectSingleNode("/ConstructionProject/OtherCostSums");
                if (OtherCSNodes != null)
                {
                    OtherCSModel = XAttrConvert<OtherCostSums>.Model(OtherCSNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + OtherCSModel.Name + "扩展项表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    OtherCSModel.ConstructionProjectsId = CProjectModel.Id;
                    OtherCSModel.Id = Guid.NewGuid();
                    GroupItemConvert<OtherCostGroup, OtherCostItem>(ref otherCostGroupList, ref otherCostItemList, CProjectModel.Id,
                        OtherCSNodes, OtherCSModel.Id, "OCS_OCG_Id", ref errMessageTemp, "OtherCostSumsId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 扩展项表中字段格式不正确；" + errMessageTemp + "\n";

                }
                #endregion

                #region ContingencyFee 穿透2级,SCSModel1 穿透2级,SCSModel2 穿透2级,SCSModel3 穿透2级
                XmlNode CFNodes = xmlFile.SelectSingleNode("/ConstructionProject/ContingencyFee");
                if (CFNodes != null)
                {
                    cfModel = XAttrConvert<ContingencyFee>.Model(CFNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + cfModel.Name + "预备费表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    cfModel.ConstructionProjectsId = CProjectModel.Id;
                    cfModel.Id = Guid.NewGuid();
                    GroupItemConvert<ContingencyFeeGroup, ContingencyFeeItem>(ref contingencyFeeGroupList, ref contingencyFeeItemList, CProjectModel.Id,
                        CFNodes, cfModel.Id, "CF_CFG_Id", ref errMessageTemp, "ContingencyFeeId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 预备费表中字段格式不正确；" + errMessageTemp + "\n";

                }
                #endregion

                #region ConstructionCost

                XmlNode ConstructionCostNodes = xmlFile.SelectSingleNode("/ConstructionProject/ConstructionSummary/ConstructionCost");

                if (ConstructionCostNodes != null)
                {
                    CCModel = XAttrConvert<ConstructionCost>.Model(ConstructionCostNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + CCModel.Name + "工程费用表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    CCModel.Id = Guid.NewGuid();
                    CCModel.ConstructionProjectId = CProjectModel.Id;

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
                                            errMessageList += "● " + projectInstallationWorkCostModel.Name + "建筑安装工程费表中字段格式不正确；" + errMessageTemp + "\n";
                                        }
                                        projectInstallationWorkCostModel.id = Guid.NewGuid();
                                        projectInstallationWorkCostModel.ConstructionCost = CCModel.Id;
                                        projectInstallationWorkCostModel.SortNum = sortP;
                                        projectInstallationWorkCostList.Add(projectInstallationWorkCostModel);
                                        ProjectInstallationWorkCostConvert(node, projectInstallationWorkCostModel.id, CProjectModel.Id, Convert.ToInt32(CProjectModel.ValuationMethod), ref errMessageTemp);//检查子节点
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
                                            errMessageList += "● " + ecostsumModel.Name + "设备及工器具购置费表中字段格式不正确；" + errMessageTemp + "\n";
                                        }
                                        ecostsumModel.ConstructionCost = CCModel.Id;
                                        ecostsumModel.id = Guid.NewGuid();
                                        ecostsumModel.SortNum = sortE;
                                        EquipmentCostList.Add(ecostsumModel);
                                        if (node.ChildNodes.Count > 0)
                                        {
                                            EquipmentCostItemList = new List<EquipmentProcurementCostItem>(node.ChildNodes.Count);
                                            int sortETwo = 1;
                                            foreach (XmlNode node1 in node.ChildNodes)
                                            {
                                                EquipmentProcurementCostItem item = XAttrConvert<EquipmentProcurementCostItem>.Model(node1.Attributes, ref errMessageTemp);
                                                if (errMessageTemp != "")
                                                {
                                                    errMessageList += "● " + item.Name + "设备及工器具购置费明细表中字段格式不正确；" + errMessageTemp + "\n";
                                                }
                                                item.EquipmentId = ecostsumModel.id;
                                                item.id = Guid.NewGuid();
                                                item.SortNum = sortETwo;
                                                EquipmentCostItemList.Add(item);
                                                sortETwo++;
                                                if (node1.ChildNodes.Count > 0 && node1.FirstChild.ChildNodes.Count > 0)
                                                {
                                                    int sortEThree = 1;
                                                    foreach (XmlNode node3 in node1.FirstChild.ChildNodes)
                                                    {
                                                        UnitPriceCalculationOfItem chargeitem = XAttrConvert<UnitPriceCalculationOfItem>.Model(node3.Attributes, ref errMessageTemp);
                                                        if (errMessageTemp != "")
                                                        {
                                                            errMessageList += "● " + chargeitem.Name + "子目单价计算表中字段格式不正确；" + errMessageTemp + "\n";
                                                        }
                                                        chargeitem.CItemFatherId = item.id;
                                                        chargeitem.MainProjectId = CProjectModel.Id;
                                                        chargeitem.SortNum = sortEThree;
                                                        ChargeItemList.Add(chargeitem);
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
                                        var list = GetTreeNodes<OtherCost>(CProjectModel.Id, node, CCModel.Id, ref errMessageTemp, "PF_SW_Id");
                                        if (list != null)
                                        {
                                            if (errMessageTemp != "")
                                            {
                                                errMessageList += "● 扩展项表中字段格式不正确；";
                                            }
                                            OtherCostList.AddRange(list);
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
                #endregion

                #region InterestDuringConstructionPeriod 穿透2级,SCSModel1 穿透2级,SCSModel2 穿透2级,SCSModel3 穿透2级
                XmlNode IDCRNodes = xmlFile.SelectSingleNode("/ConstructionProject/InterestDuringConstructionPeriod");
                if (IDCRNodes != null)
                {
                    SCSModel1 = XAttrConvert<SpecifyCostSum>.Model(IDCRNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                        errMessageList += "● " + SCSModel1.Name + "建设期贷款利息表中字段格式不正确；" + errMessageTemp + "\n";

                    SCSModel1.ConstructionProjectsId = CProjectModel.Id;
                    SCSModel1.Id = Guid.NewGuid();
                    SCSModel1.Type = 1;
                    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList1, ref statutoryFeesItemList1, CProjectModel.Id,
                        IDCRNodes, SCSModel1.Id, "SCS_SCG_Id", ref errMessageTemp, "SpecifyCostSumId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 建设期贷款利息表中字段格式不正确；" + errMessageTemp + "\n";
                }

                XmlNode IWCNodes = xmlFile.SelectSingleNode("/ConstructionProject/InitialWorkingCapital");
                if (IWCNodes != null)
                {
                    SCSModel2 = XAttrConvert<SpecifyCostSum>.Model(IWCNodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + SCSModel2.Name + "铺底流动资金表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    SCSModel2.ConstructionProjectsId = CProjectModel.Id;
                    SCSModel2.Id = Guid.NewGuid();
                    SCSModel2.Type = 2;
                    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList2, ref statutoryFeesItemList2, CProjectModel.Id,
                        IWCNodes, SCSModel2.Id, "SCS_SCG_Id", ref errMessageTemp, "SpecifyCostSumId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 铺底流动资金表中字段格式不正确；" + errMessageTemp + "\n";
                }

                XmlNode RTFINodes = xmlFile.SelectSingleNode("/ConstructionProject/RegulationTaxOfFixedAssetsInvestment");
                if (RTFINodes != null)
                {
                    SCSModel3 = XAttrConvert<SpecifyCostSum>.Model(RTFINodes.Attributes, ref errMessageTemp);
                    if (errMessageTemp != "")
                    {
                        errMessageList += "● " + SCSModel3.Name + "固定资产投资方向调节税表中字段格式不正确；" + errMessageTemp + "\n";
                    }
                    SCSModel3.ConstructionProjectsId = CProjectModel.Id;
                    SCSModel3.Id = Guid.NewGuid();
                    SCSModel3.Type = 3;
                    GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList3, ref statutoryFeesItemList3, CProjectModel.Id,
                        RTFINodes, SCSModel3.Id, "SCS_SCG_Id", ref errMessageTemp, "SpecifyCostSumId", 2);
                    if (errMessageTemp != "")
                        errMessageList += "● 固定资产投资方向调节税表中字段格式不正确；" + errMessageTemp + "\n";
                }
                #endregion

                #region 赋值
                ret.CProjectModel = CProjectModel;
                ret.OpModel = OpModel;
                ret.PinfoModel = PinfoModel;
                ret.TBModel = TBModel;
                ret.BIModel = BIModel;
                ret.SOCModel = SOCModel;
                ret.OtherCSModel = OtherCSModel;
                ret.cfModel = cfModel;
                ret.CCModel = CCModel;
                ret.SCSModel1 = SCSModel1;
                ret.SCSModel2 = SCSModel2;
                ret.SCSModel3 = SCSModel3;
                ret.attrInfoList = attrInfoList;
                ret.addInfoList = addInfoList;
                ret.addiCostList = addiCostList;
                ret.BEMMList = BEMMList;
                ret.labourMachinesSummaryList = labourMachinesSummaryList;
                ret.resElementItemList = resElementItemList;
                ret.otherCostGroupList = otherCostGroupList;
                ret.otherCostItemList = otherCostItemList;
                ret.specifygroupList = specifygroupList;
                ret.specifyitemList = specifyitemList;
                ret.contingencyFeeGroupList = contingencyFeeGroupList;
                ret.contingencyFeeItemList = contingencyFeeItemList;
                ret.projectInstallationWorkCostList = projectInstallationWorkCostList;
                ret.EquipmentCostList = EquipmentCostList;
                ret.EquipmentCostItemList = EquipmentCostItemList;
                ret.ChargeItemList = ChargeItemList;
                ret.OtherCostList = OtherCostList;
                ret.statutoryFeesGroupList1 = statutoryFeesGroupList1;
                ret.statutoryFeesGroupList2 = statutoryFeesGroupList2;
                ret.statutoryFeesGroupList3 = statutoryFeesGroupList3;
                ret.statutoryFeesItemList1 = statutoryFeesItemList1;
                ret.statutoryFeesItemList2 = statutoryFeesItemList2;
                ret.statutoryFeesItemList3 = statutoryFeesItemList3;
                ret.sectionalWorksList = sectionalWorksList;
                ret.unitWorksList = unitWorksList;
                ret.summaryOfBasicCostList = summaryOfBasicCostList;
                ret.divisionalWorksList = divisionalWorksList;
                ret.workElementList = workElementList;
                ret.summaryOfCostList = summaryOfCostList;
                ret.summaryItemList = summaryItemList;
                ret.expressElementList = expressElementList;
                ret.workContentList = workContentList;
                ret.normList = normList;
                ret.combinedNormList = combinedNormList;
                ret.unitPriceCalculationOfItemList = unitPriceCalculationOfItemList;
                ret.sundryCostsGroupList = sundryCostsGroupList;
                ret.sundryCostsItemList = sundryCostsItemList;
                ret.provisionalSumsGroupList = provisionalSumsGroupList;
                ret.provisionalSumsItemList = provisionalSumsItemList;
                ret.provisionalMaterialGroupList = provisionalMaterialGroupList;
                ret.provisionalMaterialItemList = provisionalMaterialItemList;
                ret.specialtyProvisionalPriceGroupList = specialtyProvisionalPriceGroupList;
                ret.specialtyProvisionalPriceItemList = specialtyProvisionalPriceItemList;
                ret.dayWorkRateGroupList = dayWorkRateGroupList;
                ret.dayWorkRateItemList = dayWorkRateItemList;
                ret.mainContractorAttendanceGroupList = mainContractorAttendanceGroupList;
                ret.mainContractorAttendanceItemList = mainContractorAttendanceItemList;
                ret.siteInstructionCostGroupList = siteInstructionCostGroupList;
                ret.siteInstructionCostItemList = siteInstructionCostItemList;
                ret.claimsCostGroupList = claimsCostGroupList;
                ret.claimsCostItemList = claimsCostItemList;
                ret.statutoryFeesGroupList = statutoryFeesGroupList;
                ret.statutoryFeesItemList = statutoryFeesItemList;
                ret.taxGroupList = taxGroupList;
                ret.taxItemList = taxItemList;
                #endregion

                if (errMessageList != "")
                    errMessageList = "错误提示：\n" + errMessageList + "请联系计价软件公司！\n";
                if (errDateMessageList != "")
                {
                    errMessageList = errMessageList + errDateMessageList;
                }

                ret.ExsultMessage = errMessageList;
            }
            catch (Exception ex)
            {
                ret.HidErrMessage = ex.ToString();
                ret.ExsultMessage = "您提交的xml文件格式不符合交换标准，第一步：请您确认是否按照造价监测数据接口导出的XML文件；第二步：如果确认第一步没有问题，请联系北京建科研软件技术有限公司：400-825-113进行咨询。";
            }

            return ret;
        }
        #endregion


        #region xml解析基础方法
        /// <summary>
        /// 解析建筑安装工程费节点下
        /// </summary>
        /// <param name="ResourceNode">Resource节点</param>
        /// <param name="ptablepk">Resource节点的父表主键</param>
        private void ProjectInstallationWorkCostConvert(XmlNode ResourceNode, Guid ptablepk, Guid mainProjectId, int valuationMethod,ref string errMessage)
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
                                    errMessage += "● " + sectionalWorksModel.Name + "单项工程表中字段格式不正确；" + errMessageTemp+"\n";
                                }
                                sectionalWorksModel.Id = Guid.NewGuid();
                                sectionalWorksModel.ProjectfeeId = ptablepk;
                                sectionalWorksModel.SortNum = num;
                                sectionalWorksModel.MainProjectId = mainProjectId;
                                //插入数据库时出错，去掉 ' 和 -- 
                                sectionalWorksModel.Name = sectionalWorksModel.Name.Replace("'", "").Replace("--", "");
                                sectionalWorksModel.Segment = sectionalWorksModel.Segment.Replace("'", "").Replace("--", "");
                                sectionalWorksList.Add(sectionalWorksModel);
                                SectionalWorksConvert(node, sectionalWorksModel.Id, mainProjectId, valuationMethod, sectionalWorksModel.Id, ref errMessageTemp);//检查子节点
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;
                                num++;
                            }
                            break;
                        //扩展项
                        case "othercost":
                            var list = GetTreeNodes<OtherCost>(mainProjectId, node, ptablepk, ref errMessageTemp, "PF_SW_Id");
                            if (list != null)
                            {
                                if (errMessageTemp != "")
                                {
                                    errMessage += "● 扩展项表中字段格式不正确；";
                                }
                                OtherCostList.AddRange(list);
                            }
                            break;
                        //工料机汇总
                        case "labourmaterialsequipmentsmachinessummary":
                            var labourMachinesSummarysModel = XAttrConvert<LabourMachinesSummary>.Model(node.Attributes, ref errMessageTemp);
                            if (labourMachinesSummarysModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + labourMachinesSummarysModel.Name + "工料机汇总表中字段格式不正确；" + errMessageTemp+"\n";

                                ResourceConvert(node, ptablepk, mainProjectId, sortGLJ, ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;

                                sortGLJ++;
                            }
                            break;
                        //评标主要材料
                        case "bidevaluationmainmaterial":
                            var bidEvaluationMainMaterialModel = XAttrConvert<BidEvaluationMainMaterial>.Model(node.Attributes, ref errMessageTemp);
                            if (bidEvaluationMainMaterialModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + bidEvaluationMainMaterialModel.Name + "评标主要材料表中字段格式不正确；" + errMessageTemp+"\n";
                                bidEvaluationMainMaterialModel.Id = Guid.NewGuid();
                                bidEvaluationMainMaterialModel.ProjectId = ptablepk;
                                bidEvaluationMainMaterialModel.MainProjectId = mainProjectId;
                                bidEvaluationMainMaterialModel.SortNum = sortB;
                                BEMMList.Add(bidEvaluationMainMaterialModel);
                                sortB++;
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析单项工程节点下
        /// </summary>
        /// <param name="ResourceNode">Resource节点</param>
        /// <param name="ptablepk">Resource节点的父表主键</param>
        private void SectionalWorksConvert(XmlNode ResourceNode, Guid ptablepk, Guid mainProjectId, int valuationMethod, Guid swId,ref string errMessage)
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
                            var SOCModel = XAttrConvert<SummaryOfCost>.Model(node.Attributes,ref errMessageTemp);
                            if (SOCModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + "费用汇总表中字段格式不正确；" + errMessageTemp+"\n";
                                SOCModel.id = Guid.NewGuid();
                                SOCModel.ProjectId = ptablepk;
                                SOCModel.MainProjectId = mainProjectId;
                                SOCModel.SortNum = sortSC;
                                summaryOfCostList.Add(SOCModel);
                                sortSC++;
                            }
                            break;
                        //单项工程
                        case "sectionalworks":
                            var sectionalWorksModel = XAttrConvert<SectionalWorks>.Model(node.Attributes, ref errMessageTemp);
                            if (sectionalWorksModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + sectionalWorksModel.Name + "单项工程表中字段格式不正确；" + errMessageTemp+"\n";
                                sectionalWorksModel.Id = Guid.NewGuid();
                                sectionalWorksModel.ProjectfeeId = ptablepk;
                                sectionalWorksModel.SortNum = sortSW;
                                sectionalWorksModel.MainProjectId = mainProjectId;
                                //插入数据库时出错，去掉 ' 和 -- 
                                sectionalWorksModel.Name = sectionalWorksModel.Name.Replace("'", "").Replace("--", "");
                                sectionalWorksModel.Segment = sectionalWorksModel.Segment.Replace("'", "").Replace("--", "");
                                sectionalWorksList.Add(sectionalWorksModel);
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
                                if (errMessageTemp!="")
                                    errMessage += "● " + unitWorksModel.Name + "单位工程表中字段格式不正确；" + errMessageTemp+"\n";
                                unitWorksModel.Id = Guid.NewGuid();
                                unitWorksModel.SortNum = num;
                                unitWorksModel.SectionalWorksId = ptablepk;
                                //插入数据库时出错，去掉 ' 和 -- 
                                unitWorksModel.Name = unitWorksModel.Name.Replace("'", "").Replace("--", "");
                                unitWorksModel.Segment= unitWorksModel.Segment.Replace("'", "").Replace("--", "");
                                unitWorksList.Add(unitWorksModel);
                                num++;
                                UnitWorksConvert(node, unitWorksModel.Id, mainProjectId, valuationMethod, swId, ref errMessageTemp);//检查子节点
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;
                            }
                            break;
                        //扩展项
                        case "othercost":
                            var list = GetTreeNodes<OtherCost>(mainProjectId, node, ptablepk,ref errMessageTemp, "PF_SW_Id");
                            if (list != null) {
                                if (errMessageTemp != "")
                                    errMessage += "● 扩展项表中字段格式不正确；" + errMessageTemp+"\n";
                                OtherCostList.AddRange(list); 
                            }
                            break;
                        //措施项目
                        case "preliminaries":
                            PreliminariesConvert(node, ptablepk, mainProjectId, valuationMethod, swId, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
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
        private void PreliminariesConvert(XmlNode node, Guid pTablePk, Guid mainProjectId, int valuationMethod, Guid swId,ref string errMessage)
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
                                    errMessage += "● 合计费用表中字段格式不正确；" + errMessageTemp+"\n";
                                cost.Id = Guid.NewGuid();
                                cost.CostFacherId = pTablePk;
                                cost.FatherNode = "Preliminaries";
                                cost.SortNum = sortSBC;
                                cost.MainProjectId = mainProjectId;

                                summaryOfBasicCostList.Add(cost);
                                sortSBC++;
                                int sortSBCTwo = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    var addiCost = XAttrConvert<AddiCost>.Model(node2.Attributes, ref errMessageTemp);
                                    if (addiCost != null)
                                    {
                                        if (errMessageTemp != "")
                                            errMessage += "● " + addiCost.Name + "补充费用表中字段格式不正确；" + errMessageTemp+"\n";
                                        addiCost.id = Guid.NewGuid();
                                        addiCost.CostId = cost.Id;
                                        addiCost.SortNum = sortSBCTwo;
                                        addiCostList.Add(addiCost);
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
                                        errMessage += "● " + works.Name + "分部工程表中字段格式不正确；"  + errMessageTemp+"\n";
                                    works.Id = Guid.NewGuid();
                                    works.MainProjectId = mainProjectId;
                                    works.SortNum = numDivisionalWorks;
                                    works.DWorksFatherId = pTablePk;
                                    works.FatherNodeName = "Preliminaries";
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    works.Name = works.Name.Replace("'", "").Replace("--", "");
                                    divisionalWorksList.Add(works);
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
                                        errMessage += "● " + workElement.Name + "清单项目表中字段格式不正确；"  + errMessageTemp+"\n";
                                    workElement.Id = Guid.NewGuid();
                                    workElement.SortNum = numWorkElement;
                                    workElement.WorksEleFatherId = pTablePk;
                                    workElement.FatherNodeName = "Preliminaries";
                                    workElement.MainProjectId = mainProjectId;
                                    workElement.SectionalWorksId = swId;
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    workElement.Name = workElement.Name.Replace("'", "").Replace("--","");
                                    workElement.Attr = workElement.Attr.Replace("'", "").Replace("--", "");
                                    workElement.WorkContent = workElement.WorkContent.Replace("'", "").Replace("--", "");
                                    workElementList.Add(workElement);
                                    numWorkElement++;
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
        private void UnitWorksConvert(XmlNode ResourceNode, Guid ptablepk, Guid mainProjectId, int valuationMethod, Guid swId,ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (ResourceNode != null && ResourceNode.ChildNodes.Count > 0)
            {
                int summaryofcostSortNum = 1;
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
                                if (attrInfoList1 != null) {
                                    if (errMessageTemp != "")
                                        errMessage += "● 工程特征信息表中字段格式不正确；";
                                    attrInfoList.AddRange(attrInfoList1); 
                                }
                            }
                            break;
                        //补充信息
                        case "addiinfo":
                            var addInfoList1 = GetTreeNodes<AddInfoItem>(mainProjectId, node, ptablepk, ref errMessageTemp);
                            if (addInfoList1 != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● 补充信息表中字段格式不正确；";
                                addInfoList.AddRange(addInfoList1);
                            }
                            break;
                        //费用汇总
                        case "summaryofcost":
                            var SOCModel = XAttrConvert<SummaryOfCost>.Model(node.Attributes, ref errMessageTemp);
                            if (SOCModel != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● 费用汇总表中字段格式不正确；"  + errMessageTemp+"\n";
                                SOCModel.id = Guid.NewGuid();
                                SOCModel.ProjectId = ptablepk;
                                SOCModel.MainProjectId = mainProjectId;
                                SOCModel.SortNum = summaryofcostSortNum;
                                summaryOfCostList.Add(SOCModel);
                                summaryofcostSortNum++;
                            }
                            break;
                        //单位工程费用汇总
                        case "unitworkssummary":
                            if (node.ChildNodes.Count > 0)
                            {
                                SummaryItemConvert(node, ptablepk, ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;
                            }
                            break;
                        //分部分项工程
                        case "divisionalandelementalworks":
                            DivisionalAndElementalWorksConvart(node, ptablepk, "divisionalandelementalworks", mainProjectId, valuationMethod, swId, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            break;
                        //措施项目
                        case "preliminaries":
                            PreliminariesConvert(node, ptablepk, mainProjectId, valuationMethod, swId, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            break;
                        //其他项目
                        case "sundry":
                            SundryConvert(node, ptablepk, mainProjectId, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            break;
                        //规费
                        case "statutoryfees":
                            GroupItemConvert<StatutoryFeesGroup, StatutoryFeesItem>(ref statutoryFeesGroupList, ref statutoryFeesItemList, mainProjectId,
                                node, ptablepk, "SFG_UW_Id", ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += "● 规费表中字段格式不正确；"  + errMessageTemp+"\n";
                            break;
                        //税金/增值税销项税额
                        case "tax":
                            GroupItemConvert<TaxGroup, TaxItem>(ref taxGroupList, ref taxItemList, mainProjectId, node, ptablepk, "TG_UW_Id", ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += "● 税金/增值税销项税额表中字段格式不正确；"  + errMessageTemp+"\n";
                            break;
                        //工料机汇总
                        case "labourmaterialsequipmentsmachinessummary":
                            ResourceConvert(node, ptablepk, mainProjectId, clSortNum, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            clSortNum++;
                            break;
                        //评标主要材料
                        case "bidevaluationmainmaterial":
                            if (node != null && node.ChildNodes.Count > 0)
                            {
                                int bmSortNum = 1;
                                foreach (XmlNode node1 in node.ChildNodes)
                                {
                                    BidEvaluationMainMaterial item = XAttrConvert<BidEvaluationMainMaterial>.Model(node1.Attributes, ref errMessageTemp);
                                    if (item != null)
                                    {
                                        if (errMessageTemp != "")
                                            errMessage += "● 评标主要材料表中字段格式不正确；"  + errMessageTemp+"\n";
                                        item.ProjectId = ptablepk;
                                        item.MainProjectId = mainProjectId;
                                        item.SortNum = bmSortNum;
                                        BEMMList.Add(item);
                                        bmSortNum++;
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }

        private void SummaryItemConvert(XmlNode node, Guid pTablePk,ref string errMessage)
        {
            errMessage="";
            string errMessageTemp="";
            if (node.ChildNodes.Count > 0)
            {
                int numSummaryItem = 1;
                int numSummaryGroup = 1;
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    var item = XAttrConvert<SummaryItem>.Model(node2.Attributes, ref errMessageTemp);
                    if (node2.Name.ToLower() == "unitworkssummaryitem")
                    {
                        if (item != null)
                        {
                            if (errMessageTemp != "")
                                errMessage += "● 单位工程费用汇总明细表中字段格式不正确；"  + errMessageTemp+"\n";
                            item.Id = Guid.NewGuid();
                            item.SortNum = numSummaryItem;
                            item.UnitWorksId = pTablePk;
                            summaryItemList.Add(item);
                            numSummaryItem++;
                        }
                    }
                    if (node2.Name.ToLower() == "unitworkssummarygroup")
                    {
                        if (item != null)
                        {
                            if (errMessageTemp != "")
                                errMessage += "● 单位工程费用汇总标题表中字段格式不正确；"  + errMessageTemp+"\n";
                            item.Id = Guid.NewGuid();
                            item.SortNum = numSummaryGroup;
                            item.UnitWorksId = pTablePk;
                            summaryItemList.Add(item);
                            SummaryItemConvert(node2, item.Id, ref errMessageTemp);
                            if (errMessageTemp != "")
                                errMessage += errMessageTemp;
                            numSummaryGroup++;
                        }
                    }
                }
            }
        }

        private void SundryGroupConvert(XmlNode node, Guid pTablePk, Guid mainProjectId, int pSortNum,ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (node.ChildNodes.Count > 0)
            {
                var group1 = XAttrConvert<SundryCostsGroup>.Model(node.Attributes,ref errMessageTemp);
                if (group1 != null)
                {
                    if (errMessageTemp != "")
                        errMessage += "● " + group1.Name + "其他项目费标题表中字段格式不正确；"  + errMessageTemp+"\n";
                    group1.Id = Guid.NewGuid();
                    group1.UnitWorksId = pTablePk;
                    group1.MainProjectId = mainProjectId;
                    group1.SortNum = pSortNum;
                    sundryCostsGroupList.Add(group1);
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
                                    errMessage += "● " + item.Name + "其他项目费明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                item.Id = Guid.NewGuid();
                                item.SortNum = numSundryCostsItem;
                                item.SundryCostsGroupId = group1.Id;
                                sundryCostsItemList.Add(item);
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
                var group1 = XAttrConvert<SundryCostsGroup>.Model(node.Attributes,ref errMessageTemp);
                if (group1 != null)
                {
                    if (errMessageTemp != "")
                        errMessage += "● " + group1.Name + "其他项目费标题表中字段格式不正确；"  + errMessageTemp+"\n";
                    group1.Id = Guid.NewGuid();
                    group1.UnitWorksId = pTablePk;
                    group1.MainProjectId = mainProjectId;
                    sundryCostsGroupList.Add(group1);
                }
            }
        }

        /// <summary>
        /// 解析其他项目节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void SundryConvert(XmlNode node, Guid pTablePk, Guid mainProjectId,ref string errMessage)
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
                            var group = XAttrConvert<SundryCostsGroup>.Model(node1.Attributes, ref errMessageTemp);
                            if (group != null)
                            {
                                if (errMessageTemp!="")
                                    errMessage += "● " + group.Name + "其他项目费表中字段格式不正确；"  + errMessageTemp+"\n";
                                group.Id = Guid.NewGuid();
                                group.UnitWorksId = pTablePk;
                                group.MainProjectId = mainProjectId;
                                group.SortNum = sundrycostsSortNum;
                                sundryCostsGroupList.Add(group);
                                sundrycostsSortNum++;
                                int numSundryCostsItem = 1;
                                int numSundrycostsgroup = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "sundrycostsitem")
                                    {
                                        var item = XAttrConvert<SundryCostsItem>.Model(node2.Attributes, ref errMessageTemp);
                                        if (item != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● " + item.Name + "其他项目费明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                            item.Id = Guid.NewGuid();
                                            item.SortNum = numSundryCostsItem;
                                            item.SundryCostsGroupId = group.Id;
                                            sundryCostsItemList.Add(item);
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
                            break;
                        //暂列金额
                        case "provisionalsums":
                            var pgroup = XAttrConvert<ProvisionalSumsGroup>.Model(node1.Attributes, ref errMessageTemp);
                            if (pgroup != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + pgroup.Name + "暂列金额表中字段格式不正确；"  + errMessageTemp+"\n";
                                pgroup.Id = Guid.NewGuid();
                                pgroup.UnitWorksId = pTablePk;
                                pgroup.SortNum= provisionalsumsSortNum;
                                pgroup.MainProjectId = mainProjectId;
                                provisionalSumsGroupList.Add(pgroup);
                                provisionalsumsSortNum++;
                                int itemSortNum = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "provisionalsumsitem")
                                    {
                                        var item = XAttrConvert<ProvisionalSumsItem>.Model(node2.Attributes, ref errMessageTemp);
                                        if (item != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● " + pgroup.Name + "暂列金额明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                            item.Id = Guid.NewGuid();
                                            item.ProvisionalGroupId = pgroup.Id;
                                            item.MainProjectId = mainProjectId;
                                            item.SortNum = itemSortNum;
                                            provisionalSumsItemList.Add(item);
                                            itemSortNum++;
                                        }
                                    }
                                }
                                GroupItemConvert<ProvisionalSumsGroup, ProvisionalSumsItem>(ref provisionalSumsGroupList, ref provisionalSumsItemList, mainProjectId,
                                    node1, pgroup.Id, "ProvisionalGroupId", ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += "● 暂列金额表中字段格式不正确；"  + errMessageTemp+"\n";
                            }
                            break;
                        //暂估价材料
                        case "provisionalmaterial":
                            var pmgroup = XAttrConvert<ProvisionalMaterialGroup>.Model(node1.Attributes, ref errMessageTemp);
                            if (pmgroup != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + pmgroup.Name + "暂估价材料表中字段格式不正确；"  + errMessageTemp+"\n";
                                pmgroup.Id = Guid.NewGuid();
                                pmgroup.UnitWorksId = pTablePk;
                                pmgroup.SortNum = provisionalmaterialSortNum;
                                pmgroup.MainProjectId = mainProjectId;
                                provisionalMaterialGroupList.Add(pmgroup);
                                provisionalmaterialSortNum++;
                                int itemSortNum = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "provisionalmaterialitem")
                                    {
                                        var item = XAttrConvert<ProvisionalMaterialItem>.Model(node2.Attributes, ref errMessageTemp);
                                        if (item != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● " + pmgroup.Name + "暂估价材料明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                            item.Id = Guid.NewGuid();
                                            item.ProvisionalMaterialGroupId = pmgroup.Id;
                                            item.MainProjectId = mainProjectId;
                                            item.SortNum = itemSortNum;
                                            provisionalMaterialItemList.Add(item);
                                            itemSortNum++;
                                        }
                                    }
                                }
                                GroupItemConvert<ProvisionalMaterialGroup, ProvisionalMaterialItem>(ref provisionalMaterialGroupList, ref provisionalMaterialItemList, mainProjectId,
                                    node1, pmgroup.Id, "ProvisionalMaterialGroupId", ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += "● 暂估价材料表中字段格式不正确；"  + errMessageTemp+"\n";
                            }
                            break;
                        //专业工程暂估价
                        case "specialtyprovisionalprice":
                            var sppgroup = XAttrConvert<SpecialtyProvisionalPriceGroup>.Model(node1.Attributes, ref errMessageTemp);
                            if (sppgroup != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + sppgroup.Name + "专业工程暂估价表中字段格式不正确；"  + errMessageTemp+"\n";
                                sppgroup.Id = Guid.NewGuid();
                                sppgroup.UnitWorksId = pTablePk;
                                sppgroup.SortNum = specialtyprovisionalpriceSortNum;
                                sppgroup.MainProjectId = mainProjectId;
                                specialtyProvisionalPriceGroupList.Add(sppgroup);
                                specialtyprovisionalpriceSortNum++;
                                int itemSortNum = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "specialtyprovisionalpriceitem")
                                    {
                                        var item = XAttrConvert<SpecialtyProvisionalPriceItem>.Model(node2.Attributes, ref errMessageTemp);
                                        if (item != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● " + item.Name + "专业工程暂估价明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                            item.Id = Guid.NewGuid();
                                            item.SpecialtyProvisionalPriceGroupId = sppgroup.Id;
                                            item.MainProjectId = mainProjectId;
                                            item.SortNum = itemSortNum;
                                            specialtyProvisionalPriceItemList.Add(item);
                                            itemSortNum++;
                                        }
                                    }
                                }
                                GroupItemConvert<SpecialtyProvisionalPriceGroup, SpecialtyProvisionalPriceItem>(ref specialtyProvisionalPriceGroupList, ref specialtyProvisionalPriceItemList, mainProjectId,
                                    node1, sppgroup.Id, "SpecialtyProvisionalPriceGroupId", ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += "● " + sppgroup.Name + "专业工程暂估价表中字段格式不正确；"  + errMessageTemp+"\n";
                            }
                            break;
                        //计日工
                        case "dayworkrate":
                            var dwrggroup = XAttrConvert<DayWorkRateGroup>.Model(node1.Attributes, ref errMessageTemp);
                            if (dwrggroup != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + dwrggroup.Name + "计日工标题表中字段格式不正确；"  + errMessageTemp+"\n";
                                dwrggroup.Id = Guid.NewGuid();
                                dwrggroup.UnitWorksId = pTablePk;
                                dwrggroup.MainProjectId = mainProjectId;
                                dwrggroup.SortNum = dayworkrateSortNum;
                                dayWorkRateGroupList.Add(dwrggroup);
                                dayworkrateSortNum++;
                                int itemSortNum = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "dayworkrateitem")
                                    {
                                        var item = XAttrConvert<DayWorkRateItem>.Model(node2.Attributes, ref errMessageTemp);
                                        if (item != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● " + item.Name + "计日工明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                            item.Id = Guid.NewGuid();
                                            item.DayWorkRateGroupId = dwrggroup.Id;
                                            item.MainProjectId = mainProjectId;
                                            item.SortNum = itemSortNum;
                                            dayWorkRateItemList.Add(item);
                                            itemSortNum++;
                                        }
                                    }
                                }
                                GroupItemConvert<DayWorkRateGroup, DayWorkRateItem>(ref dayWorkRateGroupList, ref dayWorkRateItemList, mainProjectId,
                                    node1, dwrggroup.Id, "DayWorkRateGroupId", ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += "● 计日工表中字段格式不正确；"  + errMessageTemp+"\n";
                            }
                            break;
                        //总承包服务费
                        case "maincontractorattendance":
                            var magggroup = XAttrConvert<MainContractorAttendanceGroup>.Model(node1.Attributes, ref errMessageTemp);
                            if (magggroup != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● 总承包服务费标题表中字段格式不正确；"  + errMessageTemp+"\n";
                                magggroup.Id = Guid.NewGuid();
                                magggroup.UnitWorksId = pTablePk;
                                magggroup.MainProjectId = mainProjectId;
                                magggroup.SortNum = maincontractorattendanceSortNum;
                                mainContractorAttendanceGroupList.Add(magggroup);
                                maincontractorattendanceSortNum++;
                                int itemSortNum = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "maincontractorattendanceitem")
                                    {
                                        var item = XAttrConvert<MainContractorAttendanceItem>.Model(node2.Attributes, ref errMessageTemp);
                                        if (item != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● 总承包服务费明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                            item.Id = Guid.NewGuid();
                                            item.MainContractorAttendanceGroupId = magggroup.Id;
                                            item.MainProjectId = mainProjectId;
                                            item.SortNum = itemSortNum;
                                            mainContractorAttendanceItemList.Add(item);
                                            itemSortNum++;
                                        }
                                    }
                                }
                                GroupItemConvert<MainContractorAttendanceGroup, MainContractorAttendanceItem>(ref mainContractorAttendanceGroupList, ref mainContractorAttendanceItemList, mainProjectId,
                                    node1, magggroup.Id, "MainContractorAttendanceGroupId", ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += "● 总承包服务费表中字段格式不正确；"  + errMessageTemp+"\n";
                            }
                            break;
                        //索赔费用
                        case "claimscost":
                            var ccgroup = XAttrConvert<ClaimsCostGroup>.Model(node1.Attributes, ref errMessageTemp);
                            if (ccgroup != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● 索赔费用标题表中字段格式不正确；"  + errMessageTemp+"\n";
                                ccgroup.Id = Guid.NewGuid();
                                ccgroup.UnitWorksId = pTablePk;
                                ccgroup.MainProjectId = mainProjectId;
                                ccgroup.SortNum = claimscostSortNum;
                                claimsCostGroupList.Add(ccgroup);
                                claimscostSortNum++;
                                int itemSortNum = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "claimscostitem")
                                    {
                                        var item = XAttrConvert<ClaimsCostItem>.Model(node2.Attributes, ref errMessageTemp);
                                        if (item != null)
                                        {
                                            item.Id = Guid.NewGuid();
                                            item.ClaimsCostGroupId = ccgroup.Id;
                                            item.MainProjectId = mainProjectId;
                                            item.SortNum = itemSortNum;
                                            claimsCostItemList.Add(item);
                                            itemSortNum++;
                                        }
                                    }
                                }
                                GroupItemConvert<ClaimsCostGroup, ClaimsCostItem>(ref claimsCostGroupList, ref claimsCostItemList, mainProjectId,
                                    node1, ccgroup.Id, "ClaimsCostGroupId", ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += "● 索赔费用表中字段格式不正确；"  + errMessageTemp+"\n";
                            }
                            break;
                        //现场签证费用
                        case "siteinstructioncost":
                            var sicgroup = XAttrConvert<SiteInstructionCostGroup>.Model(node1.Attributes, ref errMessageTemp);
                            if (sicgroup != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● 现场签证标题表中字段格式不正确；"  + errMessageTemp+"\n";
                                sicgroup.Id = Guid.NewGuid();
                                sicgroup.UnitWorksId = pTablePk;
                                sicgroup.MainProjectId = mainProjectId;
                                sicgroup.SortNum = siteinstructioncostSortNum;
                                siteInstructionCostGroupList.Add(sicgroup);
                                siteinstructioncostSortNum++;
                                int itemSortNum = 1;
                                foreach (XmlNode node2 in node1.ChildNodes)
                                {
                                    if (node2.Name.ToLower() == "siteinstructioncostitem")
                                    {
                                        var item = XAttrConvert<SiteInstructionCostItem>.Model(node2.Attributes, ref errMessageTemp);
                                        if (item != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● 现场签证明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                            item.Id = Guid.NewGuid();
                                            item.SiteInstructionCostGroupId = sicgroup.Id;
                                            item.MainProjectId = mainProjectId;
                                            item.SortNum = itemSortNum;
                                            siteInstructionCostItemList.Add(item);
                                            itemSortNum++;
                                        }
                                    }
                                }
                                GroupItemConvert<SiteInstructionCostGroup, SiteInstructionCostItem>(ref siteInstructionCostGroupList, ref siteInstructionCostItemList, mainProjectId,
                                    node1, sicgroup.Id, "SiteInstructionCostGroupId", ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += "● 现场签证表中字段格式不正确；"  + errMessageTemp+"\n";
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析分部分项工程节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void DivisionalAndElementalWorksConvart(XmlNode node, Guid pTablePk, string pTablePkName, Guid mainProjectId, int valuationMethod, Guid swId,ref string errMessage)
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
                                var cost = XAttrConvert<SummaryOfBasicCost>.Model(node1.Attributes,ref errMessageTemp);
                                if (cost != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "● 合计费用表中字段格式不正确；"  + errMessageTemp+"\n";

                                    cost.Id = Guid.NewGuid();
                                    cost.CostFacherId = pTablePk;
                                    cost.FatherNode = pTablePkName;
                                    cost.MainProjectId = mainProjectId;
                                    cost.SortNum = numCost;
                                    summaryOfBasicCostList.Add(cost);
                                    numCost++;
                                    int childNodesCostSortNum = 1;
                                    foreach (XmlNode node2 in node1.ChildNodes)
                                    {
                                        var addiCost = XAttrConvert<AddiCost>.Model(node2.Attributes, ref errMessageTemp);
                                        if (addiCost != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● " + addiCost.Name + "补充费用表中字段格式不正确；"  + errMessageTemp+"\n";
                                            addiCost.id = Guid.NewGuid();
                                            addiCost.CostId = cost.Id;
                                            addiCost.SortNum = childNodesCostSortNum;
                                            addiCostList.Add(addiCost);
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
                                        errMessage += "● " + works.Name + "分部工程表中字段格式不正确；"  + errMessageTemp+"\n";
                                    works.Id = Guid.NewGuid();
                                    works.MainProjectId = mainProjectId;
                                    works.SortNum = numDivisionalWorks;
                                    works.DWorksFatherId = pTablePk;
                                    works.FatherNodeName = pTablePkName;
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    works.Name = works.Name.Replace("'", "").Replace("--", "");
                                    divisionalWorksList.Add(works);
                                    numDivisionalWorks++;
                                    DivisionalWorksConvart(node1, works.Id, mainProjectId, valuationMethod, swId,ref errMessageTemp);
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
                                        errMessage += "● " + workElement.Name + "清单项目表中字段格式不正确；"  + errMessageTemp+"\n";
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
                                    workElementList.Add(workElement);
                                    numWorkElement++;
                                    WorkElementConvert(node1, workElement.Id, "WorkElement", mainProjectId, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                                break;
                            }
                        //定额计价项目
                        case "norm":
                            //判断是否为清单计价
                            if (valuationMethod == 2)
                            {
                                var norm = XAttrConvert<Norm>.Model(node1.Attributes, ref errMessageTemp);
                                if (norm != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "● " + norm.Name + "定额子目表中字段格式不正确；"  + errMessageTemp+"\n";
                                    norm.Id = Guid.NewGuid();
                                    norm.SortNum = numNorm;
                                    norm.NormFatherId = pTablePk;
                                    norm.FatherNodeName = pTablePkName;
                                    norm.MainProjectId = mainProjectId;
                                    normList.Add(norm);
                                    numNorm++;
                                    NormConvert(node1, norm.Id, "Norm", mainProjectId, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析分部工程节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void DivisionalWorksConvart(XmlNode node, Guid pTablePk, Guid mainProjectId, int valuationMethod, Guid swId,ref string errMessage)
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
                                        errMessage += "● 合计费用表中字段格式不正确；"  + errMessageTemp+"\n";

                                    cost.Id = Guid.NewGuid();
                                    cost.CostFacherId = pTablePk;
                                    cost.FatherNode = "DivisionalWorks";
                                    cost.MainProjectId = mainProjectId;
                                    cost.SortNum = numCost;
                                    summaryOfBasicCostList.Add(cost);
                                    numCost++;
                                    int childNodesSortNum = 1;
                                    foreach (XmlNode node2 in node1.ChildNodes)
                                    {
                                        var addiCost = XAttrConvert<AddiCost>.Model(node2.Attributes, ref errMessageTemp);
                                        if (addiCost != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● " + addiCost.Name + "补充费用表中字段格式不正确；"  + errMessageTemp+"\n";

                                            addiCost.id = Guid.NewGuid();
                                            addiCost.CostId = cost.Id;
                                            addiCost.SortNum = childNodesSortNum;
                                            addiCostList.Add(addiCost);
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
                                        errMessage += "● " + works.Name + "分部工程表中字段格式不正确；"  + errMessageTemp+"\n";

                                    works.Id = Guid.NewGuid();
                                    works.MainProjectId = mainProjectId;
                                    works.SortNum = numDivisionalWorks;
                                    works.DWorksFatherId = pTablePk;
                                    works.FatherNodeName = "DivisionalWorks";
                                    //插入数据库时出错，去掉 ' 和 -- 
                                    works.Name = works.Name.Replace("'", "").Replace("--", "");
                                    divisionalWorksList.Add(works);
                                    numDivisionalWorks++;
                                    DivisionalAndElementalWorksConvart(node1, works.Id, "divisionalworks", mainProjectId, valuationMethod, swId,ref errMessageTemp);
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
                                            errMessage += "● " + workElement.Name + "清单项目表中字段格式不正确；"  + errMessageTemp+"\n";
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
                                        workElementList.Add(workElement);
                                        numWorkElement++;
                                        WorkElementConvert(node1, workElement.Id, "WorkElement", mainProjectId, ref errMessageTemp);
                                        if (errMessageTemp != "")
                                            errMessage += errMessageTemp;
                                    }
                                }
                                break;
                            }
                        //定额计价项目
                        case "norm":
                            //判断是否为清单计价
                            if (valuationMethod == 2)
                            {
                                var norm = XAttrConvert<Norm>.Model(node1.Attributes, ref errMessageTemp);
                                if (norm != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "● " + norm.Name + "定额计价项目表中字段格式不正确；"  + errMessageTemp+"\n";
                                    norm.Id = Guid.NewGuid();
                                    norm.SortNum = numNorm;
                                    norm.NormFatherId = pTablePk;
                                    norm.FatherNodeName = "DivisionalWorks";
                                    norm.MainProjectId = mainProjectId;
                                    normList.Add(norm);
                                    numNorm++;
                                    NormConvert(node1, norm.Id, "Norm", mainProjectId, ref errMessageTemp);
                                    if (errMessageTemp != "")
                                        errMessage += errMessageTemp;
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 解析清单项目节点下
        /// </summary>
        /// <param name="node"></param>
        /// <param name="pTablePk"></param>
        private void WorkElementConvert(XmlNode node, Guid pTablePk, string fatherNodeName, Guid mainProjectId,ref string errMessage)
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
                                var cost = XAttrConvert<SummaryOfBasicCost>.Model(node1.Attributes,ref errMessageTemp);
                                if (cost != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "● 合计费用表中字段格式不正确；"  + errMessageTemp+"\n";

                                    cost.Id = Guid.NewGuid();
                                    cost.CostFacherId = pTablePk;
                                    cost.FatherNode = fatherNodeName;
                                    cost.MainProjectId = mainProjectId;
                                    cost.SortNum = numCost;
                                    summaryOfBasicCostList.Add(cost);
                                    numCost++;
                                    int childNodesSortNum = 1;
                                    foreach (XmlNode node2 in node1.ChildNodes)
                                    {
                                        var addiCost = XAttrConvert<AddiCost>.Model(node2.Attributes, ref errMessageTemp);
                                        if (addiCost != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● 补充费用表中字段格式不正确；"  + errMessageTemp+"\n";
                                            addiCost.id = Guid.NewGuid();
                                            addiCost.CostId = cost.Id;
                                            addiCost.SortNum = childNodesSortNum;
                                            addiCostList.Add(addiCost);
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
                                    errMessage += "● 工程量计算表中字段格式不正确；"  + errMessageTemp+"\n";
                                expressElement.Id = Guid.NewGuid();
                                expressElement.ExpItemFatherId = pTablePk;
                                expressElement.FatherNodeName = fatherNodeName;
                                expressElement.MainProjectId = mainProjectId;
                                expressElement.SortNum = numExpresselement;
                                expressElementList.Add(expressElement);
                                numExpresselement++;
                            }
                            break;
                        //工作内容
                        case "workcontent":
                            var workContent = XAttrConvert<WorkContent>.Model(node1.Attributes, ref errMessageTemp);
                            if (workContent != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● 工作内容表中字段格式不正确；"  + errMessageTemp+"\n";

                                workContent.Id = Guid.NewGuid();
                                workContent.WorkElementId = pTablePk;
                                workContent.MainProjectId = mainProjectId;
                                workContent.SortNum = numWorkContent;
                                workContentList.Add(workContent);
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
                                    //定额子目
                                    if (node2.Name.ToLower() == "norm")
                                    {
                                        var norm2 = XAttrConvert<Norm>.Model(node2.Attributes, ref errMessageTemp);
                                        if (norm2 != null)
                                        {
                                            if (errMessageTemp != "")
                                                errMessage += "● " + norm2.Name + "定额子目表中字段格式不正确；" + errMessageTemp + "\n";

                                            norm2.Id = Guid.NewGuid();
                                            norm2.MainProjectId = mainProjectId;
                                            norm2.SortNum = numNorm2;
                                            norm2.NormFatherId = pTablePk;
                                            norm2.FatherNodeName = fatherNodeName;
                                            normList.Add(norm2);
                                            numNorm2++;
                                            NormConvert(node2, workContent.Id, "norm", mainProjectId, ref errMessageTemp);
                                            if (errMessageTemp != "")
                                                errMessage += errMessageTemp;
                                        }
                                    }
                                }
                            }
                            break;
                        //定额子目
                        case "norm":
                            var norm = XAttrConvert<Norm>.Model(node1.Attributes, ref errMessageTemp);
                            if (norm != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● " + norm.Name + "定额子目表中字段格式不正确；" + errMessageTemp + "\n";

                                norm.Id = Guid.NewGuid();
                                norm.SortNum = numNorm;
                                norm.NormFatherId = pTablePk;
                                norm.FatherNodeName = fatherNodeName;
                                norm.MainProjectId = mainProjectId;
                                normList.Add(norm);
                                numNorm++;
                                NormConvert(node1, norm.Id, "Norm", mainProjectId, ref errMessageTemp);
                                if (errMessageTemp != "")
                                    errMessage += errMessageTemp;
                            }
                            break;
                        //单价分析
                        case "priceanalysis":
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
        private void NormConvert(XmlNode node, Guid pTablePk, string fatherNodeName, Guid mainProjectId,ref string errMessage)
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
                                var item2 = XAttrConvert<LabourMaterialsEquipmentsMachinesElement>.Model(node1.Attributes,ref errMessageTemp);
                                if (item2 != null)
                                {
                                    if (errMessageTemp != "")
                                        errMessage += "● 工料机含量明细表中字段格式不正确；"  + errMessageTemp+"\n";
                                    item2.Id = Guid.NewGuid();
                                    item2.LMEMS_ID = pTablePk;
                                    item2.SortNum = gljSortNum;
                                    resElementItemList.Add(item2);
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
                                    errMessage += "● 工程量计算表中字段格式不正确；"  + errMessageTemp+"\n";
                                expressElement.Id = Guid.NewGuid();
                                expressElement.ExpItemFatherId = pTablePk;
                                expressElement.FatherNodeName = fatherNodeName;
                                expressElement.MainProjectId = mainProjectId;
                                expressElement.SortNum = expresselementSortNum;
                                expressElementList.Add(expressElement);
                                expresselementSortNum++;
                            }
                            break;
                        //组合定额
                        case "combinednorm":
                            var combinedNorm = XAttrConvert<CombinedNorm>.Model(node1.Attributes, ref errMessageTemp);
                            if (combinedNorm != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● 组合定额表中字段格式不正确；"  + errMessageTemp+"\n";
                                combinedNorm.Id = Guid.NewGuid();
                                combinedNorm.NormId = pTablePk;
                                combinedNorm.SortNum = combinednormSortNum;
                                combinedNormList.Add(combinedNorm);
                                combinednormSortNum++;
                            }
                            break;
                        //子目单价计算
                        case "unitpricecalculationofitem":
                            var unitPriceCalculationOfItem = XAttrConvert<UnitPriceCalculationOfItem>.Model(node1.Attributes, ref errMessageTemp);
                            if (unitPriceCalculationOfItem != null)
                            {
                                if (errMessageTemp != "")
                                    errMessage += "● 子目单价计算表中字段格式不正确；"  + errMessageTemp+"\n";
                                unitPriceCalculationOfItem.Id = Guid.NewGuid();
                                unitPriceCalculationOfItem.CItemFatherId = pTablePk;
                                unitPriceCalculationOfItem.MainProjectId = mainProjectId;
                                unitPriceCalculationOfItem.SortNum = unitpricecalculationofitemSortNum;
                                unitPriceCalculationOfItemList.Add(unitPriceCalculationOfItem);
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
            Guid grouppId, string itempIdname,ref string errMessage, string grouppIdname = "UnitWorksId", int level = 2)
            where TG : class,new()
            where TI : class,new()
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
                                    TI Item2 = XAttrConvert<TI>.Model(node2.Attributes,ref errMessageTemp);
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
        private void ResourceConvert(XmlNode ResourceNode, Guid ptablepk, Guid mainProjectId, int pSortNum,ref string errMessage)
        {
            errMessage = "";
            string errMessageTemp = "";
            if (ResourceNode != null)
            {
                LabourMachinesSummary item = XAttrConvert<LabourMachinesSummary>.Model(ResourceNode.Attributes,ref errMessageTemp);
                if (item != null)
                {
                    if (errMessageTemp != "")
                    {
                        errMessage += "● " + item.Name + "工料机汇总表中字段格式不正确；"  + errMessageTemp+"\n";
                    }
                    item.Id = Guid.NewGuid();
                    item.ProjectId = ptablepk;
                    item.MainProjectId = mainProjectId;
                    item.SortNum = pSortNum;
                    labourMachinesSummaryList.Add(item);

                    int sortNum = 1;
                    foreach (XmlNode node2 in ResourceNode.ChildNodes)
                    {
                        LabourMaterialsEquipmentsMachinesElement item2 = XAttrConvert<LabourMaterialsEquipmentsMachinesElement>.Model(node2.Attributes, ref errMessageTemp);
                        if (errMessageTemp != "")
                        {
                            errMessage += "● " + item.Name + "工料机含量明细表中字段格式不正确；"  + errMessageTemp+"\n";
                        }
                        item2.LMEMS_ID = item.Id;
                        item2.SortNum = sortNum;
                        resElementItemList.Add(item2);
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
        private List<T> GetTreeNodes<T>(Guid mainProjectId, XmlNode fNode, Guid FatherTablePk,ref string errMessage, String FatherTableName = "ProjectId", int level = 2) where T : class,new()
        {
            List<T> attrList = new List<T>();
            errMessage = "";
            string errMessageTemp="";
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
        public class XAttrConvert<T> where T : class,new()
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
                            try
                            {
                                property.SetValue(model, value);
                            }
                            catch(Exception ex)
                            {
                                errMessage += property.Name + "数据类型为；" + valueType + "" + "；当前值为：" + value + "；";
                            }
                        }
                    }

                    return model;
                }
                catch (Exception ex)
                {
                    return null;
                    throw ex;
                }
            }

            private static object ConvertTo(string convertibleValue, Type t,ref string valueType)
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