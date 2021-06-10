using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAuth.Subjects
{
    public class Subject
    {
        public string Identifier { get; }
        public HashSet<SubjectPrivilege> Privileges { get; init; } = new();
        public HashSet<SubjectProperty> Properties { get; init; } = new();

        public Subject(string identifier) => Identifier = identifier;

        public bool AddPrivilege(SubjectPrivilege privilege) => Privileges.Add(privilege);

        public bool AddPrivilege(string name) => AddPrivilege(new SubjectPrivilege(name));

        public bool RemovePrivilege(string name) => Privileges.RemoveWhere(p => p.Name == name) > 0;

        public bool HasPrivilege(string name) => Privileges.Any(p => p.Name == name);

        public bool AddProperty(SubjectProperty property) => Properties.Add(property);

        public bool RemoveProperty(string key, string value) => Properties.RemoveWhere(p => p.Key == key && p.Value == value) > 0;

        public int RemoveProperties(string key) => Properties.RemoveWhere(p => p.Key == key);

        public bool HasProperty(string key, string value) => Properties.Any(p => p.Key == key && p.Value == value);

        public IEnumerable<string> GetPropertyValues(string key) => Properties.Where(p => p.Key == key).Select(p => p.Value);

        public override bool Equals(object obj) => obj is Subject subject ? Identifier == subject.Identifier : false;

        public override int GetHashCode() => HashCode.Combine(Identifier);

        public static bool operator ==(Subject left, Subject right) => left.Equals(right);

        public static bool operator !=(Subject left, Subject right) => !left.Equals(right);
    }
}