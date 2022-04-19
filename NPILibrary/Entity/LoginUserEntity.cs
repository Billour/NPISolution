using System;
using System.Collections.Generic;
using System.Text;

using Asus.Sercurity;

namespace AsusLibrary.Entity
{
    /// <summary>
    /// Login User ���
    /// �[�J����C��
    /// </summary>
    public class LoginUserEntity:LoginUser
    {
        private List<string> _Roles;

        /// <summary>
        /// NPI �s�W����C��
        /// </summary>
        public List<string> Roles
        {
            set { _Roles = value; }
            get { return _Roles; }
        }
    }
}
