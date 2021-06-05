using FusionAuth.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAuth.Test.Mocks
{
    public static class MockedSubjects
    {
        public static Subject JohnDoe
        {
            get
            {
                var john = new Subject("__JohnDoeMocked__");

                john.AddPrivilege(MockedPrivileges.IsAdmin);
                john.AddProperty(MockedProperties.Age18YearsOld);
                john.AddProperty(MockedProperties.GenderMale);
                john.AddProperty(MockedProperties.EmailJohnDoe);

                return john;
            }
        }
    }
}