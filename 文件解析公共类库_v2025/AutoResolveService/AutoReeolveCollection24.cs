using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace JKY.Models24
{
    public class AutoReeolveCollection24
    {
        public string ExsultMessage { get; set; }
        public string TipMessage { get; set; }
        public string HidErrMessage { get; set; }

        /// <summary>
        /// 建设项目
        /// </summary>
        public ConstructionProject constructionProject { get; set; }
        /// <summary>
        /// 系统信息
        /// </summary>
        public SystemInfo systemInfo { get; set; }

        #region 2 ConstructionInfo 工程信息
        /// <summary>
        /// 工程信息
        /// </summary>
        public ConstructionInfo constructionInfo { get; set; }
        /// <summary>
        /// 费用精度
        /// </summary>
        public Option option { get; set; }
        /// <summary>
        /// 项目信息
        /// </summary>
        public ProjectInfo projectInfo { get; set; }
        /// <summary>
        /// 招标信息
        /// </summary>
        public TendererInfo tendererInfo { get; set; }
        /// <summary>
        /// 投标信息
        /// </summary>
        public BidderInfo bidderInfo { get; set; }

        //public List<AttrInfo> attrInfos { get; set; }
        /// <summary>
        /// 工程特征信息明细
        /// </summary>
        public List<AttrInfoItem> attrInfoItems { get; set; }
        //public List<AddiInfo> addiInfo { get; set; }
        /// <summary>
        /// 补充信息明细
        /// </summary>
        public List<AddiInfoItem> addiInfoItems { get; set; }

        #endregion

        #region 3 SummaryOfCost  费用汇总
        /// <summary>
        /// 费用汇总
        /// </summary>
        public List<SummaryOfCost> summaryOfCost { get; set; }
        /// <summary>
        /// 补充费用
        /// </summary>
        public List<AddiCost> addiCosts { get; set; }
        #endregion

        #region 4 ConstructionSummary 费用组成
        /// <summary>
        /// 费用组成
        /// </summary>
        public ConstructionSummary constructionSummary { get; set; }

        #region 4.1 ConstructionCost 工程费用
        /// <summary>
        /// 工程费用
        /// </summary>
        public ConstructionCost constructionCost { get; set; }

        #region 4.1.1 ProjectInstallationWorkCost 建筑安装工程费
        /// <summary>
        /// 建筑安装工程费
        /// </summary>
        public List<ProjectInstallationWorkCost> projectInstallationWorkCosts { get; set; }

        #region 4.1.1.1 单项工程 sectionalWorks
        /// <summary>
        /// 单项工程
        /// </summary>
        public List<SectionalWorks> sectionalWorks { get; set; }
        /// <summary>
        /// 单位工程
        /// </summary>
        public List<UnitWorks> unitWorks { get; set; }
        /// <summary>
        /// 单位工程费用组成
        /// </summary>
        public List<UnitWorksSummary> unitWorksSummarys { get; set; }
        /// <summary>
        /// 单位工程费用汇总
        /// </summary>
        public List<UnitWorksSummaryGroup> unitWorksSummaryGroups { get; set; }
        /// <summary>
        /// 单位工程费用明细
        /// </summary>
        public List<UnitWorksSummaryItem> unitWorksSummaryItems { get; set; }
        //public List<DivisionalAndElementalWorks> divisionalAndElementalWorkss { get; set; }
        /// <summary>
        /// 分部工程
        /// </summary>
        public List<DivisionalWorks> divisionalWorkss { get; set; }
        /// <summary>
        /// 工程量计算表
        /// </summary>
        public List<ExpressElement> expressElements { get; set; }
        /// <summary>
        /// 工作内容
        /// </summary>
        public List<WorkContent> workContents { get; set; }
        /// <summary>
        /// 单价分析
        /// </summary>
        public List<PriceAnalysis> priceAnalyses { get; set; }
        /// <summary>
        /// 调整前单价明细
        /// </summary>
        public List<OriginalPriceItem> originalPriceItems { get; set; }
        /// <summary>
        /// 单价明细
        /// </summary>
        public List<PriceItem> priceItems { get; set; }

        #endregion
        #region 4.1.1.2 措施项目 preliminariess
        /// <summary>
        /// 措施项目
        /// </summary>
        public List<Preliminaries> preliminariess { get; set; }
        /// <summary>
        /// 合计费用集合
        /// </summary>
        public List<SummaryOfBasicCost> summaryOfBasicCosts { get; set; }
        /// <summary>
        /// 清单项目
        /// </summary>
        public List<WorkElement> workElements { get; set; }
        #endregion
        #region 4.1.1.3 其它项目
        /// <summary>
        /// 其它项目
        /// </summary>
        public List<Sundry> sundrys { get; set; }
        //==1 SundryCosts 1 其他项目费
        /// <summary>
        /// 其他项目费
        /// </summary>
        public List<SundryCosts> sundryCostss { get; set; }
        /// <summary>
        /// 其他项目费汇总
        /// </summary>
        public List<SundryCostsGroup> sundryCostsGroups { get; set; }
        /// <summary>
        /// 其他项目费明细
        /// </summary>
        public List<SundryCostsItem> sundryCostsItems { get; set; }

        //==2 ProvisionalSums 1 暂列金额
        /// <summary>
        /// 暂列金额
        /// </summary>
        public List<ProvisionalSums> provisionalSums { get; set; }
        /// <summary>
        /// 暂列金额汇总
        /// </summary>
        public List<ProvisionalSumsGroup> provisionalSumsGroups { get; set; }
        /// <summary>
        /// 暂列金额明细
        /// </summary>
        public List<ProvisionalSumsItem> provisionalSumsItems { get; set; }

        //==3 SpecialtyProvisionalPrice 1 专业工程暂估价
        /// <summary>
        /// 专业工程暂估价
        /// </summary>
        public List<SpecialtyProvisionalPrice> specialtyProvisionalPrices { get; set; }
        /// <summary>
        /// 专业工程暂估价汇总
        /// </summary>
        public List<SpecialtyProvisionalPriceGroup> specialtyProvisionalPriceGroups { get; set; }
        /// <summary>
        /// 专业工程暂估价明细
        /// </summary>
        public List<SpecialtyProvisionalPriceItem> specialtyProvisionalPriceItems { get; set; }

        //==4 DayWorkRate 1 计日工
        /// <summary>
        /// 计日工
        /// </summary>
        public List<DayWorkRate> dayWorkRates { get; set; }
        /// <summary>
        /// 计日工汇总
        /// </summary>
        public List<DayWorkRateGroup> dayWorkRateGroups { get; set; }
        /// <summary>
        /// 计日工明细
        /// </summary>
        public List<DayWorkRateItem> dayWorkRateItems { get; set; }

        //==5 MainContractorAttendance 1 总承包服务费
        /// <summary>
        /// 总承包服务费
        /// </summary>
        public List<MainContractorAttendance> mainContractorAttendances { get; set; }
        /// <summary>
        /// 总承包服务费汇总
        /// </summary>
        public List<MainContractorAttendanceGroup> mainContractorAttendanceGroups { get; set; }
        /// <summary>
        /// 总承包服务费明细
        /// </summary>
        public List<MainContractorAttendanceItem> mainContractorAttendanceItems { get; set; }

        //==6 OtherContents 1 合同中约定的其他项目
        /// <summary>
        /// 合同中约定的其他项目
        /// </summary>
        public List<OtherContents> otherContentss { get; set; }
        /// <summary>
        /// 合同中约定的其他项目汇总
        /// </summary>
        public List<OtherContentsGroup> otherContentsGroups { get; set; }
        /// <summary>
        /// 合同中约定的其他项目明细
        /// </summary>
        public List<OtherContentsItem> otherContentsItems { get; set; }

        #endregion
        //public List<OtherCost> projectInstallationWorkOtherCosts { get; set; }
        /// <summary>
        /// 工料机汇总
        /// </summary>
        public List<LabourMaterialsEquipmentsMachinesSummary> labourMaterialsEquipmentsMachinesSummarys { get; set; }
        #endregion

        #region 4.1.2 EquipmentProcurementCost 设备及工器具购置费
        /// <summary>
        /// 设备及工器具购置费
        /// </summary>
        public List<EquipmentProcurementCost> equipmentProcurementCosts { get; set; }
        /// <summary>
        /// 设备及工器具购置费明细
        /// </summary>
        public List<EquipmentProcurementCostItem> equipmentProcurementCostItems { get; set; }
        /// <summary>
        /// 设备及工器具购置费子目单价计算
        /// </summary>
        public List<UnitPriceCalculationOfItem> unitPriceCalculationOfItems { get; set; }
        #endregion
        /// <summary>
        /// 扩展费用
        /// </summary>
        public List<OtherCost> otherCosts { get; set; }
        #endregion

        #region 4.2 OtherInvestmentOfConstructionProject 工程建设其他费用
        /// <summary>
        /// 工程建设其他费用
        /// </summary>
        public OtherInvestmentOfConstructionProject otherInvestmentOfConstructionProject { get; set; }
        /// <summary>
        /// 工程建设其他费用汇总
        /// </summary>
        public List<OtherInvestmentOfConstructionProjectGroup> otherInvestmentOfConstructionProjectGroups { get; set; }
        /// <summary>
        /// 工程建设其他费用明细
        /// </summary>
        public List<OtherInvestmentOfConstructionProjectItem> otherInvestmentOfConstructionProjectItems { get; set; }
        #endregion

        #region 4.3 ContingencyFee 预备费
        /// <summary>
        /// 预备费
        /// </summary>
        public ContingencyFee contingencyFee { get; set; }
        /// <summary>
        /// 预备费汇总
        /// </summary>
        public List<ContingencyFeeGroup> contingencyFeeGroups { get; set; }
        /// <summary>
        /// 预备费明细
        /// </summary>
        public List<ContingencyFeeItem> contingencyFeeItems { get; set; }
        #endregion

        #region 4.4 FundraisingFee 资金筹措费
        /// <summary>
        /// 资金筹措费
        /// </summary>
        public FundraisingFee fundraisingFee { get; set; }
        /// <summary>
        /// 资金筹措费汇总
        /// </summary>
        public List<FundraisingFeeGroup> fundraisingFeeGroups { get; set; }
        /// <summary>
        /// 资金筹措费明细
        /// </summary>
        public List<FundraisingFeeItem> fundraisingFeeItems { get; set; }
        #endregion

        #region 4.5 WorkingCapital 流动资金
        /// <summary>
        /// 流动资金
        /// </summary>
        public WorkingCapital workingCapital { get; set; }
        /// <summary>
        /// 流动资金汇总
        /// </summary>
        public List<WorkingCapitalGroup> workingCapitalGroups { get; set; }
        /// <summary>
        /// 流动资金明细
        /// </summary>
        public List<WorkingCapitalItem> workingCapitalItems { get; set; }
        #endregion

        #endregion



    }
}