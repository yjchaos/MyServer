using System;
using System.Collections.Generic;
using System.Text;

namespace TaidouCommon.Model
{
    public class UserInfo
    {
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual int Age { get; set; }
    }
}
