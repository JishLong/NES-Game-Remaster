using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Player
{
	public class PlayerManager : IEnumerable
	{
		private readonly List<IPlayer> players;
		// defaultPlayer is a reference to one of the players in the list
		private IPlayer defaultPlayer { get; set; }

        private readonly Game1 game;

		public PlayerManager(Game1 game)
		{
			players = new List<IPlayer>() { new Player(game) };
			defaultPlayer = players[0];
		}

		// when a new controller connects, we can either assign it to an
		// existing player, or create a new player
		public void RegisterInputId(string id)
		{
			if (defaultPlayer.inputId == null)
			{
				defaultPlayer.inputId = id;
			}
			else
			{
				var newPlayer = new Player(game);
				newPlayer.inputId = id;
				players.Add(newPlayer);
			}

		}

		public void UnregisterInputId(string id)
		{
			var playerToRemove = players.Find(e => e.inputId == id);
			players.Remove(playerToRemove);

			if(defaultPlayer == playerToRemove)
			{
				defaultPlayer = players[0];
			}
		}

		public void SetDefaultPlayer(string id)
		{
			var p = players.Find(p => p.inputId == id);
			if (p == null)
			{
				throw new Exception($"No player with id: {id}");
			}
			else
			{
				defaultPlayer = p;
			}
		}

		public IPlayer GetDefaultPlayer()
		{
			return defaultPlayer;
		}

		// we use the enumerator to avoid exposing a mutable player list
        public IEnumerator<IPlayer> GetEnumerator()
        {
            return players.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
			return ((IEnumerable)players).GetEnumerator();
        }

		public void Draw(SpriteBatch sb)
		{
			foreach (var player in this)
			{
				player.Draw(sb);
			}
		}

		public void Update()
		{
			foreach (var player in this)
			{
				player.Update();
			}
		}
    }
}

