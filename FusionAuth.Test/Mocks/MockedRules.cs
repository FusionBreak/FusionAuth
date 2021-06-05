using FusionAuth.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAuth.Test.Mocks
{
    public static class MockedRules
    {
        public static AuthorizationRule IsAdminPrivilege => new AuthorizationRule(s => s.Privileges.Any(privilege => privilege == MockedPrivileges.IsAdmin), "SubjectIsAdmin");
        public static AuthorizationRule Is18YearsOldProperty => new AuthorizationRule(s => s.Properties.Any(property => property == MockedProperties.Age18YearsOld), "SubjectIs18YearsOld");
    }
}