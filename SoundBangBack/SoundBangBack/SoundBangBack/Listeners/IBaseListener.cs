using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SoundBangBack.Listeners
{
	interface IBaseListener
	{
		public void StartListening();

		public void ProcessRequest(HttpListenerContext listner);
	}
}
