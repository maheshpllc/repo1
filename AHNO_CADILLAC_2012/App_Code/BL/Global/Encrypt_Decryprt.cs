using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for Encrypt_Decryprt
/// </summary>
public class Encrypt_Decryprt
{
    public Encrypt_Decryprt()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // Encryption & Decryption using DES algorithm

    //Encrypt function
    public static string strEncrypt(string strData, string strKey1, string strKey2)
    {
        MemoryStream ms = new MemoryStream();

        DESCryptoServiceProvider objKey = new DESCryptoServiceProvider();
        objKey.Key = objLockKey(strKey1);
        objKey.IV = objLockKey(strKey2);

        CryptoStream encStream = new CryptoStream(ms,
        objKey.CreateEncryptor(), CryptoStreamMode.Write);
        StreamWriter sw = new StreamWriter(encStream);
        sw.WriteLine(strData);
        sw.Close();
        encStream.Close();

        byte[] bytData = ms.ToArray();
        string strReturnData = "";

        foreach (byte bytChar in bytData)
        {
            strReturnData += bytChar.ToString().PadLeft(3, Convert.ToChar("0"));
        }
        ms.Close();

        return strReturnData;
    }
    //Decrypt function
    public static string strDecrypt(string strData, string strKey1, string strKey2)
    {

        DESCryptoServiceProvider objKey = new DESCryptoServiceProvider();
        objKey.Key = objLockKey(strKey1);
        objKey.IV = objLockKey(strKey2);

        Int16 intLength = Convert.ToInt16((strData.Length / 3));
        byte[] bytData = new byte[intLength];

        for (Int16 intCount = 0; intCount < intLength; intCount++)
        {
            string strChar = strData.Substring((intCount * 3), 3);
            bytData[intCount] = Convert.ToByte(strChar);
        }
        MemoryStream ms = new MemoryStream(bytData);

        CryptoStream encStream = new CryptoStream(ms,
        objKey.CreateDecryptor(), CryptoStreamMode.Read);
        StreamReader sr = new StreamReader(encStream);
        string strReturnVal = sr.ReadLine();
        sr.Close();
        encStream.Close();
        ms.Close();

        return strReturnVal;
    }

    private static byte[] objLockKey(string strPassword)
    {
        const int intKeyLength = 8;
        strPassword = strPassword.PadRight(intKeyLength,
        Convert.ToChar(".")).Substring(0, intKeyLength);
        byte[] objKey = new byte[strPassword.Length];
        for (int intCount = 0; intCount < strPassword.Length; intCount++)
        {
            objKey[intCount] = Convert.ToByte(Convert.ToChar(strPassword.Substring(intCount, 1)));
        }
        return objKey;
    }
}

//Call the above function from any page as below
////encryption
//string encpassword=clsDecrypt.strEncrypt(password,"choice1" ,"choice2");
////decryption
//string password=clsDecrypt.string strDecrypt(encpassword,"choice1","choice2");




