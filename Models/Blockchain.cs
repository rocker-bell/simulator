// using System;
// using System.Collections.Generic;
// using System.Linq;


// public class Blockchain
// {
//     public List<Block> Chain { get; set; }
//     public List<Transaction> PendingTransactions { get; set; }
//     public int Difficulty { get; set; } = 2;
//     public decimal MiningReward { get; set; } = 1.0m;

//     public Blockchain()
//     {
//         Chain = new List<Block> { CreateGenesisBlock() };
//         PendingTransactions = new List<Transaction>();
//     }

//     private Block CreateGenesisBlock()
//     {
//         return new Block(DateTime.UtcNow, new List<Transaction>(), "0");
//     }

//     public Block GetLatestBlock() => Chain.Last();

//     public void MinePendingTransactions(string minerAddress)
//     {
//         Block block = new Block(DateTime.UtcNow, new List<Transaction>(PendingTransactions), GetLatestBlock().Hash);
//         block.MineBlock(Difficulty);
//         Chain.Add(block);
//         PendingTransactions.Clear();
//         PendingTransactions.Add(new Transaction(null, minerAddress, MiningReward));
//     }

//     public void CreateTransaction(Transaction tx)
//     {
//         PendingTransactions.Add(tx);
//     }

//     public decimal GetBalance(string address)
//     {
//         decimal balance = 0;

//         foreach (var block in Chain)
//         {
//             foreach (var tx in block.Transactions)
//             {
//                 if (tx.FromAddress == address) balance -= tx.Amount;
//                 if (tx.ToAddress == address) balance += tx.Amount;
//             }
//         }

//         return balance;
//     }

//     public bool IsChainValid()
//     {
//         for (int i = 1; i < Chain.Count; i++)
//         {
//             var currentBlock = Chain[i];
//             var previousBlock = Chain[i - 1];

//             if (currentBlock.Hash != currentBlock.CalculateHash())
//                 return false;

//             if (currentBlock.PreviousHash != previousBlock.Hash)
//                 return false;
//         }

//         return true;
//     }
// }


using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockchainSimulator.Models
{
    public class Blockchain
    {
        public List<Block> Chain { get; private set; }
        public List<Transaction> PendingTransactions { get; private set; }
        private int Difficulty { get; set; }
        private decimal MiningReward { get; set; }

        // Constructor to initialize a new Blockchain (called when no previous blockchain is available)
        public Blockchain()
        {
            Chain = new List<Block>();
            PendingTransactions = new List<Transaction>();
            Difficulty = 2;  // Difficulty of mining
            MiningReward = 10;  // Reward for mining a block

            // Create the genesis block (the first block)
            CreateGenesisBlock();
        }

        // Constructor to initialize blockchain with an existing chain (loaded from storage)
        public Blockchain(List<Block> existingChain)
        {
            Chain = existingChain ?? new List<Block>();  // If null, create an empty chain
            PendingTransactions = new List<Transaction>();
            Difficulty = 2;  // Difficulty of mining
            MiningReward = 10;  // Reward for mining a block

            // Ensure the blockchain is valid when loaded from storage (optional validation)
            if (Chain.Count == 0)
            {
                CreateGenesisBlock();  // Create a genesis block if chain is empty
            }
            else if (!IsChainValid())
            {
                throw new InvalidOperationException("The loaded blockchain is invalid.");
            }
        }

        // Create the genesis block (first block in the chain)
        // private void CreateGenesisBlock()
        // {
        //     var genesisBlock = new Block(0, DateTime.UtcNow, null, new List<Transaction>(), "0");
        //     genesisBlock.MineBlock(Difficulty);
        //     Chain.Add(genesisBlock);
        // }

        private void CreateGenesisBlock()
{
    var genesisBlock = new Block(0, DateTime.UtcNow, new List<Transaction>(), "0");
    genesisBlock.MineBlock(Difficulty);
    Chain.Add(genesisBlock);
}


        // Create a new transaction
        public void CreateTransaction(Transaction transaction)
        {
            PendingTransactions.Add(transaction);
        }

        // Mine the pending transactions
        // public void MinePendingTransactions(string minerAddress)
        // {
        //     var block = new Block(Chain.Count, DateTime.UtcNow, PendingTransactions, minerAddress, Chain.Last().Hash);
        //     block.MineBlock(Difficulty);

        //     Chain.Add(block);
        //     PendingTransactions = new List<Transaction> { new Transaction(null, minerAddress, MiningReward) };  // Reward for miner
        // }

        public void MinePendingTransactions(string minerAddress)
{
    var block = new Block(
        Chain.Count,                    // Index
        DateTime.UtcNow,                 // Timestamp
        PendingTransactions,             // Transactions
        minerAddress,                    // Miner address
        Chain.Last().Hash                // Previous hash (from the last block)
    );

    block.MineBlock(Difficulty);         // Mine the block with the given difficulty

    Chain.Add(block);                    // Add the mined block to the blockchain
    PendingTransactions = new List<Transaction> { new Transaction(null, minerAddress, MiningReward) };  // Reward the miner
}


        // Get the balance of a given address
        public decimal GetBalance(string address)
        {
            decimal balance = 0;

            foreach (var block in Chain)
            {
                foreach (var tx in block.Transactions)
                {
                    if (tx.ToAddress == address)
                    {
                        balance += tx.Amount;
                    }

                    if (tx.FromAddress == address)
                    {
                        balance -= tx.Amount;
                    }
                }
            }

            return balance;
        }

        // Validate the blockchain
        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                var currentBlock = Chain[i];
                var previousBlock = Chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;  // Invalid block hash
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;  // Invalid previous hash
                }
            }

            return true;
        }
    }
}
