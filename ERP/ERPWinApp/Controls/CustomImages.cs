using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ERP.CommonLayer;

namespace ERPWinApp
{
    public static class CustomImages
    {
        public static Image GetDialogImage(eCustomDialogImages custImaages)
        {
            System.Drawing.Image image = null;
            string absolutePath = Path.GetDirectoryName(Application.ExecutablePath);
            
            if (absolutePath.EndsWith("\\bin\\Debug"))
            {
                absolutePath = absolutePath.Replace("\\bin\\Debug", "");
            }

            string imagePath = Path.Combine(absolutePath, Constants.CONSTANT_IMAGES, Constants.CONSTANT_DIALOGS);
            
            if (!Directory.Exists(imagePath))
                return image;

            switch (custImaages)
            {
                case eCustomDialogImages.Success:
                    image = Image.FromFile(Path.Combine(imagePath, "icon_tick.png"), true);
                    break;
                case eCustomDialogImages.Error:
                    image = Image.FromFile(Path.Combine(imagePath, "icon_x.png"), true);
                    break;
                case eCustomDialogImages.Warning:
                    image = Image.FromFile(Path.Combine(imagePath, "exclamare_64.png"), true);
                    break;
                case eCustomDialogImages.Information:
                    image = Image.FromFile(Path.Combine(imagePath, "icon_info.png"), true);
                    break;
            }

            return image;
        }

        public enum eCustomDialogImages
        {
            Success,
            Error,
            Warning,
            Information
        }
    }
}
