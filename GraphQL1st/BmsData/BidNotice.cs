using System.ComponentModel.DataAnnotations.Schema;

namespace DAEHA.GraphQL1st.BmsData;

[Table("BidNotice")]
public sealed class BidNotice
{
    [Key]
    public string BidId { get; set; } = null!;

    /// <summary>
    /// 구분코드 - //MasterCode 참조 (공고유형, ACT : 주택법, 전력법, 건진법 등)
    /// </summary>
    public string? ActCode { get; set; }

    /// <summary>
    /// 입찰방식구분 - //MasterCode 참조 (입찰방식, PQB : 종심제, TP, SOQ, 면접, PQ, 입찰만)
    /// </summary>
    public string? BidMethodCode { get; set; }

    /// <summary>
    /// MasterCode 참조 (동일용역구분 - 주택법,전력법,LH,SH 등)
    /// </summary>
    public string? DongilCategoryCode { get; set; }

    [ForeignKey("DongilCategoryCode")]
    public ZMasterCode? DongilCategory { get; set; }

    /// <summary>
    /// MasterCode 참조 (참여단계구분, CPK : 설계단계,시공단계,시공후단계,시공및시공후단계)
    /// </summary>
    public string? BidStageCode { get; set; }

    /// <summary>
    /// 용역종류대분류 - //MasterCode 참조 (용역대분류 : CPB) 설계 등, 건설사업관리, 주택법감리 등..
    /// </summary>
    public string? CaseBigCode { get; set; }

    /// <summary>
    /// 용역종류중분류 - //MasterCode 참조 (용역중분류 : CPC) 건설사업관리의 경우 다중선택
    /// </summary>
    public string? CaseMiddleCode { get; set; }

    /// <summary>
    /// 용역종류소분류 - //MasterCode 참조 (용역중분류 : CPD) 건설사업관리의 경우 다중선택(감독권한대행, 외)
    /// </summary>
    public string? CaseSmallCode { get; set; }

    /// <summary>
    /// 용역종류세부분류 - //MasterCode 참조 (용역소분류 : CPE) 세부분야 포함
    /// </summary>
    public string? CaseDetailCode { get; set; }

    /// <summary>
    /// 분류 (일반,변경,취소)
    /// </summary>
    public string? G2bStatus { get; set; }

    /// <summary>
    /// G2B공고번호 - //나라장터 공고번호(차수포함)
    /// </summary>
    public string? G2bNumTxt { get; set; }

    /// <summary>
    /// 차수 - //나라장터 차수 (제거예정)
    /// </summary>
    public string? G2bNumSerial { get; set; }

    /// <summary>
    /// 개찰결과용 공고번호
    /// </summary>
    public string? BidOpenG2bNumTxt { get; set; }

    /// <summary>
    /// G2B상태가 변경, 취소 등 정정일 경우 미확인여부
    /// </summary>
    public bool? IsNotChecked { get; set; }

    /// <summary>
    /// 공고번호 - //실제 공고 번호
    /// </summary>
    public string? BidNumTxt { get; set; }

    public string? BidChangeReason { get; set; }

    /// <summary>
    /// 공고일
    /// </summary>
    public DateTime? NoticeDate { get; set; }

    /// <summary>
    /// 발주청 - //사업체정보 테이블 참조
    /// </summary>
    public string? OrderOrgCode { get; set; }

    /// <summary>
    /// 수요기관 - //사업체정보 테이블 참조
    /// </summary>
    public string? TargetOrgCode { get; set; }

    /// <summary>
    /// 담당자 - //Employee 참조 (인사정보)
    /// </summary>
    public string? EmpId { get; set; }

    public string? CheckEmpId { get; set; }

    /// <summary>
    /// 용역명(G2B) - //G2B상 용역명
    /// </summary>
    public string? BidNameG2b { get; set; }

    /// <summary>
    /// 용역명
    /// </summary>
    public string? BidName { get; set; }

    /// <summary>
    /// 업종코드 - //BizCode에서 멀티선택
    /// </summary>
    public string? G2bLisenceCode { get; set; }

    /// <summary>
    /// 발주계획ID - //발주계획 테이블에서 참조
    /// </summary>
    public string? OrderplanId { get; set; }

    /// <summary>
    /// 사전규격등록ID - //사전규격등록 테이블에서 참조
    /// </summary>
    public string? PrereleaseId { get; set; }

    /// <summary>
    /// 면접 or 제안서 여부
    /// </summary>
    public bool? IsInterview { get; set; }

