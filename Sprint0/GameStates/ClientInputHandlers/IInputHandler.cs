using System;
namespace Sprint0.GameStates.ClientInputHandlers
{
	public interface IInputHandler
	{
		void HandleInput(dynamic input);
		void Update();
	}
}

