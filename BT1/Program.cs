using System;
using System.IO;
using System.Text;

namespace BT1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.WriteLine("Nhập vào 2 số nguyên x và y:");

                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                double result = TinhBieuThuc(x, y);

                Console.WriteLine("Giá trị H là: " + result);

                // Ghi kết quả vào file
                File.WriteAllText("input.txt", $"x = {x}, y = {y}, H = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZeroException: " + ex.Message);
                Console.WriteLine("DivideByZeroException:" + ex.StackTrace);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("FormatException: " + ex.Message);
                Console.WriteLine("FormatException:" + ex.StackTrace);
            }
            catch (NotNegativeException ex)
            {
                Console.WriteLine("NotNegativeException: " + ex.Message);
                Console.WriteLine("NotNegativeException:" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception test: " + ex.Message);
                Console.WriteLine("Exception test:" + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Chương trình kết thúc.");
            }

            Console.ReadLine();
        }

        static double TinhBieuThuc(int x, int y)
        {
            int tuSo = 3 * x + 2 * y;
            int mauSo = 2 * x - y;

            if (mauSo == 0)
                throw new DivideByZeroException("Mẫu số bằng 0.");

            double giaTri = (double)tuSo / mauSo;

            if (giaTri < 0)
                throw new NotNegativeException("Giá trị trong căn nhỏ hơn 0.");

            return Math.Sqrt(giaTri);
        }

        // Ngoại lệ tự định nghĩa
        public class NotNegativeException : Exception
        {
            public NotNegativeException(string message) : base(message) { }
        }
    }
}