using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIClientImport
{
    public class DbClaimant
    {
        /// <summary>
        /// Claimant ID
        /// </summary>
        public Guid ClaimantId { get; set; }

        /// <summary>
        /// Claim ID
        /// </summary>
        public int ClaimId { get; set; }

        /// <summary>
        /// Claimant Type ID
        /// </summary>
        public int ClaimantTypeId { get; set; }

        /// <summary>
        /// Claimant Status ID
        /// </summary>
        public int ClaimantStatusId { get; set; }

        /// <summary>
        /// Address Book ID
        /// </summary>
        public int AddressBookId { get; set; }

        /// <summary>
        /// Death Date
        /// </summary>
        public DateTime DeathDate { get; set; }

        /// <summary>
        /// Death Result Of Injury
        /// </summary>
        public bool DeathResultOfInjury { get; set; }

        /// <summary>
        /// Driver License State
        /// </summary>
        public string DriverLicenseState { get; set; }

        /// <summary>
        /// Driver License
        /// </summary>
        public string DriverLicense { get; set; }

        /// <summary>
        /// Accepted
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// Accepted Date
        /// </summary>
        public DateTime AcceptedDate { get; set; }

        /// <summary>
        /// Delayed
        /// </summary>
        public bool Delayed { get; set; }

        /// <summary>
        /// Delayed Date
        /// </summary>
        public DateTime DelayedDate { get; set; }

        /// <summary>
        /// Delayed Reason ID
        /// </summary>
        public int DelayedReasonId { get; set; }

        /// <summary>
        /// Delayed Comments
        /// </summary>
        public string DelayedComments { get; set; }

        /// <summary>
        /// Denied
        /// </summary>
        public bool Denied { get; set; }

        /// <summary>
        /// Denied Date
        /// </summary>
        public DateTime DeniedDate { get; set; }

        /// <summary>
        /// Denied Reason ID
        /// </summary>
        public int DeniedReasonId { get; set; }

        /// <summary>
        /// Denied Comments
        /// </summary>
        public string DeniedComments { get; set; }

        /// <summary>
        /// Closed Date
        /// </summary>
        public DateTime ClosedDate { get; set; }

        /// <summary>
        /// Reopened Date
        /// </summary>
        public DateTime ReopenedDate { get; set; }

        /// <summary>
        /// Reopened Reason ID
        /// </summary>
        public int ReopenedReasonId { get; set; }

        /// <summary>
        /// Severity ID
        /// </summary>
        public int SeverityId { get; set; }

        /// <summary>
        /// Settlement Type ID
        /// </summary>
        public int SettlementTypeId { get; set; }

        /// <summary>
        /// Fraud ID
        /// </summary>
        public int FraudId { get; set; }

        /// <summary>
        /// Joint Coverage
        /// </summary>
        public bool JointCoverage { get; set; }

        /// <summary>
        /// Total Gross Incurred
        /// </summary>
        public Single TotalGrossIncurred { get; set; }

        /// <summary>
        /// Body Part ID
        /// </summary>
        public int BodyPartId { get; set; }

        /// <summary>
        /// Nature of Injury ID
        /// </summary>
        public int NatureOfInjuryId { get; set; }

        /// <summary>
        /// Injury Type ID
        /// </summary>
        public int InjuryTypeId { get; set; }

        /// <summary>
        /// Activity Desc
        /// </summary>
        public string ActivityDesc { get; set; }

        /// <summary>
        /// Injury Desc
        /// </summary>
        public string InjuryDesc { get; set; }

        /// <summary>
        /// How Injury Occurred
        /// </summary>
        public string HowInjuryOccurred { get; set; }

        /// <summary>
        /// Injury Equipment
        /// </summary>
        public string InjuryEquipment { get; set; }

        /// <summary>
        /// Insured Reported Date
        /// </summary>
        public DateTime InsuredReportedDate { get; set; }

        /// <summary>
        /// Administrator Reported Date
        /// </summary>
        public DateTime AdministratorReportedDate { get; set; }

        /// <summary>
        /// Notice of Injury Date
        /// </summary>
        public DateTime NoticeOfInjuryDate { get; set; }

        /// <summary>
        /// Litigated
        /// </summary>
        public bool Litigated { get; set; }

        /// <summary>
        /// Subrogated
        /// </summary>
        public bool Subrogated { get; set; }

        /// <summary>
        /// Subro Status Date
        /// </summary>
        public DateTime SubroStatuteDate { get; set; }

        /// <summary>
        /// Subro Potential
        /// </summary>
        public bool SubroPotential { get; set; }

        /// <summary>
        /// Number of Dependents
        /// </summary>
        public int NumberDependents { get; set; }

        /// <summary>
        /// Begin Work Time
        /// </summary>
        public string BeginWorkTime { get; set; }

        /// <summary>
        /// Last Worked Date
        /// </summary>
        public DateTime LastWorkedDate { get; set; }

        /// <summary>
        /// Unable Work Day
        /// </summary>
        public bool UnableWorkDay { get; set; }

        /// <summary>
        /// Returned Work Date
        /// </summary>
        public DateTime ReturnedWorkDate { get; set; }

        /// <summary>
        /// Off Work
        /// </summary>
        public bool OffWork { get; set; }

        /// <summary>
        /// Full Day Paid
        /// </summary>
        public bool FullDayPaid { get; set; }

        /// <summary>
        /// Salary Continued
        /// </summary>
        public bool SalaryContinued { get; set; }

        /// <summary>
        /// Physician First Name
        /// </summary>
        public string PhysicianFirstName { get; set; }

        /// <summary>
        /// Physician Middle Name
        /// </summary>
        public string PhysicianMiddleName { get; set; }

        /// <summary>
        /// Physician Last Name
        /// </summary>
        public string PhysicianLastName { get; set; }

        /// <summary>
        /// Physician Work Phone
        /// </summary>
        public string PhysicianWorkPhone { get; set; }

        /// <summary>
        /// Physician Address 1
        /// </summary>
        public string PhysicianAddress1 { get; set; }

        /// <summary>
        /// Physician Address 2
        /// </summary>
        public string PhysicianAddress2 { get; set; }

        /// <summary>
        /// Physician City
        /// </summary>
        public string PhysicianCity { get; set; }

        /// <summary>
        /// Physician State
        /// </summary>
        public string PhysicianState { get; set; }

        /// <summary>
        /// Physician Zip Code
        /// </summary>
        public string PhysicianZipCode { get; set; }

        /// <summary>
        /// Physician County
        /// </summary>
        public string PhysicianCounty { get; set; }

        /// <summary>
        /// Hospitalized Overnight
        /// </summary>
        public bool HospitalizedOvernight { get; set; }

        /// <summary>
        /// Hospital Address Book ID
        /// </summary>
        public int HospitalAddressBookId { get; set; }

        /// <summary>
        /// ER Treatment
        /// </summary>
        public bool ERTreatment { get; set; }

        /// <summary>
        /// TD Rate
        /// </summary>
        public Single TDRate { get; set; }

        /// <summary>
        /// PD Rate
        /// </summary>
        public Single PDRate { get; set; }

        /// <summary>
        /// VR Rate
        /// </summary>
        public Single VRRate { get; set; }

        /// <summary>
        /// Death Rate
        /// </summary>
        public Single DeathRate { get; set; }

        /// <summary>
        /// Life Pension Rate
        /// </summary>
        public Single LifePensionRate { get; set; }

        /// <summary>
        /// Supplemental Benefits
        /// </summary>
        public Single SupplementalBenefits { get; set; }

        /// <summary>
        /// PD Weeks
        /// </summary>
        public Single PDWeeks { get; set; }

        /// <summary>
        /// DWC Provide Date
        /// </summary>
        public DateTime DWCProvideDate { get; set; }

        /// <summary>
        /// DWC Received Date
        /// </summary>
        public DateTime DWCReceivedDate { get; set; }

        /// <summary>
        /// Continuous Trauma Begin Date
        /// </summary>
        public DateTime ContinuousTraumaBeginDate { get; set; }

        /// <summary>
        /// Continuous Trauma End Date
        /// </summary>
        public DateTime ContinuousTraumaEndDate { get; set; }

        /// <summary>
        /// PD Rating
        /// </summary>
        public Single PDRating { get; set; }

        /// <summary>
        /// Disability Rating Date
        /// </summary>
        public DateTime DisabilityRatingDate { get; set; }

        /// <summary>
        /// Disability Begin Date
        /// </summary>
        public DateTime DisabilityBeginDate { get; set; }

        /// <summary>
        /// Permanent Stationary Date
        /// </summary>
        public DateTime PermanentStationaryDate { get; set; }

        /// <summary>
        /// Modified Duty Offered
        /// </summary>
        public bool ModifiedDutyOffered { get; set; }

        /// <summary>
        /// Wage Statement Received
        /// </summary>
        public bool WageStatementReceived { get; set; }

        /// <summary>
        /// Medical Management
        /// </summary>
        public bool MedicalManagement { get; set; }

        /// <summary>
        /// Claimant Comments
        /// </summary>
        public string ClaimantComments { get; set; }

        /// <summary>
        /// Entry Date
        /// </summary>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Entered By
        /// </summary>
        public string EnteredBy { get; set; }

        /// <summary>
        /// Updated Date
        /// </summary>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Updated By
        /// </summary>
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Pbm Termination Date
        /// </summary>
        public DateTime PbmTerminationDate { get; set; }

        /// <summary>
        /// Loss Type ID
        /// </summary>
        public int LossTypeId { get; set; }

        /// <summary>
        /// Totaled
        /// </summary>
        public bool Totaled { get; set; }

        /// <summary>
        /// Totaled Date
        /// </summary>
        public DateTime TotaledDate { get; set; }

        /// <summary>
        /// Totaled Comments
        /// </summary>
        public string TotaledComments { get; set; }

        /// <summary>
        /// Insured Is Claimant
        /// </summary>
        public bool InsuredIsClaimant { get; set; }

        /// <summary>
        /// Claimant Unit Type ID
        /// </summary>
        public int ClaimantUnitTypeId { get; set; }

        /// <summary>
        /// Claimant Unit ID
        /// </summary>
        public int ClaimantUnitId { get; set; }

        /// <summary>
        /// Benefits 4850
        /// </summary>
        public bool Benefits4850 { get; set; }

        /// <summary>
        /// Insured Liability Percentage
        /// </summary>
        public decimal InsuredLiabilityPercentage { get; set; }

        /// <summary>
        /// Estimated Settlement Value
        /// </summary>
        public Single EstimatedSettlementValue { get; set; }

        /// <summary>
        /// Full Value
        /// </summary>
        public Single FullValue { get; set; }

        /// <summary>
        /// ICD9 Code
        /// </summary>
        public string ICD9Code { get; set; }

        /// <summary>
        /// PTD Rate
        /// </summary>
        public Single PTDRate { get; set; }

        /// <summary>
        /// TPD Rate
        /// </summary>
        public Single TPDRate { get; set; }

        /// <summary>
        /// Post Injury Wage
        /// </summary>
        public Single PostInjuryWage { get; set; }

        /// <summary>
        /// Special Instructions
        /// </summary>
        public string SpecialInstructions { get; set; }

        /// <summary>
        /// Automatic Benefits Calculation
        /// </summary>
        public bool AutomaticBenefitsCalculation { get; set; }

        /// <summary>
        /// Suffix Code
        /// </summary>
        public string SuffixCode { get; set; }

        /// <summary>
        /// Insured Unit Type ID
        /// </summary>
        public int InsuredUnitTypeId { get; set; }

        /// <summary>
        /// Insured Unit ID
        /// </summary>
        public int InsuredUnitId { get; set; }

        /// <summary>
        /// Insured Driver ID
        /// </summary>
        public int InsuredDriverId { get; set; }

        /// <summary>
        /// Insured Driver Type ID
        /// </summary>
        public int InsuredDriverTypeId { get; set; }

        /// <summary>
        /// Insured Building ID
        /// </summary>
        public int InsuredBuildingId { get; set; }

        /// <summary>
        /// Physician Country
        /// </summary>
        public string PhysicianCountry { get; set; }

        /// <summary>
        /// Closing Code ID
        /// </summary>
        public int ClosingCodeId { get; set; }

        /// <summary>
        /// Calculation Instructions
        /// </summary>
        public string CalculationInstructions { get; set; }

        /// <summary>
        /// Benefit Class ID
        /// </summary>
        public int BenefitClassId { get; set; }

        /// <summary>
        /// Member Type ID
        /// </summary>
        public int MemberTypeId { get; set; }

        /// <summary>
        /// Hospital Admission Date
        /// </summary>
        public DateTime HospitalAdmissionDate { get; set; }

        /// <summary>
        /// Hospital Discharge Date
        /// </summary>
        public DateTime HospitalDischargeDate { get; set; }

        /// <summary>
        /// Condition Code
        /// </summary>
        public string ConditionCode { get; set; }

        /// <summary>
        /// Other Name
        /// </summary>
        public string OtherName { get; set; }

        /// <summary>
        /// Other Desc
        /// </summary>
        public string OtherDesc { get; set; }

        /// <summary>
        /// Other Phone
        /// </summary>
        public string OtherPhone { get; set; }

        /// <summary>
        /// Other Email
        /// </summary>
        public string OtherEmail { get; set; }

        /// <summary>
        /// Permanent Impairment Pct
        /// </summary>
        public string PermanentImpairmentPct { get; set; }

        /// <summary>
        /// Dismemberment Paralysis Pct
        /// </summary>
        public string DismembermentParalysisPct { get; set; }

        /// <summary>
        /// Cosmetic Disfigurement Pct
        /// </summary>
        public string CosmeticDisfigurementPct { get; set; }

        /// <summary>
        /// Other Provider Address Book ID
        /// </summary>
        public int OtherProviderAddressBookId { get; set; }

        /// <summary>
        /// Other Provider Admission Date
        /// </summary>
        public DateTime OtherProviderAdmissionDate { get; set; }

        /// <summary>
        /// Other Provider Discharge Date
        /// </summary>
        public DateTime OtherProviderDischargeDate { get; set; }

        /// <summary>
        /// WC Weekly Rate
        /// </summary>
        public Single WCWeeklyRate { get; set; }

        /// <summary>
        /// WC Status
        /// </summary>
        public string WCStatus { get; set; }

        /// <summary>
        /// WC Carrier
        /// </summary>
        public string WCCarrier { get; set; }

        /// <summary>
        /// WC Contact Name
        /// </summary>
        public string WCContactName { get; set; }

        /// <summary>
        /// WC Phone
        /// </summary>
        public string WCPhone { get; set; }

        /// <summary>
        /// WC Email
        /// </summary>
        public string WCEmail { get; set; }

        /// <summary>
        /// WC Address 1
        /// </summary>
        public string WCAddress1 { get; set; }

        /// <summary>
        /// WC Address 2
        /// </summary>
        public string WCAddress2 { get; set; }

        /// <summary>
        /// WC City
        /// </summary>
        public string WCCity { get; set; }

        /// <summary>
        /// WC State
        /// </summary>
        public string WCState { get; set; }

        /// <summary>
        /// WC Zip Code
        /// </summary>
        public string WCZipCode { get; set; }

        /// <summary>
        /// WC County
        /// </summary>
        public string WCCounty { get; set; }

        /// <summary>
        /// WC Country
        /// </summary>
        public string WCCountry { get; set; }

        /// <summary>
        /// Coordinated TD Benefit
        /// </summary>
        public string CoordinatedTDBenefit { get; set; }

        /// <summary>
        /// Retroactive
        /// </summary>
        public bool Retroactive { get; set; }

        /// <summary>
        /// Elimination Period
        /// </summary>
        public string EliminationPeriod { get; set; }

        /// <summary>
        /// CPI Pct
        /// </summary>
        public string CPIPct { get; set; }

        /// <summary>
        /// CPI Date
        /// </summary>
        public DateTime CPIDate { get; set; }

        /// <summary>
        /// IPI Rate
        /// </summary>
        public Single IPIRate { get; set; }

        /// <summary>
        /// Other Address 1
        /// </summary>
        public string OtherAddress1 { get; set; }

        /// <summary>
        /// Other Address 2
        /// </summary>
        public string OtherAddress2 { get; set; }

        /// <summary>
        /// Other City
        /// </summary>
        public string OtherCity { get; set; }

        /// <summary>
        /// Other State
        /// </summary>
        public string OtherState { get; set; }

        /// <summary>
        /// Other Zip Code
        /// </summary>
        public string OtherZipCode { get; set; }

        /// <summary>
        /// Other County
        /// </summary>
        public string OtherCounty { get; set; }

        /// <summary>
        /// Other Country
        /// </summary>
        public string OtherCountry { get; set; }

        /// <summary>
        /// Heart Permanent Impairment ID
        /// </summary>
        public int HeartPermanentImpairmentId { get; set; }

        /// <summary>
        /// Ejection Fraction ID
        /// </summary>
        public int EjectionFractionId { get; set; }

        /// <summary>
        /// NY Heart Assoc Func Classification ID
        /// </summary>
        public int NYHeartAssocFuncClassificationId { get; set; }

        /// <summary>
        /// Odg Comorbidity Depression
        /// </summary>
        public bool OdgComorbidityDepression { get; set; }

        /// <summary>
        /// Odg Comorbidity Diabetes
        /// </summary>
        public bool OdgComorbidityDiabetes { get; set; }

        /// <summary>
        /// Odg Comorbidity Hypertension
        /// </summary>
        public bool OdgComorbidityHypertension { get; set; }

        /// <summary>
        /// Odg Comorbidity Legal Representation
        /// </summary>
        public bool OdgComorbidityLegalRepresentation { get; set; }

        /// <summary>
        /// Odg Comorbidity Obesity
        /// </summary>
        public bool OdgComorbidityObesity { get; set; }

        /// <summary>
        /// Odg Comorbidity Smoker
        /// </summary>
        public bool OdgComorbiditySmoker { get; set; }

        /// <summary>
        /// Odg Comorbidity Substance Abuse
        /// </summary>
        public bool OdgComorbiditySubstanceAbuse { get; set; }

        /// <summary>
        /// Odg Comorbidity Surgery
        /// </summary>
        public bool OdgComorbiditySurgery { get; set; }

        /// <summary>
        /// Odg Comorbidity Opioids
        /// </summary>
        public int OdgComorbidityOpioids { get; set; }

        /// <summary>
        /// Odg Comorbidity Job Class
        /// </summary>
        public int OdgComorbidityJobClass { get; set; }

        /// <summary>
        /// Lump Sum Indicator
        /// </summary>
        public string LumpSumIndicator { get; set; }

        /// <summary>
        /// Benefit Offset ID
        /// </summary>
        public int BenefitOffsetId { get; set; }

        /// <summary>
        /// Loss of Earning Capacity Pct
        /// </summary>
        public int LossOfEarningCapacityPct { get; set; }

        /// <summary>
        /// Pre-Existing Disability Pct
        /// </summary>
        public int PreExistingDisabilityPct { get; set; }

        /// <summary>
        /// TD Benefit Extinguishment ID
        /// </summary>
        public int TDBenefitExtinguishmentId { get; set; }

        /// <summary>
        /// Tax Filing Status ID
        /// </summary>
        public int TaxFilingStatusId { get; set; }

        /// <summary>
        /// Number of Entitled Exemptions
        /// </summary>
        public int NumberOfEntitledExemptions { get; set; }

        /// <summary>
        /// Education Level
        /// </summary>
        public string EducationLevel { get; set; }

        /// <summary>
        /// First Day of Disability After Waiting Period
        /// </summary>
        public DateTime FirstDayOfDisabilityAfterWaitingPeriod { get; set; }

        /// <summary>
        /// Date Claim Admin Knew of Employee Representation
        /// </summary>
        public DateTime DateClaimAdminKnewOfEmployeeRepresentation { get; set; }

        /// <summary>
        /// Agreement to Compensate ID
        /// </summary>
        public int AgreementToCompensateId { get; set; }

        /// <summary>
        /// Denial Rescission Date
        /// </summary>
        public DateTime DenialRescissionDate { get; set; }

        /// <summary>
        /// Partial Denial ID
        /// </summary>
        public int PartialDenialId { get; set; }

        /// <summary>
        /// Partial Denial Effective Date
        /// </summary>
        public DateTime PartialDenialEffectiveDate { get; set; }

        /// <summary>
        /// Award Order Date
        /// </summary>
        public DateTime AwardOrderDate { get; set; }

        /// <summary>
        /// Reduced Benfit Amount Type ID
        /// </summary>
        public int ReducedBenefitAmountTypeId { get; set; }

        /// <summary>
        /// Initial RTW Type ID
        /// </summary>
        public int InitialRTWTypeId { get; set; }

        /// <summary>
        /// Initial RTW Physical Restrictions Indicator
        /// </summary>
        public string InitialRTWPhysicalRestrictionsIndicator { get; set; }

        /// <summary>
        /// Initial RTW With Same Employer Indicator
        /// </summary>
        public string InitialRTWWithSameEmployerIndicator { get; set; }

        /// <summary>
        /// Initial Employer Knowledge of Disability Date
        /// </summary>
        public DateTime InitialEmployerKnowledgeOfDisabilityDate { get; set; }

        /// <summary>
        /// Initial Date Admin Knew of Loss Time
        /// </summary>
        public DateTime InitialDateAdminKnewOfLossTime { get; set; }

        /// <summary>
        /// Current Last Worked Date
        /// </summary>
        public DateTime CurrentLastWorkedDate { get; set; }

        /// <summary>
        /// Current Disability Begin Date
        /// </summary>
        public DateTime CurrentDisabiltyBeginDate { get; set; }

        /// <summary>
        /// Latest RTW Date
        /// </summary>
        public DateTime LatestRTWDate { get; set; }

        /// <summary>
        /// Latest RTW Type ID
        /// </summary>
        public int LatestRTWTypeId { get; set; }

        /// <summary>
        /// Latest RTW Physical Restrictions Indicator
        /// </summary>
        public string LatestRTWPhysicalRestrictionsIndicator { get; set; }

        /// <summary>
        /// Latest RTW With Same Employer Indicator
        /// </summary>
        public string LatestRTWWithSameEmployerIndicator { get; set; }

        /// <summary>
        /// Non Consecutive Period ID
        /// </summary>
        public int NonConsecutivePeriodId { get; set; }

        /// <summary>
        /// Date Employer Knew of Current Loss Time
        /// </summary>
        public DateTime DateEmployerKnewOfCurrentLossTime { get; set; }

        /// <summary>
        /// Current Date Admin Knew of Loss Time
        /// </summary>
        public DateTime CurrentDateAdminKnewOfLossTime { get; set; }

        /// <summary>
        /// First Name Override
        /// </summary>
        public string FirstNameOverride { get; set; }

        /// <summary>
        /// Last Name Override
        /// </summary>
        public string LastNameOverride { get; set; }

        /// <summary>
        /// Suspension Effective Date Override
        /// </summary>
        public DateTime SuspensionEffectiveDateOverride { get; set; }

        /// <summary>
        /// Suspension Narrative
        /// </summary>
        public string SuspensionNarrative { get; set; }

        /// <summary>
        /// EEID Assigned By Jurisdiction
        /// </summary>
        public string EEIDAssignedByJurisdiction { get; set; }

        /// <summary>
        /// Cancel Reason Narrative
        /// </summary>
        public string CancelReasonNarrative { get; set; }

        /// <summary>
        /// Related Jurisdiction Claim Number
        /// </summary>
        public string RelatedJurisdictionClaimNumber { get; set; }

        /// <summary>
        /// Med Record Release on File
        /// </summary>
        public bool MedRecordReleaseOnFile { get; set; }

        /// <summary>
        /// Employee SSN Release On File
        /// </summary>
        public bool EmployeeSSNReleaseOnFile { get; set; }

        /// <summary>
        /// ERID Assigned By Jurisdiction
        /// </summary>
        public string ERIDAssignedByJurisdiction { get; set; }

        /// <summary>
        /// Insolvent Insurer FEIN
        /// </summary>
        public string InsolventInsurerFEIN { get; set; }

        /// <summary>
        /// Indemnity Thru Date For Acquired Claim
        /// </summary>
        public DateTime IndemnityThruDateForAcquiredClaim { get; set; }

        /// <summary>
        /// Current Overpayment Amount
        /// </summary>
        public Single CurrentOverpaymentAmount { get; set; }

        /// <summary>
        /// Managed Care Organization Code
        /// </summary>
        public string ManagedCareOrganizationCode { get; set; }

        /// <summary>
        /// Managed Care Organization ID
        /// </summary>
        public string ManagedCareOrganizationId { get; set; }

        /// <summary>
        /// Managed Care Organization Name
        /// </summary>
        public string ManagedCareOrganizationName { get; set; }

        /// <summary>
        /// Manual State Intervention Resolved
        /// </summary>
        public string ManualStateInterventionResolved { get; set; }

        /// <summary>
        /// Initial Treatment ID
        /// </summary>
        public int InitialTreatmentId { get; set; }

        /// <summary>
        /// Body Part Location Code
        /// </summary>
        public string BodyPartLocationCode { get; set; }

        /// <summary>
        /// Body Part Finger Toe Location Code
        /// </summary>
        public string BodyPartFingerToeLocationCode { get; set; }

        /// <summary>
        /// Anticipated Wage Loss
        /// </summary>
        public string AnticipatedWageLoss { get; set; }

        /// <summary>
        /// Pre-existing Disability
        /// </summary>
        public string PreexistingDisability { get; set; }

        /// <summary>
        /// Discontinued Fringe Benefits
        /// </summary>
        public Single DiscontinuedFringeBenefits { get; set; }

        /// <summary>
        /// Permanent Impairment Minimum Payment
        /// </summary>
        public string PermanentImpairmentMinimumPayment { get; set; }

        /// <summary>
        /// Weekly Income Amount For Offset
        /// </summary>
        public Single WeeklyIncomeAmountForOffset { get; set; }

        /// <summary>
        /// Cancel Reason ID
        /// </summary>
        public int CancelReasonId { get; set; }

        /// <summary>
        /// EDI Claim Type ID
        /// </summary>
        public int EDIClaimTypeId { get; set; }

        /// <summary>
        /// Acquisition Status ID
        /// </summary>
        public int AcquisitionStatusId { get; set; }

        /// <summary>
        /// Dependent Extent of Dependency ID
        /// </summary>
        public int DependentExtentOfDependencyId { get; set; }

        /// <summary>
        /// Physician Formatted Address
        /// </summary>
        public string PhysicianFormattedAddress { get; set; }

        /// <summary>
        /// Other Formatted Address
        /// </summary>
        public string OtherFormattedAddress { get; set; }

        /// <summary>
        /// WC Formatted Address
        /// </summary>
        public string WCFormattedAddress { get; set; }

        /// <summary>
        /// Date Claim Administrator Knew Claim Met Reporting Requirement
        /// </summary>
        public DateTime DateClaimAdministratorKnewClaimMetReportingRequirement { get; set; }

        /// <summary>
        /// Date Claim Adminstrator Knew Current Disability Date
        /// </summary>
        public DateTime DateClaimAdministratorKnewCurrentDisabilityDate { get; set; }

        /// <summary>
        /// Date Employer Knew of Disability
        /// </summary>
        public DateTime DateEmployerKnewOfDisability { get; set; }

        /// <summary>
        /// Acquisition Date
        /// </summary>
        public DateTime AcquisitionDate { get; set; }

        /// <summary>
        /// Permanent Impairment Body Part Code
        /// </summary>
        public string PermanentImpairmentBodyPartCode { get; set; }

        /// <summary>
        /// Permanent Impairment Body Part Location Code
        /// </summary>
        public string PermanentImpairmentBodyPartLocationCode { get; set; }

        /// <summary>
        /// Benefit Change Reason Code
        /// </summary>
        public string BenefitChangeReasonCode { get; set; }

    }
}
