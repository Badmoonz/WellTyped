
using System;
using System.Collections.Generic;
using System.Linq;
namespace Fx
{
	public interface IDiscriminatedUnion 
	{
		object GetObject();
		Type GetType(int case_);
		int GetCase(Type t);
	}

	public sealed class DiscriminatedUnion<T1,T2> : IDiscriminatedUnion
	where T1 : class
	where T2 : class
	{
		readonly static Dictionary<Type, ClassCase> typesCache = new Dictionary<Type, ClassCase>();
		enum ClassCase {T1,T2}
		readonly ClassCase classCase;
		static DiscriminatedUnion()
		{
			typesCache[typeof(T1)] = ClassCase.T1;
			typesCache[typeof(T2)] = ClassCase.T2;
			
		}

		internal readonly object Val;
		public DiscriminatedUnion(T1 t){ Val = t; classCase = ClassCase.T1;}
		public DiscriminatedUnion(T2 t){ Val = t; classCase = ClassCase.T2;}
			
		public static implicit operator DiscriminatedUnion<T1,T2>(T1 t){ return new DiscriminatedUnion<T1,T2>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2>(T2 t){ return new DiscriminatedUnion<T1,T2>(t);}
	
		public object GetObject() { return Val; }
		public int GetCase(Type t){ return (int)typesCache[t];}
		public Type GetType(int case_){ return typesCache.First(x => (int)x.Value == case_).Key;}

	}

	public sealed class DiscriminatedUnion<T1,T2,T3> : IDiscriminatedUnion
	where T1 : class
	where T2 : class
	where T3 : class
	{
		readonly static Dictionary<Type, ClassCase> typesCache = new Dictionary<Type, ClassCase>();
		enum ClassCase {T1,T2,T3}
		readonly ClassCase classCase;
		static DiscriminatedUnion()
		{
			typesCache[typeof(T1)] = ClassCase.T1;
			typesCache[typeof(T2)] = ClassCase.T2;
			typesCache[typeof(T3)] = ClassCase.T3;
			
		}

		internal readonly object Val;
		public DiscriminatedUnion(T1 t){ Val = t; classCase = ClassCase.T1;}
		public DiscriminatedUnion(T2 t){ Val = t; classCase = ClassCase.T2;}
		public DiscriminatedUnion(T3 t){ Val = t; classCase = ClassCase.T3;}
			
		public static implicit operator DiscriminatedUnion<T1,T2,T3>(T1 t){ return new DiscriminatedUnion<T1,T2,T3>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3>(T2 t){ return new DiscriminatedUnion<T1,T2,T3>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3>(T3 t){ return new DiscriminatedUnion<T1,T2,T3>(t);}
	
		public object GetObject() { return Val; }
		public int GetCase(Type t){ return (int)typesCache[t];}
		public Type GetType(int case_){ return typesCache.First(x => (int)x.Value == case_).Key;}

	}

	public sealed class DiscriminatedUnion<T1,T2,T3,T4> : IDiscriminatedUnion
	where T1 : class
	where T2 : class
	where T3 : class
	where T4 : class
	{
		readonly static Dictionary<Type, ClassCase> typesCache = new Dictionary<Type, ClassCase>();
		enum ClassCase {T1,T2,T3,T4}
		readonly ClassCase classCase;
		static DiscriminatedUnion()
		{
			typesCache[typeof(T1)] = ClassCase.T1;
			typesCache[typeof(T2)] = ClassCase.T2;
			typesCache[typeof(T3)] = ClassCase.T3;
			typesCache[typeof(T4)] = ClassCase.T4;
			
		}

		internal readonly object Val;
		public DiscriminatedUnion(T1 t){ Val = t; classCase = ClassCase.T1;}
		public DiscriminatedUnion(T2 t){ Val = t; classCase = ClassCase.T2;}
		public DiscriminatedUnion(T3 t){ Val = t; classCase = ClassCase.T3;}
		public DiscriminatedUnion(T4 t){ Val = t; classCase = ClassCase.T4;}
			
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4>(T1 t){ return new DiscriminatedUnion<T1,T2,T3,T4>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4>(T2 t){ return new DiscriminatedUnion<T1,T2,T3,T4>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4>(T3 t){ return new DiscriminatedUnion<T1,T2,T3,T4>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4>(T4 t){ return new DiscriminatedUnion<T1,T2,T3,T4>(t);}
	
		public object GetObject() { return Val; }
		public int GetCase(Type t){ return (int)typesCache[t];}
		public Type GetType(int case_){ return typesCache.First(x => (int)x.Value == case_).Key;}

	}

	public sealed class DiscriminatedUnion<T1,T2,T3,T4,T5> : IDiscriminatedUnion
	where T1 : class
	where T2 : class
	where T3 : class
	where T4 : class
	where T5 : class
	{
		readonly static Dictionary<Type, ClassCase> typesCache = new Dictionary<Type, ClassCase>();
		enum ClassCase {T1,T2,T3,T4,T5}
		readonly ClassCase classCase;
		static DiscriminatedUnion()
		{
			typesCache[typeof(T1)] = ClassCase.T1;
			typesCache[typeof(T2)] = ClassCase.T2;
			typesCache[typeof(T3)] = ClassCase.T3;
			typesCache[typeof(T4)] = ClassCase.T4;
			typesCache[typeof(T5)] = ClassCase.T5;
			
		}

		internal readonly object Val;
		public DiscriminatedUnion(T1 t){ Val = t; classCase = ClassCase.T1;}
		public DiscriminatedUnion(T2 t){ Val = t; classCase = ClassCase.T2;}
		public DiscriminatedUnion(T3 t){ Val = t; classCase = ClassCase.T3;}
		public DiscriminatedUnion(T4 t){ Val = t; classCase = ClassCase.T4;}
		public DiscriminatedUnion(T5 t){ Val = t; classCase = ClassCase.T5;}
			
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5>(T1 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5>(T2 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5>(T3 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5>(T4 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5>(T5 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5>(t);}
	
		public object GetObject() { return Val; }
		public int GetCase(Type t){ return (int)typesCache[t];}
		public Type GetType(int case_){ return typesCache.First(x => (int)x.Value == case_).Key;}

	}

	public sealed class DiscriminatedUnion<T1,T2,T3,T4,T5,T6> : IDiscriminatedUnion
	where T1 : class
	where T2 : class
	where T3 : class
	where T4 : class
	where T5 : class
	where T6 : class
	{
		readonly static Dictionary<Type, ClassCase> typesCache = new Dictionary<Type, ClassCase>();
		enum ClassCase {T1,T2,T3,T4,T5,T6}
		readonly ClassCase classCase;
		static DiscriminatedUnion()
		{
			typesCache[typeof(T1)] = ClassCase.T1;
			typesCache[typeof(T2)] = ClassCase.T2;
			typesCache[typeof(T3)] = ClassCase.T3;
			typesCache[typeof(T4)] = ClassCase.T4;
			typesCache[typeof(T5)] = ClassCase.T5;
			typesCache[typeof(T6)] = ClassCase.T6;
			
		}

		internal readonly object Val;
		public DiscriminatedUnion(T1 t){ Val = t; classCase = ClassCase.T1;}
		public DiscriminatedUnion(T2 t){ Val = t; classCase = ClassCase.T2;}
		public DiscriminatedUnion(T3 t){ Val = t; classCase = ClassCase.T3;}
		public DiscriminatedUnion(T4 t){ Val = t; classCase = ClassCase.T4;}
		public DiscriminatedUnion(T5 t){ Val = t; classCase = ClassCase.T5;}
		public DiscriminatedUnion(T6 t){ Val = t; classCase = ClassCase.T6;}
			
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(T1 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(T2 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(T3 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(T4 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(T5 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(T6 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6>(t);}
	
		public object GetObject() { return Val; }
		public int GetCase(Type t){ return (int)typesCache[t];}
		public Type GetType(int case_){ return typesCache.First(x => (int)x.Value == case_).Key;}

	}

	public sealed class DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7> : IDiscriminatedUnion
	where T1 : class
	where T2 : class
	where T3 : class
	where T4 : class
	where T5 : class
	where T6 : class
	where T7 : class
	{
		readonly static Dictionary<Type, ClassCase> typesCache = new Dictionary<Type, ClassCase>();
		enum ClassCase {T1,T2,T3,T4,T5,T6,T7}
		readonly ClassCase classCase;
		static DiscriminatedUnion()
		{
			typesCache[typeof(T1)] = ClassCase.T1;
			typesCache[typeof(T2)] = ClassCase.T2;
			typesCache[typeof(T3)] = ClassCase.T3;
			typesCache[typeof(T4)] = ClassCase.T4;
			typesCache[typeof(T5)] = ClassCase.T5;
			typesCache[typeof(T6)] = ClassCase.T6;
			typesCache[typeof(T7)] = ClassCase.T7;
			
		}

		internal readonly object Val;
		public DiscriminatedUnion(T1 t){ Val = t; classCase = ClassCase.T1;}
		public DiscriminatedUnion(T2 t){ Val = t; classCase = ClassCase.T2;}
		public DiscriminatedUnion(T3 t){ Val = t; classCase = ClassCase.T3;}
		public DiscriminatedUnion(T4 t){ Val = t; classCase = ClassCase.T4;}
		public DiscriminatedUnion(T5 t){ Val = t; classCase = ClassCase.T5;}
		public DiscriminatedUnion(T6 t){ Val = t; classCase = ClassCase.T6;}
		public DiscriminatedUnion(T7 t){ Val = t; classCase = ClassCase.T7;}
			
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(T1 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(T2 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(T3 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(T4 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(T5 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(T6 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(T7 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7>(t);}
	
		public object GetObject() { return Val; }
		public int GetCase(Type t){ return (int)typesCache[t];}
		public Type GetType(int case_){ return typesCache.First(x => (int)x.Value == case_).Key;}

	}

	public sealed class DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8> : IDiscriminatedUnion
	where T1 : class
	where T2 : class
	where T3 : class
	where T4 : class
	where T5 : class
	where T6 : class
	where T7 : class
	where T8 : class
	{
		readonly static Dictionary<Type, ClassCase> typesCache = new Dictionary<Type, ClassCase>();
		enum ClassCase {T1,T2,T3,T4,T5,T6,T7,T8}
		readonly ClassCase classCase;
		static DiscriminatedUnion()
		{
			typesCache[typeof(T1)] = ClassCase.T1;
			typesCache[typeof(T2)] = ClassCase.T2;
			typesCache[typeof(T3)] = ClassCase.T3;
			typesCache[typeof(T4)] = ClassCase.T4;
			typesCache[typeof(T5)] = ClassCase.T5;
			typesCache[typeof(T6)] = ClassCase.T6;
			typesCache[typeof(T7)] = ClassCase.T7;
			typesCache[typeof(T8)] = ClassCase.T8;
			
		}

		internal readonly object Val;
		public DiscriminatedUnion(T1 t){ Val = t; classCase = ClassCase.T1;}
		public DiscriminatedUnion(T2 t){ Val = t; classCase = ClassCase.T2;}
		public DiscriminatedUnion(T3 t){ Val = t; classCase = ClassCase.T3;}
		public DiscriminatedUnion(T4 t){ Val = t; classCase = ClassCase.T4;}
		public DiscriminatedUnion(T5 t){ Val = t; classCase = ClassCase.T5;}
		public DiscriminatedUnion(T6 t){ Val = t; classCase = ClassCase.T6;}
		public DiscriminatedUnion(T7 t){ Val = t; classCase = ClassCase.T7;}
		public DiscriminatedUnion(T8 t){ Val = t; classCase = ClassCase.T8;}
			
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(T1 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(T2 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(T3 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(T4 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(T5 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(T6 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(T7 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(T8 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8>(t);}
	
		public object GetObject() { return Val; }
		public int GetCase(Type t){ return (int)typesCache[t];}
		public Type GetType(int case_){ return typesCache.First(x => (int)x.Value == case_).Key;}

	}

	public sealed class DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9> : IDiscriminatedUnion
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
		readonly static Dictionary<Type, ClassCase> typesCache = new Dictionary<Type, ClassCase>();
		enum ClassCase {T1,T2,T3,T4,T5,T6,T7,T8,T9}
		readonly ClassCase classCase;
		static DiscriminatedUnion()
		{
			typesCache[typeof(T1)] = ClassCase.T1;
			typesCache[typeof(T2)] = ClassCase.T2;
			typesCache[typeof(T3)] = ClassCase.T3;
			typesCache[typeof(T4)] = ClassCase.T4;
			typesCache[typeof(T5)] = ClassCase.T5;
			typesCache[typeof(T6)] = ClassCase.T6;
			typesCache[typeof(T7)] = ClassCase.T7;
			typesCache[typeof(T8)] = ClassCase.T8;
			typesCache[typeof(T9)] = ClassCase.T9;
			
		}

		internal readonly object Val;
		public DiscriminatedUnion(T1 t){ Val = t; classCase = ClassCase.T1;}
		public DiscriminatedUnion(T2 t){ Val = t; classCase = ClassCase.T2;}
		public DiscriminatedUnion(T3 t){ Val = t; classCase = ClassCase.T3;}
		public DiscriminatedUnion(T4 t){ Val = t; classCase = ClassCase.T4;}
		public DiscriminatedUnion(T5 t){ Val = t; classCase = ClassCase.T5;}
		public DiscriminatedUnion(T6 t){ Val = t; classCase = ClassCase.T6;}
		public DiscriminatedUnion(T7 t){ Val = t; classCase = ClassCase.T7;}
		public DiscriminatedUnion(T8 t){ Val = t; classCase = ClassCase.T8;}
		public DiscriminatedUnion(T9 t){ Val = t; classCase = ClassCase.T9;}
			
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T1 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T2 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T3 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T4 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T5 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T6 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T7 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T8 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
		public static implicit operator DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(T9 t){ return new DiscriminatedUnion<T1,T2,T3,T4,T5,T6,T7,T8,T9>(t);}
	
		public object GetObject() { return Val; }
		public int GetCase(Type t){ return (int)typesCache[t];}
		public Type GetType(int case_){ return typesCache.First(x => (int)x.Value == case_).Key;}

	}

}