    /// <summary>
    /// 면접 or 제안서 구분 - //MasterCode 참조 (면접유형, PQC, 면접 or 제안서)
    /// </summary>
    public string? ItvCode { get; set; }

    /// <summary>
    /// 입찰참가자격 등록 기한
    /// </summary>
    public DateTime? BidJoinEndDateTime { get; set; }

    /// <summary>
    /// 참가등록/열람 일시
    /// </summary>
    public DateTime? RegisterDateTime { get; set; }

    /// <summary>
    /// 질의기한 일시
    /// </summary>
    public DateTime? QuestionDateTime { get; set; }

    /// <summary>
    /// G2B협정마감일시
    /// </summary>
    public DateTime? G2bconsortiumEndDateTime { get; set; }

    /// <summary>
    /// PQ제출일시
    /// </summary>
    public DateTime? PqdateTime { get; set; }

    /// <summary>
    /// 제안서 제출 일시
    /// </summary>
    public DateTime? ProposalDateTime { get; set; }

    /// <summary>
    /// 면접 일시
    /// </summary>
    public DateTime? InterviewDateTime { get; set; }

    /// <summary>
    /// 입찰개시일시
    /// </summary>
    public DateTime? BidStartDateTime { get; set; }

    /// <summary>
    /// 입찰마감일시
    /// </summary>
    public DateTime? BidEndDateTime { get; set; }

    /// <summary>
    /// 개찰일시
    /// </summary>
    public DateTime? BidOpenDateTime { get; set; }

    /// <summary>
    /// 개찰일시(요일)
    /// </summary>
    public string? BidOpenDateDisplay { get; set; }

    /// <summary>
    /// 접수방법 - //MasterCode 참조 (접수방법 : PQE)
    /// </summary>
    public string? SubmitMethodCode { get; set; }

    /// <summary>
    /// 지역점수여부
    /// </summary>
    public bool? IsLocalPoints { get; set; }

    /// <summary>
    /// 해당지역 - //ViewJusoSido 참조 (주소시도 코드 참조)
    /// </summary>
    public string? LocalCode { get; set; }

    /// <summary>
    /// 사업위치
    /// </summary>
    public string? Juso { get; set; }

    /// <summary>
    /// 중복가능여부
    /// </summary>
    public bool? IsOverlap { get; set; }

    /// <summary>
    /// 총공사비
    /// </summary>
    public decimal? ConstCost { get; set; }

    /// <summary>
    /// 감리대상공사비(주택법)
    /// </summary>
    public decimal? SupervisionConstCost { get; set; }

    /// <summary>
    /// 법적인월수 산정을 위한 최대 적용 감리대가
    /// </summary>
    public decimal? MaxSupervisionConstCost { get; set; }

    /// <summary>
    /// 법적인월수 산정을 위한 최대 적용 인월수
    /// </summary>
    public decimal? MaxSupervisionManMonthCost { get; set; }

    /// <summary>
    /// 법적인월수 산정을 위한 최소 적용 감리대가
    /// </summary>
    public decimal? MinSupervisionConstCost { get; set; }

    /// <summary>
    /// 법적인월수 산정을 위한 최소 적용 인월수
    /// </summary>
    public decimal? MinSupervisionManMonthCost { get; set; }

    /// <summary>
    /// 계산식1
    /// </summary>
    public string? CalculationFormulaA { get; set; }

    /// <summary>
    /// 계산식2
    /// </summary>
    public string? CalculationFormulaB { get; set; }

    /// <summary>
    /// 0계산식3
    /// </summary>
    public string? CalculationFormulaC { get; set; }

    /// <summary>
    /// 추정가격
    /// </summary>
    public decimal? EstimateCost { get; set; }

    /// <summary>
    /// 기초금액
    /// </summary>
    public decimal? BaseCost { get; set; }

    /// <summary>
    /// 부가세포함여부
    /// </summary>
    public bool? IsVat { get; set; }

    public string? CostRatioType { get; set; }

    /// <summary>
    /// 예비가격범위요율S
    /// </summary>
    public decimal? CostRatioS { get; set; }

    /// <summary>
    /// 예비가격범위요율E
    /// </summary>
    public decimal? CostRatioE { get; set; }

    /// <summary>
    /// 낙찰하한율
    /// </summary>
    public decimal? BidLimitRatio { get; set; }

    /// <summary>
    /// 우리사 낙찰하한율
    /// </summary>
    public decimal? DongilBidLimitRatio { get; set; }

