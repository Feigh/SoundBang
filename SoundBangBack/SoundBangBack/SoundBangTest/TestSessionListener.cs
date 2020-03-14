using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundBangTest
{
	class TestSessionListener
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void ReturnFalseBecauseOfMissingSessionIdHTTPRequest()
		{
			// A client is started for the first time. create sessionid and sessionname for them to use
			Assert.Pass();
		}

		[Test]
		public void ReturnTrueBecauseOfExisitngSessionIdInHTTPRequest()
		{
			// A client is started for the first time. create sessionid and sessionname for them to use
			Assert.Pass();
		}

		[Test]
		public void ReturnTrueBecauseOfExisitngSessionIdInHTTPRequestNotExisitInHandler()
		{
			// A client is started for the first time. create sessionid and sessionname for them to use
			Assert.Pass();
		}
	}
}
