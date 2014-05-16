using System;
using MonoDevelop.Components.Commands;
using System.Net;
using System.Threading;

namespace CredentialProviderTest
{
	public class CredentialProviderHandler : CommandHandler
	{
		public CredentialProviderHandler ()
		{
		}

		protected override void Run (object dataItem)
		{

			for (int i = 0; i < 5; ++i) {
				var thread = new Thread (() => {
					PromptForCredentials ();
				});

				thread.Start ();
			}
		}

		void PromptForCredentials ()
		{
			var cp = MonoDevelop.Core.WebRequestHelper.CredentialProvider;

			var uri = new Uri ("http://nuget.org");
			var proxy = new WebProxy ();

			cp.GetCredentials (uri, proxy, MonoDevelop.Core.Web.CredentialType.ProxyCredentials, false);
		}
	}
}

