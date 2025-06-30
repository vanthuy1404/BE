using Grpc.Core;
using GrpcCalculatorServer;

public class CalculatorService : GrpcCalculatorServer.Calculator.CalculatorBase
{
    public override Task<AddReply> Add(TwoNumberRequest request, ServerCallContext context)
    {
        var result = request.FirstNumber + request.SecondNumber;
        return Task.FromResult(new AddReply { Result = result });
    }
    public override Task<SubtractReply> Subtract(TwoNumberRequest request, ServerCallContext context)
    {
        var result = request.FirstNumber - request.SecondNumber;
        return Task.FromResult(new SubtractReply { Result = result });
    }
}