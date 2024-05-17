using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace udpSocketTest
{
    public partial class Form1 : Form
    {
        private bool m_DEBUG_CHECK = true;
        private string m_ip;
        private int m_port;
        private Thread m_listenThread;
        private Thread m_receiveThread;
        private Socket m_clientSocket;

        private void setIPort()
        {
            if (m_DEBUG_CHECK)
            {
                m_ip = "127.0.0.1";
                m_port = 25101;
            }
            //m_ip, m_port 입력받는 창 구현
            else
            {

            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_START_Click(object sender, EventArgs e)
        {
            //if string 비교 금지 equal
            var strBTNName = BTN_START.Text;
            if (strBTNName == "시작")
            {
                BTN_START.Text = "멈춤";
                Log("서버 시작됨");


                m_listenThread = new Thread(new ThreadStart(Listen));
                m_listenThread.IsBackground = true;

                m_listenThread.Start();
            }
            else
            {
                BTN_START.Text = "시작";
                Log("서버 멈춤");
            }
        }

        private void Listen()
        {
            IPAddress ipaddress = IPAddress.Parse(m_ip);

            IPEndPoint endPoint = new IPEndPoint(ipaddress, m_port);

            Socket listenSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
                );

            listenSocket.Bind(endPoint);

            listenSocket.Listen(10);

            Log("클라이언트 요청 대기중...");

            // 연결 요청에 대한 수락
            m_clientSocket = listenSocket.Accept();

            Log("클라이언트 접속됨 - " + m_clientSocket.LocalEndPoint.ToString());

            // Receive 스레드 호출
            m_receiveThread = new Thread(new ThreadStart(Receive));
            m_receiveThread.IsBackground = true;
            m_receiveThread.Start();      // Receive() 호출
        }
        private void Receive()
        {
            while (true)
            {
                // 연결된 클라이언트가 보낸 데이터 수신
                byte[] receiveBuffer = new byte[512];
                int length = m_clientSocket.Receive(receiveBuffer,
                    receiveBuffer.Length, SocketFlags.None);

                // 엔터 처리
                //richTextBox1.AppendText(msg);

                // 디코딩
                string msg = Encoding.UTF8.GetString(receiveBuffer);

                //write log, listen
                Showmsg("상대]" + msg);
                Log("메시지 수신함");
            }
        }

        private void Showmsg(string msg)
        {
            if (RTB_HISTORY.InvokeRequired == true)
            {
                RTB_HISTORY.Invoke((MethodInvoker)delegate
                {
                    RTB_HISTORY.AppendText(msg);
                    RTB_HISTORY.AppendText("\r\n");

                    this.Activate();
                    RTB_HISTORY.Focus();

                    RTB_HISTORY.SelectionStart = RTB_HISTORY.Text.Length;
                    RTB_HISTORY.ScrollToCaret();
                });
            }
            else
            {
                RTB_HISTORY.AppendText(msg);
                RTB_HISTORY.AppendText("\r\n");
                this.Activate();
                RTB_HISTORY.Focus();

                RTB_HISTORY.SelectionStart = RTB_HISTORY.Text.Length;
                RTB_HISTORY.ScrollToCaret();
            }
        }

        private void TXT_CHAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (TXT_CHAT.Text.Trim() != "" && e.KeyCode == Keys.Enter)
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(TXT_CHAT.Text.Trim());
                m_clientSocket.Send(sendBuffer);
                Log("메시지 전송됨");
                Showmsg("나]" + TXT_CHAT.Text);
                TXT_CHAT.Text = "";

            }
        }
        private void Log(string msg)
        {

            if (this.LST_LOG.InvokeRequired == true)
            {
                this.LST_LOG.Invoke((MethodInvoker)delegate
                {
                    this.LST_LOG.Items.Add(string.Format("[{0}]{1}", DateTime.Now.ToString(), msg));
                });
            }
            else
            {
                this.LST_LOG.Items.Add(string.Format("[{0}]{1}", DateTime.Now.ToString(), msg));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setIPort();
        }

    }
}
