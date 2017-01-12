using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemaElectronicaLC.Util;

namespace TemaElectronicaLC.Managers
{
    class ConversionManager
    {

        public static int getIntFromChar(char a)
        {
            if(a >= '0' && a <= '9')
            {
                return a - '0';
            }
            if(a >= 'A' && a <= 'Z')
            {
                return a - 'A' + 10;
            }
            if (a >= 'a' && a <= 'z')
            {
                return a - 'a' + 10;
            }
            return -1;
        }

        public static char getCharFromInt(int a)
        {
            if(a < 10)
            {
                return (char)(a + '0');
            }
            return (char)(a + 'A' - 10);
        }

        public static int getIntFromBi(String bin)
        {
            if (bin == "0001" || bin == "001" || bin == "01")
                return 1;
            if (bin == "0010" || bin == "010" || bin == "10")
                return 2;
            if (bin == "0011" || bin == "011" || bin == "11")
                return 3;
            if (bin == "0100" || bin == "100")
                return 4;
            if (bin == "0101" || bin == "101")
                return 5;
            if (bin == "0110" || bin == "110")
                return 6;
            if (bin == "0111" || bin == "111")
                return 7;
            if (bin == "1000")
                return 8;
            if (bin == "1001")
                return 9;
            if (bin == "1010")
                return 10;
            if (bin == "1011")
                return 11;
            if (bin == "1100")
                return 12;
            if (bin == "1101")
                return 13;
            if (bin == "1110")
                return 14;
            if (bin == "1111")
                return 15;
            return 0;
        }

        public static String getBiFromInt(int a)
        {
            if (a == 1)
                return "0001";
            if (a == 2)
                return "0010";
            if (a == 3)
                return "0011";
            if (a == 4)
                return "0100";
            if (a == 5)
                return "0101";
            if (a == 6)
                return "0110";
            if (a == 7)
                return "0111";
            if (a == 8)
                return "1000";
            if (a == 9)
                return "1001";
            if (a == 10)
                return "1010";
            if (a == 11)
                return "1011";
            if (a == 12)
                return "1100";
            if (a == 13)
                return "1101";
            if (a == 14)
                return "1110";
            if (a == 15)
                return "1111";
            return "0000";
        }

        public static String getStringOfBase10(int a)
        {
            String result = "";
            while(a > 0)
            {
                result = a % 10 + result;
                a /= 10;
            }
            return result;
        }

        public static int getBinarDif(int a)
        {
            int result = 1;
            while(a > 2)
            {
                result++;
                a /= 2;
            }
            return result;
        }

        public static bool isBinarBase(int a)
        {
            if(a == 2 || a == 4 || a == 8 || a == 16 || a == 32)
            {
                return true;
            }
            return false;
        }

        public static BaseNumber convertToBaseByInter(BaseNumber a, int bazaD)
        {
            String numarD = "";
            int numarInZece = 0;
            int putereBaza = 1;
            for (int i = a.numar.Length - 1; i >= 0; i--)
            {
                numarInZece += ConversionManager.getIntFromChar(a.numar[i]) * putereBaza;
                putereBaza *= a.baza;
            }
            while(numarInZece > 0)
            {
                numarD = ConversionManager.getCharFromInt(numarInZece % bazaD) + numarD;
                numarInZece /= bazaD;
            }
            return new BaseNumber(bazaD, numarD);
        }

        public static BaseNumber convertToBaseByFastTo(BaseNumber a, int bazaD)
        {
            int binDif = ConversionManager.getBinarDif(bazaD);
            String numarS = a.numar;
            while(numarS.Length % binDif != 0)
            {
                numarS = "0" + numarS;
            }
            String numarD = "";
            for (int i =0; i < numarS.Length; i+=binDif)
            {
                numarD = numarD + ConversionManager.getCharFromInt(
                    ConversionManager.getIntFromBi(numarS.Substring(i, binDif)));
            }
            return new BaseNumber(bazaD, numarD);
        }

        public static BaseNumber convertToBaseByFastFrom(BaseNumber a)
        {
            int binDif = ConversionManager.getBinarDif(a.baza);
            String numarS = a.numar;
            String numarD = "";
            for (int i = 0; i < numarS.Length; i++)
            {
                numarD = numarD + ConversionManager.getBiFromInt(ConversionManager.getIntFromChar(numarS[i])).Substring(3- binDif,3);
            }
            return new BaseNumber(2, numarD);
        }

        public static BaseNumber addNumbersSameBase(BaseNumber a, BaseNumber b)
        {
            String number1 = a.numar;
            String number2 = b.numar;
            String result = "";
            int transport = 0;
            int len = Math.Min(number1.Length, number2.Length);
            int i;
            for (i=0;i < len; i++)
            {
                int cif = transport + ConversionManager.getIntFromChar(number1[number1.Length - i - 1]) + ConversionManager.getIntFromChar(number2[number2.Length - i - 1]);
                transport = cif / a.baza;
                result = ConversionManager.getCharFromInt(cif % a.baza) + result;
            }
            for (; i < number1.Length; i++)
            {
                int cif = transport + ConversionManager.getIntFromChar(number1[number1.Length - i - 1]);
                transport = cif / a.baza;
                result = ConversionManager.getCharFromInt(cif % a.baza) + result;
            }
            for (; i < number2.Length; i++)
            {
                int cif = transport + ConversionManager.getIntFromChar(number2[number2.Length - i - 1]);
                transport = cif / a.baza;
                result = ConversionManager.getCharFromInt(cif % a.baza) + result;
            }
            return new BaseNumber(a.baza, result);
        }

