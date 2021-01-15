using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using ImdDataAccessLayer;
namespace ImsBusinessLogicLayer
{
    public class MainBLL
    {
        public bool Login(string _user, string _pass)
        {
            MainDAL mainDal = new MainDAL();
            return mainDal.Login(_user, _pass);
        }
    }
}
