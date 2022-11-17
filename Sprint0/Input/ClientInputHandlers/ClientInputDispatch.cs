using System;
namespace Sprint0.Input.ClientInputHandlers
{
	public class ClientInputDispatch<T>
	{
		public String inputId;
		public T input;

		public ClientInputDispatch(string id, T input)
		{
			this.inputId = id;
			this.input = input;
		}

        public override string ToString()
        {
			return $"{inputId}: {input}";
        }

        public override bool Equals(object obj)
        {
            var item = obj as ClientInputDispatch<T>;
			if (item == null)
			{
				return false;
			}
			else
			{
				return item.inputId == this.inputId && item.input.Equals(this.input);
			}
        }

        public override int GetHashCode()
        {
			return this.input.GetHashCode() + inputId.GetHashCode();
        }
    }
}

