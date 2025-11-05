// src/App.js

import React, { useState } from 'react';
import { BlockchainService } from './BlockchainService.js';

function Test() {
  const [blockchain, setBlockchain] = useState([]);
  const [transaction, setTransaction] = useState({ from: '', to: '', amount: '' });
  const [minerAddress, setMinerAddress] = useState('');
  const [balanceAddress, setBalanceAddress] = useState('');
  const [balance, setBalance] = useState("");

  // Fetch the blockchain
  const fetchBlockchain = async () => {
    const data = await BlockchainService.getBlockchain();
    setBlockchain(data);
  };

  // Create a transaction
  const handleCreateTransaction = async () => {
    const tx = {
      from: transaction.from,
      to: transaction.to,
      amount: parseFloat(transaction.amount),
    };
    const response = await BlockchainService.createTransaction(tx);
    alert(response);
    setTransaction({ from: '', to: '', amount: '' });
  };

  // Mine a block
  const handleMineBlock = async () => {
    const response = await BlockchainService.mineBlock(minerAddress);
    alert(response);
    setMinerAddress('');
  };

  // Get balance
  // const handleGetBalance = async () => {
  //   const data = await BlockchainService.getBalance(balanceAddress);
  //   setBalance(data.Balance);
  // };

//   const handleGetBalance = async () => {
//   const data = await BlockchainService.getBalance(balanceAddress);
//   setBalance(data.Balance?.toString() ?? '');
// };

// const handleGetBalance = async () => {
//   try {
//     console.log("Fetching balance for address:", balanceAddress);
//     const data = await BlockchainService.getBalance(balanceAddress);
//     console.log("Received data:", data);
//     console.log("Full data:", data);


//     if (data && data.Balance !== undefined) {
//       setBalance(data.balance?.toString() ?? '');
//     } else {
//       alert("No balance data returned.");
//       setBalance('');
//     }
//   } catch (error) {
//     console.error("Error fetching balance:", error);
//     alert("Failed to fetch balance. See console for details.");
//   }
// };

const handleGetBalance = async () => {
  try {
    console.log("Fetching balance for address:", balanceAddress);
    const data = await BlockchainService.getBalance(balanceAddress);
    console.log("Received data:", data);

    if (data && data.balance !== undefined) {
      setBalance(data.balance.toString());
    } else {
      alert("No balance data returned.");
      setBalance('');
    }
  } catch (error) {
    console.error("Error fetching balance:", error);
    alert("Failed to fetch balance. See console for details.");
  }
};




  // Set balance
  const handleSetBalance = async () => {
    const response = await BlockchainService.setBalance(balanceAddress, balance);
    alert(response);
  };

  return (
    <div className="App">
      <h1>Blockchain Simulator</h1>

      <div>
        <h2>Create Transaction</h2>
        <input
          type="text"
          placeholder="From Address"
          value={transaction.from}
          onChange={(e) => setTransaction({ ...transaction, from: e.target.value })}
        />
        <input
          type="text"
          placeholder="To Address"
          value={transaction.to}
          onChange={(e) => setTransaction({ ...transaction, to: e.target.value })}
        />
        <input
          type="number"
          placeholder="Amount"
          value={transaction.amount}
          onChange={(e) => setTransaction({ ...transaction, amount: e.target.value })}
        />
        <button onClick={handleCreateTransaction}>Create Transaction</button>
      </div>

      <div>
        <h2>Mine a Block</h2>
        <input
          type="text"
          placeholder="Miner Address"
          value={minerAddress}
          onChange={(e) => setMinerAddress(e.target.value)}
        />
        <button onClick={handleMineBlock}>Mine Block</button>
      </div>

      <div>
        <h2>Get Blockchain</h2>
        <button onClick={fetchBlockchain}>Get Blockchain</button>
        <pre>{JSON.stringify(blockchain, null, 2)}</pre>
      </div>

      <div>
        <h2>Get Balance</h2>
        <input
          type="text"
          placeholder="Address"
          value={balanceAddress}
          onChange={(e) => setBalanceAddress(e.target.value)}
        />
        <button onClick={handleGetBalance}>Get Balance</button>
        {balance !== '' && <p>Balance: {balance}</p>}
      </div>

      <div>
        <h2>Set Balance</h2>
        <input
          type="text"
          placeholder="Address"
          value={balanceAddress}
          onChange={(e) => setBalanceAddress(e.target.value)}
        />
        <input
          type="number"
          placeholder="Amount"
          value={balance}
          onChange={(e) => setBalance(e.target.value)}
        />
        <button onClick={handleSetBalance}>Set Balance</button>
      </div>

      <div>
        <h2>Validate Blockchain</h2>
        <button onClick={async () => alert(await BlockchainService.validateChain())}>Validate Chain</button>
      </div>
    </div>
  );
}

export default Test;
