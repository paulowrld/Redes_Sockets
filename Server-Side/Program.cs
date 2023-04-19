using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        //Definir o endereço IP e a porta para o servidor
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        int port = 8080;

        //Criar um objeto TCPListener para ouvir por conexões na porta especificada
        TcpListener listener = new TcpListener(ipAddress, port);
        listener.Start();
        Console.WriteLine("Servidor iniciado. Aguardando por conexões...");

        //Aceitar conexões de clientes
        TcpClient client = listener.AcceptTcpClient();
        Console.WriteLine("Cliente conectado.");

        //Obter a stream de rede para enviar/receber dados
        NetworkStream networkStream = client.GetStream();

        //Ler dados recebidos do cliente
        byte[] buffer = new byte[1024];
        int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
        string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
        Console.WriteLine($"Dados recebidos do cliente: {receivedData}");

        //Enviar uma resposta ao cliente
        string responseData = "Olá, cliente!";
        byte[] responseBuffer = Encoding.ASCII.GetBytes(responseData);
        networkStream.Write(responseBuffer, 0, responseBuffer.Length);
        Console.WriteLine("Resposta enviada ao cliente.");

        //Fechar a conexão
        client.Close();
        listener.Stop();

        Console.ReadLine();
    }
}
