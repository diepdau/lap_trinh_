
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	public partial class Client : Form
	{

		IPEndPoint IP ;
		Socket client;
		public Client()
		{
			InitializeComponent();

			CheckForIllegalCrossThreadCalls = false;

			Connect();
		}

		/// <summary>
		/// Kết nối đến server
		/// </summary>
		void Connect()
		{
			IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2010);
			client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				client.Connect(IP);
			}
			catch
			{
				MessageBox.Show("Không thể kết nối đến server", "Lỗi");
				return;
			}

			Thread listen = new Thread(Receive);
			listen.IsBackground = true;
			listen.Start();
		}

		/// <summary>
		/// Đóng kết nối socket
		/// </summary>

		void CloseConnection()
		{
			client.Close();
		}

		/// <summary>
		/// Gửi tin nhắn đến server
		/// </summary>
		void Send()
		{

			if (txtInput.Text != string.Empty)
				client.Send(Serialize(txtInput.Text));
		}

		/// <summary>
		/// Lắng nghe phản hồi từ phía server
		/// </summary>
		void Receive()
		{
			try
			{
				while (true)
				{

					try 
					{
						while(true)
						{
							byte[] data = new byte[1024 * 5000];
							client.Receive(data);
							string message = (string)Deserialize(data);
							AddMessage(message);
						}
					} catch
					{
						Close();

					}
				}
			}
			catch
			{
				MessageBox.Show("Có lỗi xảy ra trong quá trình nhận phản hồi từ server. Đóng kết nối");
				CloseConnection();
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

		private void btnSendDocx_Click(object sender, EventArgs e)
		{


		}

		private void btnSend_Click(object sender, EventArgs e)
		{

			Send();
			AddMessage(txtInput.Text);
			txtInput.Text = "";

		}

		private void txtInput_TextChanged(object sender, EventArgs e)
		{

		}

		private void lsvMain_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void Client_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseConnection();
		}

		private void Client_Load(object sender, EventArgs e)
		{

		}
	}
}
