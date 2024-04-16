using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;

public class CryptoZone : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TMP_InputField inputField;
    public TextMeshProUGUI outputText;
    public TextMeshProUGUI decryptedMessageOutput;

    private byte[] key = new byte[16];
    private byte[] iv = new byte[16];
    private void Start()
    {
        // Generate the key and IV
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(key);
            rng.GetBytes(iv);
        }
    }

    public void chooseMethod()
    {
        if (dropdown.value == 0)
        {
            CalculateMD5Hash();
        }
        else
        {
            EncryptAndDecrypt();
        }
    }

    public void CalculateMD5Hash()
    {
        var source = inputField.text;

        using (var md5Hash = MD5.Create())
        {
            var sourceBytes = Encoding.UTF8.GetBytes(source);
            var hashBytes = md5Hash.ComputeHash(sourceBytes);
            var hash = HexStringFromBytes(hashBytes);

            outputText.text = "The MD5 hash of \n" + source + " is: \n" + hash;
        }
    }

    private string HexStringFromBytes(byte[] bytes)
    {
        var hexString = new StringBuilder();
        foreach (byte b in bytes)
        {
            hexString.Append(b.ToString("x2"));
        }
        return hexString.ToString();
    }

    static byte[] Encrypt(string simpletext, byte[] key, byte[] iv)
{
    byte[] cipheredtext;
    using (Aes aes = Aes.Create())
    {
        ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(simpletext);
                }

                cipheredtext = memoryStream.ToArray();
            }
        }
    }
    return cipheredtext;
}
static string Decrypt(byte[] cipheredtext, byte[] key, byte[] iv)
{
    string simpletext = String.Empty;
    using (Aes aes = Aes.Create())
    {
        ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
        using (MemoryStream memoryStream = new MemoryStream(cipheredtext))
        {
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader streamReader = new StreamReader(cryptoStream))
                {
                    simpletext = streamReader.ReadToEnd();
                }
            }
        }
    }
    return simpletext;
}

public void EncryptAndDecrypt()
{
    string message = inputField.text;

    // Encrypt the message
    byte[] encryptedMessage = Encrypt(message, key, iv);
    string encryptedMessageString = Convert.ToBase64String(encryptedMessage);
    outputText.text = "Encrypted message: " + encryptedMessageString;

    // Decrypt the message
    string decryptedMessage = Decrypt(encryptedMessage, key, iv);
    decryptedMessageOutput.text = "Decrypted message: " + decryptedMessage;
}
}

