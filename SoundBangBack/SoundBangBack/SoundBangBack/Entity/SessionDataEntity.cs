using System;
using System.Collections.Generic;
using System.Text;

namespace SoundBangBack.Entity
{
	public class SessionDataEntity
	{
		public string SessionName { get; set; }
		public Guid SessionId { get; set; }
		public PlayerEntity Player { get; set; }
	}
}
