using FusionAuth.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAuth.Test.Mocks
{
    public static class MockedProperties
    {
        public static SubjectProperty Age18YearsOld => new SubjectProperty("Age", "18");
        public static SubjectProperty GenderMale => new SubjectProperty("Gender", "Male");
        public static SubjectProperty EmailJohnDoe => new SubjectProperty("EMail", "john@doe.com");
    }
}