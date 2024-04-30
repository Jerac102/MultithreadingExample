using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;

namespace InsortMultithreadingExample
{
    internal class ImageProcessing
    {
        public long ImageProcessingTimeMaxMs = 0;
        public long ImageProcessingTimeAvgMs = 0;
        private long ImageProcessingTimeSumMs;
        public uint NotContinuousSequenceNumbers;
        public uint ProcessedObjects = 0;

        private static uint counter;
        private static uint sequence;
        public  void StartImageProcessing(ref ConcurrentQueue<ImageData> imageDatas, int acquisitionTime, System.Windows.Forms.Label lbLiveData)
        {
            ResetAnalysisData();

            var stopWatch = new Stopwatch();

            while (true)
            {
                stopWatch.Restart();
                imageDatas.TryDequeue(out ImageData imageData);

                if (imageData.Data is null)
                {
                    if (ThreadComm.Stopped)
                        break;

                    continue;
                }

                sequence = imageData.GetSequenceNumber();
                if (counter + 1 != sequence)
                {
                    NotContinuousSequenceNumbers++;
                }
                counter = sequence;

                // Create reandom time for processing
                var sleepTime = new Random().Next(15) / 10m * acquisitionTime;
                Thread.Sleep((int)sleepTime);

                stopWatch.Stop();

                // Update UI
                lbLiveData.BeginInvoke((Action)delegate ()
                {
                    lbLiveData.Text = counter.ToString();
                });
                
                SetMaxAndSumOfImageProcessingTime(stopWatch);

                if (ThreadComm.Paused && !ThreadComm.Stopped)
                    ThreadComm.ManualResetEvent.WaitOne();

                if (imageDatas.Count == 0 && ThreadComm.Stopped)
                    break;
            }

            ImageProcessingTimeAvgMs += ImageProcessingTimeSumMs / counter;
            ProcessedObjects = counter;
        }

        private void ResetAnalysisData()
        {
            counter = 0;
            sequence = 0;
            ImageProcessingTimeAvgMs = 0;
            ImageProcessingTimeSumMs = 0;
            ImageProcessingTimeMaxMs = 0;
            ProcessedObjects = 0;
        }

        private  void SetMaxAndSumOfImageProcessingTime(Stopwatch stopWatch)
        {
            if (ImageProcessingTimeMaxMs < stopWatch.ElapsedMilliseconds)
                ImageProcessingTimeMaxMs = stopWatch.ElapsedMilliseconds;

            ImageProcessingTimeSumMs += stopWatch.ElapsedMilliseconds;
        }        
    }
}
