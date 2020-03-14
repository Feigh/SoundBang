using SoundBangBack.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoundBangBack
{
	public class GameSessionHandler
	{
		private List<SessionEntity> sessionList;

		public List<SessionEntity> SessionList{ get { return sessionList; } }
		public GameSessionHandler()
		{
			sessionList = new List<SessionEntity>();
			//Test
			SessionEntity newSession = new SessionEntity();
			newSession.PlayerList = new List<PlayerEntity>();
			newSession.SessionId = Guid.NewGuid();
			newSession.SessionName = "AAAA";
			sessionList.Add(newSession);
		}

		private string GenerateSessionName()
		{
			Random _random = new Random();
			string sessionName = "";
			for(int i=0; i < 4; i++)
			{
				int num = _random.Next(0, 26);
				char let = (char)('a' + num);
				sessionName += char.ToUpper(let);
			}

			return sessionName;
		}

		public string HandleGet(SessionDataEntity body)
		{
			throw new NotImplementedException();
		}

		public SessionEntity CreateNewSession()
		{
			SessionEntity newSession = new SessionEntity();
			newSession.PlayerList = new List<PlayerEntity>();
			newSession.SessionId = Guid.NewGuid();
			newSession.SessionName = GenerateSessionName();
			sessionList.Add(newSession);

			return newSession;
		}

		public SessionDataEntity UpdatePlayerInSession(SessionDataEntity body)
		{
			if (sessionList.Find(x => x.SessionName == body.SessionName) == null)
				throw new InvalidOperationException("Could not find Session");

			var session = sessionList.Find(x => x.SessionName == body.SessionName);
			if (session.PlayerList.Find(x => x.PlayerId == body.Player.PlayerId) == null)
				throw new InvalidOperationException("Could not find Session");

			var player = session.PlayerList.Find(x => x.PlayerId == body.Player.PlayerId);
			player.PlayerName = body.Player.PlayerName;

			body.Player = player;
			return body;
		}

		public SessionDataEntity ConnectNewPlayerToSession(SessionDataEntity body)
		{
			if (sessionList.Find(x => x.SessionName == body.SessionName) == null)
				throw new InvalidOperationException("Could not find Session");

			var session = sessionList.Find(x => x.SessionName == body.SessionName);
			PlayerEntity player = new PlayerEntity() { PlayerId = Guid.NewGuid() };
			session.PlayerList.Add(player);

			body.SessionId = session.SessionId;
			body.Player = player;
			return body;
		}
	}
}
