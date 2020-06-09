using System.Diagnostics.CodeAnalysis;

namespace Pharmacy.Core.Constants
{
    public static class Enumerations
    {
        public enum UserType
        {
            Staff = 1,
            Patient = 2,
            Member = 3
        }


        public enum FormalDocumentType
        {
            License = 1,
            GroupLicense = 2
        }


        public enum RoleLevel
        {
            System = 1,
            Institution,
            Organization
        }

        public enum WebRole
        {
            SuperAdministrator = 1,
            Administrator,

            InstitutionStaff,
            InstitutionMember,

            OrganizationAdministrator,
            OrganizationManagement,
            OrganizationDoctor,
            OrganizationStaff,

            InstitutionAdministrator
        }

        public enum LogActivity
        {
            LoginSuccessful = 1,
            LoginUnsuccessful = 2,
            Logout = 3,
            SystemError = 4,
            UnauthorizedAccess = 5,
            AnonimousUser = 6,
            Visitor = 7,
            Add = 8,
            Edit = 9,
            Delete = 10,
            EditStatus = 11,
            PasswordChange = 12,
            Undefined = 13
        }

        public enum LogType
        {
            Info,
            Warning,
            Error,
            Fatal
        }

        public enum ContactType
        {
            Email = 1,
            Phone,
            Mobile
        }

        public enum UserStoryStatus
        {
            Pending = 1,
            Implementation,
            Finished,
            Rejected
        }
        public enum BugStatus
        {
            Pending = 1,
            Urgent,
            Finished
        }



        public enum PaymentTypes
        {
            Cash = 1,
            CreditCard,
            Virman
        }

        public enum SaveOptions
        {
            Save = 1,
            SaveAndOpenLink
        }

        public enum Gender : short
        {
            Male = 0,
            Female = 1
        }

    }

}
