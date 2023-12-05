# ServerSilencer
Manual fan control for Dell r720


Issues a temperature command to the ipmitool
Recieves a formatted response


Expected Temperature Command Response Sample
Sensor Name | Sensor ID | Sensor Status (ok | ns) | ???? (X.X) | Temperature (## degrees C | disabled)

Inlet Temp       | 04h | ok  |  7.1 | 26 degrees C
Exhaust Temp     | 01h | ok  |  7.1 | 44 degrees C
Temp             | 0Eh | ok  |  3.1 | 44 degrees C
Temp             | 0Fh | ok  |  3.2 | 43 degrees C


commands
# ipmitool sdr type temperature
Inlet Temp       | 04h | ok  |  7.1 | 26 degrees C
Exhaust Temp     | 01h | ok  |  7.1 | 44 degrees C
Temp             | 0Eh | ok  |  3.1 | 44 degrees C
Temp             | 0Fh | ok  |  3.2 | 43 degrees C

# ipmitool sdr list
SEL              | Not Readable      | ns
Intrusion        | 0x00              | ok
Fan1             | 5040 RPM          | ok
Fan2             | 5160 RPM          | ok
Fan3             | 5160 RPM          | ok
Fan4             | 6360 RPM          | ok
Fan5             | 6360 RPM          | ok
Fan6             | 5160 RPM          | ok
Inlet Temp       | 26 degrees C      | ok
Exhaust Temp     | 44 degrees C      | ok

# ipmitool sdr type fan
Fan1             | 30h | ok  |  7.1 | 5160 RPM
Fan2             | 31h | ok  |  7.1 | 5040 RPM
Fan3             | 32h | ok  |  7.1 | 5160 RPM
Fan4             | 33h | ok  |  7.1 | 6360 RPM
Fan5             | 34h | ok  |  7.1 | 6360 RPM
Fan6             | 35h | ok  |  7.1 | 5160 RPM
Fan Redundancy   | 75h | ok  |  7.1 | Fully Redundant