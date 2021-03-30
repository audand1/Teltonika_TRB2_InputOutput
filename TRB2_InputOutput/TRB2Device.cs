using System;

namespace TRB2_InputOutput
{
    public class TRB2Device
    {

        private bool SetupParameters = false;
        private CommunicationManager cm = new CommunicationManager();

        /// <summary>
        /// Prepare component and setup TRB2 device login parameters.
        /// </summary>
        /// <param name="Username">TRB2 device username</param>
        /// <param name="Password">TRB2 device password</param>
        /// <param name="URL"> TRB2 device IP address or hostname. Don't forget use "http://" in front of URL </param>
        /// <returns>
        /// <para>0 - OK</para>
        /// <para>1 - Username validation fail</para>
        /// <para>2 - Password validation fail</para>
        /// <para>3 - URL validation fail</para>
        /// </returns>
        public int setupParameters(string Username, string Password, string URL = "http://192.168.1.1")
        {
            SetupParameters = false;
            int response = cm.SetupParameters(Username, Password, URL);
            if (response == 0)
            {
                SetupParameters = true;
                return 0;
            }
            else
            {
                return response;
            }
        }
        /// <summary>
        /// Sync (Get) I/O data from TRB2 device.
        /// </summary>
        /// <returns>
        /// <para>0 - OK</para>
        /// <para>1 - Failed login into device</para>
        /// <para>2 - Failed get ADC value from the device</para>
        /// <para>3 - Failed get Digital I/O 1 parameters from the device</para>
        /// <para>4 - Failed get Digital I/O 2 parameters from the device</para>
        /// <para>5 - Failed get Digital I/O 3 parameters from the device</para>
        /// </returns>
        public int updateFromDevice()
        {
            if (SetupParameters)
                return cm.updateFromDevice();
            else
                throw new InvalidOperationException("Setup Parameters before updating values");
        }
        /// <summary>
        /// Sync (Set) I/O data to TRB2 device.
        /// </summary>
        /// <returns>
        /// <para>0 - OK</para>
        /// <para>1 - Failed login into device</para>
        /// <para>2 - (Empty)</para>
        /// <para>3 - Failed set Digital I/O 1 parameters to the device</para>
        /// <para>4 - Failed set Digital I/O 2 parameters to the device</para>
        /// <para>5 - Failed set Digital I/O 3 parameters to the device</para>
        /// </returns>
        public int updateToDevice()
        {
            if (SetupParameters)
                return cm.updateToDevice();
            else
                throw new InvalidOperationException("Setup Parameters before updating values");
        }

        /// <summary>
        /// Get ADC value in Volts [V] (data of the last synchronization).
        /// </summary>
        /// <returns>ADC value in Volts [V]</returns>
        public double getAnalogValue()
        {
            return TRB2DIOState.I.ADCValue;
        }
        /// <summary>
        /// Get Digital I/O value (data of the last synchronization).
        /// </summary>
        /// <param name="no">Digital I/O index. Availabe values: 1/2/3</param>
        /// <returns><para>Digital I/O value</para> 
        /// <para>True - logical 1</para>
        /// <para>False - logical 0</para></returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when Digital I/O index  isn't 1,2 or 3</exception>
        public bool getIOValue(int no)
        {
            if (no <= 3 || no >= 1)
                return TRB2DIOState.I.DIOState[no-1];
            else
                throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// Set Digital I/O value.
        /// </summary>
        /// <remarks>Don't forget to sync with your device after all setting.</remarks>
        /// <param name="no">Digital I/O index. Availabe values: 1/2/3</param>
        /// <param name="value">Digital I/O value
        /// <para>true - logical 1</para>
        /// <para>false - logical 0</para></param>
        /// <exception cref="IndexOutOfRangeException">Thrown when Digital I/O index  isn't 1,2 or 3</exception>
        public void setIOValue(int no, bool value)
        {
            if (no <= 3 || no >= 1)
                TRB2DIOState.I.DIOState[no-1] = value;
            else
                throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// Get Digital I/O direction (data of the last synchronization).
        /// </summary>
        /// <param name="no">Digital I/O index. Availabe values: 1/2/3</param>
        /// <returns>Digital I/O direction
        /// <para>True - Input</para>
        /// <para>False - Output</para></returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when Digital I/O index  isn't 1,2 or 3</exception>
        public bool getIODirection(int no)
        {
            if (no <= 3 || no >= 1)
                return TRB2DIOState.I.DIODirection[no-1];
            else
                throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// Set Digital I/O direction.
        /// </summary>
        /// <remarks>Don't forget to sync with your device after all setting.</remarks>
        /// <param name="no">Digital I/O index. Availabe values: 1/2/3</param>
        /// <param name="value">Digital I/O direction
        /// <para>True - Input</para>
        /// <para>False - Output</para></param>
        /// <exception cref="IndexOutOfRangeException">Thrown when Digital I/O index  isn't 1,2 or 3</exception>
        public void setIODirection(int no, bool value)
        {
            if (no <= 3 || no >= 1)
                TRB2DIOState.I.DIODirection[no-1] = value;
            else
                throw new IndexOutOfRangeException();
        }
        /// <summary>
        /// Set 'save configuration' option. It should be marked as 'true' when need to save direction and state to the device memory.
        /// This is relevant after device reboot.
        /// Don't forget to sync with your device after all setting.
        /// </summary>
        /// <remarks>Don't forget to sync with your device after all setting.</remarks>
        /// <param name="no">Digital I/O index. Availabe values: 1/2/3</param>
        /// <param name="value">Digital I/O direction
        /// <para>True - Save configuration to memory</para>
        /// <para>False - Don't save configuration to memory</para></param>
        /// <exception cref="IndexOutOfRangeException">Thrown when Digital I/O index  isn't 1,2 or 3</exception>
        public void setIOSaveConfig(int no, bool value)
        {
            if (no <= 3 || no >= 1)
                TRB2DIOState.I.DIOSaveConfig[no-1] = value;
            else
                throw new IndexOutOfRangeException();
        }
    }

}
