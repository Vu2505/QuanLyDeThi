using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DethiLayer
{
    public class DOKHO
    {
        DETHITRACNGHIEMEntities db = new DETHITRACNGHIEMEntities();

        public DoKho getItem(int id)
        {
            return db.DoKhoes.FirstOrDefault(x => x.MaDoKho == id);
        }
        public List<DoKho> getList()
        {
            return db.DoKhoes.ToList();
        }
    }
}
