﻿using System;
using System.Linq.Expressions;

namespace SharpRomans.Tests.Spec.Roman_Numeral.Support
{
	internal class Op : Spec.Support.Op<RomanNumeral>
	{
		protected Op(Expression<Func<RomanNumeral, RomanNumeral, bool>> exp) :
			base(exp) { }

		public static Op Gt { get { return new Op((x, y) => x > y); } }

		public static Op GtE { get { return new Op((x, y) => x >= y); } }

		public static Op Lt { get { return new Op((x, y) => x < y); } }

		public static Op LtE { get { return new Op((x, y) => x <= y); } }
	}
}