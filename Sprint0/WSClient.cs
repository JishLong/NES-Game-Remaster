using System;
using System.Reactive.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Websocket.Client;

namespace Sprint0.WebSockets
{
    // a websocket client to handle multiplayer connections with my custom server/controller
    public class WSClient
    {
        private const String connection_uri = "ws://142.93.200.13:443";
        private WebsocketClient client;
        private String roomCode = null;
        private Game1 game1;

        public WSClient(Game1 game1)
        {
            client = new WebsocketClient(new Uri(connection_uri));
            this.game1 = game1;
        }

        public void Connect()
        {
            client.Start();

            // send message to create room on server
            client.Send("{\"type\":\"create\"}");

            // register listener
            client.MessageReceived
                .Where(msg => msg.Text != null)
                .Subscribe(obj =>
                {
                    var message = JsonConvert.DeserializeObject<dynamic>(obj.Text);
                    String type = message.type;

                    // when the server notifies us of the join code, show it to the user
                    if (type == "created")
                    {
                        roomCode = message["params"]["room"];
                    }
                    // when new players join the game
                    else if (type == "joined")
                    {
                        string id = (string)message["params"]["id"];
                        game1.PlayerManager.RegisterInputId(id);
                    }

                    // when a client sends data to the host (this game)
                    else if (type == "dispatch")
                    {
                        var input = message["params"]["message"];
                        game1.CurrentState.HandleClientInput(input, (string)message["params"]["id"]);
                    }
                });
        }

        public void DrawGameCode(SpriteBatch sb)
        {
            if (roomCode != null)
            {
                sb.DrawString(Resources.SmallFont, $"Room Code: {roomCode}", new Vector2(5, 5), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
            else
            {
                sb.DrawString(Resources.SmallFont, "No connection to server", new Vector2(5, 5), Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            }
        }
    }
}

