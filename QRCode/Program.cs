using System;
using System.Drawing;
using Spire.Barcode;

namespace QRCodeGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the URL: ");
            string url = Console.ReadLine();

            string qrName = $"{Guid.NewGuid()}.png";//Guid: عشان يختار اسم مميز
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//من الانفايرمنت Desktop هاي انو يحدد ملف اسمه   
            string qrPath = System.IO.Path.Combine(desktopPath, qrName);//هون بيعمل جوين حسب ما فهمت ودخلت على كودها

            BarcodeSettings settings = new BarcodeSettings//هسا في كلاس لصفات الباركود بعمل منه اوبجيكت
            {
                Type = BarCodeType.QRCode,// EAN13  النوع تاعه او الشكل الي انا مختاره في انواع اخرى مثل 
                Data = url,// شو الداتا الي بدي اياها في البار كود+ انا ممكن اخزن فيه اوبجيكت للداتا الي بحتاج انو تكون فيه
                X = 6,//للعرض
                Y = 6,//للطول
                Data2D = "Hi Ahmad!!!",// النص الي بدي اياه يضهر فوق الباركود
        };


            BarCodeGenerator generator = new BarCodeGenerator(settings);//في كلاس بيعمل جيناريت لصفات الباركود مع صورته
            try
            {
                generator.GenerateImage().Save(qrPath);//في حال عمل جيناريت وكلشي تمام وعمل حفظ جيب هاي
                Console.WriteLine($"QR code saved as '{qrName}' on the desktop.");
            }
            catch (Exception ex)// اي اكسبشن جيب هاي 
            {
                Console.WriteLine($"An error occurred while saving the QR code: {ex.Message}");
            }


        }
    }
}
