


using System;
using System.Collections;
namespace WellTyped.CodeGen.RecordTests
{
	public sealed partial class SomeRecord : IEquatable<SomeRecord>
	{
		public SomeRecord(int a, string b)
		{
			A = a;
			B = b;
		}
	
	
		public int A {get; private set;}
		public string B {get; private set;}
	
		public static SomeRecord New(int a, string b)
		{
			return new SomeRecord(a, b);
		}
	
	
		public sealed override bool Equals(object obj)
		{
			var o = obj as SomeRecord;
			return ((object)o != null) && this.Equals(o);
	
		}
	
	
		public bool Equals(SomeRecord obj)
		{
			return ((object)obj != null)
			       && StructuralComparisons.StructuralEqualityComparer.Equals(A, obj.A)
			       && StructuralComparisons.StructuralEqualityComparer.Equals(B, obj.B);
		}
	
	
		public sealed override int GetHashCode()
		{
			int num = 0;
			num = -1640531527 + (((A == null) ? 0 : A.GetHashCode()) + ((num << 6) + (num >> 2)));
			num = -1640531527 + (((B == null) ? 0 : B.GetHashCode()) + ((num << 6) + (num >> 2)));
			return num;
		}
	
	
		public static bool operator ==(SomeRecord o1, SomeRecord o2)
		{
			return (object)o1 == null ? (object)o2 == null :  o1.Equals(o2);
	
		}
	
	
		public static bool operator !=(SomeRecord o1, SomeRecord o2)
		{
			return !(o1 == o2);
	
		}
	
	
		public SomeRecord With(WellTyped.Prelude.OptionalParam<int> a = default(WellTyped.Prelude.OptionalParam<int>), WellTyped.Prelude.OptionalParam<string> b = default(WellTyped.Prelude.OptionalParam<string>))
		{
			return new SomeRecord(a.HasValue ? a.Value : this.A , b.HasValue ? b.Value : this.B );
		}
	
	}
		

	public sealed partial class SomeMultiLineRecord : IEquatable<SomeMultiLineRecord>
	{
		public SomeMultiLineRecord(int a, string b)
		{
			A = a;
			B = b;
		}
	
	
		public int A {get; private set;}
		public string B {get; private set;}
	
		public static SomeMultiLineRecord New(int a, string b)
		{
			return new SomeMultiLineRecord(a, b);
		}
	
	
		public sealed override bool Equals(object obj)
		{
			var o = obj as SomeMultiLineRecord;
			return ((object)o != null) && this.Equals(o);
	
		}
	
	
		public bool Equals(SomeMultiLineRecord obj)
		{
			return ((object)obj != null)
			       && StructuralComparisons.StructuralEqualityComparer.Equals(A, obj.A)
			       && StructuralComparisons.StructuralEqualityComparer.Equals(B, obj.B);
		}
	
	
		public sealed override int GetHashCode()
		{
			int num = 0;
			num = -1640531527 + (((A == null) ? 0 : A.GetHashCode()) + ((num << 6) + (num >> 2)));
			num = -1640531527 + (((B == null) ? 0 : B.GetHashCode()) + ((num << 6) + (num >> 2)));
			return num;
		}
	
	
		public static bool operator ==(SomeMultiLineRecord o1, SomeMultiLineRecord o2)
		{
			return (object)o1 == null ? (object)o2 == null :  o1.Equals(o2);
	
		}
	
	
		public static bool operator !=(SomeMultiLineRecord o1, SomeMultiLineRecord o2)
		{
			return !(o1 == o2);
	
		}
	
	
		public SomeMultiLineRecord With(WellTyped.Prelude.OptionalParam<int> a = default(WellTyped.Prelude.OptionalParam<int>), WellTyped.Prelude.OptionalParam<string> b = default(WellTyped.Prelude.OptionalParam<string>))
		{
			return new SomeMultiLineRecord(a.HasValue ? a.Value : this.A , b.HasValue ? b.Value : this.B );
		}
	
	}
		

    public sealed partial class SomeGenericRecord<T> : IEquatable<SomeGenericRecord<T>>
	{
		public SomeGenericRecord(T a, T[] b)
		{
			A = a;
			B = b;
		}
	
	
		public T A {get; private set;}
		public T[] B {get; private set;}
	
		public static SomeGenericRecord<T> New(T a, T[] b)
		{
			return new SomeGenericRecord<T>(a, b);
		}
	
	
		public sealed override bool Equals(object obj)
		{
			var o = obj as SomeGenericRecord<T>;
			return ((object)o != null) && this.Equals(o);
	
		}
	
	
		public bool Equals(SomeGenericRecord<T> obj)
		{
			return ((object)obj != null)
			       && StructuralComparisons.StructuralEqualityComparer.Equals(A, obj.A)
			       && StructuralComparisons.StructuralEqualityComparer.Equals(B, obj.B);
		}
	
	
		public sealed override int GetHashCode()
		{
			int num = 0;
			num = -1640531527 + (((A == null) ? 0 : A.GetHashCode()) + ((num << 6) + (num >> 2)));
			num = -1640531527 + (((B == null) ? 0 : B.GetHashCode()) + ((num << 6) + (num >> 2)));
			return num;
		}
	
	
		public static bool operator ==(SomeGenericRecord<T> o1, SomeGenericRecord<T> o2)
		{
			return (object)o1 == null ? (object)o2 == null :  o1.Equals(o2);
	
		}
	
	
		public static bool operator !=(SomeGenericRecord<T> o1, SomeGenericRecord<T> o2)
		{
			return !(o1 == o2);
	
		}
	
	
		public SomeGenericRecord<T> With(WellTyped.Prelude.OptionalParam<T> a = default(WellTyped.Prelude.OptionalParam<T>), WellTyped.Prelude.OptionalParam<T[]> b = default(WellTyped.Prelude.OptionalParam<T[]>))
		{
			return new SomeGenericRecord<T>(a.HasValue ? a.Value : this.A , b.HasValue ? b.Value : this.B );
		}
	
	}
		

}


    