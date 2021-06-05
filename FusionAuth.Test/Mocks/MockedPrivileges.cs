using FusionAuth.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAuth.Test.Mocks
{
    public static class MockedPrivileges
    {
        public static SubjectPrivilege IsAdmin => new SubjectPrivilege("IsAdmin");
    }
}