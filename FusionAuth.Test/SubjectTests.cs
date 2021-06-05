using FusionAuth.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FusionAuth.Test
{
    public class SubjectTests
    {
        [Fact]
        public void DoNotAddDuplicatesInPrivileges()
        {
            var subject = new Subject(Guid.NewGuid().ToString());

            var privilege = new SubjectPrivilege("IsAdmin");
            var privilegeDuplicate = new SubjectPrivilege("IsAdmin");

            subject.AddPrivilege(privilege);
            subject.AddPrivilege(privilegeDuplicate);

            Assert.Single(subject.Privileges);
        }

        [Fact]
        public void DoNotAddDuplicatesInProperties()
        {
            var subject = new Subject(Guid.NewGuid().ToString());

            var property = new SubjectProperty("Group", "Member");
            var propertyeDuplicate = new SubjectProperty("Group", "Member");

            subject.AddProperty(property);
            subject.AddProperty(propertyeDuplicate);

            Assert.Single(subject.Properties);
        }
    }
}