using System;
using System.Collections.Generic;
using System.Text;

namespace SoundBangBack.Entity
{
	public class SessionEntity
	{
		public string SessionName { get; set; }
		public Guid SessionId { get; set; }
		public List<PlayerEntity> PlayerList { get; set; }
	}
}
