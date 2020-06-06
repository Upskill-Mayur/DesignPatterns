using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    public class Policy
    {
        private static readonly Policy _instance = new Policy();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Policy()
        {
        }

        private Policy()
        {
        }

        public static Policy Instance
        {
            get { return _instance; }
        }
    }

    public class PolicyWithLazyInstantiation
    {
        private static readonly Lazy<PolicyWithLazyInstantiation> lazy =
            new Lazy<PolicyWithLazyInstantiation>(() => new PolicyWithLazyInstantiation());
        
        public static PolicyWithLazyInstantiation Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private PolicyWithLazyInstantiation()
        { 
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Assert.AreSame(Policy.Instance, Policy.Instance);
        }
    }
}
