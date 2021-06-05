using FusionAuth.Rules;
using FusionAuth.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAuth
{
    public static class Authorization
    {
        public static bool IsAuthorized(Subject subject, AuthorizationRule rule) => rule.Func.Invoke(subject);

        public static bool IsAuthorized(Subject subject, IEnumerable<AuthorizationRule> rules) => !rules.Select(rule => rule.Func.Invoke(subject)).Contains(false);
    }
}