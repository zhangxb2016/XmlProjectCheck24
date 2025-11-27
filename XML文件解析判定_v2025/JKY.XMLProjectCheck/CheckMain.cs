using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using JKY.Models24;


namespace JKY.XMLProjectCheck
{

    public class CheckMain
    {
        #region 初始化变量
        List<AttrInfoItem> attrInfoList = new List<AttrInfoItem>();
        List<AddiInfoItem> addInfoList = new List<AddiInfoItem>();
        List<AddiCost> addiCostList = new List<AddiCost>();
        List<LabourMaterialsEquipmentsMachinesElement> resElementItemList = new List<LabourMaterialsEquipmentsMachinesElement>();
        List<ContingencyFeeGroup> contingencyFeeGroupList = new List<ContingencyFeeGroup>();
        List<ContingencyFeeItem> contingencyFeeItemList = new List<ContingencyFeeItem>();
        List<ProjectInstallationWorkCost> projectInstallationWorkCostList = new List<ProjectInstallationWorkCost>();
        List<EquipmentProcurementCost> EquipmentCostList = new List<EquipmentProcurementCost>();
        List<EquipmentProcurementCostItem> EquipmentCostItemList = new List<EquipmentProcurementCostItem>();
        List<UnitPriceCalculationOfItem> ChargeItemList = new List<UnitPriceCalculationOfItem>();
        List<OtherCost> OtherCostList = new List<OtherCost>();
        List<SectionalWorks> sectionalWorksList = new List<SectionalWorks>();
        List<UnitWorks> unitWorksList = new List<UnitWorks>();
        List<SummaryOfBasicCost> summaryOfBasicCostList = new List<SummaryOfBasicCost>();
        List<DivisionalWorks> divisionalWorksList = new List<DivisionalWorks>();
        List<WorkElement> workElementList = new List<WorkElement>();
        List<SummaryOfCost> summaryOfCostList = new List<SummaryOfCost>();
        List<ExpressElement> expressElementList = new List<ExpressElement>();
        List<WorkContent> workContentList = new List<WorkContent>();
        List<UnitPriceCalculationOfItem> unitPriceCalculationOfItemList = new List<UnitPriceCalculationOfItem>();
        List<SundryCostsGroup> sundryCostsGroupList = new List<SundryCostsGroup>();
        List<SundryCostsItem> sundryCostsItemList = new List<SundryCostsItem>();
        List<ProvisionalSumsGroup> provisionalSumsGroupList = new List<ProvisionalSumsGroup>();
        List<ProvisionalSumsItem> provisionalSumsItemList = new List<ProvisionalSumsItem>();
        List<SpecialtyProvisionalPriceGroup> specialtyProvisionalPriceGroupList = new List<SpecialtyProvisionalPriceGroup>();
        List<SpecialtyProvisionalPriceItem> specialtyProvisionalPriceItemList = new List<SpecialtyProvisionalPriceItem>();
        List<DayWorkRateGroup> dayWorkRateGroupList = new List<DayWorkRateGroup>();
        List<DayWorkRateItem> dayWorkRateItemList = new List<DayWorkRateItem>();
        List<MainContractorAttendanceGroup> mainContractorAttendanceGroupList = new List<MainContractorAttendanceGroup>();
        List<MainContractorAttendanceItem> mainContractorAttendanceItemList = new List<MainContractorAttendanceItem>();
       
