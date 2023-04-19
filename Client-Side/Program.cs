using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        //Definir o endereço IP e a porta do servidor
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8080;

        //Criar um objeto TCPClient para se conectar ao servidor
        TcpClient client = new TcpClient();
        client.Connect(ipAddress, port);
        Console.WriteLine("Conectado ao servidor.");

        //Obter a stream de rede para enviar/receber dados
        NetworkStream networkStream = client.GetStream();

        //Enviar dados ao servidor
        string dataToSend = "Olá, Servidor!!";
        byte[] buffer = Encoding.ASCII.GetBytes(dataToSend);
        networkStream.Write(buffer, 0, buffer.Length);
        Console.WriteLine($"Dados enviados ao servidor: {dataToSend}");

        //Ler a resposta do servidor
        byte[] responseBuffer = new byte[1024];
        int bytesRead = networkStream.Read(responseBuffer, 0, responseBuffer.Length);
        string responseData = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);
        Console.WriteLine($"Resposta recebida do servidor: {responseData}");

        //Fechar a conexão
        client.Close();

        Console.ReadLine();
    }
}
