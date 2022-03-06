using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siemens.Models;

namespace Siemens.Reposetory
{
    public interface IRepository
    {
       
        TblUser GetUser(string userName);
       
    }
}