        #endregion
        public ReturnModel<ConstructionProject> SaveXmlToDB(System.Xml.XmlDocument xml, string projectFeatureId,
    string projectFeatureName, string BuildTypeId, string fileName, string ProjectId, string HTID, string One, string Two, string Three, out string projectName, out string UploadMsg, out List<string> list)
        {
            ReturnModel<ConstructionProject> ret = new ReturnModel<ConstructionProject> { IsSuccess = 0 };
            ret.Msg = "";//初始化
            list = new List<string>();
            ConstructionProject CProjectModel = new ConstructionProject();
            //ConstructionProjectsIdTemp CProjectIdTempModel = new ConstructionProjectsIdTemp();
            Option OpModel = new Option();
            ProjectInfo PinfoModel = new ProjectInfo();
            TendererInfo TModel = new TendererInfo();
            BidderInfo BIModel = new BidderInfo();
            SummaryOfCost SOCModel = new SummaryOfCost();

            //OtherCostSums OtherCSModel = new OtherCostSums();
            ContingencyFee cfModel = new ContingencyFee();
            ConstructionCost CCModel = new ConstructionCost();
            //SpecifyCostSum SCSModel1 = new SpecifyCostSum();
            //SpecifyCostSum SCSModel2 = new SpecifyCostSum();
            //SpecifyCostSum SCSModel3 = new SpecifyCostSum();

            projectName = "";
            UploadMsg = "";

            try
            {
                XmlNode CPNode = xml.SelectSingleNode("/ConstructionProject");
                XmlNode SysInfoNode = xml.SelectSingleNode("/ConstructionProject/SystemInfo");

                var ReadXMLstart = Environment.TickCount;
                if (CPNode != null && SysInfoNode != null)
                {
                    AutoReeolveMethod24 armMethod = new AutoReeolveMethod24();
                    AutoReeolveCollection24 arcModel = armMethod.SaveXmlToDB(xml);

                    if (arcModel.ExsultMessage == "")
                    {
                        #region ConstructionProject,SystemInfo节点

                        CProjectModel = TransModel(arcModel.constructionProject, CProjectModel);
                        projectName = CProjectModel.Name;
                        #endregion

                        #region 单一数据
                        if (arcModel.option != null)
                            OpModel = TransModel(arcModel.option, OpModel);
                        else
                            OpModel = null;

                        if (arcModel.projectInfo != null)
                            PinfoModel = TransModel(arcModel.projectInfo, PinfoModel);
                        else
                            PinfoModel = null;

                        //if (arcModel.TBModel != null)
                        //    TBModel = TransModel(arcModel.TBModel, TBModel);
                        //else
                        //    TBModel = null;

                        if (arcModel.bidderInfo != null)
                            BIModel = TransModel(arcModel.bidderInfo, BIModel);
                        else
                            BIModel = null;

                        //if (arcModel.SOCModel != null)
                        //    SOCModel = TransModel(arcModel.SOCModel, SOCModel);
                        //else
                        //    SOCModel = null;

                        //if (arcModel.OtherCSModel != null)
                        //    OtherCSModel = TransModel(arcModel.OtherCSModel, OtherCSModel);
                        //else
                        //    OtherCSModel = null;

                        //if (arcModel.cfModel != null)
                        //    cfModel = TransModel(arcModel.cfModel, cfModel);
                        //else
                        //    cfModel = null;

                        //if (arcModel.CCModel != null)
                        //    CCModel = TransModel(arcModel.CCModel, CCModel);
                        //else
                        //    CCModel = null;

                        //if (arcModel.SCSModel1 != null)
                        //    SCSModel1 = TransModel(arcModel.SCSModel1, SCSModel1);
                        //else
                        //    SCSModel1 = null;

                        //if (arcModel.SCSModel2 != null)
                        //    SCSModel2 = TransModel(arcModel.SCSModel2, SCSModel2);
                        //else
                        //    SCSModel2 = null;

                        //if (arcModel.SCSModel3 != null)
                        //    SCSModel3 = TransModel(arcModel.SCSModel3, SCSModel3);
                        //else
                        //    SCSModel3 = null;
                        #endregion

                        #region 集合
                        ////if (arcModel.attrInfoList != null)
                        ////{
                        ////    foreach (var model in arcModel.attrInfoList)
                        ////    {
                        ////        AttrInfoItem dw = new AttrInfoItem();
                        ////        attrInfoList.Add(TransModel(model, dw));
                        ////    }
                        ////}

                        ////if (arcModel.addInfoList != null)
                        ////{
                        ////    foreach (var model in arcModel.addInfoList)
                        ////    {
                        ////        AddInfoItem dw = new AddInfoItem();
                        ////        addInfoList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        //if (arcModel.addiCostList != null)
                        //{
                        //    foreach (var model in arcModel.addiCostList)
                        //    {
                        //        AddiCost dw = new AddiCost();
                        //        addiCostList.Add(TransModel(model, dw));
                        //    }
                        //}
                        ////if (arcModel.BEMMList != null)
                        ////{
                        ////    foreach (var model in arcModel.BEMMList)
                        ////    {
                        ////        BidEvaluationMainMaterial dw = new BidEvaluationMainMaterial();
                        ////        BEMMList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.labourMachinesSummaryList != null)
                        ////{
                        ////    foreach (var model in arcModel.labourMachinesSummaryList)
                        ////    {
                        ////        LabourMachinesSummary dw = new LabourMachinesSummary();
                        ////        labourMachinesSummaryList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        //if (arcModel.resElementItemList != null)
                        //{
                        //    foreach (var model in arcModel.resElementItemList)
                        //    {
                        //        LabourMaterialsEquipmentsMachinesElement dw = new LabourMaterialsEquipmentsMachinesElement();
                        //        resElementItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        ////if (arcModel.otherCostGroupList != null)
                        ////{
                        ////    foreach (var model in arcModel.otherCostGroupList)
                        ////    {
                        ////        OtherCostGroup dw = new OtherCostGroup();
                        ////        otherCostGroupList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.otherCostItemList != null)
                        ////{
                        ////    foreach (var model in arcModel.otherCostItemList)
                        ////    {
                        ////        OtherCostItem dw = new OtherCostItem();
                        ////        otherCostItemList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.specifygroupList != null)
                        ////{
                        ////    foreach (var model in arcModel.specifygroupList)
                        ////    {
                        ////        SpecifyCostGroup dw = new SpecifyCostGroup();
                        ////        specifygroupList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.specifyitemList != null)
                        ////{
                        ////    foreach (var model in arcModel.specifyitemList)
                        ////    {
                        ////        SpecifyCostCostItem dw = new SpecifyCostCostItem();
                        ////        specifyitemList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        //if (arcModel.contingencyFeeGroupList != null)
                        //{
                        //    foreach (var model in arcModel.contingencyFeeGroupList)
                        //    {
                        //        ContingencyFeeGroup dw = new ContingencyFeeGroup();
                        //        contingencyFeeGroupList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.contingencyFeeItemList != null)
                        //{
                        //    foreach (var model in arcModel.contingencyFeeItemList)
                        //    {
                        //        ContingencyFeeItem dw = new ContingencyFeeItem();
                        //        contingencyFeeItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.projectInstallationWorkCostList != null)
                        //{
                        //    foreach (var model in arcModel.projectInstallationWorkCostList)
                        //    {
                        //        ProjectInstallationWorkCost dw = new ProjectInstallationWorkCost();
                        //        projectInstallationWorkCostList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.EquipmentCostList != null)
                        //{
                        //    foreach (var model in arcModel.EquipmentCostList)
                        //    {
                        //        EquipmentProcurementCost dw = new EquipmentProcurementCost();
                        //        EquipmentCostList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.EquipmentCostItemList != null)
                        //{
                        //    foreach (var model in arcModel.EquipmentCostItemList)
                        //    {
                        //        EquipmentProcurementCostItem dw = new EquipmentProcurementCostItem();
                        //        EquipmentCostItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.ChargeItemList != null)
                        //{
                        //    foreach (var model in arcModel.ChargeItemList)
                        //    {
                        //        UnitPriceCalculationOfItem dw = new UnitPriceCalculationOfItem();
                        //        ChargeItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.OtherCostList != null)
                        //{
                        //    foreach (var model in arcModel.OtherCostList)
                        //    {
                        //        OtherCost dw = new OtherCost();
                        //        OtherCostList.Add(TransModel(model, dw));
                        //    }
                        //}
                        ////if (arcModel.statutoryFeesGroupList1 != null)
                        ////{
                        ////    foreach (var model in arcModel.statutoryFeesGroupList1)
                        ////    {
                        ////        StatutoryFeesGroup dw = new StatutoryFeesGroup();
                        ////        statutoryFeesGroupList1.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.statutoryFeesGroupList2 != null)
                        ////{
                        ////    foreach (var model in arcModel.statutoryFeesGroupList2)
                        ////    {
                        ////        StatutoryFeesGroup dw = new StatutoryFeesGroup();
                        ////        statutoryFeesGroupList2.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.statutoryFeesGroupList3 != null)
                        ////{
                        ////    foreach (var model in arcModel.statutoryFeesGroupList3)
                        ////    {
                        ////        StatutoryFeesGroup dw = new StatutoryFeesGroup();
                        ////        statutoryFeesGroupList3.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.statutoryFeesItemList1 != null)
                        ////{
                        ////    foreach (var model in arcModel.statutoryFeesItemList1)
                        ////    {
                        ////        StatutoryFeesItem dw = new StatutoryFeesItem();
                        ////        statutoryFeesItemList1.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.statutoryFeesItemList2 != null)
                        ////{
                        ////    foreach (var model in arcModel.statutoryFeesItemList2)
                        ////    {
                        ////        StatutoryFeesItem dw = new StatutoryFeesItem();
                        ////        statutoryFeesItemList2.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.statutoryFeesItemList3 != null)
                        ////{
                        ////    foreach (var model in arcModel.statutoryFeesItemList3)
                        ////    {
                        ////        StatutoryFeesItem dw = new StatutoryFeesItem();
                        ////        statutoryFeesItemList3.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        //if (arcModel.sectionalWorksList != null)
                        //{
                        //    foreach (var model in arcModel.sectionalWorksList)
                        //    {
                        //        SectionalWorks dw = new SectionalWorks();
                        //        sectionalWorksList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.unitWorksList != null)
                        //{
                        //    foreach (var model in arcModel.unitWorksList)
                        //    {
                        //        UnitWorks dw = new UnitWorks();
                        //        unitWorksList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.summaryOfBasicCostList != null)
                        //{
                        //    foreach (var model in arcModel.summaryOfBasicCostList)
                        //    {
                        //        SummaryOfBasicCost dw = new SummaryOfBasicCost();
                        //        summaryOfBasicCostList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.divisionalWorksList != null)
                        //{
                        //    foreach (var model in arcModel.divisionalWorksList)
                        //    {
                        //        DivisionalWorks dw = new DivisionalWorks();
                        //        divisionalWorksList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.workElementList != null)
                        //{
                        //    foreach (var model in arcModel.workElementList)
                        //    {
                        //        WorkElement dw = new WorkElement();
                        //        workElementList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.summaryOfCostList != null)
                        //{
                        //    foreach (var model in arcModel.summaryOfCostList)
                        //    {
                        //        SummaryOfCost dw = new SummaryOfCost();
                        //        summaryOfCostList.Add(TransModel(model, dw));
                        //    }
                        //}
                        ////if (arcModel.summaryItemList != null)
                        ////{
                        ////    foreach (var model in arcModel.summaryItemList)
                        ////    {
                        ////        SummaryItem dw = new SummaryItem();
                        ////        summaryItemList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        //if (arcModel.expressElementList != null)
                        //{
                        //    foreach (var model in arcModel.expressElementList)
                        //    {
                        //        ExpressElement dw = new ExpressElement();
                        //        expressElementList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.workContentList != null)
                        //{
                        //    foreach (var model in arcModel.workContentList)
                        //    {
                        //        WorkContent dw = new WorkContent();
                        //        workContentList.Add(TransModel(model, dw));
                        //    }
                        //}
                        ////if (arcModel.normList != null)
                        ////{
                        ////    foreach (var model in arcModel.normList)
                        ////    {
                        ////        Norm dw = new Norm();
                        ////        normList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.combinedNormList != null)
                        ////{
                        ////    foreach (var model in arcModel.combinedNormList)
                        ////    {
                        ////        CombinedNorm dw = new CombinedNorm();
                        ////        combinedNormList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        //if (arcModel.unitPriceCalculationOfItemList != null)
                        //{
                        //    foreach (var model in arcModel.unitPriceCalculationOfItemList)
                        //    {
                        //        UnitPriceCalculationOfItem dw = new UnitPriceCalculationOfItem();
                        //        unitPriceCalculationOfItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.sundryCostsGroupList != null)
                        //{
                        //    foreach (var model in arcModel.sundryCostsGroupList)
                        //    {
                        //        SundryCostsGroup dw = new SundryCostsGroup();
                        //        sundryCostsGroupList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.sundryCostsItemList != null)
                        //{
                        //    foreach (var model in arcModel.sundryCostsItemList)
                        //    {
                        //        SundryCostsItem dw = new SundryCostsItem();
                        //        sundryCostsItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.provisionalSumsGroupList != null)
                        //{
                        //    foreach (var model in arcModel.provisionalSumsGroupList)
                        //    {
                        //        ProvisionalSumsGroup dw = new ProvisionalSumsGroup();
                        //        provisionalSumsGroupList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.provisionalSumsItemList != null)
                        //{
                        //    foreach (var model in arcModel.provisionalSumsItemList)
                        //    {
                        //        ProvisionalSumsItem dw = new ProvisionalSumsItem();
                        //        provisionalSumsItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        ////if (arcModel.provisionalMaterialGroupList != null)
                        ////{
                        ////    foreach (var model in arcModel.provisionalMaterialGroupList)
                        ////    {
                        ////        ProvisionalMaterialGroup dw = new ProvisionalMaterialGroup();
                        ////        provisionalMaterialGroupList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.provisionalMaterialItemList != null)
                        ////{
                        ////    foreach (var model in arcModel.provisionalMaterialItemList)
                        ////    {
                        ////        ProvisionalMaterialItem dw = new ProvisionalMaterialItem();
                        ////        provisionalMaterialItemList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        //if (arcModel.specialtyProvisionalPriceGroupList != null)
                        //{
                        //    foreach (var model in arcModel.specialtyProvisionalPriceGroupList)
                        //    {
                        //        SpecialtyProvisionalPriceGroup dw = new SpecialtyProvisionalPriceGroup();
                        //        specialtyProvisionalPriceGroupList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.specialtyProvisionalPriceItemList != null)
                        //{
                        //    foreach (var model in arcModel.specialtyProvisionalPriceItemList)
                        //    {
                        //        SpecialtyProvisionalPriceItem dw = new SpecialtyProvisionalPriceItem();
                        //        specialtyProvisionalPriceItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.dayWorkRateGroupList != null)
                        //{
                        //    foreach (var model in arcModel.dayWorkRateGroupList)
                        //    {
                        //        DayWorkRateGroup dw = new DayWorkRateGroup();
                        //        dayWorkRateGroupList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.dayWorkRateItemList != null)
                        //{
                        //    foreach (var model in arcModel.dayWorkRateItemList)
                        //    {
                        //        DayWorkRateItem dw = new DayWorkRateItem();
                        //        dayWorkRateItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.mainContractorAttendanceGroupList != null)
                        //{
                        //    foreach (var model in arcModel.mainContractorAttendanceGroupList)
                        //    {
                        //        MainContractorAttendanceGroup dw = new MainContractorAttendanceGroup();
                        //        mainContractorAttendanceGroupList.Add(TransModel(model, dw));
                        //    }
                        //}
                        //if (arcModel.mainContractorAttendanceItemList != null)
                        //{
                        //    foreach (var model in arcModel.mainContractorAttendanceItemList)
                        //    {
                        //        MainContractorAttendanceItem dw = new MainContractorAttendanceItem();
                        //        mainContractorAttendanceItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        ////if (arcModel.siteInstructionCostGroupList != null)
                        ////{
                        ////    foreach (var model in arcModel.siteInstructionCostGroupList)
                        ////    {
                        ////        SiteInstructionCostGroup dw = new SiteInstructionCostGroup();
                        ////        siteInstructionCostGroupList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.siteInstructionCostItemList != null)
                        ////{
                        ////    foreach (var model in arcModel.siteInstructionCostItemList)
                        ////    {
                        ////        SiteInstructionCostItem dw = new SiteInstructionCostItem();
                        ////        siteInstructionCostItemList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.claimsCostGroupList != null)
                        ////{
                        ////    foreach (var model in arcModel.claimsCostGroupList)
                        ////    {
                        ////        ClaimsCostGroup dw = new ClaimsCostGroup();
                        ////        claimsCostGroupList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        //if (arcModel.claimsCostItemList != null)
                        //{
                        //    foreach (var model in arcModel.claimsCostItemList)
                        //    {
                        //        ClaimsCostItem dw = new ClaimsCostItem();
                        //        claimsCostItemList.Add(TransModel(model, dw));
                        //    }
                        //}
                        ////if (arcModel.statutoryFeesGroupList != null)
                        ////{
                        ////    foreach (var model in arcModel.statutoryFeesGroupList)
                        ////    {
                        ////        StatutoryFeesGroup dw = new StatutoryFeesGroup();
                        ////        statutoryFeesGroupList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.statutoryFeesItemList != null)
                        ////{
                        ////    foreach (var model in arcModel.statutoryFeesItemList)
                        ////    {
                        ////        StatutoryFeesItem dw = new StatutoryFeesItem();
                        ////        statutoryFeesItemList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.taxGroupList != null)
                        ////{
                        ////    foreach (var model in arcModel.taxGroupList)
                        ////    {
                        ////        TaxGroup dw = new TaxGroup();
                        ////        taxGroupList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        ////if (arcModel.taxItemList != null)
                        ////{
                        ////    foreach (var model in arcModel.taxItemList)
                        ////    {
                        ////        TaxItem dw = new TaxItem();
                        ////        taxItemList.Add(TransModel(model, dw));
                        ////    }
                        ////}
                        #endregion

                    }
                    else
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = arcModel.ExsultMessage;
                        list.Add(arcModel.ExsultMessage);
                    }
                }
                else
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "XML数据格式不符合交换标准，请检查!";
                    //return ret;
                    list.Add("XML数据格式不符合交换标准，请检查!");
                }

