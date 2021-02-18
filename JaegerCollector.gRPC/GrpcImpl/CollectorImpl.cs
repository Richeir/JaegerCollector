using Grpc.Core;
using Jaeger.ApiV2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Jaeger.ApiV2.CollectorService;

namespace JaegerCollector.gRPC.GrpcImpl
{
	public class CollectorImpl : CollectorServiceBase
	{
		public override Task<PostSpansResponse> PostSpans(PostSpansRequest request, ServerCallContext context)
		{
			var json1 = JsonConvert.SerializeObject(request);
			var json2 = JsonConvert.SerializeObject(context);

			var a = 1;
			return base.PostSpans(request, context);
		}
	}
}
