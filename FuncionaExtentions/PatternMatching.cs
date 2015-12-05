using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace Fx
{
    public abstract class MatchBase<TIn, TOut> where TIn : class, IDiscriminatedUnion
    {
        public readonly Tuple<Type, Expression, Expression>[] _caseList;
        protected MatchBase(Tuple<Type, Expression, Expression>[] caseList)
        {
            _caseList = caseList;
        }
        public Func<TIn, TOut> Default(Expression<Func<TIn, TOut>> f)
        {
            return CompileMatcher(AddItem(f));
        }

        protected static Func<TIn, TOut> CompileMatcher(Tuple<Type, Expression, Expression>[] caseList)
        {
            var arg = Expression.Parameter(typeof(TIn));
            var val = Expression.PropertyOrField(arg, "Val");
            var reverted = Enumerable.Reverse(caseList).ToList();
            var retVal = Expression.Label(typeof(TOut));
            var matcher = Expression.Block(
                        Expression.Throw(Expression.Constant(new Exception("Provided value was not matched with any case"))),
                        Expression.Label(retVal, Expression.Constant(default(TOut), typeof(TOut)))
                    );
            foreach (var pair in reverted)
            {
                retVal = Expression.Label(typeof(TOut));
                var converted = Expression.Convert(val, pair.Item1);
                var action = Expression.Return(retVal, Expression.Invoke(pair.Item3, converted));
                var block = pair.Item2 == null ? (Expression) action : Expression.IfThenElse(Expression.Invoke(pair.Item2, converted), action, Expression.Return(retVal, matcher));
                matcher = Expression.Block(
                    Expression.IfThenElse(Expression.TypeIs(val, pair.Item1), block, Expression.Return(retVal, matcher)),
                    Expression.Label(retVal, Expression.Constant(default(TOut), typeof(TOut))));
            }
            var l = Expression.Lambda<Func<TIn, TOut>>(matcher, arg);
            return l.Compile();
        }

      protected Tuple<Type, Expression, Expression>[] AddItem<T1>(Expression<Func<T1, TOut>> f) where T1 : class
        {
            var temp = _caseList.ToList();
            temp.Add(Tuple.Create<Type, Expression, Expression>(typeof(T1), null, f));
            return temp.ToArray();            
        }

      protected Tuple<Type, Expression, Expression>[] AddItem<T1>(Expression<Predicate<T1>> pred, Expression<Func<T1, TOut>> f) where T1 : class
        {
            var temp = _caseList.ToList();
            temp.Add(Tuple.Create<Type, Expression, Expression>(typeof(T1), pred, f));
            return temp.ToArray();
        }
    }

    public sealed class Matcher<T1,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
        where T1 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}
        public Func<T,R> With(Expression<Func<T1,R>> f)
        {
            return CompileMatcher(AddItem(f));
        }
        public Matcher<T1, T, R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1, T, R>(AddItem(pred, f));
        }
    }



}
