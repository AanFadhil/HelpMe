using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Xml;
using Newtonsoft.Json;
namespace Helper
{

    public static class ExtendMethod
    {

        /// <summary>
        /// Method extend untuk konversi tipe datetime ke string dengan bahasa indonesia
        /// </summary>
        /// <param name="format">format string contoh DD/MMM/YYYY </param>
        /// <returns>string datetime sesuai dengan format yang diinputkan</returns>
        public static string ToStringIndonesia(this DateTime date, string format)
        {

            format = format.Replace("yyyy", date.Year.ToString());
            format = format.Replace("yyy", date.Year.ToString().Substring(1, 3));
            format = format.Replace("yy", date.Year.ToString().Substring(2, 2));

            format = format.Replace("YYYY", date.Year.ToString());
            format = format.Replace("YYY", date.Year.ToString().Substring(1, 3));
            format = format.Replace("YY", date.Year.ToString().Substring(2, 2));

            format = format.Replace("tt", date.ToString("tt"));
            format = format.Replace("t", date.ToString("t"));

            format = format.Replace("mm", date.ToString("mm"));
            format = format.Replace("ss", date.ToString("ss"));

            format = format.Replace("HH", date.ToString("HH"));
            format = format.Replace("hh", date.ToString("hh"));

            format = format.Replace("MMMM", Bulan(date.Month));
            format = format.Replace("MMM", Bulan(date.Month).Substring(0,3));
            format = format.Replace("MM", date.Month.ToString());
            format = format.Replace("dddd", Hari(date.ToString("dddd")));
            format = format.Replace("ddd", Hari(date.ToString("dddd")).Substring(0, 3));
            format = format.Replace("dd", date.ToString("dd"));

            return format;
        }

        private static string Hari(string hari)
        {
            string terbilang = "";
            hari = hari.ToLower();

            switch (hari)
            {
                case "monday":
                    terbilang = "Senin";
                    break;
                case "tuesday":
                    terbilang = "Selasa";
                    break;
                case "wednesday":
                    terbilang = "Rabu";
                    break;
                case "thursday":
                    terbilang = "Kamis";
                    break;
                case "friday":
                    terbilang = "Jumat";
                    break;
                case "saturday":
                    terbilang = "Sabtu";
                    break;
                case "sunday":
                    terbilang = "Minggu";
                    break;
                default:
                    break;
            }

            return terbilang;
        }

        private static string Bulan(int bulan)
        {
            string terbilang = "";

            switch (bulan)
            {
                case 1:
                    terbilang = "Januari";
                    break;
                case 2:
                    terbilang = "Februari";
                    break;
                case 3:
                    terbilang = "Maret";
                    break;
                case 4:
                    terbilang = "April";
                    break;
                case 5:
                    terbilang = "Mei";
                    break;
                case 6:
                    terbilang = "Juni";
                    break;
                case 7:
                    terbilang = "Juli";
                    break;
                case 8:
                    terbilang = "Agustus";
                    break;
                case 9:
                    terbilang = "September";
                    break;
                case 10:
                    terbilang = "Oktober";
                    break;
                case 11:
                    terbilang = "November";
                    break;
                case 12:
                    terbilang = "Desember";
                    break;
                default:
                    break;
            }

            return terbilang;

        }
    }

    public class HelpMe
    {
        public static string RandomName {
            get
            {
                string[] namas = { 
                                     "Amy Delia", 
                                     "Andi Zainal A. Dulung", 
                                     "Andre S Prijono", 
                                     "Edi Firmansyah",
                                     "Eliani Johan",
                                     "Era Helvani",
                                     "Jeannie Widjaja",
                                     "Jo Andreson Wiharjo",
                                     "Juliana Kusnandar",
                                     "Jusuf Tanuwidjaja",
                                     "Maria Karmila",
                                     "Markun",
                                     "Marten Liu",
                                     "Melina Jonas",
                                     "Merry",
                                     "Michael Goenawan",
                                     "Mintardjo Halim",
                                     "Mustofa"
                                 };
                Random rnd = new Random();
                return namas[rnd.Next()%namas.Length];
            }
        }

