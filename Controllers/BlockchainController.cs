// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("api/[controller]")]
// public class BlockchainController : ControllerBase
// {
//     private static Blockchain chain = new Blockchain();

//     [HttpPost("transaction")]
//     public IActionResult CreateTransaction([FromBody] Transaction tx)
//     {
//         chain.CreateTransaction(tx);
//         return Ok("Transaction added.");
//     }

//     [HttpPost("mine")]
//     public IActionResult Mine([FromQuery] string minerAddress)
//     {
//         chain.MinePendingTransactions(minerAddress);
//         return Ok("Block mined.");
//     }

//     [HttpGet("chain")]
//     public IActionResult GetChain() => Ok(chain.Chain);

//     [HttpGet("balance/{address}")]
//     public IActionResult GetBalance(string address)
//     {
//         var balance = chain.GetBalance(address);
//         return Ok(new { Address = address, Balance = balance });
//     }


//     [HttpPost("setbalance")]
// public IActionResult SetBalance([FromQuery] string address, [FromQuery] decimal amount)
// {
//     // Create a transaction from 'null' (system) to the address with the specified amount
//     var tx = new Transaction(null, address, amount);
//     chain.CreateTransaction(tx);
//     return Ok($"Added {amount} to {address}");
// }


//     [HttpGet("validate")]
//     public IActionResult ValidateChain()
//     {
//         return Ok(chain.IsChainValid());
//     }
// }


// using Microsoft.AspNetCore.Mvc;
// using BlockchainSimulator.Models;  // Ensure you are using the Models namespace for blockchain and FileStorage

// [ApiController]
// [Route("api/[controller]")]
// public class BlockchainController : ControllerBase
// {
//     // Load blockchain from file on startup
//     private static Blockchain chain = new Blockchain(FileStorage.LoadBlockchain());

//     [HttpPost("transaction")]
//     public IActionResult CreateTransaction([FromBody] Transaction tx)
//     {
//         chain.CreateTransaction(tx);

//         // Save blockchain state after each transaction
//         FileStorage.SaveBlockchain(chain.Chain);

//         return Ok("Transaction added.");
//     }

//     [HttpPost("mine")]
//     public IActionResult Mine([FromQuery] string minerAddress)
//     {
//         chain.MinePendingTransactions(minerAddress);

//         // Save blockchain state after mining a block
//         FileStorage.SaveBlockchain(chain.Chain);

//         return Ok("Block mined.");
//     }

//     [HttpGet("chain")]
//     public IActionResult GetChain() => Ok(chain.Chain);

//     [HttpGet("balance/{address}")]
//     public IActionResult GetBalance(string address)
//     {
//         var balance = chain.GetBalance(address);
//         return Ok(new { Address = address, Balance = balance });
//     }

//     [HttpPost("setbalance")]
//     public IActionResult SetBalance([FromQuery] string address, [FromQuery] decimal amount)
//     {
//         // Create a system transaction to set the balance
//         var tx = new Transaction(null, address, amount);
//         chain.CreateTransaction(tx);

//         // Save blockchain state after adding a balance
//         FileStorage.SaveBlockchain(chain.Chain);

//         return Ok($"Added {amount} to {address}");
//     }

//     [HttpGet("validate")]
//     public IActionResult ValidateChain()
//     {
//         return Ok(chain.IsChainValid());
//     }
// }


// using Microsoft.AspNetCore.Mvc;
// using BlockchainSimulator.Models;

// [ApiController]
// [Route("api/[controller]")]
// public class BlockchainController : ControllerBase
// {
//     // Load blockchain from file on startup
//     private static Blockchain chain = new Blockchain(FileStorage.LoadBlockchain());

//     [HttpPost("transaction")]
//     public IActionResult CreateTransaction([FromBody] Transaction tx)
//     {
//         chain.CreateTransaction(tx);

//         // Save blockchain state after each transaction
//         FileStorage.SaveBlockchain(chain.Chain);

//         return Ok("Transaction added.");
//     }

//     [HttpPost("mine")]
//     public IActionResult Mine([FromQuery] string minerAddress)
//     {
//         chain.MinePendingTransactions(minerAddress);

//         // Save blockchain state after mining a block
//         FileStorage.SaveBlockchain(chain.Chain);

//         return Ok("Block mined.");
//     }

//     [HttpGet("chain")]
//     public IActionResult GetChain() => Ok(chain.Chain);

