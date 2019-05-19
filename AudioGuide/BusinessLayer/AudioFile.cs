using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AudioGuide.BusinessLayer
{
    public class AudioFile
    {
        Stream staream = new FileStream("path", FileMode.Open, FileAccess.Read);
        MemoryStream ms = new MemoryStream();

        staream.CopyTo(ms);
         byte[] ads=ms.ToArray();


    }
}