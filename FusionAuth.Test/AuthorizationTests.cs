using FusionAuth.Rules;
using FusionAuth.Subjects;
using FusionAuth.Test.Mocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FusionAuth.Test
{
    public class AuthorizationTests
    {
        [Fact]
        public void AuthorizedByRule()
        {
            var subject = new Subject(Guid.NewGuid().ToString());
            subject.AddPrivilege(new SubjectPrivilege("IsAdmin"));

            var rule = new AuthorizationRule(s => s.Privileges.Any(privilege => privilege.Name == "IsAdmin"), "SubjectIsAdmin");

            Assert.True(Authorization.IsAuthorized(subject, rule));
        }

        [Fact]
        public void AuthorizedByRules()
        {
            var subject = new Subject(Guid.NewGuid().ToString());
            subject.AddPrivilege(new SubjectPrivilege("Is18YearsOld"));
            subject.AddPrivilege(new SubjectPrivilege("IsAdmin"));

            var adminRule = new AuthorizationRule(s => s.Privileges.Any(privilege => privilege.Name == "IsAdmin"), "SubjectIsAdmin");
            var ageRule = new AuthorizationRule(s => s.Privileges.Any(privilege => privilege.Name == "Is18YearsOld"), "SubjectIs18YearsOld");

            var rules = new AuthorizationRule[] { adminRule, ageRule };

            Assert.True(Authorization.IsAuthorized(subject, rules));
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void AuthorizedComplex(Subject subject, IEnumerable<AuthorizationRule> rules)
        {
            Assert.True(Authorization.IsAuthorized(subject, rules));
        }
    }

    public class TestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>()
        {
            new object[] {
                MockedSubjects.JohnDoe,
                new AuthorizationRule[]
                {
                    MockedRules.IsAdminPrivilege,
                    MockedRules.Is18YearsOldProperty
                }
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}