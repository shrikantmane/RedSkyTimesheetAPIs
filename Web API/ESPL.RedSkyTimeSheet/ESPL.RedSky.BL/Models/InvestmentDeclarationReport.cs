using System;

namespace ESPL.RedSkyTimeSheet.BL.Models
{
    public class InvestmentDeclarationReport
    {

       public class InvestmentDeclaration
        {
            public string EmpID { get; set; }
            public string EmpName { get; set; }
            public string EmpStatus { get; set; }
            public string FormStatus { get; set; }
            public string NoOfChildren { get; set; }
            public string HRA_Sec10 { get; set; }
            public string NPP_80CCD1 { get; set; }
            public string NPP_80CCD1B { get; set; }
            public string D80 { get; set; }
            public string Parents_D80 { get; set; }
            public string Interest_HomeLoan_us24 { get; set; }
            public string DD80 { get; set; }
            public string DDB80 { get; set; }
            public string U80 { get; set; }
            public string Int_Edu80E { get; set; }
            public string C80 { get; set; }
            public string G80 { get; set; }
            public string OTHERINCOME { get; set; }
            public DateTime Modified { get; set; }
            public string UpdatedInCurrentMonth { get; set; }
            

        }

    }
}
