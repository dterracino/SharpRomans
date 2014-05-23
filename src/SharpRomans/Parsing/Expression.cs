namespace SharpRomans.Parsing
{
	internal abstract class Expression
	{
		public void Interpret(Context context)
		{
			if (context.IsEmpty) return;

			if (context.StartsWith(Nine))
			{
				context.Plus(9, this).Trim(2);
			}

			else if (context.StartsWith(Four))
			{
				context.Plus(4, this).Trim(2);
			}

			else if (context.StartsWith(Five))
			{
				context.Plus(5, this).Trim(1);
			}

			int repetition = 0;
			while (context.StartsWith(One) && (repetition++ < 3))
			{
				context.Plus(1, this).Trim(1);
			}
		}

		public abstract string One { get; }

		public abstract string Four { get; }

		public abstract string Five { get; }

		public abstract string Nine { get; }

		public abstract ushort Multiplier { get; }
	}
}