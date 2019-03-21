using System;
using System.Collections.Generic;
using System.Text;

namespace PaintStore.Application.Interfaces
{
    public interface ICloudinaryService
    {
        void DeleteImage(string link);
    }
}
