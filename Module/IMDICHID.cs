using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module
{
    public interface IMDICHID
    {
        void NewData();
        void FindData();
        void SaveData();
        void DelData();
        void AddLine();
        void DelLine();
        void ExcelUpData();
        void ExcelDnData();
        void PdfDnData();
    }
}