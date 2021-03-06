using System.Collections.Generic;
using System.Numerics;
using Data.Model;
using GameServer.Game;
using GameServer.ServerPackets.Chat;

namespace GameServer.Managers
{
    /// <summary>
    /// Handles admin commands
    /// </summary>
    public static class AdminManager
    {
        /// <summary>
        /// Called when an admin sends a game commands
        /// </summary>
        /// <param name="user"></param>
        /// <param name="game"></param>
        public static void OnGameAdminCommand(GameSession client, List<string> commands)
        {
            switch (commands[0])
                {
                    case "#spawn":
                        client.GameInstance.SpawnNpc(client.CurrentUnit.WorldPosition);
                        break;
                    
                    case "#kill":
                        // TODO: Kill player maybe
                        break;
                    
                    case "#killme":
                        client.GameInstance.KillUnit(client.CurrentUnit);
                        break;
                    
                    case "#where":
                        var unitPos = client.CurrentUnit.WorldPosition;
                        
                        client.SendPacket(new Message(client.User.Callsign, 
                            $"geoX: {client.GameInstance.Map.GetGeoX((int)unitPos.X)}, geoY: {client.GameInstance.Map.GetGeoY((int)unitPos.Y)}"));
                        break;
                }
        }
    }
}