using System;
namespace Sprint0.Input.ClientInputHandlers
{
	public interface IInputHandler
	{
		void HandleInput(dynamic input, string id);
		void Update();
	}
}