        public static string RandomAddress
        {
            get
            {
                string[] namas = { 
                                    "Jl. KH Agus Salim 16, Sabang, Menteng Jakarta Pusat",
                                    "Jl. Taman Margasatwa No. 12, Warung Buncit, Jakarta Selatan",
                                    "JL. Tebet Raya No. 84, Tebet, Jakarta Selatan",
                                    "Jl. Metro Pondok Indah Kav. IV, Kebayoran Lama, Jakarta Selatan",
                                    "Jl. KH. Agus Salim No. 29A Jakarta Pusat",
                                    "Jl. Hos Cokroaminoto, No. 84, Menteng Jakarta Pusat",
                                    "Jl. Ahmad Dahlan/ Jl. Bacang I No.2 Jakarta Selatan",
                                    "Jl. Benda No. 20D, Kemang Jakarta Selatan",
                                    "Jl. Alam Segar 3 No. 8, Pondok Indah Jakarta Selatan",
                                    "Jl. Kebon Jeruk Raya No. 44 (depan SMPN 75) Jakarta Barat. Telepon: 021-5483990",
                                    "Jl. KH Asahari, Pinang Ciledug Tangerang",
                                    "Jl. Arya Putra, Kedaung Ciputat Tangerang",
                                    "Jl. Buaran Raya Blok D No. 1 Duren Sawit Jakarta Timur",
                                    "Jl. Tebet Barat 1 No. 24 (Samping SMA 26) Jakarta Selatan"
                                 };
                Random rnd = new Random();
                return namas[rnd.Next(0, namas.Length)];
            }
        }


        #region terbilang

        /// <summary>
        /// method untuk konversi angke menjadi terbilang dalam bahasa indonesia
        /// </summary>
        /// <param name="number">nomor dengan format string. titik akan dibaca sebagai koma</param>
        /// <returns>string dengan hasil terbilang</returns>
        public static string Terbilang(string number)
        {
            string terbilang = "";

            number = number.Replace(",", ".");

            var split = number.Split('.');

            string sebelumkoma = split[0];
            string setelahKoma;

            if (number.Contains("."))
            {
                setelahKoma = split[1];
            }
            else
            {
                setelahKoma = "";
            }

            string terbilangSebelumKoma = PreTerbilang(sebelumkoma);



            string terbilangSetelahKoma = "";// PreTerbilang(setelahKoma);
            bool findpos = false;

            for (int k = setelahKoma.Length; k > 0; k--)
            {
                var nowchar = setelahKoma[k - 1].ToString();
                if (nowchar != "0" || findpos)
                {
                    terbilangSetelahKoma = BacaSatuAngka(nowchar) +" "+terbilangSetelahKoma;

                    if (nowchar != "0") findpos = true;
                }
                
            }

            terbilangSetelahKoma = terbilangSetelahKoma.Trim();

            terbilang += terbilangSebelumKoma;

            if (!string.IsNullOrEmpty(terbilangSetelahKoma) || !string.IsNullOrWhiteSpace(terbilangSetelahKoma))
            {
                terbilang += " Koma " + terbilangSetelahKoma;
            }

            return terbilang;


        }

