using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaidouCommon.Model;

namespace TaidouServer.DataBase.Manager
{
    public class UserInfoManager
    {
        public UserInfo GetUserInfoByName(string username)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var userInfoList = session.QueryOver<UserInfo>().Where(user => user.Username == username);
                    transaction.Commit();
                    return userInfoList.List<UserInfo>()[0];
                }
            }
        }
    }
}
