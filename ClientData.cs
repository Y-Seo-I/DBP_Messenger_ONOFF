using System;
using System.Net.Sockets;

namespace on_off_proj
{
    class ClientData
    {
        // 연결이 확인된 클라이언트를 넣어줄 클래스입니다. 
        // readByteData는 stream데이터를 읽어올 객체입니다.
        public TcpClient client { get; set; } 
        public byte[] readByteData { get; set; } 
        public int clientNumber;

        //로그인 된 유저의 아이디
        static public string ID { get; set; }

        public ClientData(TcpClient client)
        {
            this.client = client; 
            this.readByteData = new byte[1024]; 
            // 아래부분이 1:1비동기서버에서 추가된 부분입니다. 
            // 127.0.0.1:9999에서 포트번호 직전 마지막번호를 클라이언트 번호로 지정해줍니다.
            string clientEndPoint = client.Client.LocalEndPoint.ToString(); 
            char[] point = { '.', ':' }; 
            string[] splitedData = clientEndPoint.Split(point); 
            this.clientNumber = int.Parse(splitedData[3]); 
            Console.WriteLine("{0}번 사용자 접속성공",clientNumber);
        }

    }
}
