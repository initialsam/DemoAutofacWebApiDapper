using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common
{
    public class AppSetting:IAppSetting
    {
        private string _dataContext;
        private string _testData;

        public string DataContext
        {
            get
            {
                if (string.IsNullOrEmpty(_dataContext))
                    _dataContext = ConfigurationManager.ConnectionStrings["DataContext"].ToString();

                return _dataContext;
            }

            set
            {
                _dataContext = value;
            }
        }

        public string TestData
        {
            get
            {
                if (string.IsNullOrEmpty(_testData))
                    _testData = ConfigurationManager.AppSettings["TestData"];

                return _testData;
            }

            set
            {
                _testData = value;
            }
        }
    }
}
