using System.Data.SqlTypes;

/// <summary>
/// Summary description for ClientENTBase
/// </summary>
namespace WorkerFinder.ENT
{
    public abstract class ClientENTBase
    {
        protected SqlInt32 _ClientID;
        public SqlInt32 ClientID
        {
            get
            {
                return _ClientID;
            }
            set
            {
                _ClientID = value;
            }
        }

        protected SqlString _ClientName;
        public SqlString ClientName
        {
            get
            {
                return _ClientName;
            }
            set
            {
                _ClientName = value;
            }
        }

        protected SqlString _Address;
        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        protected SqlString _PhoneNo;
        public SqlString PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }

        protected SqlString _Email;
        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }

        protected SqlString _UserName;
        public SqlString UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }

        protected SqlString _Password;
        public SqlString Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        protected SqlBoolean _IsActive;
        public SqlBoolean IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }

        protected SqlInt32 _JobTypeID;
        public SqlInt32 JobTypeID
        {
            get
            {
                return _JobTypeID;
            }
            set
            {
                _JobTypeID = value;
            }
        }

        protected SqlString _PhotoPath;
        public SqlString PhotoPath
        {
            get
            {
                return _PhotoPath;
            }
            set
            {
                _PhotoPath = value;
            }
        }

        protected SqlDateTime _BirthDate;
        public SqlDateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
            }
        }

        protected SqlString _Gender;
        public SqlString Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        protected SqlDateTime _RegistrationDate;
        public SqlDateTime RegistrationDate
        {
            get
            {
                return _RegistrationDate;
            }
            set
            {
                _RegistrationDate = value;
            }
        }


        protected SqlString _Skills;
        public SqlString Skills
        {
            get
            {
                return _Skills;
            }
            set
            {
                _Skills = value;
            }
        }

        protected SqlInt32 _Experience;
        public SqlInt32 Experience
        {
            get
            {
                return _Experience;
            }
            set
            {
                _Experience = value;
            }
        }

    }
}