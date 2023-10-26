using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DethiLayer
{
    public class DETHI
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();
        public DeThi getItem(int id)
        {
            return db.DeThis.FirstOrDefault(x => x.MaDe == id);
        }
        public List<DeThi> getList()
        {
            return db.DeThis.ToList();
        }
    }
}
