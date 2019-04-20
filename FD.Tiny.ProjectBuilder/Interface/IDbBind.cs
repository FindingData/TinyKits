using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.ProjectBuilder
{
    public interface IDbBind
    {
        string GetPropertyTypeName(string dbTypeName);
    }
}
