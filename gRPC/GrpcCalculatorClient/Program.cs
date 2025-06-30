using Grpc.Net.Client;
using GrpcCalculatorServer;

var channel = GrpcChannel.ForAddress("http://localhost:5088");
var client = new Calculator.CalculatorClient(channel);

// Nhập 2 số
Console.Write("Nhập số A: ");
int a = int.Parse(Console.ReadLine());

Console.Write("Nhập số B: ");
int b = int.Parse(Console.ReadLine());

// Gọi hàm Add
var addResult = await client.AddAsync(new TwoNumberRequest { FirstNumber = a, SecondNumber = b });
Console.WriteLine($"Tổng: {addResult.Result}");

// Gọi hàm Subtract
var subResult = await client.SubtractAsync(new TwoNumberRequest { FirstNumber = a, SecondNumber = b });
Console.WriteLine($"Hiệu: {subResult.Result}");
