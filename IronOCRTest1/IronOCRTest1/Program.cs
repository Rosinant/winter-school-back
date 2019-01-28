using System;
using IronOcr;
using System.Drawing;

namespace IronOCRTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            var img = Image.FromFile("../../img/Passport.jpg");     

            #region IronOCR
            var OCR = new AdvancedOcr
            {
                CleanBackgroundNoise = true,
                EnhanceContrast = true,
                EnhanceResolution = true,
                Language = IronOcr.Languages.Russian.OcrLanguagePack,
                Strategy = AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = false,
                InputImageType = AdvancedOcr.InputTypes.Snippet,
                RotateAndStraighten = false,
                ReadBarCodes = false,
                ColorDepth = 4
            };
            #endregion        

            #region Areas
            var areaIssuedFirst = new Rectangle
            {
                X = (img.Width / 100) * 25,
                Y = (img.Height / 100) * 8,
                Width = (img.Width/100) * 75,
                Height = (img.Height / 100) * 5
            };

            var areaIssuedSecond = new Rectangle
            {
                X = (img.Width / 100) * 4,
                Y = (img.Height / 100) * 11,
                Width = (img.Width / 100) * 96,
                Height = (img.Height / 100) * 9
            };

            var areaDateIssued = new Rectangle
            {
                X = (img.Width / 100) * 20,
                Y = (img.Height / 100) * 20,
                Width = (img.Width / 100) * 25,
                Height = (img.Height / 100) * 5
            };

            var areaCode = new Rectangle
            {
                X = (img.Width / 100) * 61,
                Y = (img.Height / 100) * 20,
                Width = (img.Width / 100) * 37,
                Height = (img.Height / 100) * 5
            };

            var areaSurname = new Rectangle
            {
                X = (img.Width / 100) * 47,
                Y = (img.Height / 100) * 55,
                Width = (img.Width / 100) * 45,
                Height = (img.Height / 100) * 9
            };

            var areaName = new Rectangle
            {
                X = (img.Width / 100) * 47,
                Y = (img.Height / 100) * 64,
                Width = (img.Width / 100) * 55,
                Height = (img.Height / 100) * 6
            };

            var areaPatronymic = new Rectangle
            {
                X = (img.Width / 100) * 47,
                Y = (img.Height / 100) * 70,
                Width = (img.Width / 100) * 50,
                Height = (img.Height / 100) * 5
            };

            var areaGender = new Rectangle
            {
                X = (img.Width / 100) * 45,
                Y = (img.Height / 100) * 75,
                Width = (img.Width / 100) * 10,
                Height = (img.Height / 100) * 5
            };

            var areaBirthday = new Rectangle
            {
                X = (img.Width / 100) * 57,
                Y = (img.Height / 100) * 75,
                Width = (img.Width / 100) * 40,
                Height = (img.Height / 100) * 5
            };

            var areaAddress = new Rectangle
            {
                X = (img.Width / 100) * 47,
                Y = (img.Height / 100) * 79,
                Width = (img.Width / 100) * 50,
                Height = (img.Height / 100) * 13
            };
            #endregion

            #region Read Text
            var readIssuedFirst = OCR.Read(img, areaIssuedFirst);
            var readIssuedSecond = OCR.Read(img, areaIssuedSecond);
            var readDateIssued = OCR.Read(img, areaDateIssued);
            var readCode = OCR.Read(img, areaCode);
            var readSurname = OCR.Read(img, areaSurname);
            var readName = OCR.Read(img, areaName);
            var readPatronymic = OCR.Read(img, areaPatronymic);
            var readGender = OCR.Read(img, areaGender);
            var readBirthday = OCR.Read(img, areaBirthday);
            var readAddress = OCR.Read(img, areaAddress);
            #endregion

            img.RotateFlip(RotateFlipType.Rotate270FlipNone);

            var areaSerial = new Rectangle
            {
                X = (img.Width / 100) * 10,
                Y = (img.Height / 100) * 1,
                Width = (img.Width / 100) * 30,
                Height = (img.Height / 100) * 7
            };

            var readSerial = OCR.Read(img, areaSerial);

            #region Write All Areas
            Console.WriteLine(readIssuedFirst);
            Console.WriteLine("-------");
            Console.WriteLine(readIssuedSecond);
            Console.WriteLine("-------");
            Console.WriteLine(readDateIssued);
            Console.WriteLine("-------");
            Console.WriteLine(readCode);
            Console.WriteLine("-------");
            Console.WriteLine(readSurname);
            Console.WriteLine("-------");
            Console.WriteLine(readName);
            Console.WriteLine("-------");
            Console.WriteLine(readPatronymic);
            Console.WriteLine("-------");
            Console.WriteLine(readGender);
            Console.WriteLine("-------");
            Console.WriteLine(readBirthday);
            Console.WriteLine("-------");
            Console.WriteLine(readAddress);
            Console.WriteLine("-------");
            Console.WriteLine(readSerial);
            Console.WriteLine("-------");
            Console.ReadKey();
            #endregion
        }
    }
}
