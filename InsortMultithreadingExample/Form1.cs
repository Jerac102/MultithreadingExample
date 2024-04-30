using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace InsortMultithreadingExample
{
    public partial class Insort : Form
    {
        public Insort()
        {
            InitializeComponent();
            CameraAcquisition = new CameraAcquisition();
            ImageProcessing = new ImageProcessing();
        }

        private static CameraAcquisition CameraAcquisition;
        private static ImageProcessing ImageProcessing;
        private static ConcurrentQueue<ImageData> imageDatas = new ConcurrentQueue<ImageData>();
        
        private static Stopwatch stopwatch;
        public Thread CameraThread;
        public Thread ImageProcessingThread;

        private void btnStart_Click(object sender, EventArgs e)
        {
            ThreadComm.Stopped = false;
            stopwatch = Stopwatch.StartNew();

            CameraThread = new Thread(() => CameraAcquisition.StartAcquisition(ref imageDatas, (int)nudAcquisitionTime.Value));
            ImageProcessingThread = new Thread(() => ImageProcessing.StartImageProcessing(ref imageDatas, (int)nudAcquisitionTime.Value, lbLiveData));
            CameraThread.Start();
            ImageProcessingThread.Start();
        }

        private void cbPause_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPause.Checked)
            {
                ThreadComm.Paused = cbPause.Checked;
            }
            else 
            {
                ThreadComm.Paused = cbPause.Checked;
                ThreadComm.ManualResetEvent.Set();
                ThreadComm.ManualResetEvent.Reset();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cbPause.Checked = false;
            ThreadComm.Stopped = !ThreadComm.Stopped;

            if (CameraThread != null)
                CameraThread.Join();
            
            if (ImageProcessingThread != null)
                ImageProcessingThread.Join();

            stopwatch.Stop();
            GenerateReport();
        }

        private void GenerateReport()
        {
            var reportText = new System.Text.StringBuilder();
            reportText.AppendLine($"Start - End duration: {stopwatch.Elapsed}");
            reportText.AppendLine($"Camera Acquisition Time Max: {CameraAcquisition.AcquisitionTimeMaxMs}");
            reportText.AppendLine($"Camera Acquisition Time Avg: {CameraAcquisition.AcquisitionTimeAvgMs}");
            reportText.AppendLine($"Image Processing Time Max: {ImageProcessing.ImageProcessingTimeMaxMs}");
            reportText.AppendLine($"Image Priocessing Time Avg: {ImageProcessing.ImageProcessingTimeAvgMs}");
            reportText.AppendLine($"Not Continuous Sequence Numbers: {ImageProcessing.NotContinuousSequenceNumbers}");
            reportText.AppendLine($"Processed objects: {ImageProcessing.ProcessedObjects}");
            reportText.AppendLine($"Gen Camera Acquisition: {System.GC.GetGeneration(CameraAcquisition)}");
            reportText.AppendLine($"Gen Image Processing: {System.GC.GetGeneration(ImageProcessing)}");
        
            tbReport.Text = reportText.ToString();
        }
    }
}
