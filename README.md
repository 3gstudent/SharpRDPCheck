# SharpRDPCheck
Use to check the valid account of the Remote Desktop Protocol(Support plaintext and ntlmhash)


Author:3gstudent

Reference:https://github.com/RDPUploader/RDPUploader

**Note:The .NET Framework must support TLSv1.2.**

Usage:

```
      SharpRDPBrute.exe <RDP ServerIP> <RDP ServerPort> <mode> <user> <password>
      <mode>:
      - plaintext
      - ntlmhash
```

Eg:

```
      SharpRDPBrute.exe 192.168.1.1 3389 plaintext user1 password1
      SharpRDPBrute.exe 192.168.1.1 3389 ntlmhash user1 c5a237b7e9d8e708d8436b6148a25fa1
```
