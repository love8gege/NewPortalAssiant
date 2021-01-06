using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NewPortalAssiant.Common
{
    public class Encrypt
    {
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="input">待加密的字符串</param>
        /// <param name="key">加密密钥</param>
        /// <returns></returns>
        public static string Encrypt3DES(string encryptString, string key, string IV)
        {
            if (string.IsNullOrEmpty(encryptString))
            {
                return encryptString;
            }
            try
            {
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                var DES = new TripleDESCryptoServiceProvider();
                var keybytes = Encoding.UTF8.GetBytes(key);
                var ivbytes = Encoding.UTF8.GetBytes(IV);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.IV = Encoding.UTF8.GetBytes(IV);
                //DES.Mode = CipherMode.ECB;
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;
                ICryptoTransform DESEncrypt = DES.CreateEncryptor();
                byte[] Buffer = encoding.GetBytes(encryptString);
                return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                //Log.Error("Encrypt3DES>>" + ex.Message);
                //MessageBox.Show(ex.Message);
                return string.Empty;
            }
        }

        /**//// <summary>
            /// MD5　32位加密
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
        public static string UserMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符

                pwd = pwd + s[i].ToString("X");

            }
            return pwd;
        }
    }
}
