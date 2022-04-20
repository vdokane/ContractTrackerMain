﻿namespace ContractTracker.ClientModels
{
    public class VendorModel
    {
        public string? VendorName { get; set; }
        public string? VendorNumber { get; set; }
        public string? VendorSequence { get; set; }
        public string? W9Status { get; set; }
    }
}

/*
 *  select top(60) VendorType, VendorNumber, SequenceNumber, PurchasingNameLine1, StatusCode, AddDate, UpdateDate from Vendors
 *  N	000000003	001	INMATE TRUST FUND	A	20110207	20191121
N	000000005	001	TALLAHASSEE REVOLVING FUND	A	20110207	20200124
N	000000006	001	DEPARTMENT OF MILITARY AFFAIRS	A	20110207	20190213
N	000000010	001	STEWART TITLE GUARANTY COMPANY	A	20210916	20210916
N	000000012	001	FDOT PAYROLL	A	20110207	20110207
N	000000078	001	DMS BUNDLED SERVICE CLAIMS	A	20181116	20181116
N	000000163	001	BONE, STEPHEN P	A	20210817	20210817
N	000000192	001	HOLIDAY CVS LLC	A	20210916	20210916
N	000000280	001	GRAYS MOBILE HOME PARK	A	20210916	20210916
N	000000292	001	HOMEWOOD SUITES BY HILTON	A	20210916	20210916
N	000000320	001	THOMAS, NYEMA	A	20210916	20210916
N	000000494	001	CASH MANAGEMENT	A	20110228	20110228
N	000000763	001	ADJUSTING ENTRY	A	20110304	20110304
F	000000776	001	SNEADS FFA ALUMNI	A	20060119	20060119
N	000000861	001	DBPR REVOLVING FUND	A	20110308	20110308
N	000000863	001	DBPR REVOLVING FUND	A	20110308	20120126
N	000000874	001	DBPR REVOLVING FUND	A	20110308	20120126
N	000000900	001	FINANCIAL STATEMENT ACCRUALS	A	20110310	20200429
N	000000924	001	UNCLAIMED PROPERTY PAYMENTS	A	20110310	20110310
N	000000927	001	DIST007 REP JASON SHOAF	A	20190619	20210217
N	000000928	001	DIST038 REP RANDY MAGGARD	A	20190619	20210217
N	000000948	001	MARATHON GAS	A	20190620	20190620
F	000001001	001	FL EBT CHILDREN & FAMILIES	A	19990205	20111018
N	000001111	001	CLOPTON, AYDEN	A	20210916	20210916
N	000001150	001	SHOEBOX INC	A	20190625	20190625
N	000001158	001	DIST040 SEN ANNETTE TADDEO	A	20170927	20210217
N	000001160	001	PAOLILLO, LAURA	A	20140703	20140703
N	000001162	001	HUMPHREY, JAMES W	A	20210917	20210917
N	000001163	001	REYES, JOSE M.	A	20140703	20140703
N	000001164	001	MOWREY, JOSEPH M.	A	20140703	20140703
N	000001165	001	RENDON, GUILLERMO	A	20140703	20140703
N	000001168	001	CHERINI, SONIA N	A	20140703	20140703
N	000001170	001	SADULLAEV, JAMSHID	A	20140703	20140703
N	000001171	001	FRANCO-BETANCUR, JULIAN	A	20140703	20140703
N	000001173	001	QUIAN, GONZALO	A	20140703	20140703
N	000001178	001	RODRIGUEZ, DIEGO	A	20140703	20140703
N	000001179	001	POWERS, TRACEY A.	A	20140703	20140703
N	000001182	001	MEISES, BIANCA M.	A	20140703	20140703
N	000001184	001	DL EXPRESS INC	A	20140703	20140703
N	000001186	001	PATEMAN, MICHAEL P.	A	20140703	20140703
N	000001187	001	CASIQUE, JENNIFER A.	A	20140703	20140703
N	000001189	001	STANCE, CHARLOTTE	A	20140703	20140703
N	000001191	001	CENTRAL CHRISTIAN UNIVERSITY	A	20140703	20140703
N	000001192	001	ARTILES, OLIVIA L.	A	20140703	20140703
N	000001193	001	GONZALEZ, LORENA	A	20140703	20140703
N	000001194	001	TMA WORLDWIDE SERVICES	A	20140703	20140703
N	000001195	001	ANDY CLEANING SERVICES, LLC	A	20140703	20140703
N	000001197	001	E&J AUTO WORKS, INC	A	20140703	20140703
N	000001198	001	ZOOM HOLDING GROUP, LLC	A	20140703	20140703
N	000001199	001	LEANDRO MERCEDES C	A	20140703	20140703
N	000001287	001	DIST116 REP DANIEL A PEREZ	A	20170929	20210217
N	000001300	001	FREDERICK TIFFANI	A	20140708	20140708
N	000001301	001	MAXBELL LTD	A	20140708	20140708
N	000001349	002	EMI MORI	A	20140820	20171005
N	000001393	001	DEPT OF THE LOTTERY	A	20110328	20110328
N	000001497	001	ROBERT, TANKEL	A	20210917	20210917
N	000001499	001	NATION, RONNIE L	A	20210917	20210917
N	000001537	001	PINTLER STATION	A	20210917	20210917
N	000001559	001	WOLFPACK MARKETING LLC	A	20210917	20210917
N	000001642	001	BLACK,WAYNE	A	20140721	20140721 */