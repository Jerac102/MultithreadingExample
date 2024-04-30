Author: Jerko Hren
Program: Implementation of Multithreading Example 1 from Insort 

Summary

  I have tried to do my best, even if I didn't work with memory managment in .NET a lot. I have to read some topics on internet before
I finished the program. But in some things I already got expirience, like using multithreading.
I used WinForms instead of WPF, because I have expirience in it and it was fastast way for me to do this example.

Program architecture:

  I have decided to use one thread for camera acquisition and one for image processing where communication between this two thread is done over ThreadComm class.
  I have used Diagnostic tool in VS to observe memory consumption. It looks ok. Memory didn't rise during program use.
  Most work was to have threads in sync, to stop, pause end start them.

API documentation:

  CameraAcquisation class
  - generate sequence number and some dummy image data in separate thread
  - push data to the queue

  ImageProcessing class
  - read and process image data from queue in separate thread

  ImageData class
  - represent image datatype from camera
  - can return sequence number in uint type from byte array

  ThreadComm class
  - has two properties Stopped and Paused to control threads (Camera Acquisition and Image Processing) like stop or pause
  - has ManualResetEvent object to be able to pause Camera Acquisition thread

  Insort : Form
  - UI for program control (start, stop, pause, report, live tracking, change acquisition time)

  I hope I have done good job and I am looking forward to hear Your feedback and learn something new.