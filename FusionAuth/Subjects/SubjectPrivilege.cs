using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAuth.Subjects
{
    public record SubjectPrivilege
    {
        public SubjectPrivilege(string name) => Name = name;

        public string Name { get; }
    }
}