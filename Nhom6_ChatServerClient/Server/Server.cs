
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
	public partial class Server : Form
	{
		IPEndPoint IP;
		Socket server;
		List<Socket> clientList;
		public Server()
		{
			InitializeComponent();

			CheckForIllegalCrossThreadCalls = false;

			Start();
		}


		/// <summary>
		/// Kết nối đến server
		/// </summary>
		void Start()
		{
			IP = new IPEndPoint(IPAddress.Any, 2010);
			server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			clientList = new List<Socket>();

			server.Bind(IP);

			Thread listen = new Thread(() =>
			{
				try
				{
					while (true)
					{
						server.Listen(100);
						Socket client = server.Accept();

						clientList.Add(client);

						Thread receive = new Thread(Receive);
						receive.IsBackground = true;
						receive.Start(client);

						AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã kết nối");
					}
				}
				catch
				{
					IP = new IPEndPoint(IPAddress.Any, 2010);
					server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				}
			});

			listen.IsBackground = true;
			listen.Start();
		}

		/// <summary>
		/// Đóng kết nối socket
		/// </summary>

		void CloseConnection()
		{
			server.Close();
		}

		/// <summary>
		/// Gửi tin nhắn cho client
		/// </summary>
		void Send(Socket client)
		{
			if (client != null && txtInput.Text != string.Empty)
				client.Send(Serialize(txtInput.Text));
		}

		/// <summary>
		/// Lắng nghe phản hồi từ phía server
		/// </summary>
		void Receive(object obj)
		{
			Socket client = obj as Socket;

			try
			{
				while (true)
				{
					byte[] buffer = new byte[1024 * 5000];
					client.Receive(buffer);

					string mesage = (string)Deserialize(buffer);
					foreach (Socket item in clientList)
					{
						if(item != null && item !=client)
							item.Send(Serialize(mesage));
					}
					AddMessage(mesage);

					
				}
			}
			catch
			{
				//AddMessage(client.RemoteEndPoint.ToString() + ": " + "Đã đóng kết nối");
				clientList.Remove(client);
				client.Close();
			}
		}


		/// <summary>
		/// Thêm tin nhắn vào màn hình
		/// </summary>
		/// <param name="message"></param>
		void AddMessage(string message)
		{
			lsvMain.Items.Add(new ListViewItem() { Text = message });
			txtInput.Clear();
		}

		/// <summary>
		/// Phân mảnh dữ liệu, tạo thành mảng byte để gửi đi
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		byte[] Serialize(object data)
		{
			MemoryStream stream = new MemoryStream();
			BinaryFormatter formatter = new BinaryFormatter();

			formatter.Serialize(stream, data);

			return stream.ToArray();
		}

		/// <summary>
		/// Gom mảnh dữ liệu, tạo thành đối tượng ban đầu
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		object Deserialize(byte[] data)
		{
			MemoryStream stream = new MemoryStream(data);
			BinaryFormatter formatter = new BinaryFormatter();

			return formatter.Deserialize(stream);
		}

		private void btnSendImage_Click(object sender, EventArgs e)
		{

		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			foreach (Socket socket in clientList)
			{
				Send(socket);
			}

			AddMessage(txtInput.Text);
			txtInput.Clear();
		}

		private void txtInput_TextChanged(object sender, EventArgs e)
		{

		}

		private void lsvMain_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void Server_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseConnection();
		}

		private void Server_Load(object sender, EventArgs e)
		{

		}
	}
}
