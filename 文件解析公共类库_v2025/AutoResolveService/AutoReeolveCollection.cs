using AutoResolveService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoResolveService
{
    public class AutoReeolveCollection
    {
        public string ExsultMessage { get; set; }
        public string HidErrMessage { get; set; }

        public ConstructionProjects CProjectModel { get; set; }
        public Options OpModel { get; set; }
        public ProjectInfo PinfoModel { get; set; }
        public TendererBidderInfo TBModel { get; set; }
        public BidderInfo BIModel { get; set; }
        public SummaryOfCost SOCModel { get; set; }
        public OtherCostSums OtherCSModel { get; set; }
        public ContingencyFee cfModel { get; set; }
        public ConstructionCost CCModel { get; set; }
        public SpecifyCostSum SCSModel1 { get; set; }
        public SpecifyCostSum SCSModel2 { get; set; }
        public SpecifyCostSum SCSModel3 { get; set; }
        public List<AttrInfoItem> attrInfoList { get; set; }
        public List<AddInfoItem> addInfoList { get; set; }
        public List<AddiCost> addiCostList { get; set; }
        public List<BidEvaluationMainMaterial> BEMMList { get; set; }
        public List<LabourMachinesSummary> labourMachinesSummaryList { get; set; }
        public List<LabourMaterialsEquipmentsMachinesElement> resElementItemList { get; set; }
        public List<OtherCostGroup> otherCostGroupList { get; set; }
        public List<OtherCostItem> otherCostItemList { get; set; }
        public List<SpecifyCostGroup> specifygroupList { get; set; }
        public List<SpecifyCostCostItem> specifyitemList { get; set; }
        public List<ContingencyFeeGroup> contingencyFeeGroupList { get; set; }
        public List<ContingencyFeeItem> contingencyFeeItemList { get; set; }
        public List<ProjectInstallationWorkCost> projectInstallationWorkCostList { get; set; }
        public List<EquipmentProcurementCost> EquipmentCostList { get; set; }
        public List<EquipmentProcurementCostItem> EquipmentCostItemList { get; set; }
        public List<UnitPriceCalculationOfItem> ChargeItemList { get; set; }
        public List<OtherCost> OtherCostList { get; set; }
        public List<StatutoryFeesGroup> statutoryFeesGroupList1 { get; set; }
        public List<StatutoryFeesGroup> statutoryFeesGroupList2 { get; set; }
        public List<StatutoryFeesGroup> statutoryFeesGroupList3 { get; set; }
        public List<StatutoryFeesItem> statutoryFeesItemList1 { get; set; }
        public List<StatutoryFeesItem> statutoryFeesItemList2 { get; set; }
        public List<StatutoryFeesItem> statutoryFeesItemList3 { get; set; }
        public List<SectionalWorks> sectionalWorksList { get; set; }
        public List<UnitWorks> unitWorksList { get; set; }
        public List<SummaryOfBasicCost> summaryOfBasicCostList { get; set; }
        public List<DivisionalWorks> divisionalWorksList { get; set; }
        public List<WorkElement> workElementList { get; set; }
        public List<SummaryOfCost> summaryOfCostList { get; set; }
        public List<SummaryItem> summaryItemList { get; set; }
        public List<ExpressElement> expressElementList { get; set; }
        public List<WorkContent> workContentList { get; set; }
        public List<Norm> normList { get; set; }
        public List<CombinedNorm> combinedNormList { get; set; }
        public List<UnitPriceCalculationOfItem> unitPriceCalculationOfItemList { get; set; }
        public List<SundryCostsGroup> sundryCostsGroupList { get; set; }
        public List<SundryCostsItem> sundryCostsItemList { get; set; }
        public List<ProvisionalSumsGroup> provisionalSumsGroupList { get; set; }
        public List<ProvisionalSumsItem> provisionalSumsItemList { get; set; }
        public List<ProvisionalMaterialGroup> provisionalMaterialGroupList { get; set; }
        public List<ProvisionalMaterialItem> provisionalMaterialItemList { get; set; }
        public List<SpecialtyProvisionalPriceGroup> specialtyProvisionalPriceGroupList { get; set; }
        public List<SpecialtyProvisionalPriceItem> specialtyProvisionalPriceItemList { get; set; }
        public List<DayWorkRateGroup> dayWorkRateGroupList { get; set; }
        public List<DayWorkRateItem> dayWorkRateItemList { get; set; }
        public List<MainContractorAttendanceGroup> mainContractorAttendanceGroupList { get; set; }
        public List<MainContractorAttendanceItem> mainContractorAttendanceItemList { get; set; }
        public List<SiteInstructionCostGroup> siteInstructionCostGroupList { get; set; }
        public List<SiteInstructionCostItem> siteInstructionCostItemList { get; set; }
        public List<ClaimsCostGroup> claimsCostGroupList { get; set; }
        public List<ClaimsCostItem> claimsCostItemList { get; set; }
        public List<StatutoryFeesGroup> statutoryFeesGroupList { get; set; }
        public List<StatutoryFeesItem> statutoryFeesItemList { get; set; }
        public List<TaxGroup> taxGroupList { get; set; }
        public List<TaxItem> taxItemList { get; set; }
    }
}