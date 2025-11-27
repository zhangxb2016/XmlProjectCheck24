using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKY.Models24
{
    public class CheckReport
    {
        public string Header { get; set; } = "【错误提示】";
        public List<CheckItemModel> ModelItems { get; set; } = new List<CheckItemModel>();

        public string Footer { get; set; } = "请联系计价软件公司！";
    }
    public class CheckItemModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 字段提醒
        /// </summary>
        public List<string> FieldTip { get; set; } = new List<string>();
    }

    public class ReturnModel<T>
    {
        /// <summary>
        /// 0=成功，1=失败，2程序异常
        /// </summary>
        public int IsSuccess { get; set; }

        public string Msg { get; set; }

        public T Data { get; set; }
    }

    /// <summary>
    /// 建设项目 by 2025
    /// </summary>
    [DisplayName("建设项目")]
    public class ConstructionProject
    {
        public Guid Id { get; set; }  //
        public string XmlName { get; set; }  //
        public DateTime CreateDate { get; set; }  //
        public DateTime? MakeDate { get; set; }  //
        public int State { get; set; }  // 0=新建，1=已保存，2=已提交，3=审核通过，4=审核不通过

        /// <summary>
        /// 项目编号
        /// </summary>
        [Required]
        public string Number { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [Required]
        public int FileKind { get; set; }
        /// <summary>
        /// 计价类别
        /// </summary>
        [Required]
        public int ValuationMethod { get; set; }
        /// <summary>
        /// 计税模式
        /// </summary>
        [Required]
        public int TaxModel { get; set; }
        /// <summary>
        /// 数据交换标准名称
        /// </summary>
        [Required]
        public string StandardName { get; set; }
        /// <summary>
        /// 数据交换标准编号
        /// </summary>
        [Required]
        public string StandardNumber { get; set; }
        /// <summary>
        /// 建设单位
        /// </summary>
        public string Developer { get; set; }
        /// <summary>
        /// 建设单位法定代表人或其授权委托人
        /// </summary>
        public string DeveloperAuthorizer { get; set; }
        /// <summary>
        /// 建设规模
        /// </summary>
        [Required] 
        public double Scale { get; set; }
        /// <summary>
        /// 建设规模计量单位
        [Required]
        public string ScaleUnit { get; set; }
        /// <summary>
        /// 材料价格时间
        /// </summary>
        [Required] 
        public DateTime MaterialPriceDate { get; set; }
        /// <summary>
        /// 人工价格时间
        /// </summary>
        [Required] 
        public DateTime LaborPriceDate { get; set; }
        /// <summary>
        /// 施工机具价格时间
        /// </summary>
        [Required] 
        public DateTime MachinePriceDate { get; set; }
        /// <summary>
        /// 项目所在地区
        /// </summary>
        [Required] 
        public string Area { get; set; }
        /// <summary>
        /// 项目所在地点
        /// </summary>
        [Required] 
        public string Location { get; set; }
        /// <summary>
        /// 编制（填报）说明
        /// </summary>
        public string Explains { get; set; }
        /// <summary>
        /// 建设性质
        /// </summary>
        [Required] 
        public int ProjectKind { get; set; }
        /// <summary>
        /// 系统信息
        /// </summary>
        public SystemInfo SystemInfo { get; set; }
        /// <summary>
        /// 工程信息
        /// </summary>
        public ConstructionInfo ConstructionInfo { get; set; }
        /// <summary>
        /// 费用汇总
        /// </summary>
        public SummaryOfCost SummaryOfCost { get; set; }
        /// <summary>
        /// 费用组成
        /// </summary>
        public ConstructionSummary ConstructionSummary { get; set; }

        //============================================关联信息
        /// <summary>
        /// 编制软件信息
        /// </summary>
        public string ID1 { get; set; }
        /// <summary>
        /// 编制机器硬件信息
        /// </summary>
        public string ID2 { get; set; }
        /// <summary>
        /// 文件生成时间
        /// </summary>
        public DateTime FileMakeDate { get; set; }
    }

    /// <summary>
    /// 系统信息 by 2025
    /// </summary>
    public partial class SystemInfo
    {
        /// <summary>
        /// 编制软件信息
        /// </summary>
        public string ID1 { get; set; }
        /// <summary>
        /// 编制机器硬件信息
        /// </summary>
        public string ID2 { get; set; }
        /// <summary>
        /// 文件生成时间
        /// </summary>
        [Required]
        public DateTime MakeDate { get; set; }
    }

    /// <summary>
    /// 工程信息 by 2025
    /// </summary>
    public partial class ConstructionInfo
    {
        /// <summary>
        /// 费用精度
        /// </summary>
        public Option Option { get; set; }
        /// <summary>
        /// 预算、结算信息
        /// </summary>
        public ProjectInfo ProjectInfo { get; set; }
        /// <summary>
        /// 招标信息
        /// </summary>
        public TendererInfo TendererInfo { get; set; }
        /// <summary>
        /// 投标信息
        /// </summary>
        public BidderInfo BidderInfo { get; set; }
        /// <summary>
        /// 工程特征信息
        /// </summary>
        public List<AttrInfo> AttrInfo { get; set; }
        /// <summary>
        /// 补充信息
        /// </summary>
        public List<AddiInfo> AddiInfo { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ConstructionProjectId { get; set; }

        public int SortNum { get; set; }
    }

    /// <summary>
    /// 费用精度 by 2025
    /// </summary>
    public partial class Option
    {
        /// <summary>
        /// 工料机消耗量、含量、数量类小数精度
        /// </summary>
        [Required]
        public double ResPrecision { get; set; }
        /// <summary>
        /// 工程量、数量类小数精度
        /// </summary>
        [Required] public double QuantityPrecision { get; set; }
        /// <summary>
        /// 金额、合价、费用类小数精度
        /// </summary>
        [Required] public double CostPrecision { get; set; }
        /// <summary>
        /// 费率（%）、比率（%）、指数（%）类小数精度
        /// </summary>
        [Required] public double RatePrecision { get; set; }

        //=================================================关联信息
        public string ProjectNumber { get; set; }
        public int SortNum { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime CreateDate { get; set; }

        //OpModel.ProjectNumber = CProjectModel.Number;
        //OpModel.SortNum = 1;
        //OpModel.ProjectId = CProjectModel.Id;
        //OpModel.CreateDate = DateTime.Now;
    }

    /// <summary>
    /// 预算、结算信息 by 2025
    /// </summary>
    public partial class ProjectInfo
    {
        /// <summary>
        /// 建设单位
        /// </summary>
        public string Developer { get; set; }
        /// <summary>
        /// 设计单位
        /// </summary>
        public string Designer { get; set; }
        /// <summary>
        /// 承包单位
        /// </summary>
        public string Contractor { get; set; }
        /// <summary>
        /// 编制单位
        /// </summary>
        [Required] public string CompileCompany { get; set; }
        /// <summary>
        /// 编制人
        /// </summary>
        public string Compiler { get; set; }
        /// <summary>
        /// 编制人资格证书编号
        /// </summary>
        public string CompilerCertNo { get; set; }
        /// <summary>
        /// 编制时间
        /// </summary>
        public DateTime? CompileDate { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string Examiner { get; set; }
        /// <summary>
        /// 审核人资格证书编号
        /// </summary>
        public string ExaminerCertNo { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? ExamineDate { get; set; }
        /// <summary>
        /// 审定人
        /// </summary>
        public string Approver { get; set; }
        /// <summary>
        /// 审定人资格证书编号
        /// </summary>
        public string ApproverCertNo { get; set; }
        /// <summary>
        /// 审定时间
        /// </summary>
        public DateTime? ApproverDate { get; set; }
        /// <summary>
        /// 工程总价（元）
        /// </summary>
        [Required] public double Total { get; set; }

        //=================================================关联信息
        public Guid ConstructionProjectId { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 招标信息 by 2025
    /// </summary>
    public partial class TendererInfo
    {
        /// <summary>
        /// 招标单位
        /// </summary>
        [Required] public string Tenderername { get; set; }
        /// <summary>
        /// 招标单位统一社会信用代码
        /// </summary>
        public string TenderUSCI { get; set; }
        /// <summary>
        /// 招标文件编制单位类型
        /// </summary>
        [Required] public int TenderCompileUnitKind { get; set; }
        /// <summary>
        /// 招标文件编制人
        /// </summary>
        public string TenderCompiler { get; set; }
        /// <summary>
        /// 招标文件编制人资格证书编号
        /// </summary>
        public string TenderCompilerCertNo { get; set; }
        /// <summary>
        /// 招标文件编制时间
        /// </summary>
        public DateTime? TenderCompileDate { get; set; }
        /// <summary>
        /// 招标文件审核人
        /// </summary>
        public string TenderExaminer { get; set; }
        /// <summary>
        /// 招标文件审核人资格证书编号
        /// </summary>
        public string TenderExaminerCertNo { get; set; }
        /// <summary>
        /// 招标文件审核时间
        /// </summary>
        public DateTime? TenderExamineDate { get; set; }
        /// <summary>
        /// 招标文件审定人
        /// </summary>
        public string TenderApprover { get; set; }
        /// <summary>
        /// 招标文件审定人资格证书编号
        /// </summary>
        public string TenderApproverCertNo { get; set; }
        /// <summary>
        /// 招标文件审定时间
        /// </summary>
        public DateTime? TenderApproveDate { get; set; }
        /// <summary>
        /// 招标代理单位
        /// </summary>
        [Required] public string Proxy { get; set; }
        /// <summary>
        /// 招标代理单位统一社会信用代码
        /// </summary>
        public string ProxyUSCI { get; set; }
        /// <summary>
        /// 造价咨询单位
        /// </summary>
        [Required] public string Consultant { get; set; }
        /// <summary>
        /// 造价咨询单位统一社会信用代码
        /// </summary>
        public string ConsultantUSCI { get; set; }
        /// <summary>
        /// 最高投标限价（元）
        /// </summary>
        [Required] public double BidPriceCeiling { get; set; }

        //==================================================关联信息
        public Guid ConstructionProjectId { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 投标信息 by 2025
    /// </summary>
    public partial class BidderInfo
    {
        /// <summary>
        /// 投标单位
        /// </summary>
        [Required] public string BidName { get; set; }
        /// <summary>
        /// 投标单位法定代表人或其授权人
        /// </summary>
        public string BidAuthorizer { get; set; }
        /// <summary>
        /// 投标总价（元）
        /// </summary>
        [Required] public double BidTotal { get; set; }
        /// <summary>
        /// 投标文件编制人
        /// </summary>
        public string BidCompiler { get; set; }
        /// <summary>
        /// 投标文件编制人资格证书编号
        /// </summary>
        public string BidCompilerCertNo { get; set; }
        /// <summary>
        /// 投标文件编制时间
        /// </summary>
        public DateTime? BidCompileDate { get; set; }
        /// <summary>
        /// 投标文件审核人
        /// </summary>
        public string BidExaminer { get; set; }
        /// <summary>
        /// 投标文件审核人资格证书编号
        /// </summary>
        public string BidExaminerCertNo { get; set; }
        /// <summary>
        /// 投标文件审核时间
        /// </summary>
        public DateTime? BidExamineDate { get; set; }
        /// <summary>
        /// 投标文件审定人
        /// </summary>
        public string BidApprover { get; set; }
        /// <summary>
        /// 投标文件审定人资格证书编号
        /// </summary>
        public string BidApproverCertNo { get; set; }
        /// <summary>
        /// 投标文件审定时间
        /// </summary>
        public DateTime? BidApproveDate { get; set; }
        //==================================================关联信息
        public Guid ConstructionProjectId { get; set; }
        public int SortNum { get; set; }
    }

    /// <summary>
    /// 工程特征信息 by 2025
    /// </summary>
    public partial class AttrInfo
    {
        /// <summary>
        /// 工程特征信息明细
        /// </summary>
        public List<AttrInfoItem> AttrInfoItem { get; set; }
    }

    /// <summary>
    /// 工程特征信息明细 by 2025
    /// </summary>
    public partial class AttrInfoItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 特征编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子项
        /// </summary>
        public List<AttrInfoItem> Children { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }


    }

    /// <summary>
    /// 补充信息 by 2025
    /// </summary
    public partial class AddiInfo
    {
        /// <summary>
        /// 补充信息明细
        /// </summary>
        public List<AddiInfoItem> AddiInfoItem { get; set; }
    }

    /// <summary>
    /// 补充信息明细 by 2025
    /// </summary>
    public partial class AddiInfoItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子项
        /// </summary>
        public List<AddiInfoItem> Children { get; set; }
        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
    }

    /// <summary>
    /// 费用汇总 by 2025
    /// </summary>
    public partial class SummaryOfCost
    {
        /// <summary>
        /// 工程总价（元）
        /// </summary>
        [Required] public double Total { get; set; }
        /// <summary>
        /// 分部分项工程费
        /// </summary>
        [Required] public double DivisionalAndElementalWorks { get; set; }
        /// <summary>
        /// 措施项目费
        /// </summary>
        [Required] public double Preliminaries { get; set; }
        /// <summary>
        /// 安全生产措施费
        /// </summary>
        public double CostForHSE { get; set; }
        /// <summary>
        /// 其他项目费
        /// </summary>
        [Required] public double SundryCosts { get; set; }
        /// <summary>
        /// 暂列金额
        /// </summary>
        public double ProvisionalSums { get; set; }
        /// <summary>
        /// 专业工程暂估价
        /// </summary>
        public double SpecialtyProvisionalPrice { get; set; }
        /// <summary>
        /// 计日工费用
        /// </summary>
        public double DayWorkRate { get; set; }
        /// <summary>
        /// 总承包服务费
        /// </summary>
        public double MainContractorAttendance { get; set; }
        /// <summary>
        /// 合同中约定的其他项目
        /// </summary>
        public double OtherContents { get; set; }
        /// <summary>
        /// 增值税
        /// </summary>
        public double Tax { get; set; }
        /// <summary>
        /// 人工费
        /// </summary>
        public double Labor { get; set; }
        /// <summary>
        /// 材料费(不含主材费)
        /// </summary>
        public double Material { get; set; }
        /// <summary>
        /// 主材设备费
        /// </summary>
        public double MainMaterialEquipment { get; set; }
        /// <summary>
        /// 主材费
        /// </summary>
        public double MainMaterial { get; set; }
        /// <summary>
        /// 设备费
        /// </summary>
        public double Equipment { get; set; }
        /// <summary>
        /// 施工机具使用费
        /// </summary>
        public double Machine { get; set; }
        /// <summary>
        /// 材料暂估单价
        /// </summary>
        public double ProvisionalMaterial { get; set; }
        /// <summary>
        /// 管理费
        /// </summary>
        public double Overhead { get; set; }
        /// <summary>
        /// 风险费
        /// </summary>
        public double RiskRate { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public double Profit { get; set; }
        /// <summary>
        /// 补充费用
        /// </summary>
        public List<AddiCost> AddiCost { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }

        public int SortNum { get; set; }

    }

    /// <summary>
    /// 补充费用 by 2025
    /// </summary>
    public partial class AddiCost
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        [Required] public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required] public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid CostId { get; set; }
        public int SortNum { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }

        public Guid ParentId { get; set; }
    }

    /// <summary>
    /// 费用组成 by 2025
    /// </summary>
    public partial class ConstructionSummary
    {
        /// <summary>
        /// 工程费用
        /// </summary>
        public ConstructionCost ConstructionCost { get; set; }
        /// <summary>
        /// 工程建设其他投资
        /// </summary>
        public OtherInvestmentOfConstructionProject OtherInvestmentOfConstructionProject { get; set; }
        /// <summary>
        /// 预备费
        /// </summary>
        public ContingencyFee ContingencyFee { get; set; }
        /// <summary>
        /// 筹措资金费
        /// </summary>
        public FundraisingFee FundraisingFee { get; set; }
        /// <summary>
        /// 流动资金
        /// </summary>
        public WorkingCapital WorkingCapital { get; set; }

        //=================================================关联信息
        public Guid ConstructionProjectsId { get; set; }
        public Guid Id { get; set; }
    }

    /// <summary>
    /// 工程费用 by 2025
    /// </summary>
    public partial class ConstructionCost
    {
        /// <summary>
        /// 工程名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 建设规模
        /// </summary>
        public double Scale { get; set; }
        /// <summary>
        /// 建设规模计量单位
        /// </summary>
        public string ScaleUnit { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 建筑安装工程费
        /// </summary>
        public ProjectInstallationWorkCost ProjectInstallationWorkCost { get; set; }
        /// <summary>
        /// 设备购置费
        /// </summary>
        public EquipmentProcurementCost EquipmentProcurementCost { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public List<OtherCost> OtherCost { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ConstructionProjectId { get; set; }
        public Guid ConstructionSummaryId { get; set; }
    }

    /// <summary>
    /// 建筑安装工程费 by 2025
    /// </summary>
    public partial class ProjectInstallationWorkCost
    {
        /// <summary>
        /// 工程名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 建设规模
        /// </summary>
        public double Scale { get; set; }
        /// <summary>
        /// 建设规模计量单位
        /// </summary>
        public string ScaleUnit { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 分部分项工程
        /// </summary>
        public List<SectionalWorks> SectionalWorks { get; set; }
        /// <summary>
        /// 措施项目
        /// </summary>
        public Preliminaries Preliminaries { get; set; }
        /// <summary>
        /// 其他项目
        /// </summary>
        public Sundry Sundry { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public List<OtherCost> OtherCost { get; set; }
        /// <summary>
        /// 工料机汇总
        /// </summary>
        public List<LabourMaterialsEquipmentsMachinesSummary> LabourMaterialsEquipmentsMachinesSummary { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ConstructionCost { get; set; }
        public int SortNum { get; set; }
        public Guid ConstructionSummaryId { get; set; }


    }

    /// <summary>
    /// 措施项目 by 2025
    /// </summary>
    public partial class Preliminaries
    {
        /// <summary>
        /// 基本费用汇总
        /// </summary>
        public List<SummaryOfBasicCost> SummaryOfBasicCost { get; set; }
        /// <summary>
        /// 工作要素
        /// </summary>
        public List<WorkElement> WorkElement { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }

        public Guid ConstructionCostId { get; set; }
    }

    /// <summary>
    /// 其他项目 by 2025
    /// </summary>
    public partial class Sundry
    {
        /// <summary>
        /// 其他项目费
        /// </summary>
        public SundryCosts SundryCosts { get; set; }
        /// <summary>
        /// 暂列金额
        /// </summary>
        public ProvisionalSums ProvisionalSums { get; set; }
        /// <summary>
        /// 专业工程暂估价
        /// </summary>
        public SpecialtyProvisionalPrice SpecialtyProvisionalPrice { get; set; }
        /// <summary>
        /// 计日工费用
        /// </summary>
        public DayWorkRate DayWorkRate { get; set; }
        /// <summary>
        /// 总承包服务费
        /// </summary>
        public MainContractorAttendance MainContractorAttendance { get; set; }
        /// <summary>
        /// 其他内容
        /// </summary>
        public OtherContents OtherContents { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid ConstructionCostId { get; set; }
    }

    /// <summary>
    /// 其他项目费 by 2025
    /// </summary>
    public partial class SundryCosts
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 暂估（暂定）金额（元）
        /// </summary>
        public double ProvisionalTotal { get; set; }
        /// <summary>
        /// 结算（确定）金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 调整金额±（元）
        /// </summary>
        public double TotalDifference { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required] public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 其他项目费汇总
        /// </summary>
        public List<SundryCostsGroup> SundryCostsGroup { get; set; }
        /// <summary>
        /// 其他项目费明细
        /// </summary>
        public List<SundryCostsItem> SundryCostsItem { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }

    /// <summary>
    /// 其他项目费汇总 by 2025
    /// </summary>
    public partial class SundryCostsGroup
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 结算金额（元）
        /// </summary>
        public double SettlementTotal { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required] public string Code { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required] public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子项汇总
        /// </summary>
        public List<SundryCostsGroup> SundryCostsGroups { get; set; }
        /// <summary>
        /// 明细项
        /// </summary>
        public List<SundryCostsItem> SundryCostsItem { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 其他项目费明细 by 2025
    /// </summary>
    public partial class SundryCostsItem
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 单价（元）
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 暂估（暂定）金额（元）
        /// </summary>
        public double ProvisionalTotal { get; set; }
        /// <summary>
        /// 结算（确定）金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 调整金额±（元）
        /// </summary>
        public double TotalDifference { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required]public string Code { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required]public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid SundryCostsGroupId { get; set; }
        public int SortNum { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }
    }


    /// <summary>
    /// 单项工程 by 2025
    /// </summary>
    public partial class SectionalWorks
    {
        /// <summary>
        /// 工程编号
        /// </summary>
        [Required]public string Number { get; set; }
        /// <summary>
        /// 工程名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 标段名称
        /// </summary>
        public string Segment { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 建设规模
        /// </summary>
        [Required] public double Scale { get; set; }
        /// <summary>
        /// 建设规模计量单位
        /// </summary>
        [Required] public string ScaleUnit { get; set; }
        /// <summary>
        /// 占整个项目费用比率(%)
        /// </summary>
        public double Ratios { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 工程特征信息
        /// </summary>
        public List<AttrInfo> AttrInfo { get; set; }
        /// <summary>
        /// 费用汇总
        /// </summary>
        public SummaryOfCost SummaryOfCost { get; set; }
        /// <summary>
        /// 子单项工程
        /// </summary>
        public List<SectionalWorks> ChildSectionalWorks { get; set; }
        /// <summary>
        /// 单位工程
        /// </summary>
        public List<UnitWorks> UnitWorks { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public List<OtherCost> OtherCost { get; set; }
        /// <summary>
        /// 工料机汇总
        /// </summary>
        public List<LabourMaterialsEquipmentsMachinesSummary> LabourMaterialsEquipmentsMachinesSummary { get; set; }

        //==========================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectfeeId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }

    }

    /// <summary>
    /// 单位工程 by 2025
    /// </summary>
    public partial class UnitWorks
    {
        /// <summary>
        /// 工程编号
        /// </summary>
        [Required] public string Number { get; set; }
        /// <summary>
        /// 工程名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 标段名称
        /// </summary>
        public string Segment { get; set; }
        /// <summary>
        /// 计价类别
        /// </summary>
        [Required] public int ValuationMethod { get; set; }
        /// <summary>
        /// 计税模式
        /// </summary>
        [Required] public int TaxModel { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 专业类别
        /// </summary>
        [Required] public string Specialty { get; set; }
        /// <summary>
        /// 工程用途
        /// </summary>
        public string Purposes { get; set; }
        /// <summary>
        /// 建设规模
        /// </summary>
        public double Scale { get; set; }
        /// <summary>
        /// 建设规模计量单位
        /// </summary>
        public string ScaleUnit { get; set; }
        /// <summary>
        /// 清单规则库名称
        /// </summary>
        [Required] public string BillDataBase { get; set; }
        /// <summary>
        /// 人工材料设备价格文件名称
        /// </summary>
        [Required] public string ResInfoPricingFile { get; set; }
        /// <summary>
        /// 材料价格时间
        /// </summary>
        [Required] public DateTime MaterialPriceDate { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 编制（填报）说明
        /// </summary>
        public string Explains { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 工程特征信息
        /// </summary>
        public List<AttrInfo> AttrInfo { get; set; }
        /// <summary>
        /// 补充信息
        /// </summary>
        public AddiInfo AddiInfo { get; set; }
        /// <summary>
        /// 单位工程费用组成
        /// </summary>
        public UnitWorksSummary UnitWorksSummary { get; set; }
        /// <summary>
        /// 分部分项工程
        /// </summary>
        public DivisionalAndElementalWorks DivisionalAndElementalWorks { get; set; }
        /// <summary>
        /// 工料机汇总
        /// </summary>
        public List<LabourMaterialsEquipmentsMachinesSummary> LabourMaterialsEquipmentsMachinesSummary { get; set; }

        //==========================================================关联信息
        public Guid Id { get; set; }
        public int SortNum { get; set; }
        public Guid SectionalWorksId { get; set; }

    }

    /// <summary>
    /// 单位工程费用组成 by 2025
    /// </summary>
    public partial class UnitWorksSummary
    {
        /// <summary>
        /// 费用组成汇总
        /// </summary>
        public List<UnitWorksSummaryGroup> Groups { get; set; }
        /// <summary>
        /// 费用组成明细
        /// </summary>
        public List<UnitWorksSummaryItem> Items { get; set; }


        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }

        public int SortNum { get; set; }

    }

    /// <summary>
    /// 单位工程费用组成汇总 by 2025
    /// </summary>
    public partial class UnitWorksSummaryGroup
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required] public string Code { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required] public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子项汇总
        /// </summary>
        public List<UnitWorksSummaryGroup> ChildGroups { get; set; }
        /// <summary>
        /// 明细项
        /// </summary>
        public List<UnitWorksSummaryItem> Items { get; set; }

        //==========================================================关联信息
        public Guid Id { get; set; }
        public int SortNum { get; set; }
        public Guid UnitWorksId { get; set; }
    }

    /// <summary>
    /// 单位工程费用组成明细 by 2025
    /// </summary>
    public partial class UnitWorksSummaryItem
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required] public string Code { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required] public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //==========================================================关联信息
        public Guid Id { get; set; }
        public int SortNum { get; set; }
        public Guid UnitWorksId { get; set; }
    }

    /// <summary>
    /// 分部分项工程 by 2025
    /// </summary>
    public partial class DivisionalAndElementalWorks
    {
        /// <summary>
        /// 合计费用
        /// </summary>
        public List<SummaryOfBasicCost> SummaryOfBasicCost { get; set; }
        /// <summary>
        /// 分部工程
        /// </summary>
        public List<DivisionalWorks> DivisionalWorks { get; set; }
        /// <summary>
        /// 工作要素
        /// </summary>
        public List<WorkElement> WorkElement { get; set; }
    }

    /// <summary>
    /// 合计费用 by 2025
    /// </summary>
    public partial class SummaryOfBasicCost
    {
        /// <summary>
        /// 人工费
        /// </summary>
        public double Labor { get; set; }
        /// <summary>
        /// 材料费
        /// </summary>
        public double Material { get; set; }
        /// <summary>
        /// 主材设备费
        /// </summary>
        public double MainMaterialEquipment { get; set; }
        /// <summary>
        /// 主材费
        /// </summary>
        public double MainMaterial { get; set; }
        /// <summary>
        /// 设备费
        /// </summary>
        public double Equipment { get; set; }
        /// <summary>
        /// 施工机具使用费
        /// </summary>
        public double Machine { get; set; }
        /// <summary>
        /// 管理费
        /// </summary>
        public double Overhead { get; set; }
        /// <summary>
        /// 风险费
        /// </summary>
        public double RiskRate { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public double Profit { get; set; }
        /// <summary>
        /// 暂估价
        /// </summary>
        public double Appraisal { get; set; }
        /// <summary>
        /// 补充费用
        /// </summary>
        public List<AddiCost> AddiCost { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid CostFacherId { get; set; }
        public Guid MainProjectId { get; set; }
        public string FatherNode { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 分部工程 by 2025
    /// </summary>
    public partial class DivisionalWorks
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required] public string Number { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 特征
        /// </summary>
        public string Attr { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 取费条件
        /// </summary>
        public string CostCondition { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 合计费用
        /// </summary>
        public List<SummaryOfBasicCost> SummaryOfBasicCost { get; set; }
        /// <summary>
        /// 子分部工程
        /// </summary>
        public List<DivisionalWorks> ChildDivisionalWorks { get; set; }
        /// <summary>
        /// 清单项目
        /// </summary>
        public List<WorkElement> WorkElement { get; set; }

        //==========================================================关联信息
        public Guid Id { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid DWorksFatherId { get; set; }
        public string FatherNodeName { get; set; }

    }

    /// <summary>
    /// 清单项目 by 2025
    /// </summary>
    public partial class WorkElement
    {
        /// <summary>
        /// 项目编码
        /// </summary>
        [Required] public string Number { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 项目特征
        /// </summary>
        [Required] public string Attr { get; set; }
        /// <summary>
        /// 工作内容
        /// </summary>
        public string WorkContent { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        [Required] public string Unit { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        [Required] public double Quantity { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 调整前单价（元）
        /// </summary>
        public double OriginalPrice { get; set; }
        /// <summary>
        /// 单价（元）
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 最高限价（元）
        /// </summary>
        public double PriceHigh { get; set; }
        /// <summary>
        /// 调整前费率(%)
        /// </summary>
        public double OriginalRate { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 调整前合价（元）
        /// </summary>
        public double OriginalTotal { get; set; }
        /// <summary>
        /// 合价（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 主要清单
        /// </summary>
        public bool Major { get; set; }
        /// <summary>
        /// 计算方式
        /// </summary>
        [Required] public int CalcType { get; set; }
        /// <summary>
        /// 专业类别
        /// </summary>
        public string Specialty { get; set; }
        /// <summary>
        /// 清单标识
        /// </summary>
        public string WorkElementIdentity { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 合计费用
        /// </summary>
        public SummaryOfBasicCost SummaryOfBasicCost { get; set; }
        /// <summary>
        /// 工程量计算表
        /// </summary>
        public List<ExpressElement> ExpressElement { get; set; }
        /// <summary>
        /// 工作内容明细
        /// </summary>
        public List<WorkContent> WorkContentDetails { get; set; }
        /// <summary>
        /// 单价分析
        /// </summary>
        public PriceAnalysis PriceAnalysis { get; set; }

        //==========================================================关联信息
        public Guid Id { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid SectionalWorksId { get; set; }
        public Guid WorksEleFatherId { get; set; }
        public string FatherNodeName { get; set; }

    }

    /// <summary>
    /// 工程量计算表 by 2025
    /// </summary>
    public partial class ExpressElement
    {
        /// <summary>
        /// 序号
        /// </summary>
        [Required] public string OrderNumber { get; set; }
        /// <summary>
        /// 工程量计算式
        /// </summary>
        [Required] public string Express { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        [Required] public double Quantity { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required] public int Kind { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ExpItemFatherId { get; set; }
        public string FatherNodeName { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 工作内容 by 2025
    /// </summary>
    public partial class WorkContent
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 工程内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子工作内容
        /// </summary>
        public List<WorkContent> ChildWorkContents { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid WorkElementId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 单价分析 by 2025
    /// </summary>
    public partial class PriceAnalysis
    {
        /// <summary>
        /// 调整前单价明细
        /// </summary>
        public List<OriginalPriceItem> OriginalPriceItems { get; set; }
        /// <summary>
        /// 单价明细
        /// </summary>
        public List<PriceItem> PriceItems { get; set; }
        /// <summary>
        /// 工料机明细
        /// </summary>
        public List<LabourMaterialsEquipmentsMachinesElement> LabourMaterialsEquipmentsMachines { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid WorkElementId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 调整前单价明细 by 2025
    /// </summary>
    public partial class OriginalPriceItem
    {
        /// <summary>
        /// 人工费
        /// </summary>
        public double Labor { get; set; }
        /// <summary>
        /// 材料费
        /// </summary>
        public double Material { get; set; }
        /// <summary>
        /// 主材设备费
        /// </summary>
        public double MainMaterialEquipment { get; set; }
        /// <summary>
        /// 主材费
        /// </summary>
        public double MainMaterial { get; set; }
        /// <summary>
        /// 设备费
        /// </summary>
        public double Equipment { get; set; }
        /// <summary>
        /// 施工机具使用费
        /// </summary>
        public double Machine { get; set; }
        /// <summary>
        /// 管理费
        /// </summary>
        public double Overhead { get; set; }
        /// <summary>
        /// 风险费
        /// </summary>
        public double RiskRate { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public double Profit { get; set; }
        /// <summary>
        /// 补充费用
        /// </summary>
        public List<AddiCost> AddiCost { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid AttrId { get; set; }
        public string AttrName { get; set; }
        public Guid PriceAnalysisId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

        public Guid ProjectId { get; set; }
        public Guid ParentId { get; set; }

    }

    /// <summary>
    /// 单价明细 by 2025
    /// </summary>
    public partial class PriceItem
    {
        /// <summary>
        /// 人工费
        /// </summary>
        public double Labor { get; set; }
        /// <summary>
        /// 材料费
        /// </summary>
        public double Material { get; set; }
        /// <summary>
        /// 主材设备费
        /// </summary>
        public double MainMaterialEquipment { get; set; }
        /// <summary>
        /// 主材费
        /// </summary>
        public double MainMaterial { get; set; }
        /// <summary>
        /// 设备费
        /// </summary>
        public double Equipment { get; set; }
        /// <summary>
        /// 施工机具使用费
        /// </summary>
        public double Machine { get; set; }
        /// <summary>
        /// 管理费
        /// </summary>
        public double Overhead { get; set; }
        /// <summary>
        /// 风险费
        /// </summary>
        public double RiskRate { get; set; }
        /// <summary>
        /// 利润
        /// </summary>
        public double Profit { get; set; }
        /// <summary>
        /// 补充费用
        /// </summary>
        public List<AddiCost> AddiCost { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid AttrId { get; set; }
        public string AttrName { get; set; }
        public Guid PriceAnalysisId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ProjectId { get; set; }

        public Guid ParentId { get; set; }
    }

    /// <summary>
    /// 预备费 by 2025
    /// </summary>
    public partial class ContingencyFee
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 预备费分组
        /// </summary>
        public List<ContingencyFeeGroup> ContingencyFeeGroups { get; set; }
        /// <summary>
        /// 预备费明细项
        /// </summary>
        public List<ContingencyFeeItem> ContingencyFeeItems { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ConstructionProjectsId { get; set; }
        public Guid ConstructionSummaryId { get; set; }

    }

    /// <summary>
    /// 资金筹措费 by 2025
    /// </summary>
    public partial class FundraisingFee
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 资金筹措费分组
        /// </summary>
        public List<FundraisingFeeGroup> FundraisingFeeGroups { get; set; }
        /// <summary>
        /// 资金筹措费明细项
        /// </summary>
        public List<FundraisingFeeItem> FundraisingFeeItems { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ConstructionProjectsId { get; set; }
        public Guid ConstructionSummaryId { get; set; }
    }

    /// <summary>
    /// 流动资金 by 2025
    /// </summary>
    public partial class WorkingCapital
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 流动资金分组
        /// </summary>
        public List<WorkingCapitalGroup> WorkingCapitalGroups { get; set; }
        /// <summary>
        /// 流动资金明细项
        /// </summary>
        public List<WorkingCapitalItem> WorkingCapitalItems { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ConstructionProjectsId { get; set; }
        public Guid ConstructionSummaryId { get; set; }
        public int Type { get; set; }
    }

    /// <summary>
    /// 工程建设其他费用 by 2025
    /// </summary>
    public partial class OtherInvestmentOfConstructionProject
    {
        /// <summary>
        /// 费用项目名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 工程建设其他费用分组
        /// </summary>
        public List<OtherInvestmentOfConstructionProjectGroup> Groups { get; set; }
        /// <summary>
        /// 工程建设其他费用明细项
        /// </summary>
        public List<OtherInvestmentOfConstructionProjectItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ConstructionProjectsId { get; set; }
        public Guid ConstructionSummaryId { get; set; }

    }

    /// <summary>
    /// 设备及工器具购置费 by 2025
    /// </summary>
    public partial class EquipmentProcurementCost
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 设备及工器具购置费明细项
        /// </summary>
        public List<EquipmentProcurementCostItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ConstructionCost { get; set; }
        public int SortNum { get; set; }
        public Guid ConstructionSummaryId { get; set; }

        public Guid SectionalWorksId { get; set; }
    }

    /// <summary>
    /// 扩展项 by 2025
    /// </summary>
    public partial class OtherCost
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 占整个项目费用比率(%)
        /// </summary>
        public double Ratios { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子扩展项
        /// </summary>
        public List<OtherCost> ChildOtherCosts { get; set; }
        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid ConstructionCostId { get; set; }
        public Guid SectionalWorksId { get; set; }

    }

    /// <summary>
    /// 暂列金额 by 2025
    /// </summary>
    public partial class ProvisionalSums
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 暂列金额分组
        /// </summary>
        public List<ProvisionalSumsGroup> Groups { get; set; }
        /// <summary>
        /// 暂列金额明细项
        /// </summary>
        public List<ProvisionalSumsItem> Items { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
    }

    /// <summary>
    /// 专业工程暂估价 by 2025
    /// </summary>
    public partial class SpecialtyProvisionalPrice
    {
        /// <summary>
        /// 工程名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 暂估金额（元）
        /// </summary>
        public double ProvisionalTotal { get; set; }
        /// <summary>
        /// 结算金额（元）
        /// </summary>
        public double SettlementTotal { get; set; }
        /// <summary>
        /// 调整金额±（元）
        /// </summary>
        public double TotalDifference { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required] public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 专业工程暂估价分组
        /// </summary>
        public List<SpecialtyProvisionalPriceGroup> Groups { get; set; }
        /// <summary>
        /// 专业工程暂估价明细项
        /// </summary>
        public List<SpecialtyProvisionalPriceItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }
    }

    /// <summary>
    /// 计日工 by 2025
    /// </summary>
    public partial class DayWorkRate
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 暂定合价（元）
        /// </summary>
        public double ProvisionalTotal { get; set; }
        /// <summary>
        /// 实际合价（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required] public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 计日工分组
        /// </summary>
        public List<DayWorkRateGroup> Groups { get; set; }
        /// <summary>
        /// 计日工明细项
        /// </summary>
        public List<DayWorkRateItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }
    }

    /// <summary>
    /// 总承包服务费 by 2025
    /// </summary>
    public partial class MainContractorAttendance
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required] public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 总承包服务费分组
        /// </summary>
        public List<MainContractorAttendanceGroup> Groups { get; set; }
        /// <summary>
        /// 总承包服务费明细项
        /// </summary>
        public List<MainContractorAttendanceItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }
    }

    /// <summary>
    /// 合同中约定的其他项目 by 2025
    /// </summary>
    public partial class OtherContents
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        [Required]public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 其他项目分组
        /// </summary>
        public List<OtherContentsGroup> Groups { get; set; }
        /// <summary>
        /// 其他项目明细项  -- zhangxiaobin xml缺乏这个元素，需要和产品确认 李恺平 2025-9-10 14:35:19
        /// </summary>
        public List<OtherContentsItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }

    }
    /// <summary>
    /// 工料机含量明细 by 2025
    /// </summary>
    public partial class LabourMaterialsEquipmentsMachinesElement
    {
        /// <summary>
        /// 工料机编码
        /// </summary>
        [Required]public string Number { get; set; }

        /// <summary>
        /// 消耗量
        /// </summary>
        [Required]public double Quantity { get; set; }

        /// <summary>
        /// 原始含量
        /// </summary>
        public double OriginalContent { get; set; }

        /// <summary>
        /// 不计价材料
        /// </summary>
        [Required]public bool NOCost { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //=================================================关联信息
        public Guid LMEMS_ID { get; set; }
        public Guid Id { get; set; }
        public int SortNum { get; set; }
        public Guid AttrId { get; set; }
        public string AttrName { get; set; }
        public Guid PriceAnalysisId { get; set; }
        public Guid MainProjectId { get; set; }
        public Guid ProjectId { get; set; }

    }
    /// <summary>
    /// 工料机汇总 by 2025
    /// </summary>
    public partial class LabourMaterialsEquipmentsMachinesSummary
    {
        /// <summary>
        /// 工料机编码
        /// </summary>
        [Required]public string Number { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        [Required] public string Specification { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required] public string Unit { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 风险幅度(%)
        /// </summary>
        public string ProviderRate { get; set; }
        /// <summary>
        /// 基准价（元）
        /// </summary>
        public double ProviderBase { get; set; }
        /// <summary>
        /// 税率(%)
        /// </summary>
        public double TaxRate { get; set; }
        /// <summary>
        /// 不含税编制价（元）
        /// </summary>
        public double NoTaxPrice { get; set; }
        /// <summary>
        /// 含税编制价（元）
        /// </summary>
        public double TaxPrice { get; set; }
        /// <summary>
        /// 不含税编制价合价（元）
        /// </summary>
        public double NoTaxTotal { get; set; }
        /// <summary>
        /// 含税编制价合价（元）
        /// </summary>
        public double TaxTotal { get; set; }
        /// <summary>
        /// 变值权重
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// 基本价格指数
        /// </summary>
        public string BasicPrice { get; set; }
        /// <summary>
        /// 现行价格指数
        /// </summary>
        public string CurrentPrice { get; set; }
        /// <summary>
        /// 工料机类型
        /// </summary>
        [Required] public int Kind { get; set; }
        /// <summary>
        /// 工料机归属
        /// </summary>
        [Required] public string Class { get; set; }
        /// <summary>
        /// 扩展属性
        /// </summary>
        public int? ExtKind { get; set; }
        /// <summary>
        /// 附加属性
        /// </summary>
        public int? AddiKind { get; set; }
        /// <summary>
        /// 主要材料
        /// </summary>
        public bool? MainMaterial { get; set; }
        /// <summary>
        /// 材料暂估单价
        /// </summary>
        public bool? ProvisionalMaterial { get; set; }
        /// <summary>
        /// 供料方式
        /// </summary>
        public int? Provider { get; set; }
        /// <summary>
        /// 价格来源
        /// </summary>
        public string PriceSource { get; set; }
        /// <summary>
        /// 交货方式
        /// </summary>
        public string Delivery { get; set; }
        /// <summary>
        /// 送达地点
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 产地
        /// </summary>
        public string ProducingArea { get; set; }
        /// <summary>
        /// 厂家
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// 质量要求
        /// </summary>
        public string Character { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 工料机含量明细
        /// </summary>
        public List<LabourMaterialsEquipmentsMachinesElement> Elements { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

        public Guid ParentId { get; set; }
        public Guid SectionalWorksId { get; set; }

    }

    /// <summary>
    /// 预备费汇总 by 2025
    /// </summary>
    public partial class ContingencyFeeGroup
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required]public string Unit { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子预备费汇总
        /// </summary>
        public List<ContingencyFeeGroup> SubGroups { get; set; }
        /// <summary>
        /// 预备费明细
        /// </summary>
        public List<ContingencyFeeItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ContingencyFeeId { get; set; }

        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }


    }

    /// <summary>
    /// 预备费明细 by 2025
    /// </summary>
    public partial class ContingencyFeeItem
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required]public string Unit { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 单价（元）
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 合价（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用类型
        /// </summary>
        public int? Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ContingencyFeeId { get; set; }

        public Guid ContingencyFeeGroupId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }

    /// <summary>
    /// 资金筹措费汇总 by 2025
    /// </summary>
    public partial class FundraisingFeeGroup
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required]public string Unit { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子资金筹措费汇总
        /// </summary>
        public List<FundraisingFeeGroup> SubGroups { get; set; }
        /// <summary>
        /// 资金筹措费明细
        /// </summary>
        public List<FundraisingFeeItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid FundraisingFeeId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
    }

    /// <summary>
    /// 资金筹措费明细 by 2025
    /// </summary>
    public partial class FundraisingFeeItem
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required]public string Unit { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid FundraisingFeeId { get; set; }

        public Guid FundraisingFeeGroupId { get; set; }

        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }

    /// <summary>
    /// 流动资金汇总 by 2025
    /// </summary>
    public partial class WorkingCapitalGroup
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required] public string Unit { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子流动资金汇总
        /// </summary>
        public List<WorkingCapitalGroup> SubGroups { get; set; }
        /// <summary>
        /// 流动资金明细
        /// </summary>
        public List<WorkingCapitalItem> Items { get; set; }
        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid WorkingCapitalId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 流动资金明细 by 2025
    /// </summary>
    public partial class WorkingCapitalItem
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required] public string Unit { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 合价（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid WorkingCapitalId { get; set; }
        public Guid WorkingCapitalGroupId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }
    /// <summary>
    /// 工程建设其他费用汇总 by 2025
    /// </summary>
    public partial class OtherInvestmentOfConstructionProjectGroup
    {
        /// <summary>
        /// 费用项目编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 费用项目名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required] public string Unit { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子工程建设其他费用汇总
        /// </summary>
        public List<OtherInvestmentOfConstructionProjectGroup> SubGroups { get; set; }
        /// <summary>
        /// 工程建设其他费用明细
        /// </summary>
        public List<OtherInvestmentOfConstructionProjectItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid OtherInvestmentOfConstructionProjectId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

    }

    /// <summary>
    /// 工程建设其他费用明细 by 2025
    /// </summary>
    public partial class OtherInvestmentOfConstructionProjectItem
    {
        /// <summary>
        /// 费用项目编号
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 费用项目名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required] public string Unit { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 单价（元）
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 计算方法说明
        /// </summary>
        public string Rule { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid OtherInvestmentOfConstructionProjectId { get; set; }

        public Guid OtherInvestmentOfConstructionProjectGroupId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }

    /// <summary>
    /// 设备及工器具购置费明细 by 2025
    /// </summary>
    public partial class EquipmentProcurementCostItem
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required]public string Number { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 型号规格及材质
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        [Required] public string Unit { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Required] public double Quantity { get; set; }
        /// <summary>
        /// 单价（元）
        /// </summary>
        [Required] public double Price { get; set; }
        /// <summary>
        /// 合价（元）
        /// </summary>
        [Required] public double Total { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int? Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 单价分析
        /// </summary>
        public UnitPriceCalculationOfItem UnitPriceCalculation { get; set; }
        //=================================================关联信息
        public Guid EquipmentId { get; set; }
        public Guid Id { get; set; }
        public int SortNum { get; set; }


    }

    /// <summary>
    /// 暂列金额汇总 by 2025
    /// </summary>
    public partial class ProvisionalSumsGroup
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required]public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子暂列金额汇总
        /// </summary>
        public List<ProvisionalSumsGroup> SubGroups { get; set; }
        /// <summary>
        /// 暂列金额明细
        /// </summary>
        public List<ProvisionalSumsItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }

    }

    /// <summary>
    /// 暂列金额明细 by 2025
    /// </summary>
    public partial class ProvisionalSumsItem
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 单价（元）
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 暂定金额（元）
        /// </summary>
        public double ProvisionalTotal { get; set; }
        /// <summary>
        /// 确定金额（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 调整金额±（元）
        /// </summary>
        public double TotalDifference { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required]public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid ProvisionalGroupId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }

    }

    /// <summary>
    /// 专业工程暂估价汇总 by 2025
    /// </summary>
    public partial class SpecialtyProvisionalPriceGroup
    {
        /// <summary>
        /// 工程名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 工程内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 暂估金额（元）
        /// </summary>
        public double ProvisionalTotal { get; set; }
        /// <summary>
        /// 结算金额（元）
        /// </summary>
        public double SettlementTotal { get; set; }
        /// <summary>
        /// 调整金额±（元）
        /// </summary>
        public double TotalDifference { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required] public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 子专业工程暂估价汇总
        /// </summary>
        public List<SpecialtyProvisionalPriceGroup> SubGroups { get; set; }
        /// <summary>
        /// 专业工程暂估价明细
        /// </summary>
        public List<SpecialtyProvisionalPriceItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }

    }

    /// <summary>
    /// 专业工程暂估价明细 by 2025
    /// </summary>
    public partial class SpecialtyProvisionalPriceItem
    {
        /// <summary>
        /// 工程名称
        /// </summary>
        [Required] public string Name { get; set; }
        /// <summary>
        /// 工程内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 工程量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 单价（元）
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double Rate { get; set; }
        /// <summary>
        /// 暂估金额不含税价格（元）
        /// </summary>
        public double NoTaxProvisionalTotal { get; set; }
        /// <summary>
        /// 暂估金额增值税（元）
        /// </summary>
        public double ProvisionalTotalTax { get; set; }
        /// <summary>
        /// 暂估金额含税价格（元）
        /// </summary>
        public double TaxOrgProvisionalTotal { get; set; }
        /// <summary>
        /// 结算金额不含税价格（元）
        /// </summary>
        public double NoTaxSettlementTotal { get; set; }
        /// <summary>
        /// 结算金额增值税（元）
        /// </summary>
        public double SettlementTotalTax { get; set; }
        /// <summary>
        /// 结算金额含税价格（元）
        /// </summary>
        public double TaxOrgSettlementTotal { get; set; }
        /// <summary>
        /// 调整金额±（元）
        /// </summary>
        public double TotalDifference { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required] public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid SpecialtyProvisionalPriceGroupId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }

    /// <summary>
    /// 计日工汇总 by 2025
    /// </summary>
    public partial class DayWorkRateGroup
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 暂定合价（元）
        /// </summary>
        public double ProvisionalTotal { get; set; }
        /// <summary>
        /// 实际合价（元）
        /// </summary>
        public double Total { get; set; }
        /// <summary>
        /// 费用代号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 计日工明细
        /// </summary>
        public List<DayWorkRateItem> Items { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }

    }

    /// <summary>
    /// 计日工明细 by 2025
    /// </summary>
    public partial class DayWorkRateItem
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Required]public string Number { get; set; }

        /// <summary>
        /// 计日工名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        [Required] public string Unit { get; set; }

        /// <summary>
        /// 暂定数量
        /// </summary>
        public double? ProvisionalQuantity { get; set; }

        /// <summary>
        /// 实际数量
        /// </summary>
        public double? Quantity { get; set; }

        /// <summary>
        /// 综合单价（元）
        /// </summary>
        public double? Price { get; set; }

        /// <summary>
        /// 暂定合价（元）
        /// </summary>
        public double? ProvisionalTotal { get; set; }

        /// <summary>
        /// 实际合价（元）
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        /// 调整金额±（元）
        /// </summary>
        public double? TotalDifference { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //==================================================关联信息
        public Guid Id { get; set; }
        public Guid DayWorkRateGroupId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }
        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }

    /// <summary>
    /// 总承包服务费汇总 by 2025
    /// </summary>
    public partial class MainContractorAttendanceGroup
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]public string Name { get; set; }

        /// <summary>
        /// 金额（元）
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required]public int Kind { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 子分组列表
        /// </summary>
        public List<MainContractorAttendanceGroup> Groups { get; set; } = new List<MainContractorAttendanceGroup>();

        /// <summary>
        /// 明细项列表
        /// </summary>
        public List<MainContractorAttendanceItem> Items { get; set; } = new List<MainContractorAttendanceItem>();

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }
        public int SortNum { get; set; }
        public Guid MainProjectId { get; set; }

    }
    /// <summary>
    /// 总承包服务费明细 by 2025
    /// </summary>
    public partial class MainContractorAttendanceItem
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]public string Name { get; set; }

        /// <summary>
        /// 项目价值（元）
        /// </summary>
        public double? Quantity { get; set; }

        /// <summary>
        /// 服务内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }

        /// <summary>
        /// 费率(%)
        /// </summary>
        public double? Rate { get; set; }

        /// <summary>
        /// 金额（元）
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        /// 确认计算基础
        /// </summary>
        public string SettlementCalBasis { get; set; }

        /// <summary>
        /// 结算金额（元）
        /// </summary>
        public double? SettlementTotal { get; set; }

        /// <summary>
        /// 调整金额±（元）
        /// </summary>
        public double? TotalDifference { get; set; }

        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required]public int Kind { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid MainContractorAttendanceGroupId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }
    /// <summary>
    /// 合同中约定的其他项目明细项 by 2025
    /// </summary>
    public partial class OtherContentsItem
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]public string Name { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public double? Quantity { get; set; }
        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }
        /// <summary>
        /// 单价（元）
        /// </summary>
        public double? Price { get; set; }
        /// <summary>
        /// 费率(%)
        /// </summary>
        public double? Rate { get; set; }
        /// <summary>
        /// 合价（元）
        /// </summary>
        public string Total { get; set; }
        /// <summary>
        /// 依据
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required]public int Kind { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
       

        //==========================================================关联信息
        public Guid Id { get; set; }
        public Guid OtherContentsGroupId { get; set; }
        public Guid MainProjectId { get; set; }
        public int SortNum { get; set; }

        public Guid ParentId { get; set; }
        public Guid UnitWorksId { get; set; }
    }
    /// <summary>
    /// 合同中约定的其他项目汇总 by 2025
    /// </summary>
    public partial class OtherContentsGroup
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]public string Name { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 金额（元）
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        /// 汇总类型
        /// </summary>
        [Required]public int Kind { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 子分组列表
        /// </summary>
        public List<OtherContentsGroup> Groups { get; set; } = new List<OtherContentsGroup>();

        /// <summary>
        /// 明细项列表
        /// </summary>
        public List<OtherContentsItem> Items { get; set; } = new List<OtherContentsItem>();

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid UnitWorksId { get; set; }

        public Guid MainProjectId { get; set; }

        public int SortNum { get; set; }

    }

    
    /// <summary>
    /// 子目单价计算 by 2025
    /// </summary>
    public partial class UnitPriceCalculationOfItem
    {
        /// <summary>
        /// 费用名称
        /// </summary>
        [Required]public string Name { get; set; }

        /// <summary>
        /// 计算基础
        /// </summary>
        public string QtyFormula { get; set; }

        /// <summary>
        /// 费率(%)
        /// </summary>
        public double? Rate { get; set; }

        /// <summary>
        /// 金额（元）
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        /// 费用代号
        /// </summary>
        [Required]public string Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 子项列表
        /// </summary>
        public List<UnitPriceCalculationOfItem> Items { get; set; } = new List<UnitPriceCalculationOfItem>();

        //=================================================关联信息
        public Guid Id { get; set; }
        public Guid MainProjectId { get; set; }
        public Guid CItemFatherId { get; set; }
        public int SortNum { get; set; }

    }


}