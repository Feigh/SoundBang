using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using SoundBangBack.Entity;

namespace SoundBangBack.Listeners
{
	class SessionListener : IBaseListener
	{
		private GameSessionHandler sessionHandler;
		public SessionListener(GameSessionHandler handler)
		{
			sessionHandler = handler;
		}

		public void ProcessRequest(HttpListenerContext context)
		{
			var responseString = "";
			int statuscode = 200;
			try
			{
				var body = JsonConvert.DeserializeObject<SessionDataEntity>(new StreamReader(context.Request.InputStream).ReadToEnd());
			}
			catch(InvalidOperationException invex)
			{
				responseString = invex.Message;
				statuscode = 500;
			}
			HttpListenerResponse response = context.Response;
			response.AddHeader("Access-Control-Allow-Origin", "*");
			response.AddHeader("Access-Control-Allow-Headers", "*");
			response.AddHeader("Access-Control-Allow-Methods", "*");
			response.StatusCode = statuscode;
			response.ContentType = "text/plain";

			byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
			response.ContentLength64 = buffer.Length;
			System.IO.Stream output = response.OutputStream;
			output.Write(buffer, 0, buffer.Length);
		}

		public void StartListening()
		{
			HttpListener listener = new HttpListener();
			listener.Prefixes.Add("http://localhost:4333/session/");
			try
			{
				listener.Start();
			}
			catch (HttpListenerException hlex)
			{
				Console.WriteLine(hlex.Message);
				return;
			}
			while (listener.IsListening)
			{
				var context = listener.GetContext();
				ProcessRequest(context);
			}
			listener.Close();
		}
	}
}