    /// <summary>
    /// 우리사 PQ점수
    /// </summary>
    public decimal? DongilPqscore { get; set; }

    /// <summary>
    /// 기술자/지역/경영/가점/감점(합계)
    /// </summary>
    public decimal? DongilPqplus { get; set; }

    /// <summary>
    /// (동일)낙찰하한율 * 기초금액
    /// </summary>
    public decimal? BidLimitRatioCost { get; set; }

    /// <summary>
    /// 공사종류중분류 - //MasterCode 참조 (공사종류 : COB - 건축공사,토목공사…)
    /// </summary>
    public string? ConstructionBigCategoryCode { get; set; }

    /// <summary>
    /// 공사종류소분류 - //MasterCode 참조 (공사종류 : COC - 단독주택,공동주택...)
    /// </summary>
    public string? ConstructionMiddleCategoryCode { get; set; }

    /// <summary>
    /// 공사종류세부분류 - //MasterCode 참조 (공사종류 : COCS - COC의 상세코드)
    /// </summary>
    public string? ConstructionDetailCategoryCode { get; set; }

    /// <summary>
    /// 사업규모
    /// </summary>
    public string? ProjectScale { get; set; }

    /// <summary>
    /// 세대수
    /// </summary>
    public int? HouseHold { get; set; }

    /// <summary>
    /// 월단가
    /// </summary>
    public decimal? ManMonth { get; set; }

    /// <summary>
    /// 착공일
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// 준공일
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// 개월수
    /// </summary>
    public decimal? MonthCount { get; set; }

    /// <summary>
    /// 날짜입력방식
    /// </summary>
    public string? SchedulePlanInputMethodCode { get; set; }

    /// <summary>
    /// 배치표날짜기준 - 30일단위(조달청) or 일반
    /// </summary>
    public bool? IsBase30Days { get; set; }

    /// <summary>
    /// 법정인월수
    /// </summary>
    public decimal? ActManMonth { get; set; }

    /// <summary>
    /// 상주인월수
    /// </summary>
    public decimal? StayManMonth { get; set; }

    /// <summary>
    /// 비상주인월수
    /// </summary>
    public decimal? NotStayManMonth { get; set; }

    /// <summary>
    /// 실제 상주개월수
    /// </summary>
    public decimal? TotalMonthCount { get; set; }

    /// <summary>
    /// 추가 필요 개월수(상주)
    /// </summary>
    public int? NeedMonthCount { get; set; }

    /// <summary>
    /// 총투입인월수
    /// </summary>
    public decimal? RealTotalManMonth { get; set; }

    /// <summary>
    /// 실투입상주인월수
    /// </summary>
    public decimal? RealStayManMonth { get; set; }

    /// <summary>
    /// 실투입비상주인월수
    /// </summary>
    public decimal? RealNotStayManMonth { get; set; }

    /// <summary>
    /// 비상주인월수비율
    /// </summary>
    public decimal? RealNotStayManMonthRatio { get; set; }

    /// <summary>
    /// 연면적
    /// </summary>
    public decimal? TotalArea { get; set; }

    /// <summary>
    /// 대지면적
    /// </summary>
    public decimal? GroundArea { get; set; }

    /// <summary>
    /// 비주거연면적
    /// </summary>
    public decimal? BijugeoArea { get; set; }

    /// <summary>
    /// 사업계획승인일(주택법)
    /// </summary>
    public DateTime? ApprovalDate { get; set; }

    /// <summary>
    /// 참여여부 - //MasterCode 참조 (입찰참여여부, PQF, 참여, 불참, 검토중, 발주청질의중)
    /// </summary>
    public string? ParticipationCode { get; set; }

    public string? NoReason { get; set; }

    /// <summary>
    /// 이행방식 - //MasterCode 참조 (이행방식 : DOA) - 단독이행, 공동이행, 단독이행, 혼합방식
    /// </summary>
    public string? DoMethodCode { get; set; }

    /// <summary>
    /// 우리사 참여방식 - //MasterCode 참조 (용역 참여방식 : DOB) - 대표사, 부간사, 분담이행사
    /// </summary>
    public string? ParticipationMethodCode { get; set; }

    /// <summary>
    /// PQ기준 - //PQStandard 참조
    /// </summary>
    public string? Pqid { get; set; }

    /// <summary>
    /// DS기준 - //DetermineStandard 참조
    /// </summary>
    public string? Dsid { get; set; }

    /// <summary>
    /// 적격심사기준명
    /// </summary>
    public string? DetermineStandardName { get; set; }

