using System;
using System.Data;
using System.Data.Odbc;
#if PC
using System.Data.OleDb;
#endif
using Microsoft.Data.SqlClient;

namespace MyConnectionFactory
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("***** Very simple connection factory *****\n");
      Setup(DataProviderEnum.SqlServer);
#if PC
      Setup(DataProviderEnum.OleDb);
#endif
      Setup(DataProviderEnum.Odbc);
      Setup(DataProviderEnum.None);
    }

    private static void Setup(DataProviderEnum dataProvider)
    {
      // Get a specific connection
      IDbConnection myConnection = GetConnection(dataProvider);
      Console.WriteLine($"Your connection is a {myConnection?.GetType().Name ?? "unrecognized type"}");
    }

    private static IDbConnection GetConnection(DataProviderEnum dataProvider) => dataProvider switch
    {
      DataProviderEnum.SqlServer => new SqlConnection(),
#if PC
      // Not supported on macOS
      DataProviderEnum.OleDb => new OleDbConnection(),
#endif
      DataProviderEnum.Odbc => new OdbcConnection(),
      _ => null
    };
  }
}
