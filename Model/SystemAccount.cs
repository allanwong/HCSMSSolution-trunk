﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCSMS.Model
{
    [Serializable]
    public class SystemAccount
    {
        public SystemAccount()
        {
            Status = AccountStatus.Locked;
            UserRole = new List<string>();
        }
        public string UserName { get ;set; }
        public string UserId { get; set; }
        public AccountStatus Status { get; set; }
        public List<string> UserRole { get; set; }
    }
}