        private static string PreTerbilang(string number)
        {
            List<string> sebutan = new List<string>();
            sebutan.Add("");
            sebutan.Add(" Ribu"); //10^3
            sebutan.Add(" Juta"); //10^6
            sebutan.Add(" Miliar"); //10^9
            sebutan.Add(" Triliun"); //10^12
            sebutan.Add(" Kuadriliun"); //10^15
            sebutan.Add(" Kuintiliun"); //10^18
            sebutan.Add(" Sekstiliun"); //10^21
            sebutan.Add(" Septiliun"); //10^24
            sebutan.Add(" Oktiliun"); //10^27
            sebutan.Add(" Noniliun"); //10^30
            sebutan.Add(" Desiliun"); //10^33

            string terbilang = "";
            number = number.Trim();
            if (number.All(char.IsDigit))
            {
                
                try
                {

                    int i = number.Length - 1;
                    int counterSbeutan = 0;
                    int counter3angka = 0;
                    string toTigaAngka = "";
                    
                    
                    while (i >= 0)
                    {
                        if (counter3angka < 3)
                        {
                            toTigaAngka = toTigaAngka.Insert(0, number[i].ToString());
                            counter3angka++;
                        }
                        
                        if (counter3angka >= 3 || i == 0)
                        {
                            if (toTigaAngka != "000")
                            {
                                terbilang = terbilang.Insert(0, BacaTigaAngka(toTigaAngka) + sebutan[counterSbeutan]);
                            }
                            counter3angka = 0;
                            counterSbeutan++;
                            toTigaAngka = "";
                        }
                        i--;
                    }

                    terbilang = terbilang.Replace("Satu Ribu", "Seribu");
                    terbilang = terbilang.Replace("  ", " ");
                    return terbilang.Trim();
                }
                catch (Exception)
                {
                    terbilang = "";
                }
            }
            else
            {

                terbilang = "";
            }

            return terbilang.Trim();
        }

        private static string BacaTigaAngka(string number)
        {
            string terbilang = "";
            try
            {

                if (number == "0")
                {
                    terbilang = "Nol";
                }
                else
                {
                    number = Convert.ToInt32(number).ToString();
                    terbilang = " "+ BacaSatuAngka(number[number.Length - 1].ToString());
                    if (number != "0")
                    {
                        if (number.Length >= 2 && number[number.Length - 2].ToString() != "0")
                        {
                            if (number[number.Length - 2].ToString() == "1" && number[number.Length - 1].ToString() != "0")
                            {
                                terbilang = terbilang.Insert(terbilang.Length, " Belas");
                            }
                            else //if(number[number.Length - 2].ToString() != "1")
                            {
                                terbilang = terbilang.Insert(0, " "+BacaSatuAngka(number[number.Length - 2].ToString()) + " Puluh");
                            }
                        }

                        if (number.Length == 3)
                        {
                            terbilang = terbilang.Insert(0, " "+BacaSatuAngka(number[number.Length - 3].ToString()) + " Ratus");
                        }
                    }
                }


                terbilang = terbilang.Replace("Satu Puluh", "Sepuluh");
                terbilang = terbilang.Replace("Satu Belas", "Sebelas");
                terbilang = terbilang.Replace("Satu Ratus", "Seratus");

            }
            catch (Exception e)
            {
                return "";
            }
            return terbilang;

        }

        private static string BacaSatuAngka(string number)
        {
            number = number.Trim();
            string terbilang = "";
            int i = Convert.ToInt32(number);

            switch (i)
            {
                case 0:
                    terbilang = "Nol";
                    break;
                case 1:
                    terbilang = "Satu";
                    break;
                case 2:
                    terbilang = "Dua";
                    break;
                case 3:
                    terbilang = "Tiga";
                    break;
                case 4:
                    terbilang = "Empat";
                    break;
                case 5:
                    terbilang = "Lima";
                    break;
                case 6:
                    terbilang = "Enam";
                    break;
                case 7:
                    terbilang = "Tujuh";
                    break;
                case 8:
                    terbilang = "Delapan";
                    break;
                case 9:
                    terbilang = "Sembilan";
                    break;

                default:
                    break;
            }

            return terbilang;
        }
        
        
        
        #endregion terbilang


        #region download


