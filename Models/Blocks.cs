// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Cryptography;
// using System.Text;

// public class Block
// {
//     public int Index { get; set; }
//     public DateTime Timestamp { get; set; }
//     public List<Transaction> Transactions { get; set; }
//     public string PreviousHash { get; set; }
//     public string Hash { get; set; }
//     public int Nonce { get; set; }

//     public Block(DateTime timestamp, List<Transaction> transactions, string previousHash = "")
//     {
//         Timestamp = timestamp;
//         Transactions = transactions;
//         PreviousHash = previousHash;
//         Hash = CalculateHash();
//         Nonce = 0;
//     }

//     public string CalculateHash()
//     {
//         using SHA256 sha256 = SHA256.Create();
//         string rawData = Index + Timestamp.ToString() + Newtonsoft.Json.JsonConvert.SerializeObject(Transactions) + PreviousHash + Nonce;
//         byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
//         return Convert.ToBase64String(bytes);
//     }

//     public void MineBlock(int difficulty)
//     {
//         string target = new string('0', difficulty);
//         while (Hash.Substring(0, difficulty) != target)
//         {
//             Nonce++;
//             Hash = CalculateHash();
//         }
//     }
// }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class Block
{
    public int Index { get; set; }
    public DateTime Timestamp { get; set; }
    public List<Transaction> Transactions { get; set; }
    public string PreviousHash { get; set; }
    public string Hash { get; set; }
    public int Nonce { get; set; }
    public string MinerAddress { get; set; }  // Added this property

    // Constructor updated to include the index, miner address, and other arguments
    public Block(int index, DateTime timestamp, List<Transaction> transactions, string minerAddress, string previousHash = "")
    {
        Index = index;
        Timestamp = timestamp;
        Transactions = transactions;
        MinerAddress = minerAddress;  // Store the miner address
        PreviousHash = previousHash;
        Hash = CalculateHash();
        Nonce = 0;
    }

    public string CalculateHash()
    {
        using SHA256 sha256 = SHA256.Create();
        string rawData = Index + Timestamp.ToString() + Newtonsoft.Json.JsonConvert.SerializeObject(Transactions) + PreviousHash + Nonce + MinerAddress;
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        return Convert.ToBase64String(bytes);
    }

    public void MineBlock(int difficulty)
    {
        string target = new string('0', difficulty);
        while (Hash.Substring(0, difficulty) != target)
        {
            Nonce++;
            Hash = CalculateHash();
        }
    }
}
