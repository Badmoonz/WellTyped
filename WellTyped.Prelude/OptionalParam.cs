using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellTyped.Prelude
{
    public struct OptionalParam<T>
    {
        public readonly bool HasValue;
        public readonly T Value;
        private OptionalParam(T value) : this()
        {
            HasValue = true;
            Value = value; 
        }

        public static implicit operator OptionalParam<T>(T value)
        {
            return new OptionalParam<T>(value);
        } 
        public readonly static OptionalParam<T> None = default(OptionalParam<T>);
    }

}
