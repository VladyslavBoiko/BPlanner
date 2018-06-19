using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDataAccess
    {
        Object GetData();
        void SetData(Object data);
    }
}
