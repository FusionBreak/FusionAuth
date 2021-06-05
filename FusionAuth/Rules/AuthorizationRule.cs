using FusionAuth.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAuth.Rules
{
    public class AuthorizationRule
    {
        public string Name { get; }
        public Func<Subject, bool> Func { get; }

        public AuthorizationRule(Func<Subject, bool> func, string name)
        {
            Func = func;
            Name = name;
        }
    }
}