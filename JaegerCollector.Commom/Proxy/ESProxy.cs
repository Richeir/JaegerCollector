using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaegerCollector.Common.Proxy
{
	public static class ESProxy
	{
		private static string _esHostAddress = "http://192.168.2.163:9200";

		private static ElasticClient _client;
		public static ElasticClient ESClient
		{
			get
			{
				if (_client == null)
				{
					var settings = new ConnectionSettings(new Uri(_esHostAddress)).DefaultIndex("people");
					_client = new ElasticClient(settings);
				}
				return _client;
			}
		}

	}
}
