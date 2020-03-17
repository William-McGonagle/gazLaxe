# `GazLAxe`
### _Project Started by William McGonagle_

> The computer is the most remarkable tool that we've ever come up with. It's the equivalent of a bicycle for our minds.
> -Steve Jobs

## What is `GazLAxe`
`GazLAxe` is an open source hacking tool that utilizes UI standards that have been brought about in our modern day. It allows an everyday user to protect themselves against hackers, scammers and everyday exploiters. `GazLAxe` also allows security options for your computer, such as allowing you to change your IP address, password, and username at will, even if you are not running `GazLAxe` on those platforms.

## Features
- [ ] Emailer
  - [ ] POSSIBLE: Act as SMTP server
  - [ ] POSSIBLE: Act as IMAP server
  - [ ] _Allows for the user to send emails to anyone with a valid email address. These emails can be formatted however the user wants. The user will also be able to embed files into the email. This will be good for getting access to a remote computer._
- [ ] Kashmir (Text Editor)
  - [ ] Encryption
    - _Allows the encryption of a selected area in the Text Editor using any of the following methods._
    - [ ] AES
    - [ ] 3DES
    - [ ] TwoFish
    - [ ] RSA
    - [ ] Cesar
    - [ ] ETC
  - [ ] Decryption
    - _Allows the decryption of a selected area in the Text Editor using any of the following methods_
    - [ ] AES
    - [ ] 3DES
    - [ ] TwoFish
    - [ ] RSA
    - [ ] Cesar
    - [ ] ETC
- [ ] FTP
  - _Allows transfer of files to specified IP address, with auth parameters._
  - [ ] UI
  - [ ] Functionality 
  - [X] Setup UI
  - [ ] Tunneling
- [ ] ~~Password Decryptor~~
  - ~~_Decrypts passwords using different methods._~~
  - __REASON FOR REMOVAL:__ This was before the Text Editor was suppost to support encrypting and decrypting different things. This may be added back in as a local version of Heartbreaker with a different name that can bruteforce encryption algorithms. Possible names include Heartbreak Hotel, The Boxer, Johnny B. Good, Juicy, Good Day Maker or Feel Good Inc. 
- [ ] `GazL-RAT`
  - _`GazL-RAT` is a Remote Access Tool that acts as though you are using the computer. The screen output, and audio output is sent directly to `GazLAxe` through UDP or TCP packets, and the Keyboard Input, Microphone Input, and Mouse Input is sent directly to the client computer with UDP or TCP packets._
  - [ ] Client Functionality
  - [ ] Server Functionality
  - [ ] UI
  - [X] Setup Screen
  - [ ] FTP Application to Client
  - [ ] Come up with new name. POSSIBLE NAMES: Emile, NigelBurn, RATBurn, Dr. Ratigan, Ratatouille, or Mickey (I know he's a mouse)
- [ ] `GazL-DOS` 
  - [ ] Implement a fair amount of [these](https://en.wikipedia.org/wiki/Denial-of-service_attack)
  - [ ] UI
  - [ ] Come up with new name: Whole Lotta Love Giver, Suize Q, Black Dog
- [X] Heartbreaker (Remote Password Guesser)
  - [X] Basic UI
  - [ ] Algorithms
    - [ ] Jack the Ripper
    - [ ] Seven Nation Army
    - [ ] Levee Breaker
  - [ ] Results Screen
  - [X] Different File Types
    - [X] JSON Array
    - [X] CSV
    - [X] Plaintext 
- [ ] SSH
  - [X] GazLAxe Terminal
  - [ ] Run in Native Terminal/ Command Prompt
  - [X] Setup
  - [ ] Allow Tunnels
- [ ] KUMP
  - [X] Setup
  - [ ] Functionality
    - [X] Change Remote Password
    - [ ] Add Remote Account
    - [ ] Add RAT virus onto remote computer
  - [X] Add Footprint/ Tag
  - [X] Specify Remote Computer Type
  - [X] Scrub Terminal History
  - [ ] Scrub All Remote Access Histories
- [ ] ~~Dundee Knife~~
  - ~~Allows the user to access and control different objects in the physical world (IOT).~~
  - [ ] ~~Cameras~~
  - [ ] ~~Lights~~
  - [ ] ~~Locks~~
  - [ ] ~~Doorbells~~
  - [ ] ~~Home Managers~~
  - [ ] ~~Speakers~~
  - [ ] ~~Robot~~
  - [ ] ~~Thermostat~~
  - [ ] __REASON FOR REMOVAL:__ Too broad. When extension support is added to GazLAxe this will be added back in as an extension. It is mostly just bloatware that will not be used. 
- [ ] Swarm Controller
  - _Gives the user control over a certain amount of computers. A script can be transfered to all of these computers that makes them check a webserver for instructions every X amount of minutes. Other methods of swarm control can also be given to all of these computers._
- [ ] Network Manager
  - _Get detailed information about everyone on your network. Works very similar to ARP, but custom ports can be used for the pinging so even computers with certain ports blocked can be pinged._
  - _This works by checking users local IP Address and then replacing the end segment with a number from 1 to 255, and then this IP address is pinged on port 22 or whatever port the user wants. It iterates this 255 times until all possible hosts are found. Custom template addresses can also be used so that the user is able to scan for public IP addresses if they perfer._
- [ ] Mr. Map
  - _Essentially NMap for GazLAxe. Does everything that NMAP can do, but with a UI._
