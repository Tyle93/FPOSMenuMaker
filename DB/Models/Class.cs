﻿using System;
using System.Collections.Generic;

namespace Future.Models
{
    public partial class Class
    {
        public Guid ClassId { get; set; }
        public Guid RegionId { get; set; }
        public int ClassIndex { get; set; }
        public string ClassName { get; set; } = null!;
        public DateTime? PayPeriodRefDate { get; set; }
        public short PayPeriodType { get; set; }
        public short EarlyInLockout { get; set; }
        public short InRound { get; set; }
        public short InGrace { get; set; }
        public short LateInLockout { get; set; }
        public short EarlyOutLockout { get; set; }
        public short OutRound { get; set; }
        public short OutGrace { get; set; }
        public short LateOutLockout { get; set; }
        public short MealDedLimit { get; set; }
        public short MealDedAmt { get; set; }
        public short DailyOtlimit { get; set; }
        public short WeeklyOtlimit { get; set; }
        public bool CanPnchUnschd { get; set; }
        public bool EmpHasTips { get; set; }
        public short LateInDock { get; set; }
        public short EarlyOutDock { get; set; }
        public bool FrontEnd { get; set; }
        public bool FeDsrpt { get; set; }
        public bool FeScrpt { get; set; }
        public bool FeRcrpt { get; set; }
        public bool BackOffice { get; set; }
        public bool BtnMnt { get; set; }
        public bool ClsMnt { get; set; }
        public bool CpnMnt { get; set; }
        public bool CustMnt { get; set; }
        public bool CmcanVw { get; set; }
        public bool CmcanAdj { get; set; }
        public bool DataMgr { get; set; }
        public bool DptMnt { get; set; }
        public bool DrkMnt { get; set; }
        public bool DscMnt { get; set; }
        public bool EmpMnt { get; set; }
        public bool EmadjTips { get; set; }
        public bool ChgEmpCls { get; set; }
        public bool EmcshDwrs { get; set; }
        public bool EmpayRates { get; set; }
        public bool EmsecLvl { get; set; }
        public bool Emtmcrd { get; set; }
        public bool Empasswd { get; set; }
        public bool Gcmnt { get; set; }
        public bool HlpMnt { get; set; }
        public bool IngMnt { get; set; }
        public bool Igmadj { get; set; }
        public bool ItmMnt { get; set; }
        public bool ImadjPrc { get; set; }
        public bool MedMnt { get; set; }
        public bool MsgMnt { get; set; }
        public bool PckLoan { get; set; }
        public bool PrcSchd { get; set; }
        public bool Unused { get; set; }
        public bool ReasMnt { get; set; }
        public bool RegMnt { get; set; }
        public bool ResMnt { get; set; }
        public bool Rsmnt { get; set; }
        public bool SchMnt { get; set; }
        public bool SpcMnt { get; set; }
        public bool TaxMnt { get; set; }
        public bool TblMnt { get; set; }
        public bool VndMnt { get; set; }
        public bool ActRpt { get; set; }
        public bool ChgInv { get; set; }
        public bool CoupRpt { get; set; }
        public bool Csrpt { get; set; }
        public bool CustLoyal { get; set; }
        public bool DscRpt { get; set; }
        public bool Ejrpt { get; set; }
        public bool EmProRpt { get; set; }
        public bool EmSlsRpt { get; set; }
        public bool EmTpsRpt { get; set; }
        public bool Lvsrpt { get; set; }
        public bool MovRpt { get; set; }
        public bool ReordRpt { get; set; }
        public bool CmSlsRpt { get; set; }
        public bool SlsAcRpt { get; set; }
        public bool SlsRgRpt { get; set; }
        public bool SlsStRpt { get; set; }
        public bool Tbrpt { get; set; }
        public bool Tcrpt { get; set; }
        public bool WageRpt { get; set; }
        public bool WkMvRpt { get; set; }
        public bool CshrMnt { get; set; }
        public bool Icrpt { get; set; }
        public bool Virpt { get; set; }
        public bool Gcissue { get; set; }
        public bool Gcdestroy { get; set; }
        public bool Gclist { get; set; }
        public bool DupCrpt { get; set; }
        public bool FeCshRpt { get; set; }
        public bool Fdmnt { get; set; }
        public bool PdOutRpt { get; set; }
        public bool Iptrpt { get; set; }
        public bool Ecrpt { get; set; }
        public bool CmcanClr { get; set; }
        public bool SlsPdRpt { get; set; }
        public bool AdjMeals { get; set; }
        public bool SurvMod { get; set; }
        public bool CanPchOutWopenChks { get; set; }
        public bool CmcanEditCc { get; set; }
        public bool Brrpt { get; set; }
        public bool Swarpt { get; set; }
        public bool ZoneMnt { get; set; }
        public bool CustCanEditFd { get; set; }
        public bool Ccmaint { get; set; }
        public bool FoodCostRpt { get; set; }
        public bool CustCanEditUserData { get; set; }
        public bool ImcanDelete { get; set; }
        public bool EjrptCanViewCcs { get; set; }
        public bool ChangeSaleNum { get; set; }
        public bool CreateNetSetDsk { get; set; }
        public bool EmpcanChgBopass { get; set; }
        public bool ResetDbs { get; set; }
        public bool CanResetActFile { get; set; }
        public bool SystemDevices { get; set; }
        public bool SystemSettings { get; set; }
        public bool CcamcanVwCcnums { get; set; }
        public bool RcslsRpt { get; set; }
        public bool Lvsgraph { get; set; }
        public bool Sbrgraph { get; set; }
        public bool InclCashTips { get; set; }
        public bool PrtSvrRpt { get; set; }
        public bool StartTimeOpt { get; set; }
        public int RptStTime { get; set; }
        public bool ShowDetail { get; set; }
        public bool DetailFmt { get; set; }
        public bool InclCashTipsInAdjCash { get; set; }
        public bool InclCashGratsInAdjCash { get; set; }
        public bool EmpInclPdOuts { get; set; }
        public bool EmpInclRoas { get; set; }
        public bool EmpNoAdjCash { get; set; }
        public bool NoTipsOnTogo { get; set; }
        public bool Isrpt { get; set; }
        public int SettleResponsibility { get; set; }
        public bool EditDashboards { get; set; }
        public bool AddDashPanel { get; set; }
        public bool EditFavorites { get; set; }
        public bool LogRpt { get; set; }
        public byte[] AssignClasses { get; set; } = null!;
        public bool BrkMnt { get; set; }
        public bool AdDriverMnt { get; set; }
        public bool Sprpt { get; set; }
        public bool CanClearBatch { get; set; }
        public bool Dbsetup { get; set; }
        public bool LicenseFuturePos { get; set; }
        public bool CustMntViewCcnum { get; set; }
        public bool TmdMnuMnt { get; set; }
        public bool CustChrgRpt { get; set; }
        public bool WFPOSMenuMakerrt { get; set; }
        public bool Wsexprt { get; set; }
        public bool CashReconMnt { get; set; }
        public bool MnuMnt { get; set; }
        public bool BackupMnt { get; set; }
        public bool CashOvrShortRpt { get; set; }
        public bool NetInstall { get; set; }
        public bool UseCustomSemiMonthly { get; set; }
        public int SemiMonthlyStart1 { get; set; }
        public int SemiMonthlyStart2 { get; set; }
        public bool AlertMnt { get; set; }
        public bool DistributorReport { get; set; }
        public bool DistributorMnt { get; set; }
        public bool? Accardis { get; set; }
        public bool? AdDriver { get; set; }
        public bool? Adppayroll { get; set; }
        public bool? Apspayroll { get; set; }
        public bool? CallerId { get; set; }
        public bool? CallerIdCom { get; set; }
        public bool? Cbspayroll { get; set; }
        public bool? ChefTec { get; set; }
        public bool? CostGuard { get; set; }
        public bool? CreditCardModule { get; set; }
        public bool? DataTranCcam { get; set; }
        public bool? DeductIt { get; set; }
        public bool? FoodTrak { get; set; }
        public bool? GreatPlainsGl { get; set; }
        public bool? GreatPlainsPayroll { get; set; }
        public bool HarmonyVdudriver { get; set; }
        public bool? HeartlandPayroll { get; set; }
        public bool? InternetCcam { get; set; }
        public bool? Mas90Gl { get; set; }
        public bool? Mas90Payroll { get; set; }
        public bool? MenuLinkGl { get; set; }
        public bool? MenuLinkPayroll { get; set; }
        public bool? MenuLinkSalesInterval { get; set; }
        public bool? MenuLink { get; set; }
        public bool? PayChexPayroll { get; set; }
        public bool? PeachtreeGl { get; set; }
        public bool QsrVduDriver { get; set; }
        public bool? QuickbooksGl { get; set; }
        public bool? QuickBooksPayroll { get; set; }
        public bool? SaaShrPayroll { get; set; }
        public bool? ScoreboardDriver { get; set; }
        public bool SecVduDriver { get; set; }
        public bool TabbedOut { get; set; }
        public bool TalonVideo { get; set; }
        public bool? VduDriver { get; set; }
        public bool? X10driver { get; set; }
        public bool? AbraPayroll { get; set; }
        public bool EnterpriseBulkUploader { get; set; }
        public bool ConvertExportPng { get; set; }
        public bool ServerAppMonitor { get; set; }
        public bool SetSvrNm { get; set; }
        public bool SvcMgr { get; set; }
        public bool WinSched { get; set; }
        public bool? PurgeOldData { get; set; }
        public bool DinePointDump { get; set; }
        public bool EffectiveWageRpt { get; set; }
        public bool TipPoolMnt { get; set; }
        public bool PagerDriver { get; set; }
        public bool PagerMaint { get; set; }
        public bool DailySalesByMonthReport { get; set; }
        public bool MobileRegistration { get; set; }
        public bool CustMntViewLoyalty { get; set; }
        public bool Mas90EmployeeWage { get; set; }
        public bool InventoryList { get; set; }
        public bool GenericPayroll { get; set; }
        public bool CustomerTransaction { get; set; }
        public bool ComparativeItemSales { get; set; }
        public bool QuickBooksExport { get; set; }
        public bool ScheduledUpdateMaintenance { get; set; }
        public bool SalesPerformance { get; set; }
        public bool ItemSales { get; set; }
        public bool Xmlexport { get; set; }
        public bool DataGroupMaintenance { get; set; }
        public bool FeAuthMobilePos { get; set; }
        public bool MobilePosserviceHost { get; set; }
        public bool HotSchedulesExport { get; set; }
        public bool HotScheduleFPOSMenuMakerort { get; set; }
        public bool ItemSize { get; set; }
        public bool ItemSizeDelete { get; set; }
        public short PayType { get; set; }
        public bool? CanViewAutoReport { get; set; }
        public bool MediaBreakdownCountByMedia { get; set; }
        public bool ShowCreditDetail { get; set; }
        public bool ResourceManager { get; set; }
    }
}
