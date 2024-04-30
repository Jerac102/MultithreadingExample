using System;

namespace InsortMultithreadingExample
{
    internal struct ImageData
    {
        public byte[] Data; 
        public ImageData(int imageSize, int seqeuenceNumber)
        {
            Data = new byte[seqeuenceNumber + imageSize];
        }

        public uint GetSequenceNumber()
        {
            return BitConverter.ToUInt32(Data, 0);
        }
    }
}