        public static BaseNumber mulNumberByCif(BaseNumber a, int b)
        {
            String number1 = a.numar;
            String result = "";
            int transport = 0;
            for (int i = 0; i < number1.Length; i++)
            {
                int cif = transport + ConversionManager.getIntFromChar(number1[number1.Length - i - 1]) * b;
                transport = cif / a.baza;
                result = ConversionManager.getCharFromInt(cif % a.baza) + result;
            }
            if(transport != 0)
            {
                result = ConversionManager.getCharFromInt(transport) + result;
            }
            return new BaseNumber(a.baza, result);
        }

        public static BaseNumber divNumberByCif(BaseNumber a, int b)
        {
            String number1 = a.numar;
            String result = "";
            int transport = 0;
            for (int i = 0; i < number1.Length; i++)
            {
                int cif = ConversionManager.getIntFromChar(number1[i]) + transport * a.baza;
                transport = cif % b;
                result = ConversionManager.getCharFromInt(cif / b) + result;
            }
            return new BaseNumber(a.baza, result);
        }

        public static BaseNumber subNumbersSameBase(BaseNumber a, BaseNumber b)
        {
            String number1 = a.numar;
            String number2 = b.numar;
            String result = "";
            int transport = 0;
            int len = Math.Min(number1.Length, number2.Length);
            int i;
            for (i = 0; i < len; i++)
            {
                int cif = transport + ConversionManager.getIntFromChar(number1[number1.Length - i - 1]) - ConversionManager.getIntFromChar(number2[number2.Length - i - 1]);
                if(cif < 0)
                {
                    transport = -1;
                    cif += a.baza;
                }
                result = ConversionManager.getCharFromInt(cif % a.baza) + result;
            }
            for (; i < number1.Length; i++)
            {
                int cif = transport + ConversionManager.getIntFromChar(number1[number1.Length - i - 1]);
                if (cif < 0)
                {
                    transport = -1;
                    cif += a.baza;
                }
                result = ConversionManager.getCharFromInt(cif % a.baza) + result;
            }
            for (; i < number2.Length; i++)
            {
                int cif = transport + ConversionManager.getIntFromChar(number2[number2.Length - i - 1]);
                if (cif < 0)
                {
                    transport = -1;
                    cif += a.baza;
                }
                result = ConversionManager.getCharFromInt(cif % a.baza) + result;
            }
            return new BaseNumber(a.baza, result);
        }

        public static BaseNumber addNumbersByInter(BaseNumber a, BaseNumber b, int bazaD)
        {
            int input1 = Convert.ToInt32(ConversionManager.convertToBaseByInter(a, 10).numar);
            int input2 = Convert.ToInt32(ConversionManager.convertToBaseByInter(b, 10).numar);
            BaseNumber output = new BaseNumber(10, ConversionManager.getStringOfBase10(input1 + input2));
            return ConversionManager.convertToBaseByInter(output, bazaD);
        }

        public static BaseNumber subNumbersByInter(BaseNumber a, BaseNumber b, int bazaD)
        {
            int input1 = Convert.ToInt32(ConversionManager.convertToBaseByInter(a, 10).numar);
            int input2 = Convert.ToInt32(ConversionManager.convertToBaseByInter(b, 10).numar);
            BaseNumber output = new BaseNumber(10, ConversionManager.getStringOfBase10(input1 - input2));
            return ConversionManager.convertToBaseByInter(output, bazaD);
        }

        public static BaseNumber mulNumbersByInter(BaseNumber a, BaseNumber b, int bazaD)
        {
            int input1 = Convert.ToInt32(ConversionManager.convertToBaseByInter(a, 10).numar);
            int input2 = Convert.ToInt32(ConversionManager.convertToBaseByInter(b, 10).numar);
            BaseNumber output = new BaseNumber(10, ConversionManager.getStringOfBase10(input1 * input2));
            return ConversionManager.convertToBaseByInter(output, bazaD);
        }

        public static BaseNumber divNumbersByInter(BaseNumber a, BaseNumber b, int bazaD)
        {
            int input1 = Convert.ToInt32(ConversionManager.convertToBaseByInter(a, 10).numar);
            int input2 = Convert.ToInt32(ConversionManager.convertToBaseByInter(b, 10).numar);
            BaseNumber output = new BaseNumber(10, ConversionManager.getStringOfBase10(input1 / input2));
            return ConversionManager.convertToBaseByInter(output, bazaD);
        }

    }
}
