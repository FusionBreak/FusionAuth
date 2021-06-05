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
        public IEnumerable<SubjectPrivilege> Privileges => _privileges;
        public IEnumerable<SubjectProperty> Properties => _properties;

        private HashSet<SubjectPrivilege> _privileges = new();
        private HashSet<SubjectProperty> _properties = new();

        public Subject(string identifier) => Identifier = identifier;

        public bool AddPrivilege(SubjectPrivilege privilege) => _privileges.Add(privilege);

        public bool AddPrivilege(string name) => AddPrivilege(new SubjectPrivilege(name));

        public bool RemovePrivilege(string name) => _privileges.RemoveWhere(p => p.Name == name) > 0;

        public bool HasPrivilege(string name) => _privileges.Any(p => p.Name == name);

        public bool AddProperty(SubjectProperty property) => _properties.Add(property);

        public bool RemoveProperty(string key, string value) => _properties.RemoveWhere(p => p.Key == key && p.Value == value) > 0;

        public int RemoveProperties(string key) => _properties.RemoveWhere(p => p.Key == key);

        public bool HasProperty(string key, string value) => _properties.Any(p => p.Key == key && p.Value == value);

        public IEnumerable<string> GetPropertyValues(string key) => _properties.Where(p => p.Key == key).Select(p => p.Value);
    }
}