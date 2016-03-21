﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using TaidouCommon.Model;

namespace TaidouServer.DataBase.Mapping
{
    class UserInfoMapping:ClassMap<UserInfo>
    {
        public UserInfoMapping()
        {
            //这里的x是TestUser的一个对象
            Id(x => x.Id).Column("id");  //设置id属性为主键
            Map(x => x.Username).Column("username");
            Map(x => x.Password).Column("password");
            Map(x => x.Age).Column("age");
            Table("testuser");
        }
    }
}