        /// <summary>
        /// method untuk membuat respon file di asp web form
        /// </summary>
        /// <param name="response">input properti Response milih page yang sedang dikerjakan</param>
        /// <param name="binaryData">binary data file yang akan didownload</param>
        /// <param name="fileName">nama file lengkap dengan extensionnya, contoh: image.jpg</param>
        public static void ToDownload(System.Web.HttpResponse response,byte[] binaryData,string fileName)
        {
            var mime = System.Web.MimeMapping.GetMimeMapping(fileName);

            fileName = System.IO.Path.GetFileName(fileName);

            response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            response.ContentType = mime;
            response.BinaryWrite(binaryData);
            response.Flush();
            response.End();
        }

        /// <summary>
        /// method untuk membuat respon file di asp web form, dengan opsi untuk menentukan akhir respon
        /// </summary>
        /// <param name="response">input properti Response milih page yang sedang dikerjakan</param>
        /// <param name="binaryData">binary data file yang akan didownload</param>
        /// <param name="fileName">nama file lengkap dengan extensionnya, contoh: image.jpg</param>
        /// <param name="isEnd">menentukan apakah respon diakhir atau tidak</param>
        public static void ToDownload(System.Web.HttpResponse response, byte[] binaryData, string fileName,bool isEnd)
        {
            var mime = System.Web.MimeMapping.GetMimeMapping(fileName);

            fileName = System.IO.Path.GetFileName(fileName);

            response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            response.ContentType = mime;
            response.BinaryWrite(binaryData);
            response.Flush();

            if (isEnd)
            {
                response.End();
            }

        }

        #endregion


        #region to roman
        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        /// <summary>
        /// konversi nomor integer menjadi string nomor romawi
        /// </summary>
        /// <param name="number">nilai integer yang akan di konversi</param>
        /// <returns>string nilai romawi</returns>
        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }


        /// <summary>
        /// konversi nilai romawi ke integer
        /// </summary>
        /// <param name="roman">nilai romawi yang akan di konversi</param>
        /// <returns>int nilai hasil koversi</returns>
        public static int RomanToInteger(string roman)
        {
            int number = 0;
            char previousChar = roman[0];
            foreach (char currentChar in roman)
            {
                number += RomanMap[currentChar];
                if (RomanMap[previousChar] < RomanMap[currentChar])
                {
                    number -= RomanMap[previousChar] * 2;
                }
                previousChar = currentChar;
            }
            return number;
        }

        #endregion to roman


        #region dataTableToJson

        public static string DataTable2JSON(DataTable data)
        {

            var xml = DataTable2XML(data);

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);

            return JsonConvert.SerializeXmlNode(xmldoc);

        }



        #endregion dataTableToJson


        #region dataTable2XML
        public static string DataTable2XML(DataTable data)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            var dt = (DataTable)data;

            if (dt.TableName.Trim() == string.Empty)
            {
                dt.TableName = "DataTable";
            }

            DataSet ds = new DataSet("DataSet");

            ds.Tables.Add(data);

            ds.WriteXml(sw);

            return sw.ToString();
        }
        #endregion


        #region JSON2Datatable

        public static DataTable Json2DataTable(string jsonArray)
        {
            return (DataTable)JsonConvert.DeserializeObject(jsonArray, (typeof(DataTable)));
        }


        #endregion


        #region dataTableToList

        public static List<T> DataTableToList<T>(DataTable data) where T : new ()
        {
            List<T> list = new List<T>();

            foreach (DataRow item in data.Rows)
            {
                var newrow = new T();
                var proplist = newrow.GetType().GetProperties();
                foreach (DataColumn col in data.Columns)
                {
                    var theprop = proplist.First(x => x.Name == col.ColumnName);

                    var setter = theprop.GetSetMethod(true);

                    if (setter != null)
                    {
                        setter.Invoke(newrow, new object[] { Convert.ChangeType(item[col], theprop.PropertyType) });
                    }

                    
                        
                }

                list.Add(newrow);

            }


            return list;
        }


        #endregion




    }
    
}
