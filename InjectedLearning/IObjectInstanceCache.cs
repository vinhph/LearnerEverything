using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectedLearning
{
    public interface IObjectInstanceCache
    {
        void Insert(string key, object value);
        void Remove(string key);
    }
}
