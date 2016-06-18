using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MobileFramework.Database
{
  public  class BusinessEntityBase : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;

        }
    }
}
