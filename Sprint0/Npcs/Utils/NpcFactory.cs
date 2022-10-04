using Microsoft.Xna.Framework;
using Sprint0.Npcs.Interfaces;
using System;

namespace Sprint0.Npcs.Utils
{
	public class NpcFactory
	{
		public INpc GetNpc(string npcType, Vector2 position)
		{
			switch (npcType)
			{
				case "OLDMAN":

					return new OldMan(position);
				case "FLAME":

					return new Flame(position);

				default:
					Console.Error.Write("Type " + npcType + " does not exist.");
					return null;
			}
		}
	}
}