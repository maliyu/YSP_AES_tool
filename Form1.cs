using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using System.Windows;

namespace YSP_AES_tool
{
    public partial class FormAEStool : Form
    {
        //private enum AesMode { Hex, Plaintext};
        //private AesMode aes_mode;
        //private AesLib.Aes aes = null;
        private AesManaged myAes = null;
        private byte[] key = null;
        private byte[] iv = null;
        private byte[] plaintext = null;
        //private byte[] ciphertext = null;

        public FormAEStool()
        {
            InitializeComponent();
        }

        private void FormAEStool_Load(object sender, EventArgs e)
        {
            plaintext = hexStringToBytes(textBoxPlaintext.Text);

            key = hexStringToBytes(textBoxKey.Text);

            iv = hexStringToBytes(textBoxIV.Text);

            //aes_mode = AesMode.Hex;
            myAes = new AesManaged();
            myAes.BlockSize = 128;
            myAes.KeySize = 128;
            myAes.Key = key;
            myAes.IV = iv;
            myAes.Mode = CipherMode.CBC;
            myAes.Padding = PaddingMode.None;

            //ciphertext = new byte[plaintext.Length];           
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            plaintext = hexStringToBytes(textBoxPlaintext.Text);
            if (plaintext == null || plaintext.Length <= 0)
            {
                MessageBox.Show("Plaintext can not be empty!");

                return;
            }

            if (plaintext.Length >= textBoxPlaintext.MaxLength)
            {
                MessageBox.Show("You have reached max size of textbox! Sorry this is limitation of our tool!");

                return;
            }

            key = hexStringToBytes(textBoxKey.Text);
            if (key == null || key.Length <= 0)
            {
                MessageBox.Show("Key can not be empty!");

                return;
            }

            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            {
                MessageBox.Show("Key size of AES standard is 128, 192, and 256 bit. Please check your key size!");

                return;
            }

            iv = hexStringToBytes(textBoxIV.Text);
            if (iv == null || iv.Length <= 0)
            {
                MessageBox.Show("IV can not be empty!");

                return;
            }

            if (iv.Length != 16)
            {
                MessageBox.Show("IV size of AES standard is 128 bit. Please check your IV size!");

                return;
            }

            myAes.BlockSize = 128;
            switch (key.Length)
            {
                case 16:
                    myAes.KeySize = 128;
                    break;
                case 24:
                    myAes.KeySize = 192;
                    break;
                case 32:
                    myAes.KeySize = 256;
                    break;
                default:
                    break;
            }
            myAes.Key = key;
            myAes.IV = iv;
            myAes.Mode = CipherMode.CBC;
            myAes.Padding = PaddingMode.None;

            try
            {
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        for (int i = 0; i < plaintext.Length;i++ )
                        {
                            csEncrypt.WriteByte(plaintext[i]);
                        }
                        //csEncrypt.FlushFinalBlock();
                        textBoxCiphertext.Text = bytesToHexString(msEncrypt.ToArray());
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static byte[] hexStringToBytes(string hexString)
        {
            if (hexString == null)
            {
                throw new ArgumentNullException("hexString");
            }

            if ((hexString.Length & 1) != 0)
            {
                throw new ArgumentOutOfRangeException("hexString", hexString, "hexString must contain an even number of characters.");
            }

            byte[] result = new byte[hexString.Length / 2];

            for (int i = 0; i < hexString.Length; i += 2)
            {
                result[i / 2] = byte.Parse(hexString.Substring(i, 2), NumberStyles.HexNumber);
            }

            return result;
        }

        private static string bytesToHexString(byte[] data)
        {
            char[] lookup = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int i = 0, p = 0, l = data.Length;
            char[] c = new char[l * 2 + 2];
            byte d;
            while (i < l)
            {
                d = data[i++];
                c[p++] = lookup[d / 0x10];
                c[p++] = lookup[d % 0x10];
            }

            return new string(c, 0, c.Length);
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            plaintext = hexStringToBytes(textBoxPlaintext.Text);
            if (plaintext == null || plaintext.Length <= 0)
            {
                MessageBox.Show("Plaintext can not be empty!");

                return;
            }

            if (plaintext.Length >= textBoxPlaintext.MaxLength)
            {
                MessageBox.Show("You have reached max size of textbox! Sorry this is limitation of our tool!");

                return;
            }

            key = hexStringToBytes(textBoxKey.Text);
            if (key == null || key.Length <= 0)
            {
                MessageBox.Show("Key can not be empty!");

                return;
            }

            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            {
                MessageBox.Show("Key size of AES standard is 128, 192, and 256 bit. Please check your key size!");

                return;
            }

            iv = hexStringToBytes(textBoxIV.Text);
            if (iv == null || iv.Length <= 0)
            {
                MessageBox.Show("IV can not be empty!");

                return;
            }

            if (iv.Length != 16)
            {
                MessageBox.Show("IV size of AES standard is 128 bit. Please check your IV size!");

                return;
            }

            myAes.BlockSize = 128;
            switch (key.Length)
            {
                case 16:
                    myAes.KeySize = 128;
                    break;
                case 24:
                    myAes.KeySize = 192;
                    break;
                case 32:
                    myAes.KeySize = 256;
                    break;
                default:
                    break;
            }
            myAes.Key = key;
            myAes.IV = iv;
            myAes.Mode = CipherMode.CBC;
            myAes.Padding = PaddingMode.None;

            try
            {
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);

                // Create the streams used for encryption.
                using (MemoryStream msDecrypt = new MemoryStream(plaintext))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] ciphertext = new byte[plaintext.Length];

                        csDecrypt.Read(ciphertext, 0, ciphertext.Length);
                        textBoxCiphertext.Text = bytesToHexString(ciphertext);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxIV_TextChanged(object sender, EventArgs e)
        {
            iv = hexStringToBytes(textBoxIV.Text);
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            if (String.Compare(textBoxCiphertext.Text, textBoxComparison.Text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                MessageBox.Show("Same!");
            }
            else
            {
                MessageBox.Show("Not the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string messageBoxText = "It is only for CBC mode.\nAll the data are in hex format. For example, \"00112233\" actually is \"0x00 0x11 0x22 0x33\"\n\nIV should be \"00000000000000000000000000000000\" when basic AES is operated. Otherwise, IV has 128 bit of fixed size.\n\nYou can compare the encryption/decryption result by copy the expected string into \"Comparison Ciphertext\"";
            string caption = "Help";
            MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}