//     [HttpGet("balance/{address}")]
//     public IActionResult GetBalance(string address)
//     {
//         var balance = chain.GetBalance(address);
//         return Ok(new { Address = address, Balance = balance });
//     }

//     [HttpPost("setbalance")]
//     public IActionResult SetBalance([FromQuery] string address, [FromQuery] decimal amount)
//     {
//         // Create a system transaction to set the balance
//         var tx = new Transaction(null, address, amount);
//         chain.CreateTransaction(tx);

//         // Save blockchain state after adding a balance
//         FileStorage.SaveBlockchain(chain.Chain);

//         return Ok($"Added {amount} to {address}");
//     }

//     [HttpGet("validate")]
//     public IActionResult ValidateChain()
//     {
//         return Ok(chain.IsChainValid());
//     }
// }


// using Microsoft.AspNetCore.Mvc;
// using BlockchainSimulator.Models;

// [ApiController]
// [Route("api/[controller]")]
// public class BlockchainController : ControllerBase
// {
//     private static Blockchain chain;

//     static BlockchainController()
//     {
//         var loadedChain = FileStorage.LoadBlockchain();

//         // If blockchain is empty, initialize with a genesis block
//         if (loadedChain.Count == 0)
//         {
//             chain = new Blockchain();
//             chain.CreateGenesisBlock(); // Make sure Blockchain.cs has this method
//             FileStorage.SaveBlockchain(chain.Chain);
//         }
//         else
//         {
//             chain = new Blockchain(loadedChain);
//         }
//     }

//     [HttpPost("transaction")]
//     public IActionResult CreateTransaction([FromBody] Transaction tx)
//     {
//         chain.CreateTransaction(tx);
//         FileStorage.SaveBlockchain(chain.Chain);
//         return Ok("Transaction added.");
//     }

//     [HttpPost("mine")]
//     public IActionResult Mine([FromQuery] string minerAddress)
//     {
//         chain.MinePendingTransactions(minerAddress);
//         FileStorage.SaveBlockchain(chain.Chain);
//         return Ok("Block mined.");
//     }

//     [HttpGet("chain")]
//     public IActionResult GetChain() => Ok(chain.Chain);

//     [HttpGet("balance/{address}")]
//     public IActionResult GetBalance(string address)
//     {
//         var balance = chain.GetBalance(address);
//         return Ok(new { Address = address, Balance = balance });
//     }

//     [HttpPost("setbalance")]
//     public IActionResult SetBalance([FromQuery] string address, [FromQuery] decimal amount)
//     {
//         var tx = new Transaction(null, address, amount);
//         chain.CreateTransaction(tx);
//         FileStorage.SaveBlockchain(chain.Chain);
//         return Ok($"Added {amount} to {address}");
//     }

//     [HttpGet("validate")]
//     public IActionResult ValidateChain() => Ok(chain.IsChainValid());
// }


using Microsoft.AspNetCore.Mvc;
using BlockchainSimulator.Models;

[ApiController]
[Route("api/[controller]")]
public class BlockchainController : ControllerBase
{
    private static Blockchain chain = Blockchain.LoadOrCreate();

    [HttpPost("transaction")]
    public IActionResult CreateTransaction([FromBody] Transaction tx)
    {
        chain.CreateTransaction(tx);
        FileStorage.SaveBlockchain(chain.Chain);
        return Ok("Transaction added.");
    }

    [HttpPost("mine")]
    public IActionResult Mine([FromQuery] string minerAddress)
    {
        chain.MinePendingTransactions(minerAddress);
        FileStorage.SaveBlockchain(chain.Chain);
        return Ok("Block mined.");
    }

    [HttpGet("chain")]
    public IActionResult GetChain() => Ok(chain.Chain);

    [HttpGet("balance/{address}")]
    public IActionResult GetBalance(string address)
    {
        var balance = chain.GetBalance(address);
        return Ok(new { Address = address, Balance = balance });
    }

    [HttpPost("setbalance")]
    public IActionResult SetBalance([FromQuery] string address, [FromQuery] decimal amount)
    {
        var tx = new Transaction(null, address, amount);
        chain.CreateTransaction(tx);
        FileStorage.SaveBlockchain(chain.Chain);
        return Ok($"Added {amount} to {address}");
    }

    [HttpGet("validate")]
    public IActionResult ValidateChain() => Ok(chain.IsChainValid());
}
