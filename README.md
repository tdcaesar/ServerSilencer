# ServerSilencer
Manual fan control for Dell r720

Steps
1. Get Temperatures
   1. Issue a temperature command to the ipmitool
   2. Receive a formatted response
   3. Parses the response
2. Check Temperatures
   1. Get Thresholds
   2. Compare Temperatures to Thresholds
   3. If Temperature is above threshold
      1. Set Mode to Automatic
   4. If Temperature is below threshold
      1. Set Mode to Manual
      2. 
      2. Continue
2. Set Fan Speed
   1. Issue a fan speed command to the ipmitool
   2. Receive a formatted response
   3. Parses the response
3. Set Automatic Mode
   3. Continue
3. Set Control Mode
6. If Manual
   1. Determine appropriate Fan Speed
   2. Set Fan Speed
7. Log Result



Expected Temperature Command Response Sample

Sensor Output

| Name         | ID  | Status | ?   | Temperature  |
|--------------|-----|--------|-----|--------------|
| Inlet Temp   | 04h | ok     | 7.1 | 26 degrees C |
| Exhaust Temp | 01h | ok     | 7.1 | 44 degrees C |
| Temp         | 0Eh | ok     | 3.1 | 44 degrees C |
| Temp         | 0Fh | ok     | 3.2 | 43 degrees C |

## Command Request Outputs

### Retrieve a list of sensors
```
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
```

### Retrieve Temperatures
```
# ipmitool sdr type temperature
Inlet Temp       | 04h | ok  |  7.1 | 26 degrees C
Exhaust Temp     | 01h | ok  |  7.1 | 44 degrees C
Temp             | 0Eh | ok  |  3.1 | 44 degrees C
Temp             | 0Fh | ok  |  3.2 | 43 degrees C
```


### Retrieve Fan Speeds
```
# ipmitool sdr type fan
Fan1             | 30h | ok  |  7.1 | 5160 RPM
Fan2             | 31h | ok  |  7.1 | 5040 RPM
Fan3             | 32h | ok  |  7.1 | 5160 RPM
Fan4             | 33h | ok  |  7.1 | 6360 RPM
Fan5             | 34h | ok  |  7.1 | 6360 RPM
Fan6             | 35h | ok  |  7.1 | 5160 RPM
Fan Redundancy   | 75h | ok  |  7.1 | Fully Redundant
```