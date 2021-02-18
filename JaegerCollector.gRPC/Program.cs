using Grpc.Core;
using Jaeger.ApiV2;
using JaegerCollector.gRPC.GrpcImpl;
using System;

namespace JaegerCollector.gRPC
{
	class Program
	{
		const string _serverHost = "localhost";
		const int _grpcPort = 5000;

		static void Main(string[] args)
		{
			Server grpcServer = new Server
			{
				Services =
				{
					CollectorService.BindService(new CollectorImpl())
				},
				Ports =
				{
					new ServerPort(_serverHost, _grpcPort, ServerCredentials.Insecure)
				}
			};

			grpcServer.Start();

			Console.WriteLine($"Jaeger collector gRPC server start at {_serverHost}:{_grpcPort}");
			Console.ReadKey();

			grpcServer.ShutdownAsync().Wait();
		}
	}
}
