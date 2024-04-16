using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using System.Text;

public class MD5HashGenerator : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI outputText;

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
}