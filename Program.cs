using System;
using System.IO.Ports;


namespace DIGITIGRADE_BIPED
{
	class MainClass
	{

		public static void Main (string[] args)
		{
			int portName = 13;
			Console.WriteLine ("Port: COM" + portName);

			int baudRate = 9600;
			Console.WriteLine ("Baud rate: " + baudRate);

			var serial = new SerialPort("COM13", baudRate);
			while(!serial.IsOpen){
				try{
					Console.WriteLine("Serial open. Input command.");

					string msg = Console.ReadLine();
					Console.Clear();
					while(msg != "E"){
//						Console.Clear();



						Console.WriteLine ("Port: COM" + portName);
						Console.WriteLine ("Baud rate: " + baudRate);
						Console.WriteLine("Serial open. Input command.");

						serial.Open();
						serial.Write(msg);

//						Console.WriteLine(serial.WriteBufferSize);
						Console.WriteLine(serial.ReadLine());

						msg = Console.ReadLine();										

						Console.Clear();
						serial.Close();


					}

					Console.WriteLine("Serial closed.");
					break;

				}catch(SystemException e){

					serial.Dispose();
					serial.DiscardInBuffer();
					serial.DiscardOutBuffer();
					serial.Close();
					Console.WriteLine("Serial closed.");
					Console.WriteLine(e);
					break;
				}
//				//		

			}
		}

	}
}