                var ReadXMLend = Environment.TickCount;

                #region  校验数据
                var CheckXMLstart = Environment.TickCount;

                if (CProjectModel.StandardName.Trim() != "建设工程造价数据交换标准")
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "上传文件格式不符，请重新上传符合《建设工程造价数据交换标准》的造价文件。";
                    //return ret;
                    list.Add("上传文件格式不符，请重新上传符合《建设工程造价数据交换标准》的造价文件。");
                }

                if (PinfoModel == null)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的XML文件里项目信息中编制信息为空，请补充完整后再上传！";
                    //return ret;
                    list.Add("您提交的XML文件里项目信息中编制信息为空，请补充完整后再上传！");
                }
                else
                {
                    if (PinfoModel.CompileCompany == "")
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = "您提交的XML文件里项目信息中编制单位为空，请补充完整后再上传！";
                        //return ret;
                        list.Add("您提交的XML文件里项目信息中编制单位为空，请补充完整后再上传！");
                    }
                    if (PinfoModel.CompileDate == null)
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = "您提交的XML文件里项目信息中编制日期为空，请补充完整后再上传！";
                        //return ret;
                        list.Add("您提交的XML文件里项目信息中编制日期为空，请补充完整后再上传！");
                    }
                    else
                    {
                        DateTime date;
                        bool flag = DateTime.TryParse(PinfoModel.CompileDate.ToString(), out date);
                        if (!flag)
                        {
                            ret.IsSuccess = 1;
                            ret.Msg = "您提交的XML文件里项目信息中编制日期格式不正确，标准格式如：2018-02-01";
                            //return ret;
                            list.Add("您提交的XML文件里项目信息中编制日期格式不正确，标准格式如：2018-02-01");
                        }
                        else
                        {
                            PinfoModel.CompileDate = date;
                        }
                    }
                }

                #region ConstructionProjects 单项成果文件校验
                if (CProjectModel == null)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的XML文件里项目名称为空，请补充项目名称后再重新上传！";
                    //return ret;
                    list.Add("您提交的XML文件里项目名称为空，请补充项目名称后再重新上传！");
                }

                //判断材料价格时间 MaterialPriceDate="2018-02" 年-月格式 
                if (CProjectModel.MaterialPriceDate == null)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的XML文件里项目信息表材料价格时间，数据格式不正确，标准格式如：2018-02";
                    //return ret;
                    list.Add("您提交的XML文件里项目信息表材料价格时间，数据格式不正确，标准格式如：2018-02");
                }
                


                #region 单项成果文件 单位校验
                string tmpUnit = CProjectModel.ScaleUnit;
                if (tmpUnit.Length > 10)
                {
                    //返回错误信息
                    ret.IsSuccess = 1;
                    ret.Msg = string.Format("您提交的xml文件里项目建设规模单位\"{0}\"有误！请您修改正确后重新上传。", tmpUnit);
                    //return ret;
                    list.Add(string.Format("您提交的xml文件里项目建设规模单位\"{0}\"有误！请您修改正确后重新上传。", tmpUnit));
                }
                CProjectModel.ScaleUnit = TransferUnit(tmpUnit);
                #endregion

                #endregion

                ////判断相同工程
                //if (!string.IsNullOrEmpty(HTID))
                //{
                //    var instance = new vw_ProjectMainInfoDao();
                //    var emodel = instance.ExistsProjectList(CProjectModel.Name, new Guid(CProjectModel.HTID.ToString()), Convert.ToInt32(CProjectModel.FileKind), new Guid(CProjectModel.CompanyId.ToString()));
                //    if (emodel.Count != 0)
                //    {
                //        string repeatMessage = instance.CheckSectionalWorkRepeat(emodel, sectionalWorksList);
                //        if (repeatMessage != "")
                //        {
                //            ret.IsSuccess = 1;
                //            ret.Msg = "您提交的“" + repeatMessage + "”单项工程已上传，不可以重复上报！";
                //            return ret;
                //        }
                //    }
                //}

                #region 单项工程专业分类、单项工程编码
                if (sectionalWorksList.Count == 0)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的xml文件单项工程信息为空，请联系计价软件公司！";
                    //return ret;
                    list.Add("您提交的xml文件单项工程信息为空，请联系计价软件公司！");
                }
                int code = 0;
                string tmpCode = "";
                //单项工程 单项工程编码2位 限制
                for (int i = 0; i < sectionalWorksList.Count; i++)
                {
                    tmpCode = "";// sectionalWorksList[i].Specialty;
                    if (tmpCode.Length != 2 || !int.TryParse(tmpCode, out code))
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件中的单项工程:{0}的编码\"{1}\"必须为2位数字！请您修改正确后重新上传。", sectionalWorksList[i].Name, tmpCode);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件中的单项工程:{0}的编码\"{1}\"必须为2位数字！请您修改正确后重新上传。", sectionalWorksList[i].Name, tmpCode));
                    }
                }

                #region 单项工程 单位校验
                for (int i = 0; i < sectionalWorksList.Count; i++)
                {
                    tmpUnit = sectionalWorksList[i].ScaleUnit;
                    if (tmpUnit.Length > 10)
                    {
                        //返回错误信息
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件中的单项工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", sectionalWorksList[i].Name, tmpUnit);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件中的单项工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", sectionalWorksList[i].Name, tmpUnit));
                    }
                    sectionalWorksList[i].ScaleUnit = TransferUnit(tmpUnit);
                }
                #endregion

                int SpecialtyNum = 0;
                string dxProjectNameTemp = CProjectModel.Name; //拼接单项工程名称
                dxProjectNameTemp = sectionalWorksList[0].Name;
                for (int i = 0; i < sectionalWorksList.Count; i++)
                {
                    //dxProjectNameTemp += "/" + sectionalWorksList[i].Name;
                    //if (sectionalWorksList[i].Specialty != "" && sectionalWorksList[i].Specialty != null)
                    //{
                    //    SpecialtyNum = 2;
                    //    if (i > 0)
                    //    {
                    //        if (sectionalWorksList[i].Specialty != sectionalWorksList[i - 1].Specialty)
                    //        {
                    //            SpecialtyNum = 1;
                    //        }
                    //    }
                    //}
                }

                CProjectModel.Name = dxProjectNameTemp;
                //if (SpecialtyNum == 0)
                //{
                //    ret.IsSuccess = 1;
                //    ret.Msg = "您提交的XML文件里，没有设置或录入单项工程专业类别，请补充完整后再上传！";
                //    return ret;
                //}
                //if (SpecialtyNum == 1)
                //{
                //    ret.IsSuccess = 1;
                //    ret.Msg = "您提交的xml文件里有多个单项工程，请确保一个XML文件只有一个单项工程！";
                //    return ret;
                //}
                #endregion

                #region 单位工程专业分类、单位工程编码
                if (unitWorksList.Count == 0)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "您提交的xml文件里单位工程信息为空，请补充单位工程信息后再上传！";
                    //return ret;
                    list.Add("您提交的xml文件里单位工程信息为空，请补充单位工程信息后再上传！");
                }

                //判断xml是否只有一个单项工程
                if (sectionalWorksList.Count != 1)
                {
                    ret.IsSuccess = 1;
                    ret.Msg = "一个XML文件只能包含一个单项工程，请核对后再次上传！";
                    //return ret;
                    list.Add("一个XML文件只能包含一个单项工程，请核对后再次上传！");
                }
                    //if (CheckSpecialty(sectionalWorksList[0].Specialty, unitWorksList))
                    //{
                    //    ret.IsSuccess = 1;
                    //    ret.Msg = "您上传的XML文件在制作或导出过程中，单位工程未对应正确的专业类别，请修改您的文件，导出新的XML文件后，重新上传。";
                    //    //return ret;
                    //    list.Add("您上传的XML文件在制作或导出过程中，单位工程未对应正确的专业类别，请修改您的文件，导出新的XML文件后，重新上传。");
                //}
                //单位工程 单位工程编码4位 限制
                for (int i = 0; i < unitWorksList.Count; i++)
                {
                    tmpCode = unitWorksList[i].Specialty;
                    if (tmpCode.Length != 4 || !int.TryParse(tmpCode, out code))
                    {
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件中的单位工程:{0}的编码\"{1}\"必须为4位数字！请您修改正确后重新上传。", unitWorksList[i].Name, tmpCode);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件中的单位工程:{0}的编码\"{1}\"必须为4位数字！请您修改正确后重新上传。", unitWorksList[i].Name, tmpCode));
                    }
                }
                decimal unitWorksTotal = 0;

                #region 单位工程 单位校验
                for (int i = 0; i < unitWorksList.Count; i++)
                {
                    unitWorksTotal += Convert.ToDecimal(unitWorksList[i].Total);
                    tmpUnit = unitWorksList[i].ScaleUnit;
                    if (tmpUnit.Length > 10)
                    {
                        //返回错误信息
                        ret.IsSuccess = 1;
                        ret.Msg = string.Format("您提交的xml文件中的单位工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", unitWorksList[i].Name, tmpUnit);
                        //return ret;
                        list.Add(string.Format("您提交的xml文件中的单位工程:{0}的单位\"{1}\"有误！请您修改正确后重新上传。", unitWorksList[i].Name, tmpUnit));
                    }
                    unitWorksList[i].ScaleUnit = TransferUnit(tmpUnit);
                }
                #endregion
                //if (CheckMoney(unitWorksTotal, Convert.ToDecimal(PinfoModel.Total)))  20190906取消判断这个
                //{
                //    ret.IsSuccess = 1;                 
                //    ret.Msg = string.Format("您上传的成果文件单位工程总造价\"{1}\"与项目造价\"{0}\"不一致，请核准金额后再上传。", unitWorksTotal, PinfoModel.Total);
                //    return ret;                    
                //}
                //1.您上传的成果文件，建筑安装工程费与单项工程金额不等，请核对后再次上传。
                //2.您上传的成果文件，单项工程金额与单位工程金额合计不等，请核对后再次上传。
                if (CheckMoney(Convert.ToDecimal(sectionalWorksList[0].Total), Convert.ToDecimal(projectInstallationWorkCostList[0].Total)))
                {
                    ret.IsSuccess = 1;
                    ret.Msg = string.Format("您上传的成果文件，建筑安装工程费\"{1}\"与单项工程金额\"{0}\"不等，请核对后再次上传。", sectionalWorksList[0].Total, projectInstallationWorkCostList[0].Total);
                    //return ret;
                    list.Add(string.Format("您上传的成果文件，建筑安装工程费\"{1}\"与单项工程金额\"{0}\"不等，请核对后再次上传。", sectionalWorksList[0].Total, projectInstallationWorkCostList[0].Total));
                }
                if (CheckMoney(unitWorksTotal, Convert.ToDecimal(sectionalWorksList[0].Total)))
                {
                    ret.IsSuccess = 1;
                    ret.Msg = string.Format("您上传的成果文件，单项工程金额\"{1}\"与单位工程金额合计\"{0}\"不等，请核对后再次上传。", unitWorksTotal, sectionalWorksList[0].Total);
                    //return ret;
                    list.Add(string.Format("您上传的成果文件，单项工程金额\"{1}\"与单位工程金额合计\"{0}\"不等，请核对后再次上传。", unitWorksTotal, sectionalWorksList[0].Total));
                }

                int uwSpecialtyNum = 0;
                foreach (UnitWorks modelUW in unitWorksList)
                {
                    if (modelUW.Specialty != null && modelUW.Specialty != "")
                    {
                        uwSpecialtyNum += 1;
                    }
                }

                //if (uwSpecialtyNum == 0)
                //{
                //    ret.IsSuccess = 1;
                //    ret.Msg = "您提交的xml文件里单位工程没有专业类别，请补充完整后再上传！";
                //    return ret;
                //}
                #endregion

                //if (CProjectModel.ScaleUnit == "" || CProjectModel.ScaleUnit == null)
                //{
                //    ret.IsSuccess = 1;
                //    ret.Msg = "您提交的xml文件里建设规模单位为空，请选择建设规模单位后再上传！";
                //    return ret;
                //}

                //if (unitPriceCalculationOfItemList.Count == 0)
                //{
                //    ret.IsSuccess = 1;
                //    ret.Msg = "您提交的xml文件里子目单价计算信息为空，请联系计价软件公司！";
                //    return ret;
                //}
                //if (string.IsNullOrWhiteSpace(CProjectModel.Scale))
                //{
                //    ret.IsSuccess = 1;
                //    ret.Msg = "您提交的xml文件里建设规模为空，请输入建设规模！";
                //    //return ret;
                //    list.Add("您提交的xml文件里建设规模为空，请输入建设规模！");
                //}

                //分解工程规模
                //string[] scaleResolveList = JKY.Common.DataConvert.GetNumberUnit(CProjectModel.Scale);
                //CProjectModel.Scale = scaleResolveList[0];
                //CProjectModel.ScaleValue = scaleResolveList[0];
                //CProjectModel.ScaleUnitNew = scaleResolveList[1];

                var CheckXMLend = Environment.TickCount;
                #endregion

                #region   保存数据


                ret.Data = CProjectModel;
                UploadMsg = " 读取信息时间：" + (ReadXMLend - ReadXMLstart).ToString() + "毫秒;" + "验证时间：" + (CheckXMLend - CheckXMLstart).ToString() + "毫秒。";// + "保存信息时间：" + (SaveCpend - SaveCpstart).ToString() + "毫秒。";
                #endregion
            }
            //catch (Exception ex)
            catch (Exception ex)
            {
                ret.IsSuccess = 2;
                ret.Msg = "您提交的xml文件格式不符合交换标准，第一步：请您确认是否按照造价监测数据接口导出的XML文件；第二步：如果确认第一步没有问题，请联系北京建科研软件技术有限公司：400-825-113进行咨询。";
                list.Add("您提交的xml文件格式不符合交换标准，第一步：请您确认是否按照造价监测数据接口导出的XML文件；第二步：如果确认第一步没有问题，请联系北京建科研软件技术有限公司：400-825-113进行咨询。");
            }

            return ret;
        }
        //平台
        //List<string> FJ_unitWorks = new List<string>() { "0101", "0102", "0301", "0302", "0303", "0304", "0305", "0306", "0307", "0308" };
        //List<string> SZ_unitWorks = new List<string>() { "0401", "0402", "0403", "0404", "0405", "0406", "0407", "0408", "0409" };
        //List<string> GD_unitWorks = new List<string>() { "0801", "0802", "0803", "0804", "0805", "0806", "0807", "0808", "0809" };
        //List<string> YL_unitWorks = new List<string>() { "0501", "0502", "0503" };
        //List<string> KS_unitWorks = new List<string>() { "0601", "0602" };
        //标准
        List<string> FJ_unitWorks = new List<string>() { "0101", "0102", "0103", "0104", "0105", "0106", "0301", "0302", "0303", "0304", "0305", "0306", "0307", "0308", "0309", "0310", "0311", "0312", "0313", "0314", "0315" };
        List<string> FG_unitWorks = new List<string>() { "0201", "0202" };
        List<string> AZ_unitWorks = new List<string>() { "0301", "0302", "0303", "0304", "0305", "0306", "0307", "0308", "0309", "0310", "0311", "0312", "0313", "0314", "0315" };
        List<string> SZ_unitWorks = new List<string>() { "0401", "0402", "0403", "0404", "0405", "0406", "0407", "0408", "0409", "0410" };
        List<string> YL_unitWorks = new List<string>() { "0501", "0502" };
        List<string> KS_unitWorks = new List<string>() { "0601", "0602" };
        List<string> GD_unitWorks = new List<string>() { "0801", "0802", "0803", "0804", "0805", "0806", "0807", "0808", "0809" };
        List<string> BP_unitWorks = new List<string>() { "0901", "0902", "0903", "0904", "0905", "0906" };
        List<string> XS_unitWorks = new List<string>() { "3101", "3102", "3103", "3104" };
        /// <summary>
        /// 检测 unitWorksList 是否与单项工程对应
        /// </summary>
        /// <param name="v"></param>
        /// <param name="unitWorksList"></param>
        /// <returns></returns>
        private bool CheckSpecialty(string v_code, List<UnitWorks> unitWorksList)
        {
            List<string> vu = new List<string>();
            switch (v_code)
            {
                case "01": vu = FJ_unitWorks; break;
                case "02": vu = FG_unitWorks; break;
                case "03": vu = AZ_unitWorks; break;
                case "04": vu = SZ_unitWorks; break;
                case "05": vu = YL_unitWorks; break;
                case "06": vu = KS_unitWorks; break;
                case "08": vu = GD_unitWorks; break;
                case "09": vu = BP_unitWorks; break;
                case "31": vu = XS_unitWorks; break;

                default:
                    return false;
                    //break;
            }
            for (int i = 0; i < unitWorksList.Count; i++)
            {
                if (vu.IndexOf(unitWorksList[i].Specialty) == -1)
                {
                    return true;
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
