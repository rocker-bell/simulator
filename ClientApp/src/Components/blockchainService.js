// // In BlockchainService.js

// const API_URL = 'http://localhost:5000/api/blockchain';

// export const BlockchainService = {
//   mineBlock: async (minerAddress) => {
//     const response = await fetch(`${API_URL}/mine?minerAddress=${minerAddress}`, {
//       method: 'POST',
//     });
//     return response.text(); // or .json() based on your API response
//   },

//   createTransaction: async (tx) => {
//     const response = await fetch(`${API_URL}/transaction`, {
//       method: 'POST',
//       headers: { 'Content-Type': 'application/json' },
//       body: JSON.stringify(tx),
//     });
//     return response.text();
//   },

//   // ... other methods to match your controller endpoints
// };


// front-end/src/services/BlockchainService.js

// const API_URL = 'http://localhost:5000/api/blockchain'; // Adjust if needed

// export const BlockchainService = {
//   getBlockchain: async () => {
//     const response = await fetch(`${API_URL}/chain`);
//     return response.json();
//   },

//   getBalance: async (address) => {
//     const response = await fetch(`${API_URL}/balance/${address}`);
//     return response.json();
//   },

//   validateChain: async () => {
//     const response = await fetch(`${API_URL}/validate`);
//     return response.json();
//   },

//   // Add other API functions here as needed
// };

// BlockchainService.js
// const API_URL = 'http://localhost:5000/api/blockchain'; // Change if backend runs on a different port
const API_URL = window.location.origin; // uses the same host as the frontend

export const BlockchainService = {
  getBlockchain: async () => {
    const response = await fetch(`${API_URL}/chain`);
    return response.json();
  },

  createTransaction: async (tx) => {
    const response = await fetch(`${API_URL}/transaction`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(tx),
    });
    return response.text();
  },

  mineBlock: async (minerAddress) => {
    const response = await fetch(`${API_URL}/mine?minerAddress=${minerAddress}`, {
      method: 'POST',
    });
    return response.text();
  },

  getBalance: async (address) => {
    const response = await fetch(`${API_URL}/balance/${address}`);
    return response.json();
  },

  setBalance: async (address, amount) => {
    const response = await fetch(`${API_URL}/setbalance?address=${address}&amount=${amount}`, {
      method: 'POST',
    });
    return response.text();
  },

  validateChain: async () => {
    const response = await fetch(`${API_URL}/validate`);
    return response.json();
  }
};

