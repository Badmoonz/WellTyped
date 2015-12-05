
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Fx
{

    public sealed class Matcher<T1,T2,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
		where T1 : class
		where T2 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}

        public Matcher<T2,T,R> With(Expression<Func<T1,R>> f)
        {
            return new Matcher<T2,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T,R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1,T2,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T,R> With(Expression<Func<T2,R>> f)
        {
            return new Matcher<T1,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T,R> With(Expression<Predicate<T2>> pred, Expression<Func<T2, R>> f)
        {
            return new Matcher<T1,T2,T,R>(AddItem(pred, f));
        }
    }

    public sealed class Matcher<T1,T2,T3,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
		where T1 : class
		where T2 : class
		where T3 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}

        public Matcher<T2,T3,T,R> With(Expression<Func<T1,R>> f)
        {
            return new Matcher<T2,T3,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T,R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1,T2,T3,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T3,T,R> With(Expression<Func<T2,R>> f)
        {
            return new Matcher<T1,T3,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T,R> With(Expression<Predicate<T2>> pred, Expression<Func<T2, R>> f)
        {
            return new Matcher<T1,T2,T3,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T,R> With(Expression<Func<T3,R>> f)
        {
            return new Matcher<T1,T2,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T,R> With(Expression<Predicate<T3>> pred, Expression<Func<T3, R>> f)
        {
            return new Matcher<T1,T2,T3,T,R>(AddItem(pred, f));
        }
    }

    public sealed class Matcher<T1,T2,T3,T4,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}

        public Matcher<T2,T3,T4,T,R> With(Expression<Func<T1,R>> f)
        {
            return new Matcher<T2,T3,T4,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T,R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T3,T4,T,R> With(Expression<Func<T2,R>> f)
        {
            return new Matcher<T1,T3,T4,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T,R> With(Expression<Predicate<T2>> pred, Expression<Func<T2, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T4,T,R> With(Expression<Func<T3,R>> f)
        {
            return new Matcher<T1,T2,T4,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T,R> With(Expression<Predicate<T3>> pred, Expression<Func<T3, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T,R> With(Expression<Func<T4,R>> f)
        {
            return new Matcher<T1,T2,T3,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T,R> With(Expression<Predicate<T4>> pred, Expression<Func<T4, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T,R>(AddItem(pred, f));
        }
    }

    public sealed class Matcher<T1,T2,T3,T4,T5,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}

        public Matcher<T2,T3,T4,T5,T,R> With(Expression<Func<T1,R>> f)
        {
            return new Matcher<T2,T3,T4,T5,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T,R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T3,T4,T5,T,R> With(Expression<Func<T2,R>> f)
        {
            return new Matcher<T1,T3,T4,T5,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T,R> With(Expression<Predicate<T2>> pred, Expression<Func<T2, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T4,T5,T,R> With(Expression<Func<T3,R>> f)
        {
            return new Matcher<T1,T2,T4,T5,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T,R> With(Expression<Predicate<T3>> pred, Expression<Func<T3, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T5,T,R> With(Expression<Func<T4,R>> f)
        {
            return new Matcher<T1,T2,T3,T5,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T,R> With(Expression<Predicate<T4>> pred, Expression<Func<T4, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T,R> With(Expression<Func<T5,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T,R> With(Expression<Predicate<T5>> pred, Expression<Func<T5, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T,R>(AddItem(pred, f));
        }
    }

    public sealed class Matcher<T1,T2,T3,T4,T5,T6,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
		where T6 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}

        public Matcher<T2,T3,T4,T5,T6,T,R> With(Expression<Func<T1,R>> f)
        {
            return new Matcher<T2,T3,T4,T5,T6,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T,R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T3,T4,T5,T6,T,R> With(Expression<Func<T2,R>> f)
        {
            return new Matcher<T1,T3,T4,T5,T6,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T,R> With(Expression<Predicate<T2>> pred, Expression<Func<T2, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T4,T5,T6,T,R> With(Expression<Func<T3,R>> f)
        {
            return new Matcher<T1,T2,T4,T5,T6,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T,R> With(Expression<Predicate<T3>> pred, Expression<Func<T3, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T5,T6,T,R> With(Expression<Func<T4,R>> f)
        {
            return new Matcher<T1,T2,T3,T5,T6,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T,R> With(Expression<Predicate<T4>> pred, Expression<Func<T4, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T6,T,R> With(Expression<Func<T5,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T6,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T,R> With(Expression<Predicate<T5>> pred, Expression<Func<T5, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T,R> With(Expression<Func<T6,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T,R> With(Expression<Predicate<T6>> pred, Expression<Func<T6, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T,R>(AddItem(pred, f));
        }
    }

    public sealed class Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
		where T6 : class
		where T7 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}

        public Matcher<T2,T3,T4,T5,T6,T7,T,R> With(Expression<Func<T1,R>> f)
        {
            return new Matcher<T2,T3,T4,T5,T6,T7,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T3,T4,T5,T6,T7,T,R> With(Expression<Func<T2,R>> f)
        {
            return new Matcher<T1,T3,T4,T5,T6,T7,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> With(Expression<Predicate<T2>> pred, Expression<Func<T2, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T4,T5,T6,T7,T,R> With(Expression<Func<T3,R>> f)
        {
            return new Matcher<T1,T2,T4,T5,T6,T7,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> With(Expression<Predicate<T3>> pred, Expression<Func<T3, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T5,T6,T7,T,R> With(Expression<Func<T4,R>> f)
        {
            return new Matcher<T1,T2,T3,T5,T6,T7,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> With(Expression<Predicate<T4>> pred, Expression<Func<T4, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T6,T7,T,R> With(Expression<Func<T5,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T6,T7,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> With(Expression<Predicate<T5>> pred, Expression<Func<T5, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T7,T,R> With(Expression<Func<T6,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T7,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> With(Expression<Predicate<T6>> pred, Expression<Func<T6, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T,R> With(Expression<Func<T7,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> With(Expression<Predicate<T7>> pred, Expression<Func<T7, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T,R>(AddItem(pred, f));
        }
    }

    public sealed class Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
		where T6 : class
		where T7 : class
		where T8 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}

        public Matcher<T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Func<T1,R>> f)
        {
            return new Matcher<T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Func<T2,R>> f)
        {
            return new Matcher<T1,T3,T4,T5,T6,T7,T8,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Predicate<T2>> pred, Expression<Func<T2, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T4,T5,T6,T7,T8,T,R> With(Expression<Func<T3,R>> f)
        {
            return new Matcher<T1,T2,T4,T5,T6,T7,T8,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Predicate<T3>> pred, Expression<Func<T3, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T5,T6,T7,T8,T,R> With(Expression<Func<T4,R>> f)
        {
            return new Matcher<T1,T2,T3,T5,T6,T7,T8,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Predicate<T4>> pred, Expression<Func<T4, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T6,T7,T8,T,R> With(Expression<Func<T5,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T6,T7,T8,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Predicate<T5>> pred, Expression<Func<T5, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T7,T8,T,R> With(Expression<Func<T6,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T7,T8,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Predicate<T6>> pred, Expression<Func<T6, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T8,T,R> With(Expression<Func<T7,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T8,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Predicate<T7>> pred, Expression<Func<T7, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T,R> With(Expression<Func<T8,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Predicate<T8>> pred, Expression<Func<T8, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(pred, f));
        }
    }

    public sealed class Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> : MatchBase<T,R>
        where T : class, IDiscriminatedUnion
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
		where T6 : class
		where T7 : class
		where T8 : class
		where T9 : class
    {
        public Matcher(Tuple<Type, Expression, Expression>[] caseList) : base(caseList){}

        public Matcher<T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Func<T1,R>> f)
        {
            return new Matcher<T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T1>> pred, Expression<Func<T1, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Func<T2,R>> f)
        {
            return new Matcher<T1,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T2>> pred, Expression<Func<T2, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Func<T3,R>> f)
        {
            return new Matcher<T1,T2,T4,T5,T6,T7,T8,T9,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T3>> pred, Expression<Func<T3, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T5,T6,T7,T8,T9,T,R> With(Expression<Func<T4,R>> f)
        {
            return new Matcher<T1,T2,T3,T5,T6,T7,T8,T9,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T4>> pred, Expression<Func<T4, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T6,T7,T8,T9,T,R> With(Expression<Func<T5,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T6,T7,T8,T9,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T5>> pred, Expression<Func<T5, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T7,T8,T9,T,R> With(Expression<Func<T6,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T7,T8,T9,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T6>> pred, Expression<Func<T6, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T8,T9,T,R> With(Expression<Func<T7,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T8,T9,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T7>> pred, Expression<Func<T7, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T9,T,R> With(Expression<Func<T8,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T9,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T8>> pred, Expression<Func<T8, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R> With(Expression<Func<T9,R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T,R>(AddItem(f));
        }
        public Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R> With(Expression<Predicate<T9>> pred, Expression<Func<T9, R>> f)
        {
            return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,T,R>(AddItem(pred, f));
        }
    }


	public static class PatternMatchingHelper
	{
	public static Matcher<T1,T2, DiscriminatedUnion<T1,T2>,R> Match<T1,T2,R>(this DiscriminatedUnion<T1,T2> du, R target)
		where T1 : class
		where T2 : class
	{
		return new Matcher<T1,T2,DiscriminatedUnion<T1,T2>,R>(new Tuple<Type, Expression, Expression>[0]);
	}
	
	public static Matcher<T1,T2,T3, DiscriminatedUnion<T1,T2,T3>,R> Match<T1,T2,T3,R>(this DiscriminatedUnion<T1,T2,T3> du, R target)
		where T1 : class
		where T2 : class
		where T3 : class
	{
		return new Matcher<T1,T2,T3,DiscriminatedUnion<T1,T2,T3>,R>(new Tuple<Type, Expression, Expression>[0]);
	}
	
	public static Matcher<T1,T2,T3,T4, DiscriminatedUnion<T1,T2,T3,T4>,R> Match<T1,T2,T3,T4,R>(this DiscriminatedUnion<T1,T2,T3,T4> du, R target)
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
	{
		return new Matcher<T1,T2,T3,T4,DiscriminatedUnion<T1,T2,T3,T4>,R>(new Tuple<Type, Expression, Expression>[0]);
	}
	
	public static Matcher<T1,T2,T3,T4,T5, DiscriminatedUnion<T1,T2,T3,T4,T5>,R> Match<T1,T2,T3,T4,T5,R>(this DiscriminatedUnion<T1,T2,T3,T4,T5> du, R target)
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
	{
		return new Matcher<T1,T2,T3,T4,T5,DiscriminatedUnion<T1,T2,T3,T4,T5>,R>(new Tuple<Type, Expression, Expression>[0]);
	}
	
	public static Matcher<T1,T2,T3,T4,T5,T6, DiscriminatedUnion<T1,T2,T3,T4,T5,T6>,R> Match<T1,T2,T3,T4,T5,T6,R>(this DiscriminatedUnion<T1,T2,T3,T4,T5,T6> du, R target)
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
		where T6 : class
	{
		return new Matcher<T1,T2,T3,T4,T5,T6,DiscriminatedUnion<T1,T2,T3,T4,T5,T6>,R>(new Tuple<Type, Expression, Expression>[0]);
	}
	
	public static Matcher<T1,T2,T3,T4,T5,T6,T7, DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>,R> Match<T1,T2,T3,T4,T5,T6,T7,R>(this DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7> du, R target)
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
		where T6 : class
		where T7 : class
	{
		return new Matcher<T1,T2,T3,T4,T5,T6,T7,DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>,R>(new Tuple<Type, Expression, Expression>[0]);
	}
	
	public static Matcher<T1,T2,T3,T4,T5,T6,T7,T8, DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>,R> Match<T1,T2,T3,T4,T5,T6,T7,T8,R>(this DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8> du, R target)
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
		where T6 : class
		where T7 : class
		where T8 : class
	{
		return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>,R>(new Tuple<Type, Expression, Expression>[0]);
	}
	
	public static Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9, DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>,R> Match<T1,T2,T3,T4,T5,T6,T7,T8,T9,R>(this DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9> du, R target)
		where T1 : class
		where T2 : class
		where T3 : class
		where T4 : class
		where T5 : class
		where T6 : class
		where T7 : class
		where T8 : class
		where T9 : class
	{
		return new Matcher<T1,T2,T3,T4,T5,T6,T7,T8,T9,DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>,R>(new Tuple<Type, Expression, Expression>[0]);
	}
	

	}


}
