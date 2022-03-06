using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siemens.Models;

namespace Siemens.Reposetory
{
    public class Repository : IRepository
    {
        SiemensContext db = new SiemensContext();
        
        public TblUser GetUser(string userName)
        {
            return db.TblUsers.Where(x => x.Name == userName).FirstOrDefault();

        }

    }
}
