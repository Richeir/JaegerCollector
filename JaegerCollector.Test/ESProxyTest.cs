using JaegerCollector.Common.Proxy;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JaegerCollector.Test
{
	public class ESProxyTest
	{
		[Fact]
		public async Task IndexESTest()
		{
			var person = new Person
			{
				Id = 1,
				FirstName = "Martijn",
				LastName = "Laarman"
			};

			var indexResponse = ESProxy.ESClient.IndexDocument(person);
			var asyncIndexResponse = await ESProxy.ESClient.IndexDocumentAsync(person);
		}

		[Fact]
		public async Task RetriveESTest()
		{
			var searchResponse = await ESProxy.ESClient.SearchAsync<Person>(s => s
			.From(0)
			.Size(10)
			.Query(q => q.
				Match(m => m
					.Field(f => f.FirstName)
					.Query("Martijn")
					)
				)
			);
			var people = searchResponse.Documents;
		}
	}

	public class Person
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
