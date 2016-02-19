using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AForge.Video.FFMPEG;

namespace GravitatioanlSimulation.Writer
{
    class VideoWriter :IWriter
    {
        private VideoFileWriter _videoFileWriterwriter;


        public void Initialization(string OutputFile, int Width, int Height)
        {
            _videoFileWriterwriter = new VideoFileWriter();
            _videoFileWriterwriter.Open(OutputFile, Width, Height, 25, VideoCodec.MPEG4, 100000000);
        }

        public void Write(Bitmap bitmap)
        {
            _videoFileWriterwriter.WriteVideoFrame(bitmap);
        }

        public void SaveResult()
        {
            _videoFileWriterwriter.Close();
        }
    }
}
