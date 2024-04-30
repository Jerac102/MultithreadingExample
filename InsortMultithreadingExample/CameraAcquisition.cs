using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace InsortMultithreadingExample
{
    internal class CameraAcquisition
    {
        internal uint Counter = 0;
        public long AcquisitionTimeMaxMs { get; set; } = 0;
        public long AcquisitionTimeAvgMs { get; set; } = 0;

        ImageData ImageData = new ImageData(1024, 4);
        public void StartAcquisition(ref ConcurrentQueue<ImageData> imageDatas, int acquisitionTime)
        {
            ResetAnalysisData();
            var stopWatch = new Stopwatch();
            while (true)
            {
                stopWatch.Restart();
                Counter++;
                ImageData.Data[3] = (byte)(Counter >> 24);
                ImageData.Data[2] = (byte)(Counter >> 16);
                ImageData.Data[1] = (byte)(Counter >> 8);
                ImageData.Data[0] = (byte)Counter;
                ImageData.Data[4] = (byte)new Random().Next(255);

                var tempImageData = new byte[1028];
                ImageData.Data.CopyTo(tempImageData, 0);
                imageDatas.Enqueue(new ImageData() { Data = tempImageData });

                Thread.Sleep(acquisitionTime);

                stopWatch.Stop();
                SetMaxAndAverageCameraAcquisitionTime(stopWatch);

                if (ThreadComm.Paused && !ThreadComm.Stopped)
                    ThreadComm.ManualResetEvent.WaitOne();

                if (ThreadComm.Stopped)
                    break;
            }

            AcquisitionTimeAvgMs = AcquisitionTimeAvgMs / Counter;
        }

        private void ResetAnalysisData()
        {
            Counter = 0;
            AcquisitionTimeMaxMs = 0;
            AcquisitionTimeAvgMs = 0;
    }

        private void SetMaxAndAverageCameraAcquisitionTime(Stopwatch stopWatch)
        {
            if (AcquisitionTimeMaxMs < stopWatch.ElapsedMilliseconds)
                AcquisitionTimeMaxMs = stopWatch.ElapsedMilliseconds;

            AcquisitionTimeAvgMs += stopWatch.ElapsedMilliseconds;
        }
    }
}
