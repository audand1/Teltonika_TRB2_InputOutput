using System;
using System.Threading;
using TRB2_InputOutput;
namespace TestEnv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TRB2Device device = new TRB2Device();
            int response = device.setupParameters("admin", "admin01", "http://192.168.1.1");
            
            response = device.updateFromDevice();
            Console.WriteLine("Get status: " + response);
            if (response == 0)
            {
                double adc = device.getAnalogValue();
                Console.WriteLine("ADC0 value: " + adc);

                bool dio1 = device.getIOValue(1);
                bool dio1_dir = device.getIODirection(1);
                Console.WriteLine("DIO1 value: " + dio1);
                Console.WriteLine("DIO1 Direction: " + (dio1_dir ? "input" : "output"));

                bool dio2 = device.getIOValue(2);
                bool dio2_dir = device.getIODirection(2);
                Console.WriteLine("DIO2 value: " + dio2);
                Console.WriteLine("DIO2 Direction: " + (dio2_dir ? "input" : "output"));

                bool dio3 = device.getIOValue(3);
                bool dio3_dir = device.getIODirection(3);
                Console.WriteLine("DIO3 value: " + dio3);
                Console.WriteLine("DIO3 Direction: " + (dio3_dir ? "input" : "output"));
            }


            Console.WriteLine("*************************************************");

            device.setIODirection(1, true);
  
            device.setIODirection(2, true);

            device.setIODirection(3, false);
            device.setIOValue(3, false);
            response = device.updateToDevice();
            Console.WriteLine("Set status: " + response);

            Console.WriteLine("*************************************************");

            response = device.updateFromDevice();
            Console.WriteLine("Get status: " + response);
            if (response == 0)
            {
                double adc = device.getAnalogValue();
                Console.WriteLine("ADC0 value: " + adc);

                bool dio1 = device.getIOValue(1);
                bool dio1_dir = device.getIODirection(1);
                Console.WriteLine("DIO1 value: " + dio1);
                Console.WriteLine("DIO1 Direction: " + (dio1_dir ? "input" : "output"));

                bool dio2 = device.getIOValue(2);
                bool dio2_dir = device.getIODirection(2);
                Console.WriteLine("DIO2 value: " + dio2);
                Console.WriteLine("DIO2 Direction: " + (dio2_dir ? "input" : "output"));

                bool dio3 = device.getIOValue(3);
                bool dio3_dir = device.getIODirection(3);
                Console.WriteLine("DIO3 value: " + dio3);
                Console.WriteLine("DIO3 Direction: " + (dio3_dir ? "input" : "output"));
            }


            

            while (true)
            {
                device.updateFromDevice();
                Console.WriteLine("ADC0 value: " + device.getAnalogValue());
                Thread.Sleep(300);
            }


            Console.WriteLine("*************************************************");
        }
    }
}
