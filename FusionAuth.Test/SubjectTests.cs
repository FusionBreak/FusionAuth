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
        public void EquivalenceCanBeDetermined()
        {
            var guid = Guid.NewGuid().ToString();

            var subject = new Subject(guid);
            var subjectDuplicate = new Subject(guid);

            var subjectFake = new Subject(Guid.NewGuid().ToString());

            Assert.Equal(subject, subjectDuplicate);
            Assert.True(subject == subjectDuplicate);
            Assert.False(subject != subjectDuplicate);
            Assert.True(subject.Equals(subjectDuplicate));

            Assert.NotEqual(subject, subjectFake);
            Assert.True(subject != subjectFake);
            Assert.False(subject == subjectFake);
            Assert.False(subject.Equals(subjectFake));
        }

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