using SoundBangBack.Listeners;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SoundBangBack
{
	public class GameHandler
	{
		public GameHandler()
		{
			
		}

		public void GameLoop()
		{
			/*
			 * börja lyssna på local session
			 * när ett meddelande kommer in så kolla vad det är för metod och vad för authentication den har i headern
			 * om det är en get
			 * kolla i authentication om den har nån session id
			 * kolla i meddeelandet
			 * om det är sessionaction:start
			 * så skicka till handlern
			 * som har en sessionlist där den skapar en ny instans och lägger i listan
			 * listan skapar en session id och ett session namn den skickar tillbaka
			 * handler skickar ett responce med session id och session name
			 * 
			 */
			GameSessionHandler handler = new GameSessionHandler();

			SessionListener sessionListener = new SessionListener(handler);
			sessionListener.StartListening();
		}

		public void InitializeNewGameSession()
		{

		}

		private void ProcessRequest(HttpListenerContext context)
		{

		}

		public void ListenToServerInput()
		{

		}
	}
}
