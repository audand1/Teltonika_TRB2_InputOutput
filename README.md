#  Teltonika TRB2  Input and Output management component

This package is for Teltonika TRB2 gateways Input and Output management. With this component you can easily without any problems control your device digital output, read analog input value and etc.

# Get started
Just install this component from NuGet package manager into your .Net project and that's all. :)
[NuGet link](https://www.nuget.org/packages/Teltonika_TRB2_InputOutput/1.0.0)

# Package documentation

## Contents

- [TRB2Device](#T-TRB2_InputOutput-TRB2Device 'TRB2_InputOutput.TRB2Device')
  - [getAnalogValue()](#M-TRB2_InputOutput-TRB2Device-getAnalogValue 'TRB2_InputOutput.TRB2Device.getAnalogValue')
  - [getIODirection(no)](#M-TRB2_InputOutput-TRB2Device-getIODirection-System-Int32- 'TRB2_InputOutput.TRB2Device.getIODirection(System.Int32)')
  - [getIOValue(no)](#M-TRB2_InputOutput-TRB2Device-getIOValue-System-Int32- 'TRB2_InputOutput.TRB2Device.getIOValue(System.Int32)')
  - [setIODirection(no,value)](#M-TRB2_InputOutput-TRB2Device-setIODirection-System-Int32,System-Boolean- 'TRB2_InputOutput.TRB2Device.setIODirection(System.Int32,System.Boolean)')
  - [setIOSaveConfig(no,value)](#M-TRB2_InputOutput-TRB2Device-setIOSaveConfig-System-Int32,System-Boolean- 'TRB2_InputOutput.TRB2Device.setIOSaveConfig(System.Int32,System.Boolean)')
  - [setIOValue(no,value)](#M-TRB2_InputOutput-TRB2Device-setIOValue-System-Int32,System-Boolean- 'TRB2_InputOutput.TRB2Device.setIOValue(System.Int32,System.Boolean)')
  - [setupParameters(Username,Password,URL)](#M-TRB2_InputOutput-TRB2Device-setupParameters-System-String,System-String,System-String- 'TRB2_InputOutput.TRB2Device.setupParameters(System.String,System.String,System.String)')
  - [updateFromDevice()](#M-TRB2_InputOutput-TRB2Device-updateFromDevice 'TRB2_InputOutput.TRB2Device.updateFromDevice')
  - [updateToDevice()](#M-TRB2_InputOutput-TRB2Device-updateToDevice 'TRB2_InputOutput.TRB2Device.updateToDevice')

<a name='T-TRB2_InputOutput-TRB2Device'></a>
## TRB2Device `type`

##### Namespace

TRB2_InputOutput

<a name='M-TRB2_InputOutput-TRB2Device-getAnalogValue'></a>
### getAnalogValue() `method`

##### Summary

Get ADC value in Volts [V] (data of the last synchronization).

##### Returns

ADC value in Volts [V]

##### Parameters

This method has no parameters.

<a name='M-TRB2_InputOutput-TRB2Device-getIODirection-System-Int32-'></a>
### getIODirection(no) `method`

##### Summary

Get Digital I/O direction (data of the last synchronization).

##### Returns

Digital I/O direction

True - Input

False - Output

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| no | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Digital I/O index. Availabe values: 1/2/3 |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | Thrown when Digital I/O index  isn't 1,2 or 3 |

<a name='M-TRB2_InputOutput-TRB2Device-getIOValue-System-Int32-'></a>
### getIOValue(no) `method`

##### Summary

Get Digital I/O value (data of the last synchronization).

##### Returns

Digital I/O value

True - logical 1

False - logical 0

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| no | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Digital I/O index. Availabe values: 1/2/3 |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | Thrown when Digital I/O index  isn't 1,2 or 3 |

<a name='M-TRB2_InputOutput-TRB2Device-setIODirection-System-Int32,System-Boolean-'></a>
### setIODirection(no,value) `method`

##### Summary

Set Digital I/O direction.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| no | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Digital I/O index. Availabe values: 1/2/3 |
| value | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Digital I/O direction

True - Input

False - Output |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | Thrown when Digital I/O index  isn't 1,2 or 3 |

##### Remarks

Don't forget to sync with your device after all setting.

<a name='M-TRB2_InputOutput-TRB2Device-setIOSaveConfig-System-Int32,System-Boolean-'></a>
### setIOSaveConfig(no,value) `method`

##### Summary

Set 'save configuration' option. It should be marked as 'true' when need to save direction and state to the device memory.
This is relevant after device reboot.
Don't forget to sync with your device after all setting.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| no | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Digital I/O index. Availabe values: 1/2/3 |
| value | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Digital I/O direction

True - Save configuration to memory

False - Don't save configuration to memory |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | Thrown when Digital I/O index  isn't 1,2 or 3 |

##### Remarks

Don't forget to sync with your device after all setting.

<a name='M-TRB2_InputOutput-TRB2Device-setIOValue-System-Int32,System-Boolean-'></a>
### setIOValue(no,value) `method`

##### Summary

Set Digital I/O value.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| no | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Digital I/O index. Availabe values: 1/2/3 |
| value | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Digital I/O value

true - logical 1

false - logical 0 |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') | Thrown when Digital I/O index  isn't 1,2 or 3 |

##### Remarks

Don't forget to sync with your device after all setting.

<a name='M-TRB2_InputOutput-TRB2Device-setupParameters-System-String,System-String,System-String-'></a>
### setupParameters(Username,Password,URL) `method`

##### Summary

Prepare component and setup TRB2 device login parameters.

##### Returns

0 - OK

1 - Username validation fail

2 - Password validation fail

3 - URL validation fail

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| Username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | TRB2 device username |
| Password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | TRB2 device password |
| URL | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | TRB2 device IP address or hostname. Don't forget use "http://" in front of URL |

<a name='M-TRB2_InputOutput-TRB2Device-updateFromDevice'></a>
### updateFromDevice() `method`

##### Summary

Sync (Get) I/O data from TRB2 device.

##### Returns

0 - OK

1 - Failed login into device

2 - Failed get ADC value from the device

3 - Failed get Digital I/O 1 parameters from the device

4 - Failed get Digital I/O 2 parameters from the device

5 - Failed get Digital I/O 3 parameters from the device

##### Parameters

This method has no parameters.

<a name='M-TRB2_InputOutput-TRB2Device-updateToDevice'></a>
### updateToDevice() `method`

##### Summary

Sync (Set) I/O data to TRB2 device.

##### Returns

0 - OK

1 - Failed login into device

2 - (Empty)

3 - Failed set Digital I/O 1 parameters to the device

4 - Failed set Digital I/O 2 parameters to the device

5 - Failed set Digital I/O 3 parameters to the device

##### Parameters

This method has no parameters.


# Examples

####  Setup component with default TRB2 credentials
```
TRB2Device device = new TRB2Device();
int response = device.setupParameters("admin", "admin01", "http://192.168.1.1");
if (response == 0)
{
// Success
}else
{
// Not success
}
```
----------
####  Get newest data form device (Sync) and print it
```
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
```
----------
####  Setup I/O  and send  (Sync)  to device 
```
device.setIODirection(1, true); // First I/O, as Input

device.setIODirection(2, true); // Second I/O, as Input

device.setIODirection(3, false); // Third I/O as Output
device.setIOValue(3, false); // Third Output state as logical "0"

response = device.updateToDevice();
Console.WriteLine("Set status: " + response);
```
----------
####  Read analog input value in the infinity loop
```
while (true)
{
	device.updateFromDevice();
	Console.WriteLine("ADC0 value: " + device.getAnalogValue());
	Thread.Sleep(300);
}
```
----------


