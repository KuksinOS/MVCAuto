using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAuto.Library.Internal.DataAccess
{
    internal class SqlDataAccess : IDisposable
    {
        private IDbConnection _connection;
        private bool _isClosed = false;
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public void Dispose()
        {
            if (!_isClosed)
            {
                try
                {
                   
                }
                catch (Exception)
                {
                    //TODO-Log this issue
                    //throw;
                }
            }

            _connection = null;

        }



    }
}