    /// <summary>
    /// 적격심사 종합평점(커트라인)
    /// </summary>
    public int? DetermineScore { get; set; }

    /// <summary>
    /// 수행능력배점
    /// </summary>
    public int? PqscoreRatioScore { get; set; }

    /// <summary>
    /// 지역업체 배점
    /// </summary>
    public int? LocalOfficeScore { get; set; }

    /// <summary>
    /// 기술인 경력 배점
    /// </summary>
    public int? EmpCareerScore { get; set; }

    /// <summary>
    /// 경영상태 배점
    /// </summary>
    public int? BusinessConditionsScore { get; set; }

    /// <summary>
    /// 입찰가격 배점
    /// </summary>
    public int? BidCostScore { get; set; }

    /// <summary>
    /// 입찰가격 상수
    /// </summary>
    public int? BidCostConstPoint { get; set; }

    /// <summary>
    /// 입찰가격 소숫점 한도
    /// </summary>
    public int? BidRoundPoint { get; set; }

    public bool? IsWeeklyReport { get; set; }

    /// <summary>
    /// 사용인감계 신청했는지 여부
    /// </summary>
    public bool? IsUseSealRequest { get; set; }

    /// <summary>
    /// 특이사항
    /// </summary>
    public string? Comments { get; set; }

    /// <summary>
    /// 낙찰업체
    /// </summary>
    public string? SuccessCorpId { get; set; }

    /// <summary>
    /// 공고담당자 - //입찰공고테이블에 BidPM로 전송
    /// </summary>
    public string? BidPm { get; set; }

    /// <summary>
    /// 공고담당자 전화
    /// </summary>
    public string? BidPmTel { get; set; }

    /// <summary>
    /// 공고담당자 메일주소
    /// </summary>
    public string? BidPmEmail { get; set; }

    /// <summary>
    /// 입찰공고링크
    /// </summary>
    public string? BidLink { get; set; }

    /// <summary>
    /// 예정가격(개찰결과)
    /// </summary>
    public decimal? AverageCost { get; set; }

    /// <summary>
    /// 예정금액 / 기초금액 (낙찰포인트)
    /// </summary>
    public decimal? AverageBaseRatio { get; set; }

    /// <summary>
    /// 실제 개찰일시
    /// </summary>
    public DateTime? BidOpenRealDateTime { get; set; }

    /// <summary>
    /// 개찰결과 추첨가격에서 기초금액기준 상위갯수
    /// </summary>
    public int? AboveCount { get; set; }

    /// <summary>
    /// 개찰결과에서 복수예비가격 작성시각
    /// </summary>
    public DateTime? DrawCostInputDateTime { get; set; }

    /// <summary>
    /// 개찰결과에서 투찰 참가 수
    /// </summary>
    public int? DrawedCount { get; set; }

    /// <summary>
    /// 개찰결과링크
    /// </summary>
    public string? ResultLink { get; set; }

    /// <summary>
    /// 사업개요 및 사업주체,설계자,시공자 정보를 가져온 입찰공고 BidID
    /// </summary>
    public string? ImportFromBidId { get; set; }

    /// <summary>
    /// 입력일자 - //입력한 날짜
    /// </summary>
    public DateTime? InputDatetime { get; set; }

    public string? InputEmpId { get; set; }

    /// <summary>
    /// 변경일자 - //변경한 날짜
    /// </summary>
    public DateTime? ChangeDatetime { get; set; }

    /// <summary>
    /// 변경자ID - //변경한 사람의 ID
    /// </summary>
    public string? ChangeEmpId { get; set; }

    public string? FileLink01 { get; set; }

    public string? FileLink02 { get; set; }

    public string? FileLink03 { get; set; }

    public string? FileLink04 { get; set; }

    public string? FileLink05 { get; set; }

    public string? FileLink06 { get; set; }

    public string? FileLink07 { get; set; }

    public string? FileLink08 { get; set; }

    public string? FileLink09 { get; set; }

    public string? FileLink10 { get; set; }

    public string? FileName01 { get; set; }

    public string? FileName02 { get; set; }

    public string? FileName03 { get; set; }

    public string? FileName04 { get; set; }

    public string? FileName05 { get; set; }

    public string? FileName06 { get; set; }

    public string? FileName07 { get; set; }

    public string? FileName08 { get; set; }

    public string? FileName09 { get; set; }

    public string? FileName10 { get; set; }

    public string? InfoKey { get; set; }

    public string? ChgNtceRsn { get; set; }
}
