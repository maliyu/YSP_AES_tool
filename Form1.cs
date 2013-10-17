using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace YSP_AES_tool
{
    public partial class FormAEStool : Form
    {
        private enum AesMode { Hex, Plaintext};
        private AesMode aes_mode;
        private AesLib.Aes aes = null;
        private byte[] key = null;
        private byte[] plaintext = null;
        private byte[] ciphertext = null;

        public FormAEStool()
        {
            InitializeComponent();
        }

        private void FormAEStool_Load(object sender, EventArgs e)
        {
            aes_mode = AesMode.Hex;

            plaintext = hexStringToBytes(textBoxPlaintext.Text);

            key = hexStringToBytes(textBoxKey.Text);
            
            ciphertext = new byte[16];           
        }

        private void textBoxPlaintext_TextChanged(object sender, EventArgs e)
        {
            if (aes_mode == AesMode.Hex)
            {
                plaintext = hexStringToBytes(textBoxPlaintext.Text);
            }
            else if (aes_mode == AesMode.Plaintext)
            {
                plaintext = Encoding.ASCII.GetBytes(textBoxPlaintext.Text);
            }
        }

        private void textBoxKey_TextChanged(object sender, EventArgs e)
        {
            if (aes_mode == AesMode.Hex)
            {
                key = hexStringToBytes(textBoxKey.Text);
            }
            else if (aes_mode == AesMode.Plaintext)
            {
                key = Encoding.ASCII.GetBytes(textBoxKey.Text);
            }
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
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

            try
            {
                switch (key.Length)
                {
                    case 16:
                        aes = new AesLib.Aes(AesLib.Aes.KeySize.Bits128, key);
                        break;
                    case 24:
                        aes = new AesLib.Aes(AesLib.Aes.KeySize.Bits192, key);
                        break;
                    case 32:
                        aes = new AesLib.Aes(AesLib.Aes.KeySize.Bits256, key);
                        break;
                    default:
                        break;
                }

                if (aes != null)
                {
                    aes.Cipher(plaintext, ciphertext);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ciphertext != null)
                {
                    /*if (aes_mode == AesMode.Hex)
                    {
                        textBoxCiphertext.Text = bytesToHexString(ciphertext);
                    }
                    else if (aes_mode == AesMode.Plaintext)
                    {
                        textBoxCiphertext.Text = Encoding.ASCII.GetString(ciphertext);
                    }*/

                    textBoxCiphertext.Text = bytesToHexString(ciphertext);
                }
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

            try
            {
                switch (key.Length)
                {
                    case 16:
                        aes = new AesLib.Aes(AesLib.Aes.KeySize.Bits128, key);
                        break;
                    case 24:
                        aes = new AesLib.Aes(AesLib.Aes.KeySize.Bits192, key);
                        break;
                    case 32:
                        aes = new AesLib.Aes(AesLib.Aes.KeySize.Bits256, key);
                        break;
                    default:
                        break;
                }

                if (aes != null)
                {
                    aes.InvCipher(plaintext, ciphertext);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ciphertext != null)
                {
                    /*if (aes_mode == AesMode.Hex)
                    {
                        textBoxCiphertext.Text = bytesToHexString(ciphertext);
                    }
                    else if (aes_mode == AesMode.Plaintext)
                    {
                        textBoxCiphertext.Text = Encoding.ASCII.GetString(ciphertext);
                    }*/

                    textBoxCiphertext.Text = bytesToHexString(ciphertext);
                }
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            aes_mode = AesMode.Hex;

            plaintext = hexStringToBytes(textBoxPlaintext.Text);

            key = hexStringToBytes(textBoxKey.Text);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            aes_mode = AesMode.Plaintext;

            plaintext = Encoding.ASCII.GetBytes(textBoxPlaintext.Text);

            key = Encoding.ASCII.GetBytes(textBoxKey.Text);
        }
    }
}