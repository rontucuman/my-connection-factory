using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConnectionFactory
{
  enum DataProviderEnum
  {
    // OleDb is windows only and is not supported in .NET Core
    SqlServer,
#if PC
    OleDb,
#endif
    Odbc,
    None
  }
}
